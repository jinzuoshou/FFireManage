using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using FFireDataManger;
using FFireManage;
using FFireManage.Model;
using FFireManage.Service;
using FFireManage.Utility;
using log4net;

namespace FFireDataDocking
{
    public partial class FormDataDocking : Form
    {
        private FireCommandController m_FireCommandConotroller = null;
        private AreaCodeController m_AreaCodeController = null;
        private List<AreaCodeInfo> areaCodeList = null;
        private static log4net.ILog fireCommandLog = LogManager.GetLogger("FireCommandLogger");
        public FormDataDocking()
        {
            InitializeComponent();
            this.btnAddFireCommand.Enabled = false;

            m_FireCommandConotroller = new FireCommandController();
            m_FireCommandConotroller.AddEvent += M_FireCommandConotroller_AddEvent;

            this.m_AreaCodeController = new AreaCodeController();
            this.m_AreaCodeController.QueryEvent += M_AreaCodeController_QueryEvent;
        }

        private void M_AreaCodeController_QueryEvent(object sender, ServiceEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<AreaCodeInfo> result = JsonHelper.JSONToObject<GetListResultInfo<AreaCodeInfo>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            areaCodeList = result.rows;
                            this.btnAddFireCommand.Enabled = true;
                        }
                    }
                    catch
                    {

                    }

                }
                else
                {
                    MessageBox.Show(sender.ToString(), "获取行政区出错", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }));
        }

        private void M_FireCommandConotroller_AddEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    try
                    {
                        BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                        if (result.status == 10000)
                        {
                            fireCommandLog.Info(string.Format("{0}插入{1}", result.obj, result.msg));
                        }
                        else
                        {
                            fireCommandLog.Error(string.Format("{0}插入{1}", result.obj, result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        fireCommandLog.Error(ex.Message);
                    }

                }
                else
                {
                    fireCommandLog.Error(sender.ToString());
                }
            }));
        }

        private void btnAddFireCommand_Click(object sender, EventArgs e)
        {
            IWorkspace workspace = WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");
            if (workspace == null)
                return;
            IFeatureDataset featureDataSet = (workspace as IFeatureWorkspace).OpenFeatureDataset("FireInfo");
            IFeatureClass fireCommandFeatureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Command");

            List<Fire_Command> fireCommandList = GetEntities<Fire_Command>(fireCommandFeatureClass);
            if (fireCommandList != null)
            {
                fireCommandList.ForEach((f) =>
                 {
                     f.shape = FFireDataManger.Converters.PointToWKT(f.longitude, f.latitude);
                     f.mediaByteDict=GetFileDict(f);
                 });
            }
            foreach (Fire_Command fireCommand in fireCommandList)
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    this.m_FireCommandConotroller.Add(fireCommand);
                });
                task.Wait();
            }
            MessageBox.Show(this, "森林防火指挥部入库成功");
        }

        private List<T> GetEntities<T>(IFeatureClass featureClass)
        where T : class, new()
        {
            if (featureClass == null)
                return null;

            ITable pTable = featureClass as ITable;

            ICursor pCursor = pTable.Search(null, false);
            IRow pRow = pCursor.NextRow();

            List<T> entities = new List<T>();
            while (pRow != null)
            {
                T entity = new T();
                Type type = entity.GetType();
                PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.GetField); //获取指定名称的属性
                StringBuilder strBuild = new StringBuilder();
                for (int i = 0; i < pRow.Fields.FieldCount; i++)
                {
                    for (int j = 0; j < propertyInfos.Length; j++)
                    {
                        PropertyInfo info = propertyInfos[j];
                        if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                        {

                        }
                        else if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeBlob)
                        {
                            //pDataRow[i] = "Element";
                        }
                        else if (pRow.Fields.Field[i].Name == info.Name)
                        {
                            object[] objAttrs = info.GetCustomAttributes(typeof(CustomAttribute), true);
                            if (objAttrs != null && objAttrs.Length > 0)
                            {
                                CustomAttribute attr = objAttrs[0] as CustomAttribute;
                                if (attr != null)
                                {
                                    if (attr.EnumType != null)
                                    {
                                        int value = 0;
                                        try
                                        {
                                            value = Convert.ToInt32(Enum.Parse(attr.EnumType, Convert.ToString(pRow.get_Value(i))));
                                        }
                                        catch
                                        {
                                            value = 0;
                                        }
                                        finally
                                        {
                                            info.SetValue(entity, value, null);
                                        }
                                    }
                                    else
                                    {
                                        if (!Convert.IsDBNull(pRow.get_Value(i)))
                                        {
                                            info.SetValue(entity, Convert.ChangeType(pRow.get_Value(i), info.PropertyType), null);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (!Convert.IsDBNull(pRow.get_Value(i)))
                                {
                                    info.SetValue(entity, Convert.ChangeType(pRow.get_Value(i), info.PropertyType), null);
                                }
                            }
                        }
                    }
                }
                entities.Add(entity);
                pRow = pCursor.NextRow();
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pCursor);
            return entities;
        }

        private Dictionary<string, object> GetFileDict(Fire_Command fireCommand)
        {
            Dictionary<string, object> fileDict = new Dictionary<string, object>();
            if (fireCommand.picture1 != null && fireCommand.picture1 != "")
            {
                string filePath = Regex.Replace(fireCommand.picture1, @"[\r\n]", "");
                if (File.Exists(filePath))
                {
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                    fileDict.Add(fileName, filePath);
                }
            }
            if (fireCommand.picture2 != null && fireCommand.picture2 != "")
            {
                string filePath = Regex.Replace(fireCommand.picture2, @"[\r\n]", "");
                if (File.Exists(filePath))
                {
                    string fileName = System.IO.Path.GetFileName(filePath);
                    fileDict.Add(fileName, filePath);
                }
            }
            if (fireCommand.video != null && fireCommand.video != "")
            {
                string filePath = Regex.Replace(fireCommand.video, @"[\r\n]", "");
                if (File.Exists(filePath))
                {
                    string fileName = System.IO.Path.GetFileName(filePath);
                    fileDict.Add(fileName, filePath);
                }
            }
            return fileDict;
        }

        private void FormDataDocking_Load(object sender, EventArgs e)
        {
            this.m_AreaCodeController.GetList("450000", 3);
        }
    }
}
