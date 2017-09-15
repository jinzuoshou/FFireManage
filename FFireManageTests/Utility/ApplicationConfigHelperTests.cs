using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFireManage.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFireManage.Utility.Tests
{
    [TestClass()]
    public class ApplicationConfigHelperTests
    {
        [TestMethod()]
        public void GetValueByKeyTest()
        {
            string s;
            s = ApplicationConfigHelper.GetValueByKey((string)null);
        }
    }
}