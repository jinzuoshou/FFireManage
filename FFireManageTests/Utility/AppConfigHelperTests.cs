using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFireManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFireManage.Tests
{
    [TestClass()]
    public class AppConfigHelperTests
    {
        [TestMethod()]
        public void GetAppConfigTest()
        {
            string s;
            s = AppConfigHelper.GetAppConfig((string)null);
        }
    }
}