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
    public class GridUserTableControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            //测试用例1 输入null
            GridUserTableController gridUserTableController;
            gridUserTableController = new GridUserTableController();
            gridUserTableController.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);

            //测试用例2 dictionary[""]=null;
            Dictionary<string, object> dictionary;
            gridUserTableController = new GridUserTableController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            gridUserTableController.Get(dictionary);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);
        }

        [TestMethod()]
        public void AddTest()
        {
            GridUserTableController gridUserTableController;
            // 测试用例1 entity=null
            gridUserTableController = new GridUserTableController();
            gridUserTableController.Add((GridUserTableInfo)null);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);

            //测试用例2 
            gridUserTableController = new GridUserTableController();
            GridUserTableInfo s0 = new GridUserTableInfo();
            s0.id = (string)null;
            s0.name = (string)null;
            s0.gender = default(int?);
            s0.age = default(int?);
            s0.post = (string)null;
            s0.phone = (string)null;
            s0.organization = (string)null;
            s0.type = default(int?);
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.photo = (List<MediaFile>)null;
            gridUserTableController.Add(s0);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);

            //测试用例3
            gridUserTableController = new GridUserTableController();
            s0.id = "";
            s0.name = (string)null;
            s0.gender = default(int?);
            s0.age = default(int?);
            s0.post = (string)null;
            s0.phone = (string)null;
            s0.organization = (string)null;
            s0.type = default(int?);
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.photo = (List<MediaFile>)null;
            gridUserTableController.Add(s0);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);

            //测试用例4
            gridUserTableController = new GridUserTableController();
            s0.id = "";
            s0.name = "";
            s0.gender = default(int?);
            s0.age = default(int?);
            s0.post = (string)null;
            s0.phone = (string)null;
            s0.organization = (string)null;
            s0.type = default(int?);
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.photo = (List<MediaFile>)null;
            gridUserTableController.Add(s0);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);

        }

        [TestMethod()]
        public void EditTest()
        {
            //测试用例1
            GridUserTableController gridUserTableController;
            gridUserTableController = new GridUserTableController();
            gridUserTableController.Edit((GridUserTableInfo)null);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);
            //测试用例2
            gridUserTableController = new GridUserTableController();
            GridUserTableInfo s0 = new GridUserTableInfo();
            s0.id = (string)null;
            s0.name = (string)null;
            s0.gender = default(int?);
            s0.age = default(int?);
            s0.post = (string)null;
            s0.phone = (string)null;
            s0.organization = (string)null;
            s0.type = default(int?);
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.photo = (List<MediaFile>)null;
            gridUserTableController.Edit(s0);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);

            //测试用例3
            gridUserTableController = new GridUserTableController();          
            s0.id = "";
            s0.name = (string)null;
            s0.gender = default(int?);
            s0.age = default(int?);
            s0.post = (string)null;
            s0.phone = (string)null;
            s0.organization = (string)null;
            s0.type = default(int?);
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.photo = (List<MediaFile>)null;
            gridUserTableController.Edit(s0);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);

            //测试用例3
            gridUserTableController = new GridUserTableController();           
            s0.id = "";
            s0.name = (string)null;
            s0.gender = default(int?);
            s0.age = default(int?);
            s0.post = (string)null;
            s0.phone = (string)null;
            s0.organization = (string)null;
            s0.type = default(int?);
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.photo = (List<MediaFile>)null;
            gridUserTableController.Edit(s0);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);

            //测试用例4
            gridUserTableController = new GridUserTableController();
            s0.id = "";
            s0.name = "";
            s0.gender = default(int?);
            s0.age = default(int?);
            s0.post = (string)null;
            s0.phone = (string)null;
            s0.organization = (string)null;
            s0.type = default(int?);
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.photo = (List<MediaFile>)null;
            gridUserTableController.Edit(s0);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //测试用例1
            GridUserTableController gridUserTableController;
            gridUserTableController = new GridUserTableController();
            gridUserTableController.Delete((Dictionary<string, object>)null);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);

            //测试用例2
            Dictionary<string, object> dictionary;
            gridUserTableController = new GridUserTableController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            gridUserTableController.Delete(dictionary);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);
        }

        [TestMethod()]
        public void AddMediaTest()
        {
            //测试用例1
            GridUserTableController gridUserTableController;
            gridUserTableController = new GridUserTableController();
            gridUserTableController.AddMedia(
                          (Dictionary<string, object>)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);

            //测试用例2
            Dictionary<string, object> dictionary;
            gridUserTableController = new GridUserTableController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            gridUserTableController.AddMedia
                (dictionary, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest()
        {
            //测试用例1
            GridUserTableController gridUserTableController;
            gridUserTableController = new GridUserTableController();
            gridUserTableController.DeleteMedia((Dictionary<string, object>)null);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);

            //测试用例2
            Dictionary<string, object> dictionary;
            gridUserTableController = new GridUserTableController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            gridUserTableController.DeleteMedia(dictionary);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            GridUserTableController gridUserTableController;
            gridUserTableController = new GridUserTableController();
            gridUserTableController.Delete((string)null);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);
        }

        [TestMethod()]
        public void AddMediaTest1()
        {
            // 测试用例1
            GridUserTableController gridUserTableController;
            gridUserTableController = new GridUserTableController();
            gridUserTableController.AddMedia
                ((string)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);

            //测试用例2
            Dictionary<string, object> dictionary;
            gridUserTableController = new GridUserTableController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            gridUserTableController.AddMedia((string)null, dictionary);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest1()
        {
            GridUserTableController gridUserTableController;
            gridUserTableController = new GridUserTableController();
            gridUserTableController.DeleteMedia((string)null);
            Assert.IsNotNull((object)gridUserTableController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)gridUserTableController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)gridUserTableController).Port);
        }
    }
}