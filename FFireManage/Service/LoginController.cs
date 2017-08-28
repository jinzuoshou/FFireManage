using FFireManage.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace FFireManage.Service
{
    /// <summary>
    /// 用户登录业务访问类
    /// </summary>
    public class LoginController : BaseService
    {
        private string m_Url = string.Empty;


        public event EventHandler LoginEvent;
        
        public LoginController()
        {
            this.m_Url = "http://" + base.Server + ":" + base.Port + "/loginController.do?login";
        }

        #region 用户登录

        public void Login(string account, int deviceType, string imei, string deviceName,string deviceId, string password)
        {
            string parameter = "&account=" + account 
                + "&deviceType=" + deviceType 
                + "&imei=" + imei 
                + "&deviceName=" + deviceName
                + "&deviceId="  + deviceId
                + "&password=" + password;

            Thread thread = new Thread(()=>
            {
                string url = this.m_Url;

                bool iss = false;
                string content = HttpHelper2.HttpGet(url, parameter, out iss);

                if (LoginEvent != null)
                {
                    if (iss)
                    {
                        LoginEvent(content, new EventArgs());
                    }
                    else
                    {
                        LoginEvent(content, null);
                    }
                }
            });
            thread.Start();
        }

        #endregion
    }
}
