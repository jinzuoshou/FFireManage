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
    public class ArtificiallakeControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            ArtificiallakeController artificiallakeController;
            Dictionary<string, object> dictionary;
            artificiallakeController = new ArtificiallakeController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            artificiallakeController.Get(dictionary);
            Assert.IsNotNull((object)artificiallakeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)artificiallakeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)artificiallakeController).Port);


            artificiallakeController.Get(null);
            Assert.IsNotNull((object)artificiallakeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)artificiallakeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)artificiallakeController).Port);

        }

        [TestMethod()]
        [PexGeneratedBy(typeof(ArtificiallakeControllerTests))]
        public void AddTest()
        {
            ArtificiallakeController artificiallakeController;
            artificiallakeController = new ArtificiallakeController();
            //测试用例1 实例化实体
            Fire_Artificiallake s0 = new Fire_Artificiallake();
            s0.objectid = 0;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.volume = 0;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.shape = (string)null;
            s0.status = 0;
            s0.storage_area = 0;
            s0.storage_capacity = 0;
            s0.maximum_depth = 0;
            s0.management_unit = 0;
            s0.traffic_condition = (string)null;
            s0.is_cableway = (string)null;
            s0.is_take_water = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            artificiallakeController.Add(s0);
            Assert.IsNotNull((object)artificiallakeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)artificiallakeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)artificiallakeController).Port);

            //测试用例2 参数为null
            artificiallakeController.Add(null);
            Assert.IsNotNull((object)artificiallakeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)artificiallakeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)artificiallakeController).Port);

        }

        [TestMethod()]
        [PexGeneratedBy(typeof(ArtificiallakeControllerTests))]
        public void EditTest()
        {
            ArtificiallakeController artificiallakeController;
            artificiallakeController = new ArtificiallakeController();
            //测试用例1 实例化 Fire_Artificiallake实体
            Fire_Artificiallake s0 = new Fire_Artificiallake();
            s0.objectid = 0;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.volume = 0;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.shape = (string)null;
            s0.status = 0;
            s0.storage_area = 0;
            s0.storage_capacity = 0;
            s0.maximum_depth = 0;
            s0.management_unit = 0;
            s0.traffic_condition = (string)null;
            s0.is_cableway = (string)null;
            s0.is_take_water = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            artificiallakeController.Edit(s0);
            Assert.IsNotNull((object)artificiallakeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)artificiallakeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)artificiallakeController).Port);

            //测试用例2
            artificiallakeController.Edit(null);
            Assert.IsNotNull((object)artificiallakeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)artificiallakeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)artificiallakeController).Port);
        }

        [TestMethod()]
        [PexGeneratedBy(typeof(ArtificiallakeControllerTests))]
        public void DeleteTest()
        {
            ArtificiallakeController artificiallakeController;
            Dictionary<string, object> dictionary;
            artificiallakeController = new ArtificiallakeController();

            //测试用例1 
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            artificiallakeController.Delete(dictionary);
            Assert.IsNotNull((object)artificiallakeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)artificiallakeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)artificiallakeController).Port);

            //测试用例2
            artificiallakeController.Delete((Dictionary<string, object>)null);
            Assert.IsNotNull((object)artificiallakeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)artificiallakeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)artificiallakeController).Port);
        }

        [TestMethod()]
        [PexGeneratedBy(typeof(ArtificiallakeControllerTests))]
        public void DeleteTest1()
        {
            ArtificiallakeController artificiallakeController;
            artificiallakeController = new ArtificiallakeController();
            artificiallakeController.Delete((string)null);
            Assert.IsNotNull((object)artificiallakeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)artificiallakeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)artificiallakeController).Port);
        }
    }
}