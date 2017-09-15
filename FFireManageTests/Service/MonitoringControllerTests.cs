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
    public class MonitoringControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            MonitoringController monitoringController;

            // 测试用例1
            monitoringController = new MonitoringController();
            monitoringController.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)monitoringController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)monitoringController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)monitoringController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            monitoringController = new MonitoringController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            monitoringController.Get(dictionary);
            Assert.IsNotNull((object)monitoringController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)monitoringController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)monitoringController).Port);
        }

        [TestMethod()]
        public void AddTest()
        {
            MonitoringController monitoringController;

            // 测试用例1
            monitoringController = new MonitoringController();
            monitoringController.Add((Fire_ForestRemoteMonitoring)null);
            Assert.IsNotNull((object)monitoringController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)monitoringController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)monitoringController).Port);

            // 测试用例2
            monitoringController = new MonitoringController();
            Fire_ForestRemoteMonitoring s0 = new Fire_ForestRemoteMonitoring();
            s0.objectid = 0;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.county = (string)null;
            s0.deviceid = (string)null;
            s0.ip = (string)null;
            s0.image = (byte[])null;
            s0.height = 0;
            s0.elevation = 0;
            s0.h_offset = 0;
            s0.v_offset = 0;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.shape = (string)null;
            s0.user_ = (string)null;
            s0.password = (string)null;
            s0.city = (string)null;
            s0.channel = 0;
            s0.Port = 0;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.username = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            monitoringController.Add(s0);
            Assert.IsNotNull((object)monitoringController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)monitoringController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)monitoringController).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            MonitoringController monitoringController;

            // 测试用例1
            monitoringController = new MonitoringController();
            monitoringController.Edit((Fire_ForestRemoteMonitoring)null);
            Assert.IsNotNull((object)monitoringController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)monitoringController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)monitoringController).Port);

            // 测试用例2
            monitoringController = new MonitoringController();
            Fire_ForestRemoteMonitoring s0 = new Fire_ForestRemoteMonitoring();
            s0.objectid = 0;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.county = (string)null;
            s0.deviceid = (string)null;
            s0.ip = (string)null;
            s0.image = (byte[])null;
            s0.height = 0;
            s0.elevation = 0;
            s0.h_offset = 0;
            s0.v_offset = 0;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.shape = (string)null;
            s0.user_ = (string)null;
            s0.password = (string)null;
            s0.city = (string)null;
            s0.channel = 0;
            s0.Port = 0;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.username = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            monitoringController.Edit(s0);
            Assert.IsNotNull((object)monitoringController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)monitoringController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)monitoringController).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            MonitoringController monitoringController;

            //测试用例1
            monitoringController = new MonitoringController();
            monitoringController.Delete( (Dictionary<string, object>)null);
            Assert.IsNotNull((object)monitoringController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)monitoringController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)monitoringController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            monitoringController = new MonitoringController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            monitoringController.Delete(dictionary);
            Assert.IsNotNull((object)monitoringController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)monitoringController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)monitoringController).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            MonitoringController monitoringController;
            monitoringController = new MonitoringController();
            monitoringController.Delete((string)null);
            Assert.IsNotNull((object)monitoringController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)monitoringController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)monitoringController).Port);
        }
    }
}