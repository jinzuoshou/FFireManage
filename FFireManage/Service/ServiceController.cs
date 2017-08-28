using FFireManage.Model;
using FFireManage.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FFireManage.Service
{
    /// <summary>
    /// 广西森林防火业务数据业务访问类（通过http访问webservice接口）
    /// </summary>
    public class ServiceController : BaseService
    {
        private string m_FullUrl = string.Empty;
        private string m_Url = string.Empty;
        private string m_Resource = string.Empty;

        public event EventHandler GetUserListByPacEvent;
        public event EventHandler RegistUserEvent;
        public event EventHandler EditUserEvent;
        public event EventHandler DeleteUserEvent;

        public event EventHandler GetAreaCodeListEvent;

        public event EventHandler CreateLicenceKeyEvent;
        public event EventHandler GetLicenceListByPacEvent;
        public event EventHandler DeleteLicenseEvent;
        public event EventHandler ProofLicenseEvent;
        public event EventHandler RegisterLicenseEvent;
        public event EventHandler UpdateLicenseEvent;
        public event EventHandler LogoutLicenseEvent;

        public event EventHandler GetHotListEvent;
        public event EventHandler AddHotEvent;
        public event EventHandler EditHotEvent;
        public event EventHandler DeleteHotEvent;

        public event EventHandler GetMonitorListEvent;
        public event EventHandler AddMonitorEvent;
        public event EventHandler EditMonitorEvent;
        public event EventHandler DeleteMonitorEvent;

        public event EventHandler GetWatchTowerListEvent;
        public event EventHandler AddWatchTowerEvent;
        public event EventHandler EditWatchTowerEvent;
        public event EventHandler DeleteWatchTowerEvent;

        public event EventHandler GetRadioStationListEvent;
        public event EventHandler AddRadioStationEvent;
        public event EventHandler EditRadioStationEvent;
        public event EventHandler DeleteRadioStationEvent;

        public event EventHandler GetFireCommandListEvent;
        public event EventHandler AddFireCommandEvent;
        public event EventHandler EditFireCommandEvent;
        public event EventHandler DeleteFireCommandEvent;

        public event EventHandler GetFireForestBeltListEvent;
        public event EventHandler AddFireForestBeltEvent;
        public event EventHandler EditFireForestBeltEvent;
        public event EventHandler DeleteFireForestBeltEvent;

        public event EventHandler GetArtificiallakeListEvent;
        public event EventHandler AddArtificiallakeEvent;
        public event EventHandler EditArtificiallakeEvent;
        public event EventHandler DeleteArtificiallakeEvent;

        public event EventHandler GetDangerousFacilitiesListEvent;
        public event EventHandler AddDangerousFacilitiesEvent;
        public event EventHandler EditDangerousFacilitiesEvent;
        public event EventHandler DeleteDangerousFacilitiesEvent;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ServiceController()
        {
            this.m_FullUrl = "http://" + base.Server + ":" + base.Port + "/if/serviceController/action?";
            this.m_Url = "http://" + base.Server + ":" + base.Port;
            this.m_Resource = "/if/serviceController/action?";
        }

        #region 用户管理

        #region 获取用户列表

        /// <summary>
        /// 0 --- 只查找该级别 默认 
        /// 1 --- 只查询下一级
        /// 2 --- 查询所有下一级 不推荐使用
        /// 3 --- 查询所有下一级，最大到县
        /// </summary>
        /// <param name="pac"></param>
        /// <param name="fetchType"></param>
        public void GetUserListByPac(string pac,int fetchType=3,int online=0,int page=1,int rows=30,
            string sort=null,string order="asc")
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",220001 },
                {"pac",pac },
                {"fetchType",fetchType },
                {"page",page },
                {"rows",rows },
                {"sort",(sort==null)?"":sort },
                {"order",order },
                {"online",(online==0)?"":online.ToString() },
            };

            Thread thread = new Thread(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);
                if (GetUserListByPacEvent != null)
                {
                    if (iss)
                    {
                        GetUserListByPacEvent(content, new EventArgs());
                    }
                    else
                    {
                        GetUserListByPacEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        #endregion

        #region 用户注册

        public void RegistUserForGet(UserInfo user)
        {
            //参数字典
            Dictionary<string, object> parameterDict = user.ObjectToDict();
            parameterDict.Add("f", 221001);

            Thread thread = new Thread(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (RegistUserEvent != null)
                {
                    if (iss)
                    {
                        RegistUserEvent(content, new EventArgs());
                    }
                    else
                    {
                        RegistUserEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        public void RegistUserForPost(UserInfo user)
        {
            //参数字典
            Dictionary<string, object> parameterDict = user.ObjectToDict();
            parameterDict.Add("f", 221001);

            Thread thread = new Thread(()=>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (RegistUserEvent != null)
                {
                    if (iss)
                    {
                        RegistUserEvent(content, new EventArgs());
                    }
                    else
                    {
                        RegistUserEvent(content, null);
                    }
                }
            });
            thread.Start();
        }


        #endregion

        #region 编辑用户

        public void EditUserForGet(UserInfo user)
        {
            //参数字典
            Dictionary<string, object> parameterDict = user.ObjectToDict();
            parameterDict.Add("f", 222001);

            Thread thread = new Thread(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);
                if (EditUserEvent != null)
                {
                    if (iss)
                    {
                        EditUserEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditUserEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        public void EditUserForPost(UserInfo user)
        {
            //参数字典
            Dictionary<string, object> parameterDict = user.ObjectToDict();
            parameterDict.Add("f", 222001);

            Thread thread = new Thread(() =>
            {
                bool iss = false;

                string content = RestSharpHelper.HttpPost(this.m_Url, this.m_Resource, parameterDict, out iss);

                if (EditUserEvent != null)
                {
                    if (iss)
                    {
                        EditUserEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditUserEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        #endregion

        #region 删除用户

        public void DeleteUserForGet(int id)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",223001 },
                {"id",id }
            };

            Thread thread = new Thread(()=> 
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (DeleteUserEvent != null)
                {
                    if (iss)
                    {
                        DeleteUserEvent(content, new EventArgs());
                    }
                    else
                    {
                        DeleteUserEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        #endregion

        #endregion

        #region 根据PAC获取行政区代码列表

        public void GetAreaCodeList(string pac, int fetchType)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f", 210002},
                {"pac", pac},
                {"fetchType", fetchType},
            };

            Thread thread = new Thread(()=> 
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (GetAreaCodeListEvent != null)
                {
                    if (iss)
                    {
                        GetAreaCodeListEvent(content, new EventArgs());
                    }
                    else
                    {
                        GetAreaCodeListEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        #endregion

        #region 许可授权

        #region 生成授权许可代码

        public void CreateLicenceKeyForGet(string account, string pac, int number, int deviceType=2)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f", 321001},
                {"account", account},
                {"pac", pac},
                {"number", number},
                {"deviceType",deviceType }
            };

            Thread thread = new Thread(()=> 
            {
                bool iss = false;

                string content = RestSharpHelper.HttpGet(this.m_Url, this.m_Resource,parameterDict, out iss);

                if (CreateLicenceKeyEvent != null)
                {
                    if (iss)
                    {
                        CreateLicenceKeyEvent(content, new EventArgs());
                    }
                    else
                    {
                        CreateLicenceKeyEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        public void CreateLicenseKeyForPost(string account,string pac,int number,int deviceType=2)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f", 321001},
                {"account", account},
                {"pac", pac},
                {"number", number},
                {"deviceType",deviceType }
            };

            Thread thread = new Thread(()=> 
            {
                bool iss = false;

                string content = RestSharpHelper.HttpPost(this.m_Url, this.m_Resource, parameterDict, out iss);

                if (CreateLicenceKeyEvent != null)
                {
                    if (iss)
                    {
                        CreateLicenceKeyEvent(content, new EventArgs());
                    }
                    else
                    {
                        CreateLicenceKeyEvent(content, null);
                    }
                }
            });
            thread.Start();
        }


        #endregion

        #region 获取授权许可列表

        public void GetLicenceListByPac(string pac, int rows, int page)
        {
            /*
             * 
             fetchType 说明

             0 -- 只查询当前  默认
             1 -- 只查询下一级
             2 -- 查询所有下一级
             3 -- 查询所有下一级，最大到区/县
             */
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f" ,210003},
                {"pac" ,pac},
                {"rows" ,rows},
                {"page" ,page},
                {"fetchType" ,0},
            };

            Thread thread = new Thread(()=> 
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);
                if (GetLicenceListByPacEvent != null)
                {
                    if (iss)
                    {
                        GetLicenceListByPacEvent(content, new EventArgs());
                    }
                    else
                    {
                        GetLicenceListByPacEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        #endregion

        #region 注册许可
        public void RegisterLicenseForGet(string key, string imei, int device)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",322003 },
                {"key",key },
                {"imei",imei },
                {"device",device },
            };

            Thread thread = new Thread(()=>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (RegisterLicenseEvent != null)
                {
                    if (iss)
                    {
                        RegisterLicenseEvent(content, new EventArgs());
                    }
                    else
                    {
                        RegisterLicenseEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        public void RegisterLicenseForPost(string key, string imei, int device)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",322003 },
                {"key",key },
                {"imei",imei },
                {"device",device },
            };

            Thread thread = new Thread(()=> 
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (RegisterLicenseEvent != null)
                {
                    if (iss)
                    {
                        RegisterLicenseEvent(content, new EventArgs());
                    }
                    else
                    {
                        RegisterLicenseEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        #endregion

        #region 校验许可
        public void ProofLicenseForGet(string imei)
        {
            string parameter = "f=320001&imei=" + imei;
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f" ,320001},
                {"imei",imei }
            };

            Thread thread = new Thread(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (ProofLicenseEvent != null)
                {
                    if (iss)
                    {
                        ProofLicenseEvent(content, new EventArgs());
                    }
                    else
                    {
                        ProofLicenseEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        public void ProofLicenseForPost(string imei)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f" ,320001},
                {"imei",imei }
            };

            Thread thread = new Thread(()=> 
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url, this.m_Resource, parameterDict, out iss);

                if (ProofLicenseEvent != null)
                {
                    if (iss)
                    {
                        ProofLicenseEvent(content, new EventArgs());
                    }
                    else
                    {
                        ProofLicenseEvent(content, null);
                    }
                }
            });
            thread.Start();
        }
        #endregion

        #region 更新许可
        public void UpdateLicenseForGet(int id, string imei, string pac, string key)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",322002 },
                {"id",id },
                {"imei",imei },
                {"pac",pac },
                {"key",key },
            };
            Thread thread = new Thread(()=> 
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (UpdateLicenseEvent != null)
                {
                    if (iss)
                    {
                        UpdateLicenseEvent(content, new EventArgs());
                    }
                    else
                    {
                        UpdateLicenseEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        public void UpdateLicenseForPost(int id, string imei, string pac, string key)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",322002 },
                {"id",id },
                {"imei",imei },
                {"pac",pac },
                {"key",key },
            };
            Thread thread = new Thread(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url, this.m_Resource,parameterDict, out iss);

                if (UpdateLicenseEvent != null)
                {
                    if (iss)
                    {
                        UpdateLicenseEvent(content, new EventArgs());
                    }
                    else
                    {
                        UpdateLicenseEvent(content, null);
                    }
                }
            });
            thread.Start();
        }
        #endregion

        #region 注销许可
        public void LogoutLicenseForGet(string key, string imei)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",322001 },
                {"key",key },
                {"imei",imei },
            };

            Thread thread = new Thread(()=>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (LogoutLicenseEvent != null)
                {
                    if (iss)
                    {
                        LogoutLicenseEvent(content, new EventArgs());
                    }
                    else
                    {
                        LogoutLicenseEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        public void LogoutLicenseForPost(string key, string imei)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",322001 },
                {"key",key },
                {"imei",imei },
            };

            Thread thread = new Thread(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (LogoutLicenseEvent != null)
                {
                    if (iss)
                    {
                        LogoutLicenseEvent(content, new EventArgs());
                    }
                    else
                    {
                        LogoutLicenseEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        #endregion

        #region 删除许可

        public void DeleteLicenseForGet(int id)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",323001 },
                {"id",id }
            };

            Thread thread = new Thread(()=> 
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);
                if (DeleteLicenseEvent != null)
                {
                    if (iss)
                    {
                        DeleteLicenseEvent(content, new EventArgs());
                    }
                    else
                    {
                        DeleteLicenseEvent(content, null);
                    }
                }
            });
            thread.Start();
        }


        #endregion

        #endregion

        #region 热点管理

        #region 热点列表查询
        /// <summary>
        /// 通过Get访问方式获取热点列表
        /// </summary>
        /// <param name="pac"></param>
        /// <param name="fetchType"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="sort"></param>
        /// <param name="order"></param>
        public void GetHotListForGet(string pac=null, int fetchType = 3, int page = 1,
            int rows = 30, string sort = null, string order="desc")
        {
            //参数列表
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f", 4110001},
                {"pac", (pac == null) ? "":pac},
                {"fetchType", fetchType},
                {"page", page},
                {"rows", rows},
                {"sort", (sort==null)?"":sort},
                {"order", order}
            };
            
            Thread thread = new Thread(()=> 
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (GetHotListEvent != null)
                {
                    if (iss)
                    {
                        GetHotListEvent(content, new EventArgs());
                    }
                    else
                    {
                        GetHotListEvent(content, null);
                    }
                }
            });
            thread.Start();
        }
        #endregion

        #region 添加热点
        /// <summary>
        /// 通过Get访问方式添加热点
        /// </summary>
        /// <param name="hot"></param>
        public void AddHotForGet(Fire_Hot hot)
        {
            //参数字典
            Dictionary<string, object> parameterDict = hot.ObjectToDict();
            parameterDict.Add("f", 4111001);

            Thread thread = new Thread(() =>
            {
                bool iss = false;

                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (AddHotEvent != null)
                {
                    if (iss)
                    {
                        AddHotEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddHotEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        /// <summary>
        /// 通过Post访问方式添加热点
        /// </summary>
        /// <param name="hot"></param>
        public void AddHotForPost(Fire_Hot hot)
        {
            //参数字典
            Dictionary<string, object> parameterDict = hot.ObjectToDict();
            parameterDict.Add("f", 4111001);

            Thread thread = new Thread(()=> 
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url, this.m_Resource, parameterDict, out iss);

                if (AddHotEvent != null)
                {
                    if (iss)
                    {
                        AddHotEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddHotEvent(content, null);
                    }
                }
            });
            thread.Start();
        }
        #endregion

        #region 编辑热点
        /// <summary>
        /// 通过Get访问方式编辑热点
        /// </summary>
        /// <param name="hot"></param>
        public void EditHotForGet(Fire_Hot hot)
        {
            //参数字典
            Dictionary<string, object> parameterDict = hot.ObjectToDict();
            parameterDict.Add("f", 4112001);

            Thread thread = new Thread(()=>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (EditHotEvent != null)
                {
                    if (iss)
                    {
                        EditHotEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditHotEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        /// <summary>
        /// 通过Post访问方式编辑热点
        /// </summary>
        /// <param name="hot"></param>
        public void EditHotForPost(Fire_Hot hot)
        {
            //参数字典
            Dictionary<string, object> parameterDict = hot.ObjectToDict();
            parameterDict.Add("f", 4112001);

            Thread thread = new Thread(()=>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (EditHotEvent != null)
                {
                    if (iss)
                    {
                        EditHotEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditHotEvent(content, null);
                    }
                }
            });
            thread.Start();
        }
        #endregion

        #region 删除热点
        /// <summary>
        /// 通过Get访问形式删除热点
        /// </summary>
        /// <param name="id"></param>
        public void DeleteHotForGet(string id)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4113001 },
                {"id",id }
            };

            Thread thread = new Thread(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (DeleteHotEvent != null)
                {
                    if (iss)
                    {
                        DeleteHotEvent(content, new EventArgs());
                    }
                    else
                    {
                        DeleteHotEvent(content, null);
                    }
                }
            });
            thread.Start();
        }
        #endregion
        #endregion

        #region 视频监控点管理

        #region 查询视频监控点列表
        /// <summary>
        /// 通过Get访问方式查询监控点列表
        /// </summary>
        public void GetMonitorForGet(string pac=null,int fetchType=3,int page=1,int rows=30,
            string sort=null,string order="asc")
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4120001},
                {"pac",(pac == null) ? "" : pac},
                {"fetchType",fetchType},
                {"page",page},
                {"rows",rows},
                {"sort",(sort == null) ? "" : sort},
                { "order",order}
            };

            Thread thread = new Thread(()=> 
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (GetMonitorListEvent != null)
                {
                    if (iss)
                    {
                        GetMonitorListEvent(content, new EventArgs());
                    }
                    else
                    {
                        GetMonitorListEvent(content, null);
                    }
                }
            });
            thread.Start();
        }
        #endregion

        #region 添加视频监控点
        /// <summary>
        /// 通过Get访问方式新增视频监控点
        /// </summary>
        /// <param name="monitor"></param>
        public void AddMonitorForGet(Fire_ForestRemoteMonitoring monitor)
        {
            //参数字典
            Dictionary<string, object> parameterDict = monitor.ObjectToDict();
            parameterDict.Add("f", 4121001);

            Thread thread = new Thread(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (AddMonitorEvent != null)
                {
                    if (iss)
                    {
                        AddMonitorEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddMonitorEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        /// <summary>
        /// 通过Post访问方式新增视频监控点
        /// </summary>
        /// <param name="monitor"></param>
        public void AddMonitorForPost(Fire_ForestRemoteMonitoring monitor)
        {
            //参数字典
            Dictionary<string, object> parameterDict = monitor.ObjectToDict();
            parameterDict.Add("f", 4121001);

            Thread thread = new Thread(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (AddMonitorEvent != null)
                {
                    if (iss)
                    {
                        AddMonitorEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddMonitorEvent(content, null);
                    }
                }
            });
            thread.Start();
        }
        #endregion

        #region 编辑视频监控点
        /// <summary>
        /// 通过Get访问方式编辑视频监控点
        /// </summary>
        /// <param name="monitor"></param>
        public void EditMonitorForGet(Fire_ForestRemoteMonitoring monitor)
        {
            //参数字典
            Dictionary<string, object> parameterDict = monitor.ObjectToDict();
            parameterDict.Add("f", 4122001);

            Thread thread = new Thread(()=>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (EditMonitorEvent != null)
                {
                    if (iss)
                    {
                        EditMonitorEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditMonitorEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        /// <summary>
        /// 通过Get访问方式编辑视频监控点
        /// </summary>
        /// <param name="monitor"></param>
        public void EditMonitorForPost(Fire_ForestRemoteMonitoring monitor)
        {
            //参数字典
            Dictionary<string, object> parameterDict = monitor.ObjectToDict();
            parameterDict.Add("f", 4122001);

            Thread thread = new Thread(()=>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (EditMonitorEvent != null)
                {
                    if (iss)
                    {
                        EditMonitorEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditMonitorEvent(content, null);
                    }
                }
            });
            thread.Start();
        }
        #endregion

        #region 删除视频监控点
        /// <summary>
        /// 通过Get访问方式删除视频监控点
        /// </summary>
        /// <param name="id"></param>
        public void DeleteMonitorForGet(string id)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f", 4123001},
                {"id",id }
            };

            Thread thread = new Thread(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);
                if (DeleteMonitorEvent != null)
                {
                    if (iss)
                    {
                        DeleteMonitorEvent(content, new EventArgs());
                    }
                    else
                    {
                        DeleteMonitorEvent(content, null);
                    }
                }
            });
            thread.Start();
        }
        #endregion

        #endregion

        #region 瞭望台

        #region 获取瞭望台列表
        public void GetWatchTowerListForGet(string pac, int fetchType = 3, int page = 1, int rows = 30,
            string sort = null, string order = "desc")
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4130001},
                {"pac",(pac == null) ? "" : pac},
                {"fetchType",fetchType},
                {"page",page},
                {"rows",rows},
                {"sort",(sort == null) ? "" : sort},
                { "order",order}
            };

            Task task = Task.Factory.StartNew(() => 
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (GetWatchTowerListEvent != null)
                {
                    if (iss)
                    {
                        GetWatchTowerListEvent(content, new EventArgs());
                    }
                    else
                    {
                        GetWatchTowerListEvent(content, null);
                    }
                }
            });
        }
        #endregion

        #region 添加瞭望台

        /// <summary>
        /// 通过Get方式添加瞭望台
        /// </summary>
        /// <param name="watchTower">瞭望台对象</param>
        public void AddWatchTowerForGet(Fire_Observatory watchTower)
        {
            //参数字典
            Dictionary<string, object> parameterDict = watchTower.ObjectToDict();
            parameterDict.Add("f", 4131001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss,watchTower.mediaByteDict);

                if (AddWatchTowerEvent != null)
                {
                    if (iss)
                    {
                        AddWatchTowerEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddWatchTowerEvent(content, null);
                    }
                }
            });
        }

        /// <summary>
        /// 通过Post方式添加瞭望台
        /// </summary>
        /// <param name="watchTower">瞭望台对象</param>
        public void AddWatchTowerForPost(Fire_Observatory watchTower)
        {
            //参数字典
            Dictionary<string, object> parameterDict = watchTower.ObjectToDict();
            parameterDict.Add("f", 4131001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url, this.m_Resource, parameterDict, out iss, watchTower.mediaByteDict);

                if (AddWatchTowerEvent != null)
                {
                    if (iss)
                    {
                        AddWatchTowerEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddWatchTowerEvent(content, null);
                    }
                }
            });
        }
        #endregion

        #region 编辑瞭望台

        /// <summary>
        /// 通过Get方式编辑瞭望台
        /// </summary>
        /// <param name="watchTower">瞭望台对象</param>
        public void EditWatchTowerForGet(Fire_Observatory watchTower)
        {
            //参数字典
            Dictionary<string, object> parameterDict = watchTower.ObjectToDict();
            parameterDict.Add("f", 4132001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (EditWatchTowerEvent != null)
                {
                    if (iss)
                    {
                        EditWatchTowerEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditWatchTowerEvent(content, null);
                    }
                }
            });
        }

        /// <summary>
        /// 通过Post方式编辑瞭望台
        /// </summary>
        /// <param name="watchTower">瞭望台对象</param>
        public void EditWatchTowerForPost(Fire_Observatory watchTower)
        {
            //参数字典
            Dictionary<string, object> parameterDict = watchTower.ObjectToDict();
            parameterDict.Add("f", 4132001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url, this.m_Resource, parameterDict, out iss);

                if (EditWatchTowerEvent != null)
                {
                    if (iss)
                    {
                        EditWatchTowerEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditWatchTowerEvent(content, null);
                    }
                }
            });
        }
        #endregion

        #region 删除瞭望台
        public void DeleteWatchTowerForGet(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f", 4133001},
                {"id",id }
            };

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (DeleteWatchTowerEvent != null)
                {
                    if (iss)
                    {
                        DeleteWatchTowerEvent(content, new EventArgs());
                    }
                    else
                    {
                        DeleteWatchTowerEvent(content, null);
                    }
                }
            });
        }
        #endregion

        #endregion

        #region 无线电台站

        #region 获取无线电台站列表
        public void GetRadioStationListForGet(string pac, int fetchType = 3, int page = 1, int rows = 30,
            string sort = null, string order = "desc")
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4140001},
                {"pac",(pac == null) ? "" : pac},
                {"fetchType",fetchType},
                {"page",page},
                {"rows",rows},
                {"sort",(sort == null) ? "" : sort},
                { "order",order}
            };

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (GetRadioStationListEvent != null)
                {
                    if (iss)
                    {
                        GetRadioStationListEvent(content, new EventArgs());
                    }
                    else
                    {
                        GetRadioStationListEvent(content, null);
                    }
                }
            });
        }

        #endregion

        #region 添加无线电台站

        /// <summary>
        /// 通过Get方式添加无线电台站
        /// </summary>
        /// <param name="radioStation">无线电台站对象</param>
        public void AddRadioStationForGet(Fire_RadioStation radioStation)
        {
            Dictionary<string, object> parameterDict = radioStation.ObjectToDict();
            parameterDict.Add("f", 4141001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss,radioStation.mediaByteDict);

                if (AddRadioStationEvent != null)
                {
                    if (iss)
                    {
                        AddRadioStationEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddRadioStationEvent(content, null);
                    }
                }
            });
        }

        /// <summary>
        /// 通过Post方式添加无线电台站
        /// </summary>
        /// <param name="radioStation">无线电台站对象</param>
        public void AddRadioStationForPost(Fire_RadioStation radioStation)
        {
            Dictionary<string, object> parameterDict = radioStation.ObjectToDict();
            parameterDict.Add("f", 4141001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url, this.m_Resource, parameterDict, out iss, radioStation.mediaByteDict);

                if (AddRadioStationEvent != null)
                {
                    if (iss)
                    {
                        AddRadioStationEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddRadioStationEvent(content, null);
                    }
                }
            });
        }
        #endregion

        #region 编辑无线电台站

        /// <summary>
        /// 通过Get方式编辑无线电台站
        /// </summary>
        /// <param name="radioStation">无线电台站对象</param>
        public void EidtRadioStationForGet(Fire_RadioStation radioStation)
        {
            Dictionary<string, object> parameterDict = radioStation.ObjectToDict();
            parameterDict.Add("f", 4142001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (EditRadioStationEvent != null)
                {
                    if (iss)
                    {
                        EditRadioStationEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditRadioStationEvent(content, null);
                    }
                }
            });
        }

        /// <summary>
        /// 通过Post方式编辑无线电台站
        /// </summary>
        /// <param name="radioStation">无线电台站对象</param>
        public void EditRadioStationForPost(Fire_RadioStation radioStation)
        {
            Dictionary<string, object> parameterDict = radioStation.ObjectToDict();
            parameterDict.Add("f", 4142001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url, this.m_Resource, parameterDict, out iss);

                if (EditRadioStationEvent != null)
                {
                    if (iss)
                    {
                        EditRadioStationEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditRadioStationEvent(content, null);
                    }
                }
            });
        }

        #endregion

        #region 删除无线电台站
        public void DeleteRadioStationForGet(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f", 4143001},
                {"id",id }
            };

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (DeleteRadioStationEvent != null)
                {
                    if (iss)
                    {
                        DeleteRadioStationEvent(content, new EventArgs());
                    }
                    else
                    {
                        DeleteRadioStationEvent(content, null);
                    }
                }
            });
        }
        #endregion

        #endregion

        #region 森林防火指挥部

        #region 获取森林防火指挥部列表

        public void GetFireCommandListForGet(string pac, int fetchType = 3, int page = 1, int rows = 30,
            string sort = null, string order = "desc")
        { 
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4150001},
                {"pac",(pac == null) ? "" : pac},
                {"fetchType",fetchType},
                {"page",page},
                {"rows",rows},
                {"sort",(sort == null) ? "" : sort},
                { "order",order}
            };

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (GetFireCommandListEvent != null)
                {
                    if (iss)
                    {
                        GetFireCommandListEvent(content, new EventArgs());
                    }
                    else
                    {
                        GetFireCommandListEvent(content, null);
                    }
                }
            });
        }

        #endregion

        #region 添加森林防火指挥部

        /// <summary>
        /// 通过Get方式添加森林防火指挥部
        /// </summary>
        /// <param name="fireCommand">森林防火指挥部对象</param>
        public void AddFireCommandForGet(Fire_Command fireCommand)
        {
            Dictionary<string, object> paremterDict = fireCommand.ObjectToDict();
            paremterDict.Add("f", 4151001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, paremterDict, out iss,fireCommand.mediaByteDict);

                if (AddFireCommandEvent != null)
                {
                    if (iss)
                    {
                        AddFireCommandEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddFireCommandEvent(content, null);
                    }
                }
            });
        }

        /// <summary>
        /// 通过Post方式添加森林防火指挥部
        /// </summary>
        /// <param name="fireCommand">森林防火指挥部对象</param>
        public void AddFireCommandForPost(Fire_Command fireCommand)
        {
            Dictionary<string, object> paremterDict = fireCommand.ObjectToDict();
            paremterDict.Add("f", 4151001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url,this.m_Resource, paremterDict, out iss,fireCommand.mediaByteDict);

                if (AddFireCommandEvent != null)
                {
                    if (iss)
                    {
                        AddFireCommandEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddFireCommandEvent(content, null);
                    }
                }
            });
        }
        #endregion

        #region 编辑森林防火指挥部
        public void EditFireCommandForGet(Fire_Command fireCommand)
        {
            Dictionary<string, object> paremterDict = fireCommand.ObjectToDict();
            paremterDict.Add("f", 4152001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, paremterDict, out iss);

                if (EditFireCommandEvent != null)
                {
                    if (iss)
                    {
                        EditFireCommandEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditFireCommandEvent(content, null);
                    }
                }
            });
        }
        public void EditFireCommandForPost(Fire_Command fireCommand)
        {
            Dictionary<string, object> paremterDict = fireCommand.ObjectToDict();
            paremterDict.Add("f", 4152001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url, this.m_Resource, paremterDict, out iss);

                if (EditFireCommandEvent != null)
                {
                    if (iss)
                    {
                        EditFireCommandEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditFireCommandEvent(content, null);
                    }
                }
            });
        }
        #endregion

        #region 删除森林防火指挥部
        public void DeleteFireCommandForGet(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f", 4153001},
                {"id",id }
            };

            Task task = Task.Factory.StartNew(() => 
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (DeleteFireCommandEvent != null)
                {
                    if (iss)
                    {
                        DeleteFireCommandEvent(content, new EventArgs());
                    }
                    else
                    {
                        DeleteFireCommandEvent(content, null);
                    }
                }
            });
        }
        #endregion
        #endregion

        #region 防火林带

        #region 获取防火林带列表
        public void GetFireForestBeltListForGet(string pac, int fetchType = 3, int page = 1, int rows = 30,
            string sort = null, string order = "desc")
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4160001},
                {"pac",(pac == null) ? "" : pac},
                {"fetchType",fetchType},
                {"page",page},
                {"rows",rows},
                {"sort",(sort == null) ? "" : sort},
                { "order",order}
            };

            Task task = Task.Factory.StartNew(() => 
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (GetFireForestBeltListEvent != null)
                {
                    if (iss)
                    {
                        GetFireForestBeltListEvent(content, new EventArgs());
                    }
                    else
                    {
                        GetFireForestBeltListEvent(content, null);
                    }
                }
            });
        }
        #endregion

        #region 添加防火林带
        /// <summary>
        /// 通过Get方式添加防火林带
        /// </summary>
        /// <param name="ffBelt"></param>
        public void AddFireForestBeltForGet(Fire_ForestBeltPoint ffBelt)
        {
            Dictionary<string, object> paremterDict = ffBelt.ObjectToDict();
            paremterDict.Add("f", 4161001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url, this.m_Resource, paremterDict, out iss, ffBelt.mediaByteDict);

                if (AddFireForestBeltEvent != null)
                {
                    if (iss)
                    {
                        AddFireForestBeltEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddFireForestBeltEvent(content, null);
                    }
                }
            });
        }

        /// <summary>
        /// 通过Post方式添加防火林带
        /// </summary>
        /// <param name="ffBelt"></param>
        public void AddFireForestBeltForPost(Fire_ForestBeltPoint ffBelt)
        {
            Dictionary<string, object> paremterDict = ffBelt.ObjectToDict();
            paremterDict.Add("f", 4161001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url,this.m_Resource, paremterDict, out iss, ffBelt.mediaByteDict);

                if (AddFireForestBeltEvent != null)
                {
                    if (iss)
                    {
                        AddFireForestBeltEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddFireForestBeltEvent(content, null);
                    }
                }
            });
        }
        #endregion

        #region 编辑防火林带

        /// <summary>
        /// 通过Get方式编辑防火林带
        /// </summary>
        /// <param name="ffBelt"></param>
        public void EditFireForestBeltForGet(Fire_ForestBeltPoint ffBelt)
        {
            Dictionary<string, object> paremterDict = ffBelt.ObjectToDict();
            paremterDict.Add("f", 4162001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, paremterDict, out iss);

                if (EditFireForestBeltEvent != null)
                {
                    if (iss)
                    {
                        EditFireForestBeltEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditFireForestBeltEvent(content, null);
                    }
                }
            });
        }

        /// <summary>
        /// 通过Post方式编辑防火林带
        /// </summary>
        /// <param name="ffBelt"></param>
        public void EditFireForestBeltForPost(Fire_ForestBeltPoint ffBelt)
        {
            Dictionary<string, object> paremterDict = ffBelt.ObjectToDict();
            paremterDict.Add("f", 4162001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url, this.m_Resource, paremterDict, out iss);

                if (EditFireForestBeltEvent != null)
                {
                    if (iss)
                    {
                        EditFireForestBeltEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditFireForestBeltEvent(content, null);
                    }
                }
            });
        }
        #endregion

        #region 删除防火林带
        public void DeleteFireForestBeltForGet(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f", 4163001},
                {"id",id }
            };

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (DeleteFireForestBeltEvent != null)
                {
                    if (iss)
                    {
                        DeleteFireForestBeltEvent(content, new EventArgs());
                    }
                    else
                    {
                        DeleteFireForestBeltEvent(content, null);
                    }
                }
            });
        }
        #endregion

        #endregion

        #region 航空灭火蓄水池

        #region 获取航空灭火蓄水池列表

        public void GetArtificiallakeListForGet(string pac, int fetchType = 3, int page = 1, int rows = 30,
            string sort = null, string order = "desc")
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4170001},
                {"pac",(pac == null) ? "" : pac},
                {"fetchType",fetchType},
                {"page",page},
                {"rows",rows},
                {"sort",(sort == null) ? "" : sort},
                { "order",order}
            };

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (GetArtificiallakeListEvent != null)
                {
                    if (iss)
                    {
                        GetArtificiallakeListEvent(content, new EventArgs());
                    }
                    else
                    {
                        GetArtificiallakeListEvent(content, null);
                    }
                }
            });
        }

        #endregion

        #region 添加航空灭火蓄水池

        /// <summary>
        /// 通过Get方式添加航空灭火蓄水池
        /// </summary>
        /// <param name="artificiallake"></param>
        public void AddArtificiallakeForGet(Fire_Artificiallake artificiallake)
        {
            Dictionary<string, object> paremterDict = artificiallake.ObjectToDict();
            paremterDict.Add("f", 4171001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, paremterDict, out iss,artificiallake.mediaByteDict);

                if (AddArtificiallakeEvent != null)
                {
                    if (iss)
                    {
                        AddArtificiallakeEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddArtificiallakeEvent(content, null);
                    }
                }
            });
        }

        /// <summary>
        /// 通过Post方式添加航空灭火蓄水池
        /// </summary>
        /// <param name="artificiallake"></param>
        public void AddArtificiallakeForPost(Fire_Artificiallake artificiallake)
        {
            Dictionary<string, object> paremterDict = artificiallake.ObjectToDict();
            paremterDict.Add("f", 4171001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url,this.m_Resource, paremterDict, out iss, artificiallake.mediaByteDict);

                if (AddArtificiallakeEvent != null)
                {
                    if (iss)
                    {
                        AddArtificiallakeEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddArtificiallakeEvent(content, null);
                    }
                }
            });
        }

        #endregion

        #region 编辑航空灭火蓄水池

        /// <summary>
        /// 通过Get方式编辑航空灭火蓄水池
        /// </summary>
        /// <param name="artificiallake"></param>
        public void EditArtificiallakeForGet(Fire_Artificiallake artificiallake)
        {
            Dictionary<string, object> paremterDict = artificiallake.ObjectToDict();
            paremterDict.Add("f", 4172001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url, this.m_Resource, paremterDict, out iss);

                if (EditArtificiallakeEvent != null)
                {
                    if (iss)
                    {
                        EditArtificiallakeEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditArtificiallakeEvent(content, null);
                    }
                }
            });
        }

        /// <summary>
        /// 通过Post方式编辑航空灭火蓄水池
        /// </summary>
        /// <param name="artificiallake"></param>
        public void EditArtificiallakeForPost(Fire_Artificiallake artificiallake)
        {
            Dictionary<string, object> paremterDict = artificiallake.ObjectToDict();
            paremterDict.Add("f", 4172001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url, this.m_Resource, paremterDict, out iss);

                if (EditArtificiallakeEvent != null)
                {
                    if (iss)
                    {
                        EditArtificiallakeEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditArtificiallakeEvent(content, null);
                    }
                }
            });
        }

        #endregion

        #region 删除航空灭火蓄水池
        public void DeleteArtificiallakeForGet(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4173001 },
                {"id",id}
            };

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (DeleteArtificiallakeEvent != null)
                {
                    if (iss)
                    {
                        DeleteArtificiallakeEvent(content, new EventArgs());
                    }
                    else
                    {
                        DeleteArtificiallakeEvent(content, null);
                    }
                }
            });
        }
        #endregion
        #endregion

        #region 林区危险及重要性设备设施

        #region 获取林区危险及重要性设备设施列表

        public void GetDangerousFacilitiesListForGet(string pac, int fetchType = 3, int page = 1, int rows = 30,
            string sort = null, string order = "desc")
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4180001},
                {"pac",(pac == null) ? "" : pac},
                {"fetchType",fetchType},
                {"page",page},
                {"rows",rows},
                {"sort",(sort == null) ? "" : sort},
                { "order",order}
            };

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url, this.m_Resource, parameterDict, out iss);

                if (GetDangerousFacilitiesListEvent != null)
                {
                    if (iss)
                    {
                        GetDangerousFacilitiesListEvent(content, new EventArgs());
                    }
                    else
                    {
                        GetDangerousFacilitiesListEvent(content, null);
                    }
                }
            });
            
        }

        #endregion

        #region 添加林区危险及重要性设备设施

        /// <summary>
        /// 通过Get方式添加林区危险及重要性设备设施
        /// </summary>
        /// <param name="artificiallake"></param>
        public void AddDangerousFacilitiesForGet(Fire_DangerousFacilities dangerousFacilities)
        {
            Dictionary<string, object> parameterDict = dangerousFacilities.ObjectToDict();
            parameterDict.Add("f", 4181001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url, this.m_Resource, parameterDict, out iss, dangerousFacilities.mediaByteDict);

                if (AddDangerousFacilitiesEvent != null)
                {
                    if (iss)
                    {
                        AddDangerousFacilitiesEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddDangerousFacilitiesEvent(content, null);
                    }
                }
            });
        }

        /// <summary>
        /// 通过Post方式添加林区危险及重要性设备设施
        /// </summary>
        /// <param name="dangerousFacilities"></param>
        public void AddDangerousFacilitiesForPost(Fire_DangerousFacilities dangerousFacilities)
        {
            Dictionary<string, object> parameterDict = dangerousFacilities.ObjectToDict();
            parameterDict.Add("f", 4181001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url, this.m_Resource, parameterDict,out iss, dangerousFacilities.mediaByteDict);

                if (AddDangerousFacilitiesEvent != null)
                {
                    if (iss)
                    {
                        AddDangerousFacilitiesEvent(content, new EventArgs());
                    }
                    else
                    {
                        AddDangerousFacilitiesEvent(content, null);
                    }
                }
            });
            task.Wait();
        }

        #endregion

        #region 编辑林区危险及重要性设备设施

        /// <summary>
        /// 通过Get方式编辑林区危险及重要性设备设施
        /// </summary>
        /// <param name="dangerousFacilities"></param>
        public void EditDangerousFacilitiesForGet(Fire_DangerousFacilities dangerousFacilities)
        {
            //参数字典
            Dictionary<string, object> parameterDict = dangerousFacilities.ObjectToDict();
            parameterDict.Add("f", 4182001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (EditDangerousFacilitiesEvent != null)
                {
                    if (iss)
                    {
                        EditDangerousFacilitiesEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditDangerousFacilitiesEvent(content, null);
                    }
                }
            });
        }

        /// <summary>
        /// 通过Post方式编辑林区危险及重要性设备设施
        /// </summary>
        /// <param name="dangerousFacilities"></param>
        public void EditDangerousFacilitiesForPost(Fire_DangerousFacilities dangerousFacilities)
        {
            //参数字典
            Dictionary<string, object> parameterDict = dangerousFacilities.ObjectToDict();
            parameterDict.Add("f", 4182001);

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpPost(this.m_Url,this.m_Resource, parameterDict, out iss);

                if (EditDangerousFacilitiesEvent != null)
                {
                    if (iss)
                    {
                        EditDangerousFacilitiesEvent(content, new EventArgs());
                    }
                    else
                    {
                        EditDangerousFacilitiesEvent(content, null);
                    }
                }
            });
        }

        #endregion

        #region 删除林区危险及重要性设备设施
        public void DeleteDangerousFacilitiesForGet(string id)
        {
            Dictionary<string, object> paremeterDict = new Dictionary<string, object>()
            {
                {"f", 4183001},
                {"id",id}
            };

            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = RestSharpHelper.HttpGet(this.m_Url,this.m_Resource, paremeterDict, out iss);

                if (DeleteDangerousFacilitiesEvent != null)
                {
                    if (iss)
                    {
                        DeleteDangerousFacilitiesEvent(content, new EventArgs());
                    }
                    else
                    {
                        DeleteDangerousFacilitiesEvent(content, null);
                    }
                }
            });
        }
        #endregion
        #endregion
    }
}
