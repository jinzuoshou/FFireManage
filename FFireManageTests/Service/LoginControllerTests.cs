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
    public class LoginControllerTests
    {
        [TestMethod()]
        public void LoginControllerTest()
        {
            LoginController loginController;
            loginController = new LoginController();
        }

        [TestMethod()]
        public void LoginTest()
        {
            LoginController loginController;

            // 测试用例1
            loginController = new LoginController();
            loginController.Login((string)null, 0,
                       (string)null, (string)null, (string)null, (string)null);
            Assert.IsNotNull((object)loginController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)loginController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)loginController).Port);

            // 测试用例2
            loginController = new LoginController();
            loginController.Login( (string)null, 1,
                       (string)null, (string)null, (string)null, (string)null);
            Assert.IsNotNull((object)loginController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)loginController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)loginController).Port);

            //测试用例3
            loginController = new LoginController();
            loginController.Login( (string)null, 320,
                       (string)null, (string)null, (string)null, (string)null);
            Assert.IsNotNull((object)loginController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)loginController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)loginController).Port);

            //测试用例4
            loginController = new LoginController();
            loginController.Login( "", 0,
                       (string)null, (string)null, (string)null, (string)null);
            Assert.IsNotNull((object)loginController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)loginController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)loginController).Port);

            // 测试用例5
            loginController = new LoginController();
            loginController.Login( (string)null, int.MinValue,
                       (string)null, (string)null, (string)null, (string)null);
            Assert.IsNotNull((object)loginController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)loginController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)loginController).Port);

            // 测试用例6
            loginController = new LoginController();
            loginController.Login( (string)null, int.MaxValue,
                       (string)null, (string)null, (string)null, (string)null);
            Assert.IsNotNull((object)loginController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)loginController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)loginController).Port);

            // 测试用例7
            loginController = new LoginController();
            loginController.Login( "", 1,
                       (string)null, (string)null, (string)null, (string)null);
            Assert.IsNotNull((object)loginController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)loginController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)loginController).Port);

            // 测试用例8
            loginController = new LoginController();
            loginController.Login( (string)null, int.MaxValue,
                       "", (string)null, (string)null, (string)null);
            Assert.IsNotNull((object)loginController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)loginController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)loginController).Port);

            // 测试用例9
            loginController = new LoginController();
            loginController.Login( "", int.MaxValue,
                       (string)null, "", (string)null, (string)null);
            Assert.IsNotNull((object)loginController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)loginController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)loginController).Port);

            // 测试用例10
            loginController = new LoginController();
            loginController.Login
                ( "", int.MaxValue, (string)null, "", (string)null, "");
            Assert.IsNotNull((object)loginController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)loginController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)loginController).Port);

            // 测试用例11
            loginController = new LoginController();
            loginController.Login( "", int.MaxValue, "", "", (string)null, "");
            Assert.IsNotNull((object)loginController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)loginController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)loginController).Port);

            // 测试用例12
            loginController = new LoginController();
            loginController.Login( (string)null, -1304428544,
                       (string)null, (string)null, "", (string)null);
            Assert.IsNotNull((object)loginController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)loginController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)loginController).Port);
        }
    }
}