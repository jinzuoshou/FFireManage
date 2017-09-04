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
using ESRI.ArcGIS.ADF;
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
        private FireHBrigadeController m_FireHBrigadeController = null;
        private FirePBrigadeController m_FirePBrigadeController = null;


        private static log4net.ILog fireCommandLog = LogManager.GetLogger("FireCommandLogger");
        private static log4net.ILog fireHBrigadeLog = LogManager.GetLogger("FireHBrigadeLogger");
        private static log4net.ILog firePBrigadeLog = LogManager.GetLogger("FirePBrigadeLogger");

        private List<AreaCodeInfo> areaCodeList = null;
        
        private Fire_Command currentFireCommand = null;
        private Fire_HBrigade currentFireHBrigade = null;

        private Dictionary<string, IFeatureClass> featureClassDict = new Dictionary<string, IFeatureClass>();
        private IWorkspace workspace = null;

        public FormDataDocking()
        {
            InitializeComponent();
            this.btnAddFireCommand.Enabled = false;

            m_FireCommandConotroller = new FireCommandController();
            m_FireCommandConotroller.AddEvent += M_FireCommandConotroller_AddEvent;

            this.m_AreaCodeController = new AreaCodeController();
            this.m_AreaCodeController.QueryEvent += M_AreaCodeController_QueryEvent;

            this.m_FireHBrigadeController = new FireHBrigadeController();
            this.m_FireHBrigadeController.AddEvent += M_FireHBrigadeController_AddEvent;

            workspace = WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");
        }

       

        private void FormDataDocking_Load(object sender, EventArgs e)
        {
            this.m_AreaCodeController.GetList("450000", 3);
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

        #region 森林防火指挥部
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
                            currentFireCommand.id = result.obj;

                            fireCommandLog.Info(string.Format("{0}插入{1}", result.obj, result.msg));
                            IFeatureClass featureClass = null;
                            if (featureClassDict.ContainsKey("Fire_Command"))
                            {
                                featureClass = featureClassDict["Fire_Command"];
                            }
                            else
                            {
                                featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Command");
                            }
                            if(featureClass!=null)
                            {
                                if(this.SetValue(featureClass, currentFireCommand.OBJECTID, currentFireCommand.id))
                                {
                                    fireCommandLog.Info(string.Format("本地库插入{0}成功",  result.msg));
                                }

                            }
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
            if (workspace == null)
                workspace=WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");
            
            IFeatureClass fireCommandFeatureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Command");

            if(fireCommandFeatureClass!=null && !featureClassDict.ContainsKey("Fire_Command"))
            {
                featureClassDict.Add("Fire_Command", fireCommandFeatureClass);
            }

            List<Fire_Command> fireCommandList = fireCommandFeatureClass.GetEntities<Fire_Command>();
            if (fireCommandList != null)
            {
                fireCommandList.ForEach((f) =>
                 {
                     f.shape = FFireDataManger.Converters.PointToWKT(f.longitude, f.latitude);
                     f.mediaByteDict=GetMediaDict(f);
                 });
            }
            foreach (Fire_Command fireCommand in fireCommandList)
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    currentFireCommand = fireCommand;
                    this.m_FireCommandConotroller.Add(fireCommand);
                });
                task.Wait();
            }
            MessageBox.Show(this, "森林防火指挥部入库成功");
        }

        private Dictionary<string, object> GetMediaDict(Fire_Command fireCommand)
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
        #endregion

        #region 半专业森林消防队
        private void btnAddFireHBrigade_Click(object sender, EventArgs e)
        {
            if (workspace == null)
                workspace = WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");

            IFeatureClass featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_HBrigade");

            if (featureClass != null && !featureClassDict.ContainsKey("Fire_HBrigade"))
            {
                featureClassDict.Add("Fire_HBrigade", featureClass);
            }

            List<Fire_HBrigade> entities = featureClass.GetEntities<Fire_HBrigade>();
            if (entities != null)
            {
                entities.ForEach((f) =>
                {
                    f.shape = FFireDataManger.Converters.PointToWKT(f.longitude, f.latitude);
                    f.mediaByteDict = GetMediaDict(f);
                });
            }
            foreach (Fire_HBrigade entity in entities)
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    currentFireHBrigade = entity;
                    this.m_FireHBrigadeController.Add(entity);
                });
                task.Wait();
            }
            MessageBox.Show(this, "半专业森林消防队入库成功");
        }

        private Dictionary<string, object> GetMediaDict(Fire_HBrigade fireHBrigade)
        {
            Dictionary<string, object> fileDict = new Dictionary<string, object>();
            if (fireHBrigade.picture1 != null && fireHBrigade.picture1 != "")
            {
                string filePath = Regex.Replace(fireHBrigade.picture1, @"[\r\n]", "");
                if (File.Exists(filePath))
                {
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                    fileDict.Add(fileName, filePath);
                }
            }
            if (fireHBrigade.picture2 != null && fireHBrigade.picture2 != "")
            {
                string filePath = Regex.Replace(fireHBrigade.picture2, @"[\r\n]", "");
                if (File.Exists(filePath))
                {
                    string fileName = System.IO.Path.GetFileName(filePath);
                    fileDict.Add(fileName, filePath);
                }
            }
            if (fireHBrigade.video != null && fireHBrigade.video != "")
            {
                string filePath = Regex.Replace(fireHBrigade.video, @"[\r\n]", "");
                if (File.Exists(filePath))
                {
                    string fileName = System.IO.Path.GetFileName(filePath);
                    fileDict.Add(fileName, filePath);
                }
            }
            return fileDict;
        }

        private void M_FireHBrigadeController_AddEvent(object sender, ServiceEventArgs e)
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
                            currentFireHBrigade.id = result.obj;

                            fireHBrigadeLog.Info(string.Format("{0}插入{1}", result.obj, result.msg));
                            IFeatureClass featureClass = null;
                            if (featureClassDict.ContainsKey("Fire_HBrigade"))
                            {
                                featureClass = featureClassDict["Fire_HBrigade"];
                            }
                            else
                            {
                                featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_HBrigade");
                            }
                            if (featureClass != null)
                            {
                                if (this.SetValue(featureClass, currentFireHBrigade.OBJECTID, currentFireHBrigade.id))
                                {
                                    fireHBrigadeLog.Info(string.Format("本地库插入{0}成功", result.msg));
                                }
                            }
                        }
                        else
                        {
                            fireHBrigadeLog.Error(string.Format("{0}插入{1}", result.obj, result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        fireHBrigadeLog.Error(ex.Message);
                    }

                }
                else
                {
                    fireHBrigadeLog.Error(sender.ToString());
                }
            }));
        }
        #endregion

        private bool SetValue(IFeatureClass featureClass, int objectId, string id)
        {
            int idFieldIndex = featureClass.FindField("id");
            IQueryFilter queryFilter = new QueryFilterClass
            {
                SubFields = "id",
                WhereClause = string.Format("OBJECTID={0}", objectId)
            };

            // Create a ComReleaser for buffer management.  
            using (ComReleaser comReleaser = new ComReleaser())
            {
                // Create a feature buffer containing the values to be updated.  
                IFeatureBuffer featureBuffer = featureClass.CreateFeatureBuffer();
                featureBuffer.set_Value(idFieldIndex, id);
                comReleaser.ManageLifetime(featureBuffer);

                // Cast the class to ITable and perform the updates.  
                ITable table = (ITable)featureClass;
                IRowBuffer rowBuffer = (IRowBuffer)featureBuffer;
                table.UpdateSearchedRows(queryFilter, rowBuffer);
                return true;
            }
        }
    }
}
