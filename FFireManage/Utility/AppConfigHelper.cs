using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FFireManage
{
    public class AppConfigHelper
    {
        public static string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {

                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return null;
        }
    }
}
