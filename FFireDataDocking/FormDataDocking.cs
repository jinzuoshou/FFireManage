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
        private FireOfficeController m_FireOfficeController = null;
        private ObservatoryController m_ObservatoryController = null;
        private WarningBoardsController m_WarningBoardsController = null;
        private FireWarehouseController m_FireWarehouseController = null;
        private RadioStationController m_RadioStationController = null;
        private FireImportantUnitsController m_FireImportUnitsController = null;
        private ForestBeltPointController m_ForestBeltPointController = null;


        private static log4net.ILog fireCommandLog = LogManager.GetLogger("FireCommandLogger");
        private static log4net.ILog fireHBrigadeLog = LogManager.GetLogger("FireHBrigadeLogger");
        private static log4net.ILog firePBrigadeLog = LogManager.GetLogger("FirePBrigadeLogger");
        private static log4net.ILog fireOfficeLog = LogManager.GetLogger("FireOfficeLogger");
        private static log4net.ILog fireObservatoryLog = LogManager.GetLogger("FireObservatoryLogger");
        private static log4net.ILog warningBoardsLog = LogManager.GetLogger("WarningBoardsLogger");
        private static log4net.ILog fireWarehouseLog = LogManager.GetLogger("FireWarehouseLogger");
        private static log4net.ILog fireRadioStationLog = LogManager.GetLogger("FireRadioStationLogger");
        private static log4net.ILog fireImportantUnitsLog = LogManager.GetLogger("FireImportantUnitsLogger");
        private static log4net.ILog forestBeltPointLog = LogManager.GetLogger("ForestBeltPointLogger");

        private List<AreaCodeInfo> areaCodeList = null;

        private List<Fire_Command> tempFireCommandList = new List<Fire_Command>();
        private List<Fire_HBrigade> tempFireHBrigadeList = null;
        private List<Fire_PBrigade> tempFirePBrigadeList = null;
        private List<Fire_Office> tempFireOfficeList = null;
        private List<Fire_Observatory> tempObservatoryList = null;
        private List<Fire_Warehouse> tempFireWarehouseList = null;
        private List<Fire_RadioStation> tempFireRadioStationList = null;
        private List<Fire_ImportantUnits> tempFireImportantUnitsList = null;

        private Dictionary<string, IFeatureClass> featureClassDict = new Dictionary<string, IFeatureClass>();
        private IWorkspace workspace = null;
        private bool IsDelete = false;

        public FormDataDocking()
        {
            InitializeComponent();
            this.btnAddFireCommand.Enabled = false;

            this.m_AreaCodeController = new AreaCodeController();
            this.m_AreaCodeController.QueryEvent += M_AreaCodeController_QueryEvent;

            this.m_FireCommandConotroller = new FireCommandController();
            this.m_FireCommandConotroller.AddEvent += M_FireCommandConotroller_AddEvent;
            this.m_FireCommandConotroller.QueryEvent += M_FireCommandConotroller_QueryEvent;
            this.m_FireCommandConotroller.DeleteEvent += M_FireCommandConotroller_DeleteEvent;

            this.m_FireHBrigadeController = new FireHBrigadeController();
            this.m_FireHBrigadeController.AddEvent += M_FireHBrigadeController_AddEvent;
            this.m_FireHBrigadeController.QueryEvent += M_FireHBrigadeController_QueryEvent;
            this.m_FireHBrigadeController.DeleteEvent += M_FireHBrigadeController_DeleteEvent;

            this.m_FirePBrigadeController = new FirePBrigadeController();
            this.m_FirePBrigadeController.AddEvent += M_FirePBrigadeController_AddEvent;
            this.m_FirePBrigadeController.QueryEvent += M_FirePBrigadeController_QueryEvent;
            this.m_FirePBrigadeController.DeleteEvent += M_FirePBrigadeController_DeleteEvent;

            this.m_FireOfficeController = new FireOfficeController();
            this.m_FireOfficeController.AddEvent += M_FireOfficeController_AddEvent;
            this.m_FireOfficeController.QueryEvent += M_FireOfficeController_QueryEvent;
            this.m_FireOfficeController.DeleteEvent += M_FireOfficeController_DeleteEvent;

            this.m_ObservatoryController = new ObservatoryController();
            this.m_ObservatoryController.AddEvent += M_ObservatoryController_AddEvent;
            this.m_ObservatoryController.QueryEvent += M_ObservatoryController_QueryEvent;
            this.m_ObservatoryController.DeleteEvent += M_ObservatoryController_DeleteEvent;

            this.m_WarningBoardsController = new WarningBoardsController();
            this.m_WarningBoardsController.AddEvent += M_WarningBoardsController_AddEvent;
            this.m_WarningBoardsController.QueryEvent += M_WarningBoardsController_QueryEvent;
            this.m_WarningBoardsController.DeleteEvent += M_WarningBoardsController_DeleteEvent;

            this.m_FireWarehouseController = new FireWarehouseController();
            this.m_FireWarehouseController.AddEvent += M_FireWarehouseController_AddEvent;
            this.m_FireWarehouseController.QueryEvent += M_FireWarehouseController_QueryEvent;
            this.m_FireWarehouseController.DeleteEvent += M_FireWarehouseController_DeleteEvent;

            this.m_RadioStationController = new RadioStationController();
            this.m_RadioStationController.AddEvent += M_RadioStationController_AddEvent;
            this.m_RadioStationController.QueryEvent += M_RadioStationController_QueryEvent;
            this.m_RadioStationController.DeleteEvent += M_RadioStationController_DeleteEvent;

            this.m_FireImportUnitsController = new FireImportantUnitsController();
            this.m_FireImportUnitsController.AddEvent += M_FireImportUnitsController_AddEvent;
            this.m_FireImportUnitsController.QueryEvent += M_FireImportUnitsController_QueryEvent;
            this.m_FireImportUnitsController.DeleteEvent += M_FireImportUnitsController_DeleteEvent;

            this.m_ForestBeltPointController = new ForestBeltPointController();
            this.m_ForestBeltPointController.AddEvent += M_ForestBeltPointController_AddEvent;
            this.m_ForestBeltPointController.QueryEvent += M_ForestBeltPointController_QueryEvent;
            this.m_ForestBeltPointController.DeleteEvent += M_ForestBeltPointController_DeleteEvent;


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

        private bool UpdateId(IFeatureClass featureClass, string pac, double longitude, double latitude, string id)
        {
            int idFieldIndex = featureClass.FindField("id");
            IQueryFilter queryFilter = new QueryFilterClass
            {
                SubFields = "id",
                WhereClause = string.Format("pac=\'{0}\' and longitude={1} and latitude={2}", pac, longitude, latitude)
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
                    tempFireCommandList.RemoveAt(0);
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
                            if (featureClass != null)
                            {
                                if (this.SetValue(featureClass, fireCommand.OBJECTID, fireCommand.id))
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

            }));
        }

        private void btnAddFireCommand_Click(object sender, EventArgs e)
        {
            if (workspace == null)
                workspace = WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");

            IFeatureClass featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Command");

            if (featureClass != null && !featureClassDict.ContainsKey("Fire_Command"))
            {
                featureClassDict.Add("Fire_Command", featureClass);
            }

            List<Fire_Command> entities = featureClass.GetEntities<Fire_Command>();
            if (entities != null)
            {
                entities.ForEach((f) =>
                {
                    f.shape = FFireDataManger.Converters.PointToWKT(f.longitude, f.latitude);
                    f.mediaByteDict = GetMediaDict(f);
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
            IsDelete = true;
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

        private void btnUpdateFireCommandId_Click(object sender, EventArgs e)
        {
            IsDelete = false;
            Task task = Task.Factory.StartNew(() =>
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
            });
            task.Wait();
            MessageBox.Show(this, "森林防火指挥部本地库id更新成功");
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
                            if (IsDelete)
                            {
                                foreach (Fire_Command entity in entities)
                                {
                                    this.m_FireCommandConotroller.Delete(entity.id);
                                }
                            }
                            else
                            {
                                IFeatureClass featureClass = null;
                                if (featureClassDict.ContainsKey("Fire_Command"))
                                {
                                    featureClass = featureClassDict["Fire_Command"];
                                }
                                else
                                {
                                    featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Command");
                                }
                                foreach (Fire_Command entity in entities)
                                {
                                    if (this.UpdateId(featureClass, entity.pac, entity.longitude, entity.latitude, entity.id))
                                    {
                                        fireCommandLog.Info(string.Format("{0}本地库更新{1}成功", entity.name + ":" + entity.address, entity.id));
                                    }
                                }
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
                    tempFireHBrigadeList.RemoveAt(0);
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
            }));
        }

        private void btnDeleteFireHBrigade_Click(object sender, EventArgs e)
        {
            IsDelete = true;
            this.m_FireHBrigadeController.Get(new Dictionary<string, object>()
                {
                    {"pac","450000" },
                    {"fetchType",3},
                    {"page", 1},
                    {"rows",1000},
                    {"sort","id"},
                    {"order","desc"}
                });
        }

        private void M_FireHBrigadeController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            fireHBrigadeLog.Info(string.Format("删除{0}", result.msg));

                        }
                        else
                        {
                            fireHBrigadeLog.Info(string.Format("删除{0}", result.msg));
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

        private void M_FireHBrigadeController_QueryEvent(object sender, ServiceEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<Fire_HBrigade> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_HBrigade>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            List<Fire_HBrigade> entities = result.rows;
                            if (entities == null)
                            {
                                return;
                            }
                            if (IsDelete)
                            {
                                foreach (Fire_HBrigade entity in entities)
                                {
                                    this.m_FireHBrigadeController.Delete(entity.id);
                                }
                            }
                            else
                            {
                                IFeatureClass featureClass = null;
                                if (featureClassDict.ContainsKey("Fire_HBrigade"))
                                {
                                    featureClass = featureClassDict["Fire_HBrigade"];
                                }
                                else
                                {
                                    featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_HBrigade");
                                }
                                foreach (Fire_HBrigade entity in entities)
                                {
                                    if (this.UpdateId(featureClass, entity.pac, entity.longitude, entity.latitude, entity.id))
                                    {
                                        fireHBrigadeLog.Info(string.Format("{0}本地库更新{1}成功", entity.name + ":" + entity.address, entity.id));
                                    }
                                }
                            }
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

        private void btnUpdateFireHBrigadeId_Click(object sender, EventArgs e)
        {
            IsDelete = false;
            Task task = Task.Factory.StartNew(() =>
            {
                this.m_FireHBrigadeController.Get(new Dictionary<string, object>()
                {
                    {"pac","450000" },
                    {"fetchType",3},
                    {"page", 1},
                    {"rows",1000},
                    {"sort","id"},
                    {"order","desc"}
                });
            });
            task.Wait();
            MessageBox.Show(this, "半专业森林消防队本地库id更新成功");
        }
        #endregion

        #region 专业森林消防队
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
            entities.OrderBy(f => f.OBJECTID);
            tempFirePBrigadeList = entities;
            foreach (Fire_PBrigade entity in entities)
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    this.m_FirePBrigadeController.Add(entity);
                });
                task.Wait();
            }
            MessageBox.Show(this, "专业森林消防队入库成功");
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

        private void M_FirePBrigadeController_AddEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    if (tempFirePBrigadeList.Count == 0)
                        return;
                    Fire_PBrigade firePBrigade = tempFirePBrigadeList[0];
                    tempFirePBrigadeList.RemoveAt(0);
                    try
                    {
                        BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);


                        if (result.status == 10000)
                        {
                            firePBrigade.id = result.obj;
                            firePBrigadeLog.Info(string.Format("{0}:{1}插入{2}", firePBrigade.OBJECTID, result.obj, result.msg));

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
                                    firePBrigadeLog.Info(string.Format("{0}本地库插入{1}成功", firePBrigade.OBJECTID, firePBrigade.id));
                                }
                            }
                        }
                        else
                        {
                            firePBrigadeLog.Info(string.Format("{0}:{1}插入{2}", firePBrigade.OBJECTID, result.obj, result.msg));
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
            }));
        }

        private void btnDeleteAllFirePBrigade_Click(object sender, EventArgs e)
        {
            IsDelete = true;
            this.m_FirePBrigadeController.Get(new Dictionary<string, object>()
                {
                    {"pac","450000" },
                    {"fetchType",3},
                    {"page", 1},
                    {"rows",1000},
                    {"sort","id"},
                    {"order","desc"}
                });
        }

        private void M_FirePBrigadeController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            firePBrigadeLog.Info(string.Format("删除{0}", result.msg));

                        }
                        else
                        {
                            firePBrigadeLog.Info(string.Format("删除{0}", result.msg));
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
            }));
        }

        private void M_FirePBrigadeController_QueryEvent(object sender, ServiceEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<Fire_PBrigade> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_PBrigade>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            List<Fire_PBrigade> entities = result.rows;
                            if (entities == null)
                            {
                                return;
                            }
                            if (IsDelete)
                            {
                                foreach (Fire_PBrigade entity in entities)
                                {
                                    this.m_FirePBrigadeController.Delete(entity.id);
                                }
                            }
                            else
                            {
                                IFeatureClass featureClass = null;
                                if (featureClassDict.ContainsKey("Fire_PBrigade"))
                                {
                                    featureClass = featureClassDict["Fire_PBrigade"];
                                }
                                else
                                {
                                    featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_PBrigade");
                                }
                                foreach (Fire_PBrigade entity in entities)
                                {
                                    if (this.UpdateId(featureClass, entity.pac, entity.longitude, entity.latitude, entity.id))
                                    {
                                        firePBrigadeLog.Info(string.Format("{0}本地库更新{1}成功", entity.name + ":" + entity.address, entity.id));
                                    }
                                }
                            }
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
            }));
        }

        private void btnUpdateFirePBrigadeId_Click(object sender, EventArgs e)
        {
            IsDelete = false;
            Task task = Task.Factory.StartNew(() =>
            {
                this.m_FirePBrigadeController.Get(new Dictionary<string, object>()
                {
                    {"pac","450000" },
                    {"fetchType",3},
                    {"page", 1},
                    {"rows",1000},
                    {"sort","id"},
                    {"order","desc"}
                });
            });
            task.Wait();
            MessageBox.Show(this, "专业森林消防队本地库id更新成功");
        }
        #endregion

        #region 森林防火办公室
        private void M_FireOfficeController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            fireOfficeLog.Info(string.Format("删除{0}", result.msg));

                        }
                        else
                        {
                            fireOfficeLog.Info(string.Format("删除{0}", result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        fireOfficeLog.Error(ex.Message);
                    }
                }
                else
                {
                    fireOfficeLog.Error(sender.ToString());
                }
            }));
        }

        private void M_FireOfficeController_QueryEvent(object sender, ServiceEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<Fire_Office> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_Office>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            List<Fire_Office> entities = result.rows;
                            if (entities == null)
                            {
                                return;
                            }
                            if (IsDelete)
                            {
                                foreach (Fire_Office entity in entities)
                                {
                                    this.m_FireOfficeController.Delete(entity.id);
                                }
                            }
                            else
                            {
                                IFeatureClass featureClass = null;
                                if (featureClassDict.ContainsKey("Fire_Office"))
                                {
                                    featureClass = featureClassDict["Fire_Office"];
                                }
                                else
                                {
                                    featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Office");
                                }
                                foreach (Fire_Office entity in entities)
                                {
                                    if (this.UpdateId(featureClass, entity.pac, entity.longitude, entity.latitude, entity.id))
                                    {
                                        fireOfficeLog.Info(string.Format("{0}本地库更新{1}成功", entity.name + ":" + entity.address, entity.id));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        fireOfficeLog.Error(ex.Message);
                    }

                }
                else
                {
                    fireOfficeLog.Error(sender.ToString());
                }
            }));
        }

        private void M_FireOfficeController_AddEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    if (tempFireOfficeList.Count == 0)
                        return;
                    Fire_Office fireOffice = tempFireOfficeList[0];
                    tempFireOfficeList.RemoveAt(0);
                    try
                    {
                        BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                        if (result.status == 10000)
                        {
                            fireOffice.id = result.obj;
                            fireOfficeLog.Info(string.Format("{0}:{1}插入{2}", fireOffice.OBJECTID, result.obj, result.msg));

                            IFeatureClass featureClass = null;
                            if (featureClassDict.ContainsKey("Fire_Office"))
                            {
                                featureClass = featureClassDict["Fire_Office"];
                            }
                            else
                            {
                                featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Office");
                            }
                            if (featureClass != null)
                            {
                                if (this.SetValue(featureClass, fireOffice.OBJECTID, fireOffice.id))
                                {
                                    fireOfficeLog.Info(string.Format("{0}本地库插入{1}成功", fireOffice.OBJECTID, fireOffice.id));
                                }
                            }
                        }
                        else
                        {
                            fireOfficeLog.Info(string.Format("{0}:{1}插入{2}", fireOffice.OBJECTID, result.obj, result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        fireOfficeLog.Error(ex.Message);
                    }
                }
                else
                {
                    fireOfficeLog.Error(sender.ToString());
                }
            }));
        }

        private void btnFireOffice_Click(object sender, EventArgs e)
        {
            if (workspace == null)
                workspace = WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");

            IFeatureClass featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Office");

            if (featureClass != null && !featureClassDict.ContainsKey("Fire_Office"))
            {
                featureClassDict.Add("Fire_Office", featureClass);
            }

            List<Fire_Office> entities = featureClass.GetEntities<Fire_Office>();
            if (entities != null)
            {
                entities.ForEach((f) =>
                {
                    f.shape = FFireDataManger.Converters.PointToWKT(f.longitude, f.latitude);
                    f.mediaByteDict = GetMediaDict(f);
                });
            }
            entities.OrderBy(f => f.OBJECTID);
            tempFireOfficeList = entities;
            foreach (Fire_Office entity in entities)
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    this.m_FireOfficeController.Add(entity);
                });
                task.Wait();
            }
            MessageBox.Show(this, "森林办公室入库成功");
        }

        private Dictionary<string, object> GetMediaDict(Fire_Office entity)
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

        private void btnUpdateFireOfficeId_Click(object sender, EventArgs e)
        {
            IsDelete = false;
            Task task = Task.Factory.StartNew(() =>
            {
                this.m_FireOfficeController.Get(new Dictionary<string, object>()
                {
                    {"pac","450000" },
                    {"fetchType",3},
                    {"page", 1},
                    {"rows",1000},
                    {"sort","id"},
                    {"order","desc"}
                });
            });
            task.Wait();
            MessageBox.Show(this, "森林防火办公室本地库id更新成功");
        }

        private void btnDeleteAllFireOffice_Click(object sender, EventArgs e)
        {
            IsDelete = true;
            this.m_FireOfficeController.Get(new Dictionary<string, object>()
            {
                {"pac","450000" },
                {"fetchType",3},
                {"page", 1},
                {"rows",1000},
                {"sort","id"},
                {"order","desc"}
            });
        }
        #endregion

        #region 瞭望台
        private void btnAddFireObservatory_Click(object sender, EventArgs e)
        {
            if (workspace == null)
                workspace = WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");

            IFeatureClass featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Observatory");

            if (featureClass != null && !featureClassDict.ContainsKey("Fire_Observatory"))
            {
                featureClassDict.Add("Fire_Observatory", featureClass);
            }

            List<Fire_Observatory> entities = featureClass.GetEntities<Fire_Observatory>();
            if (entities != null)
            {
                entities.ForEach((f) =>
                {
                    f.SHAPE = FFireDataManger.Converters.PointToWKT(f.longitude, f.latitude);
                    f.mediaByteDict = GetMediaDict(f);
                    if(f.build_year!=null && f.build_year!="" && f.build_year.Length==4)
                    {
                        f.build_year = string.Format("{0}-00-00 00:00:00", f.build_year);
                    }
                });
            }
            entities.OrderBy(f => f.OBJECTID);
            tempObservatoryList = entities;
            foreach (Fire_Observatory entity in entities)
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    this.m_ObservatoryController.Add(entity);
                });
                task.Wait();
            }
            MessageBox.Show(this, "瞭望台入库成功");
        }

        private Dictionary<string, object> GetMediaDict(Fire_Observatory entity)
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

        private void btnUpdateObservatoryId_Click(object sender, EventArgs e)
        {
            IsDelete = false;
            Task task = Task.Factory.StartNew(() =>
            {
                this.m_ObservatoryController.Get(new Dictionary<string, object>()
                {
                    {"pac","450000" },
                    {"fetchType",3},
                    {"page", 1},
                    {"rows",1000},
                    {"sort","id"},
                    {"order","desc"}
                });
            });
            task.Wait();
            MessageBox.Show(this, "瞭望台本地库id更新成功");
        }

        private void btnDeleteAllObservatory_Click(object sender, EventArgs e)
        {
            IsDelete = true;
            this.m_ObservatoryController.Get(new Dictionary<string, object>()
            {
                {"pac","450000" },
                {"fetchType",3},
                {"page", 1},
                {"rows",1000},
                {"sort","id"},
                {"order","desc"}
            });
        }

        private void M_ObservatoryController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            fireObservatoryLog.Info(string.Format("删除{0}", result.msg));

                        }
                        else
                        {
                            fireObservatoryLog.Info(string.Format("删除{0}", result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        fireObservatoryLog.Error(ex.Message);
                    }
                }
                else
                {
                    fireObservatoryLog.Error(sender.ToString());
                }
            }));
        }

        private void M_ObservatoryController_QueryEvent(object sender, ServiceEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<Fire_Observatory> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_Observatory>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            List<Fire_Observatory> entities = result.rows;
                            if (entities == null)
                            {
                                return;
                            }
                            if (IsDelete)
                            {
                                foreach (Fire_Observatory entity in entities)
                                {
                                    this.m_ObservatoryController.Delete(entity.id);
                                }
                            }
                            else
                            {
                                IFeatureClass featureClass = null;
                                if (featureClassDict.ContainsKey("Fire_Observatory"))
                                {
                                    featureClass = featureClassDict["Fire_Observatory"];
                                }
                                else
                                {
                                    featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Observatory");
                                }
                                foreach (Fire_Observatory entity in entities)
                                {
                                    if (this.UpdateId(featureClass, entity.pac, entity.longitude, entity.latitude, entity.id))
                                    {
                                        fireObservatoryLog.Info(string.Format("{0}本地库更新{1}成功", entity.name + ":" + entity.address, entity.id));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        fireObservatoryLog.Error(ex.Message);
                    }

                }
                else
                {
                    fireObservatoryLog.Error(sender.ToString());
                }
            }));
        }

        private void M_ObservatoryController_AddEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    if (tempObservatoryList.Count == 0)
                        return;
                    Fire_Observatory fireObservatory = tempObservatoryList[0];
                    tempObservatoryList.RemoveAt(0);
                    try
                    {
                        BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                        if (result.status == 10000)
                        {
                            fireObservatory.id = result.obj;
                            fireObservatoryLog.Info(string.Format("{0}:{1}插入{2}", fireObservatory.OBJECTID, result.obj, result.msg));

                            IFeatureClass featureClass = null;
                            if (featureClassDict.ContainsKey("Fire_Observatory"))
                            {
                                featureClass = featureClassDict["Fire_Observatory"];
                            }
                            else
                            {
                                featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Observatory");
                            }
                            if (featureClass != null)
                            {
                                if (this.SetValue(featureClass, fireObservatory.OBJECTID, fireObservatory.id))
                                {
                                    fireObservatoryLog.Info(string.Format("{0}本地库插入{1}成功", fireObservatory.OBJECTID, fireObservatory.id));
                                }
                            }
                        }
                        else
                        {
                            fireObservatoryLog.Info(string.Format("{0}:{1}插入{2}", fireObservatory.OBJECTID, result.obj, result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        fireObservatoryLog.Error(ex.Message);
                    }
                }
                else
                {
                    fireObservatoryLog.Error(sender.ToString());
                }
            }));
        }
        #endregion

        #region 大型警示牌
        private void btnAddWarningBoards_Click(object sender, EventArgs e)
        {
            if (workspace == null)
                workspace = WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");

            IFeatureClass featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_WarningBoards");

            if (featureClass != null && !featureClassDict.ContainsKey("Fire_WarningBoards"))
            {
                featureClassDict.Add("Fire_WarningBoards", featureClass);
            }

            IQueryFilter queryFilter = new QueryFilterClass()
            {
                WhereClause = "id is null"
            };
            List<Fire_WarningBoards> entities = featureClass.GetEntities<Fire_WarningBoards>(queryFilter);
            //List<Fire_WarningBoards> entities = featureClass.GetEntities<Fire_WarningBoards>();
            if (entities != null)
            {
                entities.ForEach((f) =>
                {
                    f.SHAPE = FFireDataManger.Converters.PointToWKT(f.longitude, f.latitude);
                    f.mediaByteDict = GetMediaDict(f);
                    if (f.build_year != null && f.build_year != "" && f.build_year.Length == 4)
                    {
                        f.build_year = string.Format("{0}-00-00 00:00:00", f.build_year);
                    }
                    f.manager = (f.manager == null || f.manager == "") ? " " : f.manager;
                    f.phone = (f.phone == null || f.phone == "") ? " " : f.phone;
                });
            }
            entities.OrderBy(w => w.OBJECTID);
            foreach (Fire_WarningBoards warningBoards in entities)
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    this.m_WarningBoardsController.Add(warningBoards);
                });
                task.Wait();
                
            }
            MessageBox.Show(this, "大型警示牌入库成功");
        }

        private Dictionary<string, object> GetMediaDict(Fire_WarningBoards entity)
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
                    FileInfo fiInput = new FileInfo(filePath);
                    double len = fiInput.Length;
                    if (len < 1 * 1024 * 1024 * 30)
                        fileDict.Add(fileName, filePath);
                }
            }
            return fileDict;
        }

        private void btnUpdateWarningBoardsId_Click(object sender, EventArgs e)
        {
            IsDelete = false;
            Task task = Task.Factory.StartNew(() =>
            {
                this.m_WarningBoardsController.Get(new Dictionary<string, object>()
                {
                    {"pac","450000" },
                    {"fetchType",3},
                    {"page", 1},
                    {"rows",2200},
                    {"sort","id"},
                    {"order","desc"}
                });
            });
            task.Wait();
            MessageBox.Show(this, "大型警示牌本地库id更新成功");
        }

        private bool UpdateId(IFeatureClass featureClass,Fire_WarningBoards entity)
        {
            int idFieldIndex = featureClass.FindField("id");
            IQueryFilter queryFilter = new QueryFilterClass
            {
                SubFields = "id",
                WhereClause = string.Format("pac=\'{0}\' and longitude={1} and latitude={2} and name=\'{3}\' and manager=\'{4}\'", entity.pac, entity.longitude, entity.latitude, entity.name, entity.manager)
            };

            // Create a ComReleaser for buffer management.  
            using (ComReleaser comReleaser = new ComReleaser())
            {
                // Create a feature buffer containing the values to be updated.  
                IFeatureBuffer featureBuffer = featureClass.CreateFeatureBuffer();
                featureBuffer.set_Value(idFieldIndex, entity.id);
                comReleaser.ManageLifetime(featureBuffer);

                // Cast the class to ITable and perform the updates.  
                ITable table = (ITable)featureClass;
                IRowBuffer rowBuffer = (IRowBuffer)featureBuffer;
                table.UpdateSearchedRows(queryFilter, rowBuffer);
                return true;
            }
        }
        private void btnDeleteAllWarningBoards_Click(object sender, EventArgs e)
        {
            IsDelete = true;
            this.m_WarningBoardsController.Get(new Dictionary<string, object>()
            {
                {"pac","450000" },
                {"fetchType",3},
                {"page", 1},
                {"rows",1000},
                {"sort","id"},
                {"order","desc"}
            });
        }

        private void M_WarningBoardsController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            warningBoardsLog.Info(string.Format("删除{0}", result.msg));
                        }
                        else
                        {
                            warningBoardsLog.Info(string.Format("删除{0}", result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        warningBoardsLog.Error(ex.Message);
                    }
                }
                else
                {
                    warningBoardsLog.Error(sender.ToString());
                }
            }));
        }

        private void M_WarningBoardsController_QueryEvent(object sender, ServiceEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<Fire_WarningBoards> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_WarningBoards>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            List<Fire_WarningBoards> entities = result.rows;
                            if (entities == null)
                            {
                                return;
                            }
                            if (IsDelete)
                            {
                                foreach (Fire_WarningBoards entity in entities)
                                {
                                    this.m_WarningBoardsController.Delete(entity.id);
                                }
                            }
                            else
                            {
                                Dictionary<string, Fire_WarningBoards> trueDict = new Dictionary<string, Fire_WarningBoards>();
                                List<Fire_WarningBoards> mustList = new List<Fire_WarningBoards>();
                                foreach (var entity in entities)
                                {
                                    string key = entity.name + entity.manager + entity.longitude.ToString() + entity.latitude.ToString() + entity.pac;
                                    if (!trueDict.ContainsKey(key))
                                    {
                                        trueDict.Add(key, entity);
                                    }
                                    else
                                    {
                                        mustList.Add(entity);
                                    }
                                }
                                foreach(var entity in mustList)
                                {
                                    this.m_WarningBoardsController.Delete(entity.id);
                                }
                                IFeatureClass featureClass = null;
                                if (featureClassDict.ContainsKey("Fire_WarningBoards"))
                                {
                                    featureClass = featureClassDict["Fire_WarningBoards"];
                                }
                                else
                                {
                                    featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_WarningBoards");
                                }
                                
                                foreach (Fire_WarningBoards entity in trueDict.Values)
                                {
                                    if (this.UpdateId(featureClass,entity))
                                    {
                                        warningBoardsLog.Info(string.Format("{0}本地库更新{1}成功", entity.name + ":" + entity.address, entity.id));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        warningBoardsLog.Error(ex.Message);
                    }

                }
                else
                {
                    warningBoardsLog.Error(sender.ToString());
                }
            }));
        }

        private void M_WarningBoardsController_AddEvent(object sender, ServiceEventArgs e)
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
                            warningBoardsLog.Info(string.Format("{0}插入{1}", result.obj, result.msg));
                        }
                        else
                        {
                            warningBoardsLog.Error(string.Format("{0}插入{1}", result.obj, result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        warningBoardsLog.Error(ex.Message);
                    }
                }
                else
                {
                    warningBoardsLog.Error(sender.ToString());
                }

            }));
        }
        #endregion

        #region 森林防火物资储备库

        private void btnAddFireWarehouse_Click(object sender, EventArgs e)
        {
            if (workspace == null)
                workspace = WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");

            IFeatureClass featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Warehouse");

            if (featureClass != null && !featureClassDict.ContainsKey("Fire_Warehouse"))
            {
                featureClassDict.Add("Fire_Warehouse", featureClass);
            }

            List<Fire_Warehouse> entities = featureClass.GetEntities<Fire_Warehouse>();
            if (entities != null)
            {
                entities.ForEach((f) =>
                {
                    f.shape = FFireDataManger.Converters.PointToWKT(f.longitude, f.latitude);
                    f.mediaByteDict = GetMediaDict(f);
                    if (f.build_year != null && f.build_year != "" && f.build_year.Length == 4)
                    {
                        f.build_year = string.Format("{0}-00-00 00:00:00", f.build_year);
                    }
                    f.manager = (f.manager == null || f.manager == "") ? " " : f.manager;
                    f.phone = (f.phone == null || f.phone == "") ? " " : f.phone;
                });
            }
            entities.OrderBy(w => w.OBJECTID);
            this.tempFireWarehouseList = entities;
            foreach (Fire_Warehouse warningBoards in entities)
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    this.m_FireWarehouseController.Add(warningBoards);
                });
                task.Wait();
            }
            MessageBox.Show(this, "森林防火物资储备库入库成功");
        }

        private Dictionary<string, object> GetMediaDict(Fire_Warehouse entity)
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
            //if (entity.video != null && entity.video != "")
            //{
            //    string filePath = Regex.Replace(entity.video, @"[\r\n]", "");
            //    if (File.Exists(filePath))
            //    {
            //        string fileName = System.IO.Path.GetFileName(filePath);
            //        fileDict.Add(fileName, filePath);
            //    }
            //}
            return fileDict;
        }

        private void btnUpdateFireWarehouse_Click(object sender, EventArgs e)
        {

            IsDelete = false;
            Task task = Task.Factory.StartNew(() =>
            {
                this.m_FireWarehouseController.Get(new Dictionary<string, object>()
                {
                    {"pac","450000" },
                    {"fetchType",3},
                    {"page", 1},
                    {"rows",1000},
                    {"sort","id"},
                    {"order","desc"}
                });
            });
            task.Wait();
            MessageBox.Show(this, "森林防火物资储备库本地库id更新成功");
        }

        private void btnDeleteAllFireWarehouse_Click(object sender, EventArgs e)
        {
            IsDelete = true;
            this.m_FireWarehouseController.Get(new Dictionary<string, object>()
            {
                {"pac","450000" },
                {"fetchType",3},
                {"page", 1},
                {"rows",1000},
                {"sort","id"},
                {"order","desc"}
            });
        }

        private void M_FireWarehouseController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            fireWarehouseLog.Info(string.Format("删除{0}", result.msg));

                        }
                        else
                        {
                            fireWarehouseLog.Info(string.Format("删除{0}", result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        fireWarehouseLog.Error(ex.Message);
                    }
                }
                else
                {
                    fireWarehouseLog.Error(sender.ToString());
                }
            }));
        }

        private void M_FireWarehouseController_QueryEvent(object sender, ServiceEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<Fire_Warehouse> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_Warehouse>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            List<Fire_Warehouse> entities = result.rows;
                            if (entities == null)
                            {
                                return;
                            }
                            if (IsDelete)
                            {
                                foreach (Fire_Warehouse entity in entities)
                                {
                                    this.m_FireWarehouseController.Delete(entity.id);
                                }
                            }
                            else
                            {
                                IFeatureClass featureClass = null;
                                if (featureClassDict.ContainsKey("Fire_Warehouse"))
                                {
                                    featureClass = featureClassDict["Fire_Warehouse"];
                                }
                                else
                                {
                                    featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Warehouse");
                                }
                                foreach (Fire_Warehouse entity in entities)
                                {
                                    if (this.UpdateId(featureClass, entity.pac, entity.longitude, entity.latitude, entity.id))
                                    {
                                        fireWarehouseLog.Info(string.Format("{0}本地库更新{1}成功", entity.name + ":" + entity.address, entity.id));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        fireWarehouseLog.Error(ex.Message);
                    }

                }
                else
                {
                    fireWarehouseLog.Error(sender.ToString());
                }
            }));
        }

        private void M_FireWarehouseController_AddEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    if (tempFireWarehouseList.Count == 0)
                        return;
                    Fire_Warehouse fireWarehouse = tempFireWarehouseList[0];
                    tempFireWarehouseList.RemoveAt(0);
                    try
                    {
                        BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                        if (result.status == 10000)
                        {
                            fireWarehouse.id = result.obj;
                            fireWarehouseLog.Info(string.Format("{0}:{1}插入{2}", fireWarehouse.OBJECTID, result.obj, result.msg));

                            IFeatureClass featureClass = null;
                            if (featureClassDict.ContainsKey("Fire_Warehouse"))
                            {
                                featureClass = featureClassDict["Fire_Warehouse"];
                            }
                            else
                            {
                                featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Warehouse");
                            }
                            if (featureClass != null)
                            {
                                if (this.SetValue(featureClass, fireWarehouse.OBJECTID, fireWarehouse.id))
                                {
                                    fireWarehouseLog.Info(string.Format("{0}本地库插入{1}成功", fireWarehouse.OBJECTID, fireWarehouse.id));
                                }
                            }
                        }
                        else
                        {
                            fireWarehouseLog.Info(string.Format("{0}:{1}插入{2}", fireWarehouse.OBJECTID, result.obj, result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        fireWarehouseLog.Error(ex.Message);
                    }
                }
                else
                {
                    fireWarehouseLog.Error(sender.ToString());
                }
            }));
        }
        #endregion

        #region 无线电台站

        private void btnAddFireRadioStation_Click(object sender, EventArgs e)
        {
            if (workspace == null)
                workspace = WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");

            IFeatureClass featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_RadioStation");

            if (featureClass != null && !featureClassDict.ContainsKey("Fire_RadioStation"))
            {
                featureClassDict.Add("Fire_RadioStation", featureClass);
            }

            List<Fire_RadioStation> entities = featureClass.GetEntities<Fire_RadioStation>();
            if (entities != null)
            {
                entities.ForEach((f) =>
                {
                    f.shape = FFireDataManger.Converters.PointToWKT(f.longitude, f.latitude);
                    f.mediaByteDict = GetMediaDict(f);
                    if (f.build_year != null && f.build_year != "" && f.build_year.Length == 4)
                    {
                        f.build_year = string.Format("{0}-00-00 00:00:00", f.build_year);
                    }
                    f.radioname = (f.radioname == null || f.radioname=="") ? " " : f.radioname;
                    f.num_radio = (f.num_radio == null || f.num_radio=="") ? " " : f.num_radio;
                });
            }
            entities.OrderBy(f => f.objectid);
            tempFireRadioStationList = entities;
            foreach (Fire_RadioStation entity in entities)
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    this.m_RadioStationController.Add(entity);
                });
                task.Wait();
            }
            MessageBox.Show(this, "无线电台站入库成功");
        }

        private Dictionary<string, object> GetMediaDict(Fire_RadioStation entity)
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

        private void btnUpdateFireRadioStationId_Click(object sender, EventArgs e)
        {
            IsDelete = false;
            Task task = Task.Factory.StartNew(() =>
            {
                this.m_RadioStationController.Get(new Dictionary<string, object>()
                {
                    {"pac","450000" },
                    {"fetchType",3},
                    {"page", 1},
                    {"rows",1000},
                    {"sort","id"},
                    {"order","desc"}
                });
            });
            task.Wait();
            MessageBox.Show(this, "无线电台站本地库id更新成功");
        }

        private void btnDeleteAllRadioStation_Click(object sender, EventArgs e)
        {
            IsDelete = true;
            this.m_RadioStationController.Get(new Dictionary<string, object>()
            {
                {"pac","450000" },
                {"fetchType",3},
                {"page", 1},
                {"rows",1000},
                {"sort","id"},
                {"order","desc"}
            });
        }

        private void M_RadioStationController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            fireRadioStationLog.Info(string.Format("删除{0}", result.msg));

                        }
                        else
                        {
                            fireRadioStationLog.Info(string.Format("删除{0}", result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        fireRadioStationLog.Error(ex.Message);
                    }
                }
                else
                {
                    fireRadioStationLog.Error(sender.ToString());
                }
            }));
        }

        private void M_RadioStationController_QueryEvent(object sender, ServiceEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<Fire_RadioStation> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_RadioStation>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            List<Fire_RadioStation> entities = result.rows;
                            if (entities == null)
                            {
                                return;
                            }
                            if (IsDelete)
                            {
                                foreach (Fire_RadioStation entity in entities)
                                {
                                    this.m_RadioStationController.Delete(entity.id);
                                }
                            }
                            else
                            {
                                IFeatureClass featureClass = null;
                                if (featureClassDict.ContainsKey("Fire_RadioStation"))
                                {
                                    featureClass = featureClassDict["Fire_RadioStation"];
                                }
                                else
                                {
                                    featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_RadioStation");
                                }
                                foreach (Fire_RadioStation entity in entities)
                                {
                                    if (this.UpdateId(featureClass, entity.pac, entity.longitude, entity.latitude, entity.id))
                                    {
                                        fireRadioStationLog.Info(string.Format("{0}本地库更新{1}成功", entity.name + ":" + entity.address, entity.id));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        fireRadioStationLog.Error(ex.Message);
                    }

                }
                else
                {
                    fireRadioStationLog.Error(sender.ToString());
                }
            }));
        }

        private void M_RadioStationController_AddEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    if (tempFireRadioStationList.Count == 0)
                        return;
                    Fire_RadioStation fireRadioStation = tempFireRadioStationList[0];
                    tempFireRadioStationList.RemoveAt(0);
                    try
                    {
                        BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                        if (result.status == 10000)
                        {
                            fireRadioStation.id = result.obj;
                            fireRadioStationLog.Info(string.Format("{0}:{1}插入{2}", fireRadioStation.objectid, result.obj, result.msg));

                            IFeatureClass featureClass = null;
                            if (featureClassDict.ContainsKey("Fire_RadioStation"))
                            {
                                featureClass = featureClassDict["Fire_RadioStation"];
                            }
                            else
                            {
                                featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_RadioStation");
                            }
                            if (featureClass != null)
                            {
                                if (this.SetValue(featureClass, fireRadioStation.objectid, fireRadioStation.id))
                                {
                                    fireRadioStationLog.Info(string.Format("{0}本地库插入{1}成功", fireRadioStation.objectid, fireRadioStation.id));
                                }
                            }
                        }
                        else
                        {
                            fireRadioStationLog.Info(string.Format("{0}:{1}插入{2}", fireRadioStation.objectid, result.obj, result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        fireRadioStationLog.Error(ex.Message);
                    }
                }
                else
                {
                    fireRadioStationLog.Error(sender.ToString());
                }
            }));
        }
        #endregion

        #region 重点防火单位
        private void btnAddFireImportantUnits_Click(object sender, EventArgs e)
        {
            if (workspace == null)
                workspace = WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");

            IFeatureClass featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_ImportantUnits");

            if (featureClass != null && !featureClassDict.ContainsKey("Fire_ImportantUnits"))
            {
                featureClassDict.Add("Fire_ImportantUnits", featureClass);
            }

            List<Fire_ImportantUnits> entities = featureClass.GetEntities<Fire_ImportantUnits>();
            if (entities != null)
            {
                entities.ForEach((f) =>
                {
                    f.SHAPE = FFireDataManger.Converters.PointToWKT(f.longitude, f.latitude);
                    f.mediaByteDict = GetMediaDict(f);
                    f.name = (f.name == null || f.name == "") ? " " : f.name;
                });
            }
            entities.OrderBy(f => f.OBJECTID);
            tempFireImportantUnitsList = entities;
            foreach (Fire_ImportantUnits entity in entities)
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    this.m_FireImportUnitsController.Add(entity);
                });
                task.Wait();
            }
            MessageBox.Show(this, "重点防火单位入库成功");
        }

        private Dictionary<string, object> GetMediaDict(Fire_ImportantUnits entity)
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

        private void btnFireImportantUnitsId_Click(object sender, EventArgs e)
        {
            IsDelete = false;
            Task task = Task.Factory.StartNew(() =>
            {
                this.m_FireImportUnitsController.Get(new Dictionary<string, object>()
                {
                    {"pac","450000" },
                    {"fetchType",3},
                    {"page", 1},
                    {"rows",1000},
                    {"sort","id"},
                    {"order","desc"}
                });
            });
            task.Wait();
            MessageBox.Show(this, "重点防火单位本地库id更新成功");
        }

        private void btnDeleteAllFireImportantUnits_Click(object sender, EventArgs e)
        {
            IsDelete = true;
            this.m_FireImportUnitsController.Get(new Dictionary<string, object>()
            {
                {"pac","450000" },
                {"fetchType",3},
                {"page", 1},
                {"rows",1000},
                {"sort","id"},
                {"order","desc"}
            });
        }

        private void M_FireImportUnitsController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            fireImportantUnitsLog.Info(string.Format("删除{0}", result.msg));

                        }
                        else
                        {
                            fireImportantUnitsLog.Info(string.Format("删除{0}", result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        fireImportantUnitsLog.Error(ex.Message);
                    }
                }
                else
                {
                    fireImportantUnitsLog.Error(sender.ToString());
                }
            }));
        }

        private void M_FireImportUnitsController_QueryEvent(object sender, ServiceEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<Fire_ImportantUnits> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_ImportantUnits>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            List<Fire_ImportantUnits> entities = result.rows;
                            if (entities == null)
                            {
                                return;
                            }
                            if (IsDelete)
                            {
                                foreach (Fire_ImportantUnits entity in entities)
                                {
                                    this.m_FireImportUnitsController.Delete(entity.id);
                                }
                            }
                            else
                            {
                                IFeatureClass featureClass = null;
                                if (featureClassDict.ContainsKey("Fire_ImportantUnits"))
                                {
                                    featureClass = featureClassDict["Fire_ImportantUnits"];
                                }
                                else
                                {
                                    featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_ImportantUnits");
                                }
                                foreach (Fire_ImportantUnits entity in entities)
                                {
                                    if (this.UpdateId(featureClass, entity.pac, entity.longitude, entity.latitude, entity.id))
                                    {
                                        fireImportantUnitsLog.Info(string.Format("{0}本地库更新{1}成功", entity.name + ":" + entity.address, entity.id));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        fireImportantUnitsLog.Error(ex.Message);
                    }

                }
                else
                {
                    fireImportantUnitsLog.Error(sender.ToString());
                }
            }));
        }

        private void M_FireImportUnitsController_AddEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    if (tempFireImportantUnitsList.Count == 0)
                        return;
                    Fire_ImportantUnits fireImportantUnits = tempFireImportantUnitsList[0];
                    tempFireImportantUnitsList.RemoveAt(0);
                    try
                    {
                        BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                        if (result.status == 10000)
                        {
                            fireImportantUnits.id = result.obj;
                            fireImportantUnitsLog.Info(string.Format("{0}:{1}插入{2}", fireImportantUnits.OBJECTID, result.obj, result.msg));

                            IFeatureClass featureClass = null;
                            if (featureClassDict.ContainsKey("Fire_ImportantUnits"))
                            {
                                featureClass = featureClassDict["Fire_ImportantUnits"];
                            }
                            else
                            {
                                featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_ImportantUnits");
                            }
                            if (featureClass != null)
                            {
                                if (this.SetValue(featureClass, fireImportantUnits.OBJECTID, fireImportantUnits.id))
                                {
                                    fireImportantUnitsLog.Info(string.Format("{0}本地库插入{1}成功", fireImportantUnits.OBJECTID, fireImportantUnits.id));
                                }
                            }
                        }
                        else
                        {
                            fireImportantUnitsLog.Info(string.Format("{0}:{1}插入{2}", fireImportantUnits.OBJECTID, result.obj, result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        fireImportantUnitsLog.Error(ex.Message);
                    }
                }
                else
                {
                    fireImportantUnitsLog.Error(sender.ToString());
                }
            }));
        }
        #endregion

        #region 防火林带
        private void btnAddllForestBeltPoint_Click(object sender, EventArgs e)
        {
            if (workspace == null)
                workspace = WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");

            IFeatureClass featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_ForestBeltPoint");

            if (featureClass != null && !featureClassDict.ContainsKey("Fire_ForestBeltPoint"))
            {
                featureClassDict.Add("Fire_ForestBeltPoint", featureClass);
            }

            List<Fire_ForestBeltPoint> entities = featureClass.GetEntities<Fire_ForestBeltPoint>();
            if (entities != null)
            {
                entities.ForEach((f) =>
                {
                    f.SHAPE = FFireDataManger.Converters.PointToWKT(f.longitude, f.latitude);
                    f.mediaByteDict = GetMediaDict(f);
                    if (f.build_year != null && f.build_year != "")
                    {
                        if (f.build_year.Length == 4)
                        {
                            f.build_year = string.Format("{0}-00-00 00:00:00", f.build_year);
                        }
                        else if (f.build_year.Length == 2)
                        {
                            f.build_year = string.Format("19{0}-00-00 00:00:00", f.build_year);
                        }
                        else if(f.build_year.Contains("年") && f.build_year.Length==3)
                        {
                            f.build_year = string.Format("19{0}-00-00 00:00:00", f.build_year.Replace("年",""));
                        }
                    }
                });
            }
            entities.OrderBy(w => w.OBJECTID);
            foreach (Fire_ForestBeltPoint warningBoards in entities)
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    this.m_ForestBeltPointController.Add(warningBoards);
                });
                task.Wait();
            }
            MessageBox.Show(this, "防火林带入库成功");
        }

        private Dictionary<string, object> GetMediaDict(Fire_ForestBeltPoint entity)
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
                    FileInfo fiInput = new FileInfo(filePath);
                    double len = fiInput.Length;
                    if(len<1*1024*1024*30)
                        fileDict.Add(fileName, filePath);
                }
            }
            return fileDict;
        }

        private void btnUpdatellForestBeltPointId_Click(object sender, EventArgs e)
        {
            IsDelete = false;
            Task task = Task.Factory.StartNew(() =>
            {
                this.m_ForestBeltPointController.Get(new Dictionary<string, object>()
                {
                    {"pac","450000" },
                    {"fetchType",3},
                    {"page", 1},
                    {"rows",1000},
                    {"sort","id"},
                    {"order","desc"}
                });
            });
            task.Wait();
            MessageBox.Show(this, "防火林带本地库id更新成功");
        }

        private void btnDeleteAllForestBeltPoint_Click(object sender, EventArgs e)
        {
            IsDelete = true;
            this.m_ForestBeltPointController.Get(new Dictionary<string, object>()
            {
                {"pac","450000" },
                {"fetchType",3},
                {"page", 1},
                {"rows",1000},
                {"sort","id"},
                {"order","desc"}
            });
        }

        private void M_ForestBeltPointController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            forestBeltPointLog.Info(string.Format("删除{0}", result.msg));
                        }
                        else
                        {
                            forestBeltPointLog.Info(string.Format("删除{0}", result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        forestBeltPointLog.Error(ex.Message);
                    }
                }
                else
                {
                    forestBeltPointLog.Error(sender.ToString());
                }
            }));
        }

        private void M_ForestBeltPointController_QueryEvent(object sender, ServiceEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<Fire_ForestBeltPoint> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_ForestBeltPoint>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            List<Fire_ForestBeltPoint> entities = result.rows;
                            if (entities == null)
                            {
                                return;
                            }
                            if (IsDelete)
                            {
                                foreach (Fire_ForestBeltPoint entity in entities)
                                {
                                    this.m_ForestBeltPointController.Delete(entity.id);
                                }
                            }
                            else
                            {
                                IFeatureClass featureClass = null;
                                if (featureClassDict.ContainsKey("Fire_ForestBeltPoint"))
                                {
                                    featureClass = featureClassDict["Fire_ForestBeltPoint"];
                                }
                                else
                                {
                                    featureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_ForestBeltPoint");
                                }
                                foreach (Fire_ForestBeltPoint entity in entities)
                                {
                                    if (this.UpdateId(featureClass, entity.pac, entity.longitude, entity.latitude, entity.id))
                                    {
                                        forestBeltPointLog.Info(string.Format("{0}本地库更新{1}成功", entity.name + ":" + entity.start_addr+":"+entity.stop_addr, entity.id));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        forestBeltPointLog.Error(ex.Message);
                    }

                }
                else
                {
                    forestBeltPointLog.Error(sender.ToString());
                }
            }));
        }

        private void M_ForestBeltPointController_AddEvent(object sender, ServiceEventArgs e)
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
                            forestBeltPointLog.Info(string.Format("{0}插入{1}", result.obj, result.msg));
                        }
                        else
                        {
                            forestBeltPointLog.Error(string.Format("{0}插入{1}", result.obj, result.msg));
                        }
                    }
                    catch (Exception ex)
                    {
                        forestBeltPointLog.Error(ex.Message);
                    }
                }
                else
                {
                    forestBeltPointLog.Error(sender.ToString());
                }

            }));
        }
        #endregion
    }
}
