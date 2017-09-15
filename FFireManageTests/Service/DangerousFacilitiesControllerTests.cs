using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFireManage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFireManage.Service.Tests
{
    [TestClass()]
    public class DangerousFacilitiesControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            //测试用例1 字典中key中的""替换成null

            DangerousFacilitiesController dangerousFacilitiesController;
            Dictionary<string, object> dictionary;
            dangerousFacilitiesController = new DangerousFacilitiesController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            dangerousFacilitiesController.Get(dictionary);
            Assert.IsNotNull((object)dangerousFacilitiesController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)dangerousFacilitiesController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)dangerousFacilitiesController).Port);

            //测试用例2 parameterDict=null;
            dangerousFacilitiesController.Get(null);
            Assert.IsNotNull((object)dangerousFacilitiesController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)dangerousFacilitiesController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)dangerousFacilitiesController).Port);
        }

        [TestMethod()]
        public void AddTest()
        {
            
            DangerousFacilitiesController dangerousFacilitiesController;
            dangerousFacilitiesController = new DangerousFacilitiesController();
            //测试用例1
            Fire_DangerousFacilities s0 = new Fire_DangerousFacilities();
            s0.objectid = 0;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.type = "0";
            s0.content = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.shape = (string)null;
            s0.status = 0;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            dangerousFacilitiesController.Add(s0);
            Assert.IsNotNull((object)dangerousFacilitiesController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)dangerousFacilitiesController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)dangerousFacilitiesController).Port);

            //测试用例2
            dangerousFacilitiesController.Add((Fire_DangerousFacilities)null);
            Assert.IsNotNull((object)dangerousFacilitiesController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)dangerousFacilitiesController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)dangerousFacilitiesController).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            DangerousFacilitiesController dangerousFacilitiesController;
            dangerousFacilitiesController = new DangerousFacilitiesController();
            //测试用例1 实例化实体
            Fire_DangerousFacilities s0 = new Fire_DangerousFacilities();
            s0.objectid = 0;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.type = "0";
            s0.content = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.shape = (string)null;
            s0.status = 0;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            dangerousFacilitiesController.Edit( s0);
            Assert.IsNotNull((object)dangerousFacilitiesController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)dangerousFacilitiesController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)dangerousFacilitiesController).Port);

            //测试用例2 
            dangerousFacilitiesController.Edit((Fire_DangerousFacilities)null);
            Assert.IsNotNull((object)dangerousFacilitiesController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)dangerousFacilitiesController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)dangerousFacilitiesController).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            DangerousFacilitiesController dangerousFacilitiesController;
            Dictionary<string, object> dictionary;
            dangerousFacilitiesController = new DangerousFacilitiesController();
            //测试用例1 将字典(dictionary)中的""替换为null
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            dangerousFacilitiesController.Delete( dictionary);
            Assert.IsNotNull((object)dangerousFacilitiesController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)dangerousFacilitiesController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)dangerousFacilitiesController).Port);

            //测试用例2  dictionary=null;
            dangerousFacilitiesController.Delete( (Dictionary<string, object>)null);
            Assert.IsNotNull((object)dangerousFacilitiesController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)dangerousFacilitiesController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)dangerousFacilitiesController).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            DangerousFacilitiesController dangerousFacilitiesController;
            dangerousFacilitiesController = new DangerousFacilitiesController();
            dangerousFacilitiesController.Delete( (string)null);
            Assert.IsNotNull((object)dangerousFacilitiesController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)dangerousFacilitiesController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)dangerousFacilitiesController).Port);
        }
    }
}