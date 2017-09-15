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
    public class WarningBoardsControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            WarningBoardsController warningBoardsController;

            // 测试用例1
            warningBoardsController = new WarningBoardsController();
            warningBoardsController.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            warningBoardsController = new WarningBoardsController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            warningBoardsController.Get(dictionary);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);
        }

        [TestMethod()]
        public void AddTest()
        {
            WarningBoardsController warningBoardsController;

            // 测试用例1
            warningBoardsController = new WarningBoardsController();
            warningBoardsController.Add((Fire_WarningBoards)null);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);

            // 测试用例2
            warningBoardsController = new WarningBoardsController();
            Fire_WarningBoards s0 = new Fire_WarningBoards();
            s0.OBJECTID = 0;
            s0.SHAPE = (string)null;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.content = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.status = (string)null;
            s0.note = (string)null;
            s0.build_year = (string)null;
            s0.build_unit = (string)null;
            s0.type = (string)null;
            s0.id = (string)null;
            s0.number = (string)null;
            s0.management_unit = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            warningBoardsController.Add(s0);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);

            // 测试用例3
            Dictionary<string, object> dictionary;
            warningBoardsController = new WarningBoardsController();
            dictionary = new Dictionary<string, object>();
            dictionary[""] = (object)null;
            s0 = new Fire_WarningBoards();
            s0.OBJECTID = 0;
            s0.SHAPE = (string)null;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.content = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.status = (string)null;
            s0.note = (string)null;
            s0.build_year = (string)null;
            s0.build_unit = (string)null;
            s0.type = (string)null;
            s0.id = (string)null;
            s0.number = (string)null;
            s0.management_unit = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = dictionary;
            s0.mediaFiles = (List<MediaFile>)null;
            warningBoardsController.Add(s0);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            WarningBoardsController warningBoardsController;

            // 测试用例1
            warningBoardsController = new WarningBoardsController();
            warningBoardsController.Edit((Fire_WarningBoards)null);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);

            //测试用例2
            warningBoardsController = new WarningBoardsController();
            Fire_WarningBoards s0 = new Fire_WarningBoards();
            s0.OBJECTID = 0;
            s0.SHAPE = (string)null;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.content = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.status = (string)null;
            s0.note = (string)null;
            s0.build_year = (string)null;
            s0.build_unit = (string)null;
            s0.type = (string)null;
            s0.id = (string)null;
            s0.number = (string)null;
            s0.management_unit = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            warningBoardsController.Edit(s0);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            WarningBoardsController warningBoardsController;

            // 测试用例1
            warningBoardsController = new WarningBoardsController();
            warningBoardsController.Delete((Dictionary<string, object>)null);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            warningBoardsController = new WarningBoardsController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            warningBoardsController.Delete(dictionary);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);
        }

        [TestMethod()]
        public void AddMediaTest()
        {
            WarningBoardsController warningBoardsController;

            // 测试用例1
            warningBoardsController = new WarningBoardsController();
            warningBoardsController.AddMedia(
                          (Dictionary<string, object>)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            warningBoardsController = new WarningBoardsController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            warningBoardsController.AddMedia
                (dictionary, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest()
        {
            WarningBoardsController warningBoardsController;

            // 测试用例1
            warningBoardsController = new WarningBoardsController();
            warningBoardsController.DeleteMedia((Dictionary<string, object>)null);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            warningBoardsController = new WarningBoardsController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            warningBoardsController.DeleteMedia(dictionary);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            WarningBoardsController warningBoardsController;
            warningBoardsController = new WarningBoardsController();
            warningBoardsController.Delete((string)null);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);
        }

        [TestMethod()]
        public void AddMediaTest1()
        {
            WarningBoardsController warningBoardsController;
            warningBoardsController = new WarningBoardsController();
            warningBoardsController.AddMedia
                ((string)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest1()
        {
            WarningBoardsController warningBoardsController;
            warningBoardsController = new WarningBoardsController();
            warningBoardsController.DeleteMedia((string)null);
            Assert.IsNotNull((object)warningBoardsController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)warningBoardsController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)warningBoardsController).Port);
        }
    }
}