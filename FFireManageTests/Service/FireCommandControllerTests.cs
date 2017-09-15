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
    public class FireCommandControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            FireCommandController fireCommandController;
            Dictionary<string, object> dictionary;
            // 测试用例1
            fireCommandController = new FireCommandController();
            fireCommandController.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireCommandController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireCommandController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireCommandController).Port);
            // 测试用例2
            fireCommandController = new FireCommandController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireCommandController.Get( dictionary);
            Assert.IsNotNull((object)fireCommandController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireCommandController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireCommandController).Port);

        }

        [TestMethod()]
        public void AddTest()
        {
            FireCommandController fireCommandController;
            //用例测试1
            fireCommandController = new FireCommandController();
            fireCommandController.Add( (Fire_Command)null);
            Assert.IsNotNull((object)fireCommandController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireCommandController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireCommandController).Port);
            //用例测试2
            fireCommandController = new FireCommandController();
            Fire_Command s0 = new Fire_Command();
            s0.OBJECTID = 0;
            s0.shape = (string)null;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.phone = (string)null;
            s0.director = (string)null;
            s0.dir_phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.num_people = 0;
            s0.institutions = (string)null;
            s0.type = (string)null;
            s0.level = (string)null;
            s0.status = 0;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.commander = (string)null;
            s0.commander_phone = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            fireCommandController.Add( s0);
            Assert.IsNotNull((object)fireCommandController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireCommandController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireCommandController).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            FireCommandController fireCommandController;
            // 测试用例1
            fireCommandController = new FireCommandController();
            fireCommandController.Edit( (Fire_Command)null);
            Assert.IsNotNull((object)fireCommandController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireCommandController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireCommandController).Port);

            // 测试用例2
            fireCommandController = new FireCommandController();
            Fire_Command s0 = new Fire_Command();
            s0.OBJECTID = 0;
            s0.shape = (string)null;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.phone = (string)null;
            s0.director = (string)null;
            s0.dir_phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.num_people = 0;
            s0.institutions = (string)null;
            s0.type = (string)null;
            s0.level = (string)null;
            s0.status = 0;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.commander = (string)null;
            s0.commander_phone = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            fireCommandController.Edit( s0);
            Assert.IsNotNull((object)fireCommandController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireCommandController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireCommandController).Port);

        }

        [TestMethod()]
        public void DeleteTest()
        {
            FireCommandController fireCommandController;
            // 测试用例1
            fireCommandController = new FireCommandController();
            fireCommandController.Delete((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireCommandController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireCommandController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireCommandController).Port);
            // 测试用例2
            Dictionary<string, object> dictionary;
            fireCommandController = new FireCommandController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireCommandController.Delete( dictionary);
            Assert.IsNotNull((object)fireCommandController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireCommandController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireCommandController).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            FireCommandController fireCommandController;
            fireCommandController = new FireCommandController();
            fireCommandController.Delete((string)null);
            Assert.IsNotNull((object)fireCommandController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireCommandController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireCommandController).Port);
        }
    }
}