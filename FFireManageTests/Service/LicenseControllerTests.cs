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
    public class LicenseControllerTests
    {
        [TestMethod()]
        public void CreateLicenseTest()
        {
            LicenseController licenseController;
            licenseController = new LicenseController();
            licenseController.CreateLicense((string)null, (string)null, 0, 0);
            Assert.IsNotNull((object)licenseController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)licenseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)licenseController).Port);
        }

        [TestMethod()]
        public void GetTest()
        {
            LicenseController licenseController;
            licenseController = new LicenseController();
            licenseController.Get((string)null, 0, 0);
            Assert.IsNotNull((object)licenseController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)licenseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)licenseController).Port);
        }

        [TestMethod()]
        public void GetTest1()
        {
            LicenseController licenseController;

            // 测试用例1
            licenseController = new LicenseController();
            licenseController.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)licenseController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)licenseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)licenseController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            licenseController = new LicenseController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            licenseController.Get(dictionary);
            Assert.IsNotNull((object)licenseController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)licenseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)licenseController).Port);
        }

        [TestMethod()]
        public void RegisterTest()
        {
            LicenseController licenseController;
            licenseController = new LicenseController();
            licenseController.Register( (string)null, (string)null, 0);
            Assert.IsNotNull((object)licenseController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)licenseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)licenseController).Port);
        }

        [TestMethod()]
        public void ProofLicenseTest()
        {
            LicenseController licenseController;
            licenseController = new LicenseController();
            licenseController.ProofLicense((string)null);
            Assert.IsNotNull((object)licenseController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)licenseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)licenseController).Port);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            LicenseController licenseController;
            licenseController = new LicenseController();
            licenseController.Update( 0, (string)null, (string)null, (string)null);
            Assert.IsNotNull((object)licenseController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)licenseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)licenseController).Port);
        }

        [TestMethod()]
        public void LogoutLicenseForPostTest()
        {
            LicenseController licenseController;
            licenseController = new LicenseController();
            licenseController.LogoutLicenseForPost((string)null, (string)null);
            Assert.IsNotNull((object)licenseController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)licenseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)licenseController).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            LicenseController licenseController;

            // 测试用例1
            licenseController = new LicenseController();
            licenseController.Delete( (Dictionary<string, object>)null);
            Assert.IsNotNull((object)licenseController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)licenseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)licenseController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            licenseController = new LicenseController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            licenseController.Delete( dictionary);
            Assert.IsNotNull((object)licenseController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)licenseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)licenseController).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            LicenseController licenseController;
            licenseController = new LicenseController();
            licenseController.Delete( 0);
            Assert.IsNotNull((object)licenseController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)licenseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)licenseController).Port);
        }
    }
}