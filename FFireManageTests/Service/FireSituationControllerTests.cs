using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFireManage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFireManage.Model;

namespace FFireManage.Service.Tests
{
    [TestClass()]
    public class FireSituationControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            FireSituationController fireSituationController;

            // 测试用例1
            fireSituationController = new FireSituationController();
            fireSituationController.Add((FireSituation)null);

            // 测试用例2
            fireSituationController = new FireSituationController();
            FireSituation s0 = new FireSituation();
            s0.state = 0;
            s0.type = 0;
            s0.time = (string)null;
            s0.description = (string)null;
            s0.duty = (string)null;
            s0.occupation = (string)null;
            s0.reporter = (string)null;
            s0.fireType = 0;
            s0.age = 0;
            s0.area = 0;
            s0.latitude = 0;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.fireFighting = 0;
            s0.place = (string)null;
            s0.id = (string)null;
            s0.mediaFiles = (List<MediaFile>)null;
            s0.MediaFileDict = (Dictionary<string, object>)null;
            fireSituationController.Add(s0);
            Assert.IsNotNull((object)fireSituationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireSituationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireSituationController).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            FireSituationController fireSituationController;

            // 测试用例1
            fireSituationController = new FireSituationController();
            fireSituationController.Delete((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireSituationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireSituationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireSituationController).Port);

            //测试用例2
            Dictionary<string, object> dictionary;
            fireSituationController = new FireSituationController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireSituationController.Delete(dictionary);
            Assert.IsNotNull((object)fireSituationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireSituationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireSituationController).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            FireSituationController fireSituationController;

            // 测试用例1
            fireSituationController = new FireSituationController();
            fireSituationController.Edit((FireSituation)null);

            //测试用例2
            fireSituationController = new FireSituationController();
            FireSituation s0 = new FireSituation();
            s0.state = 0;
            s0.type = 0;
            s0.time = (string)null;
            s0.description = (string)null;
            s0.duty = (string)null;
            s0.occupation = (string)null;
            s0.reporter = (string)null;
            s0.fireType = 0;
            s0.age = 0;
            s0.area = 0;
            s0.latitude = 0;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.fireFighting = 0;
            s0.place = (string)null;
            s0.id = (string)null;
            s0.mediaFiles = (List<MediaFile>)null;
            s0.MediaFileDict = (Dictionary<string, object>)null;
            fireSituationController.Edit(s0);
            Assert.IsNotNull((object)fireSituationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireSituationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireSituationController).Port);
        }

        [TestMethod()]
        public void GetTest()
        {
            FireSituationController fireSituationController;

            // 测试用例1
            fireSituationController = new FireSituationController();
            fireSituationController.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireSituationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireSituationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireSituationController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            fireSituationController = new FireSituationController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireSituationController.Get(dictionary);
            Assert.IsNotNull((object)fireSituationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireSituationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireSituationController).Port);
        }

        [TestMethod()]
        public void AddMediaTest()
        {
            FireSituationController fireSituationController;

            //测试用例1
            fireSituationController = new FireSituationController();
            fireSituationController.AddMedia((Dictionary<string, object>)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireSituationController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireSituationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireSituationController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            fireSituationController = new FireSituationController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireSituationController.AddMedia(dictionary, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireSituationController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireSituationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireSituationController).Port);
        }

        [TestMethod()]
        public void AddMediaTest1()
        {
            FireSituationController fireSituationController;
            fireSituationController = new FireSituationController();
            fireSituationController.AddMedia
                ((string)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireSituationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireSituationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireSituationController).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest()
        {
            FireSituationController fireSituationController;

            //测试用例1
            fireSituationController = new FireSituationController();
            fireSituationController.DeleteMedia( (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireSituationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireSituationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireSituationController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            fireSituationController = new FireSituationController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireSituationController.DeleteMedia(dictionary);
            Assert.IsNotNull((object)fireSituationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireSituationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireSituationController).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest1()
        {
            FireSituationController fireSituationController;
            fireSituationController = new FireSituationController();
            fireSituationController.DeleteMedia((string)null);
            Assert.IsNotNull((object)fireSituationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireSituationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireSituationController).Port);
        }
    }
}