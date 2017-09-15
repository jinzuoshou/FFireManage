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
    public class UserControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            UserController userController;

            // 测试用例1
            userController = new UserController();
            userController.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)userController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)userController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)userController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            userController = new UserController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            userController.Get(dictionary);
            Assert.IsNotNull((object)userController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)userController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)userController).Port);
        }

        [TestMethod()]
        public void AddTest()
        {
            UserController userController;

            // 测试用例1
            userController = new UserController();
            userController.Add((UserInfo)null);
            Assert.IsNotNull((object)userController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)userController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)userController).Port);

            // 测试用例2
            userController = new UserController();
            UserInfo s0 = new UserInfo();
            s0.id = 0;
            s0.account = (string)null;
            s0.accountType = 0;
            s0.deviceType = 0;
            s0.deviceName = (string)null;
            s0.deviceId = (string)null;
            s0.pac = (string)null;
            s0.competence = 0;
            s0.headFilename = (string)null;
            s0.iosToken = (string)null;
            s0.jid = (string)null;
            s0.online = 0;
            s0.name = (string)null;
            s0.password = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.voipAccount = (string)null;
            s0.voipPassword = (string)null;
            s0.subscriber = (string)null;
            s0.imei = (string)null;
            s0.token = (string)null;
            s0.headPortrait = (string)null;
            userController.Add(s0);
            Assert.IsNotNull((object)userController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)userController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)userController).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            UserController userController;

            // 测试用例1
            userController = new UserController();
            userController.Edit((UserInfo)null);
            Assert.IsNotNull((object)userController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)userController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)userController).Port);

            // 测试用例2
            userController = new UserController();
            UserInfo s0 = new UserInfo();
            s0.id = 0;
            s0.account = (string)null;
            s0.accountType = 0;
            s0.deviceType = 0;
            s0.deviceName = (string)null;
            s0.deviceId = (string)null;
            s0.pac = (string)null;
            s0.competence = 0;
            s0.headFilename = (string)null;
            s0.iosToken = (string)null;
            s0.jid = (string)null;
            s0.online = 0;
            s0.name = (string)null;
            s0.password = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.voipAccount = (string)null;
            s0.voipPassword = (string)null;
            s0.subscriber = (string)null;
            s0.imei = (string)null;
            s0.token = (string)null;
            s0.headPortrait = (string)null;
            userController.Edit(s0);
            Assert.IsNotNull((object)userController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)userController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)userController).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            UserController userController;

            // 测试用例1
            userController = new UserController();
            userController.Delete((Dictionary<string, object>)null);
            Assert.IsNotNull((object)userController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)userController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)userController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            userController = new UserController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            userController.Delete(dictionary);
            Assert.IsNotNull((object)userController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)userController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)userController).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            UserController userController;
            userController = new UserController();
            userController.Delete( 0);
            Assert.IsNotNull((object)userController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)userController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)userController).Port);
        }
    }
}