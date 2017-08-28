using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
    class GlobeHelper
    {
        private static GlobeHelper instance = null;
        private static readonly object padlock = new object();


        public static GlobeHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new GlobeHelper();
                        }
                    }
                }
                return instance;
            }
        }



        private string token = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Token
        {
            get { return token; }
            set { token = value; }
        }

        private UserInfo user;
        /// <summary>
        /// 
        /// </summary>
        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
