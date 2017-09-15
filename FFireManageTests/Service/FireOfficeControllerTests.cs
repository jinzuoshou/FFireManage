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
    public class FireOfficeControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            FireOfficeController fireOfficeController;
            //测试用例1
            fireOfficeController = new FireOfficeController();
            fireOfficeController.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);
            //测试用例2
            Dictionary<string, object> dictionary;
            fireOfficeController = new FireOfficeController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireOfficeController.Get(dictionary);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);
        }

        [TestMethod()]
        public void AddTest()
        {
            FireOfficeController fireOfficeController;
            //测试用例1
            fireOfficeController = new FireOfficeController();
            fireOfficeController.Add( (Fire_Office)null);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);

            //测试用例2
            fireOfficeController = new FireOfficeController();
            Fire_Office s0 = new Fire_Office();
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
            s0.status = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            fireOfficeController.Add(s0);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);

            //测试用例3
            Dictionary<string, object> dictionary;
            fireOfficeController = new FireOfficeController();
            dictionary = new Dictionary<string, object>();
            dictionary[""] = (object)null;
            s0 = new Fire_Office();
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
            s0.status = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = dictionary;
            s0.mediaFiles = (List<MediaFile>)null;
            fireOfficeController.Add(s0);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            FireOfficeController fireOfficeController;
            
            //用例测试1
            fireOfficeController = new FireOfficeController();
            fireOfficeController.Edit((Fire_Office)null);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);

            //用例测试2
            fireOfficeController = new FireOfficeController();
            Fire_Office s0 = new Fire_Office();
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
            s0.status = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            fireOfficeController.Edit(s0);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            FireOfficeController fireOfficeController;

            //用例测试1
            fireOfficeController = new FireOfficeController();
            fireOfficeController.Delete((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);

            //测试用例2
            Dictionary<string, object> dictionary;
            fireOfficeController = new FireOfficeController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireOfficeController.Delete(dictionary);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);
        }

        [TestMethod()]
        public void AddMediaTest()
        {
            FireOfficeController fireOfficeController;

            //测试用例1
            fireOfficeController = new FireOfficeController();
            fireOfficeController.AddMedia((Dictionary<string, object>)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);

            //测试用例2
            Dictionary<string, object> dictionary;
            fireOfficeController = new FireOfficeController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireOfficeController.AddMedia( dictionary, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest()
        {
            FireOfficeController fireOfficeController;

            //测试用例1
            fireOfficeController = new FireOfficeController();
            fireOfficeController.DeleteMedia( (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);

            //测试用例2
            Dictionary<string, object> dictionary;
            fireOfficeController = new FireOfficeController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireOfficeController.DeleteMedia(dictionary);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            FireOfficeController fireOfficeController;
            fireOfficeController = new FireOfficeController();
            fireOfficeController.Delete((string)null);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);
        }

        [TestMethod()]
        public void AddMediaTest1()
        {
            FireOfficeController fireOfficeController;
            fireOfficeController = new FireOfficeController();
            fireOfficeController.AddMedia( (string)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest1()
        {
            FireOfficeController fireOfficeController;
            fireOfficeController = new FireOfficeController();
            fireOfficeController.DeleteMedia((string)null);
            Assert.IsNotNull((object)fireOfficeController);
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)fireOfficeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireOfficeController).Port);
        }
    }
}