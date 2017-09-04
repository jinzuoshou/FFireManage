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
    /// 许可授权业务访问类（通过http访问webservice接口）
    /// </summary>
    public class LicenseController : BaseServiceControler<LicenceInfo>
    {
        #region 许可授权

        #region 生成授权许可代码

        public event EventHandler<ServiceEventArgs> CreateLicenceEvent;
        private void OnCreateLicenceEvent(object sender, ServiceEventArgs e)
        {
            if (CreateLicenceEvent != null)
                CreateLicenceEvent(sender, e);
        }
        public void CreateLicense(string account,string pac,int number,int deviceType=2)
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

            this.ExecutePost(parameterDict, OnCreateLicenceEvent);
        }

        #endregion

        #region 获取授权许可列表

        public void Get(string pac, int rows, int page)
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
            this.ExecuteGet(parameterDict, OnQueryEvent);
            
        }

        public override void Get(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 210003);
                }
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        #endregion

        #region 注册许可
        public void Register(string key, string imei, int device)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",322003 },
                {"key",key },
                {"imei",imei },
                {"device",device },
            };
            this.ExecutePost(parameterDict, OnAddEvent);

        }
        #endregion

        #region 校验许可

        public event EventHandler<ServiceEventArgs> ProofLicenseEvent;
        private void OnProofLicenseEvent(object sender, ServiceEventArgs e)
        {
            if (ProofLicenseEvent != null)
            {
                ProofLicenseEvent(sender, e);
            }
        }

        public void ProofLicense(string imei)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f" ,320001},
                {"imei",imei }
            };
            this.ExecuteGet(parameterDict, OnProofLicenseEvent);
        }
        #endregion

        #region 更新许可

        public void Update(int id, string imei, string pac, string key)
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
            this.ExecutePost(parameterDict, OnEditEvent);
        }
        #endregion

        #region 注销许可

        public event EventHandler<ServiceEventArgs> LogoutLicenseEvent;
        private void OnLogoutLicenseEvent(object sender,ServiceEventArgs e)
        {
            if (LogoutLicenseEvent != null)
                LogoutLicenseEvent(sender, e);
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
            this.ExecuteGet(parameterDict, OnLogoutLicenseEvent);
            
        }

        #endregion

        #region 删除许可

        public override void Delete(Dictionary<string, object> parameterDict)
        {
            if(parameterDict!=null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 323001);
                this.ExecuteGet(parameterDict, OnDeleteEvent);
            }
        }

        public void Delete(int id)
        {
            //参数字典
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",323001 },
                {"id",id }
            };

            this.ExecuteGet(parameterDict, OnDeleteEvent);
        }

        #endregion

        #endregion

    }
}
