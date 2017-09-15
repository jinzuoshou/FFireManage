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
    public class FireImportantUnitsControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            FireImportantUnitsController fireImportantUnitsController;
            //用例测试1
            fireImportantUnitsController = new FireImportantUnitsController();
            fireImportantUnitsController.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);
            // 用例测试2
            Dictionary<string, object> dictionary;
            fireImportantUnitsController = new FireImportantUnitsController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireImportantUnitsController.Get(dictionary);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);
        }

        [TestMethod()]
        public void AddTest()
        {
            FireImportantUnitsController fireImportantUnitsController;
            // 用例测试1
            fireImportantUnitsController = new FireImportantUnitsController();
            fireImportantUnitsController.Add((Fire_ImportantUnits)null);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);

            // 用例测试2
            fireImportantUnitsController = new FireImportantUnitsController();
            Fire_ImportantUnits s0 = new Fire_ImportantUnits();
            s0.OBJECTID = 0;
            s0.SHAPE = (string)null;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.num_people = 0;
            s0.build_area = 0;
            s0.type = (string)null;
            s0.status = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.management_unit = (string)null;
            s0.pac = (string)null;
            s0.city_name = (string)null;
            s0.county_name = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            fireImportantUnitsController.Add(s0);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);
            // 用例测试3
            Dictionary<string, object> dictionary;
            fireImportantUnitsController = new FireImportantUnitsController();
            dictionary = new Dictionary<string, object>();
            dictionary[""] = (object)null;
            s0 = new Fire_ImportantUnits();
            s0.OBJECTID = 0;
            s0.SHAPE = (string)null;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.num_people = 0;
            s0.build_area = 0;
            s0.type = (string)null;
            s0.status = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.management_unit = (string)null;
            s0.pac = (string)null;
            s0.city_name = (string)null;
            s0.county_name = (string)null;
            s0.mediaByteDict = dictionary;
            s0.mediaFiles = (List<MediaFile>)null;
            fireImportantUnitsController.Add(s0);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            FireImportantUnitsController fireImportantUnitsController;
            //用例测试1
            fireImportantUnitsController = new FireImportantUnitsController();
            fireImportantUnitsController.Edit((Fire_ImportantUnits)null);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);
            // 用例测试2
            fireImportantUnitsController = new FireImportantUnitsController();
            Fire_ImportantUnits s0 = new Fire_ImportantUnits();
            s0.OBJECTID = 0;
            s0.SHAPE = (string)null;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.num_people = 0;
            s0.build_area = 0;
            s0.type = (string)null;
            s0.status = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.management_unit = (string)null;
            s0.pac = (string)null;
            s0.city_name = (string)null;
            s0.county_name = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            fireImportantUnitsController.Edit(s0);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);

        }

        [TestMethod()]
        public void DeleteTest()
        {
            FireImportantUnitsController fireImportantUnitsController;
            // 测试用例1
            fireImportantUnitsController = new FireImportantUnitsController();
            fireImportantUnitsController.Delete((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);
            //测试用例2
            Dictionary<string, object> dictionary;
            fireImportantUnitsController = new FireImportantUnitsController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireImportantUnitsController.Delete(dictionary);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);
        }

        [TestMethod()]
        public void AddMediaTest()
        {
            FireImportantUnitsController fireImportantUnitsController;
            // 测试用例1
            fireImportantUnitsController = new FireImportantUnitsController();
            fireImportantUnitsController.AddMedia(
                          (Dictionary<string, object>)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);
            //测试用例2
            Dictionary<string, object> dictionary;
            fireImportantUnitsController = new FireImportantUnitsController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireImportantUnitsController.AddMedia(dictionary, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest()
        {
            FireImportantUnitsController fireImportantUnitsController;
            Dictionary<string, object> dictionary;
            //测试用例1
            fireImportantUnitsController = new FireImportantUnitsController();
            fireImportantUnitsController.DeleteMedia((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);
            //测试用例2
            fireImportantUnitsController = new FireImportantUnitsController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireImportantUnitsController.DeleteMedia(dictionary);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            FireImportantUnitsController fireImportantUnitsController;
            fireImportantUnitsController = new FireImportantUnitsController();
            fireImportantUnitsController.Delete((string)null);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);
        }

        [TestMethod()]
        public void AddMediaTest1()
        {
            FireImportantUnitsController fireImportantUnitsController;
            fireImportantUnitsController = new FireImportantUnitsController();
            fireImportantUnitsController.AddMedia((string)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);

        }

        [TestMethod()]
        public void DeleteMediaTest1()
        {
            FireImportantUnitsController fireImportantUnitsController;
            fireImportantUnitsController = new FireImportantUnitsController();
            fireImportantUnitsController.DeleteMedia((string)null);
            Assert.IsNotNull((object)fireImportantUnitsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireImportantUnitsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireImportantUnitsController).Port);
        }
    }
}