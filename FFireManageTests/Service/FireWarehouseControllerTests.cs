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
    public class FireWarehouseControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            FireWarehouseController fireWarehouseController;

            // 测试用例1
            fireWarehouseController = new FireWarehouseController();
            fireWarehouseController.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            fireWarehouseController = new FireWarehouseController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireWarehouseController.Get(dictionary);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);

        }

        [TestMethod()]
        public void AddTest()
        {
            FireWarehouseController fireWarehouseController;

            // 测试用例1
            fireWarehouseController = new FireWarehouseController();
            fireWarehouseController.Add((Fire_Warehouse)null);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);

            // 测试用例2
            fireWarehouseController = new FireWarehouseController();
            Fire_Warehouse s0 = new Fire_Warehouse();
            s0.OBJECTID = 0;
            s0.shape = (string)null;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.phone = (string)null;
            s0.manager = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.typeid = 0;
            s0.user_id = 0;
            s0.mat_id = 0;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.build_year = (string)null;
            s0.build_area = 0;
            s0.status = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.note = (string)null;
            s0.type = (string)null;
            s0.id = (string)null;
            s0.management_unit = (string)null;
            s0.director = (string)null;
            s0.reserve_type = (string)null;
            s0.quantity = (short)0;
            s0.pac = (string)null;
            s0.city = (string)null;
            s0.county = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            fireWarehouseController.Add(s0);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);

            // 测试用例3
            Dictionary<string, object> dictionary;
            fireWarehouseController = new FireWarehouseController();
            dictionary = new Dictionary<string, object>();
            dictionary[""] = (object)null;
            s0 = new Fire_Warehouse();
            s0.OBJECTID = 0;
            s0.shape = (string)null;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.phone = (string)null;
            s0.manager = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.typeid = 0;
            s0.user_id = 0;
            s0.mat_id = 0;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.build_year = (string)null;
            s0.build_area = 0;
            s0.status = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.note = (string)null;
            s0.type = (string)null;
            s0.id = (string)null;
            s0.management_unit = (string)null;
            s0.director = (string)null;
            s0.reserve_type = (string)null;
            s0.quantity = (short)0;
            s0.pac = (string)null;
            s0.city = (string)null;
            s0.county = (string)null;
            s0.mediaByteDict = dictionary;
            s0.mediaFiles = (List<MediaFile>)null;
            fireWarehouseController.Add(s0);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            FireWarehouseController fireWarehouseController;

            // 测试用例1
            fireWarehouseController = new FireWarehouseController();
            fireWarehouseController.Edit((Fire_Warehouse)null);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);

            // 测试用例2
            fireWarehouseController = new FireWarehouseController();
            Fire_Warehouse s0 = new Fire_Warehouse();
            s0.OBJECTID = 0;
            s0.shape = (string)null;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.phone = (string)null;
            s0.manager = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.typeid = 0;
            s0.user_id = 0;
            s0.mat_id = 0;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.build_year = (string)null;
            s0.build_area = 0;
            s0.status = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.note = (string)null;
            s0.type = (string)null;
            s0.id = (string)null;
            s0.management_unit = (string)null;
            s0.director = (string)null;
            s0.reserve_type = (string)null;
            s0.quantity = (short)0;
            s0.pac = (string)null;
            s0.city = (string)null;
            s0.county = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            fireWarehouseController.Edit(s0);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            FireWarehouseController fireWarehouseController;

            //测试用例1
            fireWarehouseController = new FireWarehouseController();
            fireWarehouseController.Delete((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            fireWarehouseController = new FireWarehouseController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireWarehouseController.Delete(dictionary);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);
        }

        [TestMethod()]
        public void AddMediaTest()
        {
            FireWarehouseController fireWarehouseController;

            // 测试用例1
            fireWarehouseController = new FireWarehouseController();
            fireWarehouseController.AddMedia(
                          (Dictionary<string, object>)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            fireWarehouseController = new FireWarehouseController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireWarehouseController.AddMedia
                (dictionary, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest()
        {
            FireWarehouseController fireWarehouseController;

            // 测试用例1
            fireWarehouseController = new FireWarehouseController();
            fireWarehouseController.DeleteMedia((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            fireWarehouseController = new FireWarehouseController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireWarehouseController.DeleteMedia(dictionary);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            FireWarehouseController fireWarehouseController;
            fireWarehouseController = new FireWarehouseController();
            fireWarehouseController.Delete((string)null);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);
        }

        [TestMethod()]
        public void AddMediaTest1()
        {
            FireWarehouseController fireWarehouseController;
            fireWarehouseController = new FireWarehouseController();
            fireWarehouseController.AddMedia
                ((string)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest1()
        {
            FireWarehouseController fireWarehouseController;
            fireWarehouseController = new FireWarehouseController();
            fireWarehouseController.DeleteMedia( (string)null);
            Assert.IsNotNull((object)fireWarehouseController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireWarehouseController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireWarehouseController).Port);
        }
    }
}