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
        
        private List<Fire_Command> tempFireCommandList = new List<Fire_Command>();
        private List<Fire_HBrigade> tempFireHBrigadeList = null;
        private List<Fire_PBrigade> tempFirePBrigadeList = null;

        private Dictionary<string, IFeatureClass> featureClassDict = new Dictionary<string, IFeatureClass>();
        private IWorkspace workspace = null;

        public FormDataDocking()
        {
            InitializeComponent();
            this.btnAddFireCommand.Enabled = false;

            this.m_FireCommandConotroller = new FireCommandController();
            this.m_FireCommandConotroller.AddEvent += M_FireCommandConotroller_AddEvent;
            this.m_FireCommandConotroller.QueryEvent += M_FireCommandConotroller_QueryEvent;
            this.m_FireCommandConotroller.DeleteEvent += M_FireCommandConotroller_DeleteEvent;

            this.m_AreaCodeController = new AreaCodeController();
            this.m_AreaCodeController.QueryEvent += M_AreaCodeController_QueryEvent;
            

            this.m_FireHBrigadeController = new FireHBrigadeController();
            this.m_FireHBrigadeController.AddEvent += M_FireHBrigadeController_AddEvent;
            this.m_FireHBrigadeController.QueryEvent += M_FireHBrigadeController_QueryEvent;
            this.m_FireHBrigadeController.DeleteEvent += M_FireHBrigadeController_DeleteEvent;

            this.m_FirePBrigadeController = new FirePBrigadeController();
            this.m_FireHBrigadeController.AddEvent += M_FireHBrigadeController_AddEvent1;

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
                    if (tempFireCommandList.Count == 0)
                        return;
                    Fire_Command fireCommand = tempFireCommandList[0];
                    try
                    {
                        BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);
                        

                        if (result.status == 10000)
                        {
                            fireCommandLog.Info(string.Format("{0}插入{1}", result.obj, result.msg));

                            fireCommand.id = result.obj;
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
                                if(this.SetValue(featureClass, fireCommand.OBJECTID, fireCommand.id))
                                {
                                    fireCommandLog.Info(string.Format("本地库插入{0}成功", fireCommand.id));
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
                tempFireCommandList.RemoveAt(0);
            }));
        }

        private void btnAddFireCommand_Click(object sender, EventArgs e)
        {
            if (workspace == null)
                workspace=WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");
            
            IFeatureClass featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Command");

            if(featureClass!=null && !featureClassDict.ContainsKey("Fire_Command"))
            {
                featureClassDict.Add("Fire_Command", featureClass);
            }

            List<Fire_Command> entities= featureClass.GetEntities<Fire_Command>();
            if (entities != null)
            {
                entities.ForEach((f) =>
                 {
                     f.shape = FFireDataManger.Converters.PointToWKT(f.longitude, f.latitude);
                     f.mediaByteDict=GetMediaDict(f);
                 });
            }
            this.tempFireCommandList = entities;
            foreach (Fire_Command fireCommand in entities)
            {
                Task task = Task.Factory.StartNew(() =>
                {
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

        private void btnDeleteFireCommands_Click(object sender, EventArgs e)
        {
            this.m_FireCommandConotroller.Get(new Dictionary<string, object>()
                {
                    {"pac","450000" },
                    {"fetchType",3},
                    {"page", 1},
                    {"rows",1000},
                    {"sort","id"},
                    {"order","desc"}
                });
        }

        private void M_FireCommandConotroller_QueryEvent(object sender, ServiceEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<Fire_Command> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_Command>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            List<Fire_Command> entities = result.rows;
                            if (entities == null)
                            {
                                return;
                            }
                            foreach (Fire_Command entity in entities)
                            {
                                this.m_FireCommandConotroller.Delete(entity.id);
                            }
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

        private void M_FireCommandConotroller_DeleteEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    try
                    {
                        BaseResultInfo<object> result = JsonHelper.JSONToObject<BaseResultInfo<object>>(content);

                        if (result.status == 10000)
                        {
                            fireCommandLog.Info(string.Format("删除{0}", result.msg));

                        }
                        else
                        {
                            fireCommandLog.Info(string.Format("删除{0}", result.msg));
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
            tempFireHBrigadeList = entities;
            foreach (Fire_HBrigade entity in entities)
            {
                Task task = Task.Factory.StartNew(() =>
                {
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
                    if (tempFireHBrigadeList.Count == 0)
                        return;
                    Fire_HBrigade fireHBrigade = tempFireHBrigadeList[0];
                    string content = e.Content;
                    try
                    {
                        BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                        if (result.status == 10000)
                        {
                            fireHBrigade.id = result.obj;

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
                                if (this.SetValue(featureClass, fireHBrigade.OBJECTID, fireHBrigade.id))
                                {
                                    fireHBrigadeLog.Info(string.Format("本地库插入{0}成功", fireHBrigade.id));
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
                tempFireHBrigadeList.RemoveAt(0);
            }));
        }

        private void btnDeleteFireHBrigade_Click(object sender, EventArgs e)
        {

        }

        private void M_FireHBrigadeController_DeleteEvent(object sender, ServiceEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void M_FireHBrigadeController_QueryEvent(object sender, ServiceEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 半专业森林消防队
        private void btnAddFirePBrigade_Click(object sender, EventArgs e)
        {
            if (workspace == null)
                workspace = WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");

            IFeatureClass featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_PBrigade");

            if (featureClass != null && !featureClassDict.ContainsKey("Fire_PBrigade"))
            {
                featureClassDict.Add("Fire_PBrigade", featureClass);
            }

            List<Fire_PBrigade> entities = featureClass.GetEntities<Fire_PBrigade>();
            if (entities != null)
            {
                entities.ForEach((f) =>
                {
                    f.shape = FFireDataManger.Converters.PointToWKT(f.longitude, f.latitude);
                    f.mediaByteDict = GetMediaDict(f);
                });
            }
            tempFirePBrigadeList = entities;
            foreach (Fire_PBrigade entity in entities)
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    this.m_FirePBrigadeController.Add(entity);
                });
                task.Wait();
            }
            MessageBox.Show(this,"专业森林消防队入库成功");
        }

        private Dictionary<string, object> GetMediaDict(Fire_PBrigade entity)
        {
            Dictionary<string, object> fileDict = new Dictionary<string, object>();
            if (entity.picture1 != null && entity.picture1 != "")
            {
                string filePath = Regex.Replace(entity.picture1, @"[\r\n]", "");
                if (File.Exists(filePath))
                {
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                    fileDict.Add(fileName, filePath);
                }
            }
            if (entity.picture2 != null && entity.picture2 != "")
            {
                string filePath = Regex.Replace(entity.picture2, @"[\r\n]", "");
                if (File.Exists(filePath))
                {
                    string fileName = System.IO.Path.GetFileName(filePath);
                    fileDict.Add(fileName, filePath);
                }
            }
            if (entity.video != null && entity.video != "")
            {
                string filePath = Regex.Replace(entity.video, @"[\r\n]", "");
                if (File.Exists(filePath))
                {
                    string fileName = System.IO.Path.GetFileName(filePath);
                    fileDict.Add(fileName, filePath);
                }
            }
            return fileDict;
        }

        private void M_FireHBrigadeController_AddEvent1(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    if (tempFirePBrigadeList.Count == 0)
                        return;
                    Fire_PBrigade firePBrigade = tempFirePBrigadeList[0];
                    try
                    {
                        BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);


                        if (result.status == 10000)
                        {
                            firePBrigadeLog.Info(string.Format("{0}插入{1}", result.obj, result.msg));

                            firePBrigade.id = result.obj;
                            IFeatureClass featureClass = null;
                            if (featureClassDict.ContainsKey("Fire_PBrigade"))
                            {
                                featureClass = featureClassDict["Fire_PBrigade"];
                            }
                            else
                            {
                                featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_PBrigade");
                            }
                            if (featureClass != null)
                            {
                                if (this.SetValue(featureClass, firePBrigade.OBJECTID, firePBrigade.id))
                                {
                                    firePBrigadeLog.Info(string.Format("本地库插入{0}成功", firePBrigade.id));
                                }
                            }
                        }
                        else
                        {
                            firePBrigadeLog.Error(string.Format("{0}插入{1}", result.obj, result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        firePBrigadeLog.Error(ex.Message);
                    }
                }
                else
                {
                    firePBrigadeLog.Error(sender.ToString());
                }
                tempFirePBrigadeList.RemoveAt(0);
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
