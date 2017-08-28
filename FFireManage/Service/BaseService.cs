using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFireManage.Utility;
namespace FFireManage.Service
{
    public class BaseService
    {
        private string m_Server = "127.0.0.1";
        /// <summary>
        /// Server
        /// </summary>
        public string Server
        {
            get { return m_Server; }
        }

        private int m_Port = 8080;
        /// <summary>
        /// Port
        /// </summary>
        public int Port
        {
            get { return m_Port; }
        }


        public BaseService()
        {
            string string_server = ApplicationConfigHelper.GetValueByKey("Ip");

            if (!string.IsNullOrEmpty(string_server))
            {
                this.m_Server = string_server;
            }

            string string_port = ApplicationConfigHelper.GetValueByKey("Port");

            if (!string.IsNullOrEmpty(string_port))
            {
                try
                {
                    this.m_Port = Convert.ToInt32(string_port);
                }
                catch
                {
                }
            }
        }

        public string GetHomeUrl()
        {
            string image_url = "http://" + Server + ":" + Port;
            return image_url;
        }

    }
}
