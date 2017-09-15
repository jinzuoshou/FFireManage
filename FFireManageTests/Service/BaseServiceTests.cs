using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFireManage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFireManage.Service.Tests;
using Microsoft.Pex.Framework.Generated;

namespace FFireManage.Service.Tests
{
    [TestClass()]
    public class BaseServiceTests
    {
        [TestMethod()]
        [PexGeneratedBy(typeof(BaseServiceTests))]
        public void BaseServiceTest()
        {
            BaseService baseService;
            baseService = new BaseService();
        }

        [TestMethod()]
        [PexGeneratedBy(typeof(BaseServiceTests))]
        public void GetHomeUrlTest()
        {
            BaseService baseService;
            string s;
            baseService = new BaseService();
            s = baseService.GetHomeUrl();
            Assert.IsNotNull((object)baseService);
            Assert.AreEqual<string>("127.0.0.1", baseService.Server);
            Assert.AreEqual<int>(8080, baseService.Port);
        }
    }
}