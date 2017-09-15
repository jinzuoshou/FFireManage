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
    public class AreaCodeControllerTests
    {
        [TestMethod()]
        [PexGeneratedBy(typeof(AreaCodeControllerTests))]
        public void GetTest()
        {
            AreaCodeController areaCodeController;
            Dictionary<string, object> dictionary;
            areaCodeController = new AreaCodeController();

            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            areaCodeController.Get(dictionary);
            Assert.IsNotNull((object)areaCodeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)areaCodeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)areaCodeController).Port);

            areaCodeController.Get(null);
            Assert.IsNotNull((object)areaCodeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)areaCodeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)areaCodeController).Port);            
        }

        [TestMethod()]
        [PexGeneratedBy(typeof(AreaCodeControllerTests))]
        public void GetListTest()
        {
            AreaCodeController areaCodeController;
            areaCodeController = new AreaCodeController();
            areaCodeController.GetList((string)null, 0);
            Assert.IsNotNull((object)areaCodeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)areaCodeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)areaCodeController).Port);
        }
    }
}