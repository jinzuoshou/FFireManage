using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FFireManage.Utility
{
    public class ApplicationConfigHelper
    {
        public static string GetValueByKey(string strKey)
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
