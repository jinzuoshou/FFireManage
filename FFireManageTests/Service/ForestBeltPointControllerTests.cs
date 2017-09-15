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
    public class ForestBeltPointControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            ForestBeltPointController forestBeltPointController;

            // 测试用例1
            forestBeltPointController = new ForestBeltPointController();
            forestBeltPointController.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)forestBeltPointController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)forestBeltPointController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)forestBeltPointController).Port);

            // 测试用例2 
            Dictionary<string, object> dictionary;
            forestBeltPointController = new ForestBeltPointController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            forestBeltPointController.Get( dictionary);
            Assert.IsNotNull((object)forestBeltPointController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)forestBeltPointController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)forestBeltPointController).Port);
        }

        [TestMethod()]
        public void AddTest()
        {
            ForestBeltPointController forestBeltPointController;

            // 测试用例1
            forestBeltPointController = new ForestBeltPointController();
            forestBeltPointController.Add((Fire_ForestBeltPoint)null);
            Assert.IsNotNull((object)forestBeltPointController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)forestBeltPointController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)forestBeltPointController).Port);

            // 测试用例2
            forestBeltPointController = new ForestBeltPointController();
            Fire_ForestBeltPoint s0 = new Fire_ForestBeltPoint();
            s0.OBJECTID = 0;
            s0.SHAPE = (string)null;
            s0.start_addr = (string)null;
            s0.stop_addr = (string)null;
            s0.name = (string)null;
            s0.build_addr = (string)null;
            s0.build_year = (string)null;
            s0.tree_type = (string)null;
            s0.type = (string)null;
            s0.build_unit = (string)null;
            s0.belt_len = default(double?);
            s0.belt_width = default(double?);
            s0.status = 0;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.row_spacing = (string)null;
            s0.id = (string)null;
            s0.management_unit = (string)null;
            s0.phone = (string)null;
            s0.manager = (string)null;
            s0.pac = (string)null;
            s0.city_name = (string)null;
            s0.county_name = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            forestBeltPointController.Add( s0);
            Assert.IsNotNull((object)forestBeltPointController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)forestBeltPointController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)forestBeltPointController).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            ForestBeltPointController forestBeltPointController;
             
            // 测试用例1
            forestBeltPointController = new ForestBeltPointController();
            forestBeltPointController.Edit((Fire_ForestBeltPoint)null);
            Assert.IsNotNull((object)forestBeltPointController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)forestBeltPointController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)forestBeltPointController).Port);

            // 测试用例2
            forestBeltPointController = new ForestBeltPointController();
            Fire_ForestBeltPoint s0 = new Fire_ForestBeltPoint();
            s0.OBJECTID = 0;
            s0.SHAPE = (string)null;
            s0.start_addr = (string)null;
            s0.stop_addr = (string)null;
            s0.name = (string)null;
            s0.build_addr = (string)null;
            s0.build_year = (string)null;
            s0.tree_type = (string)null;
            s0.type = (string)null;
            s0.build_unit = (string)null;
            s0.belt_len = default(double?);
            s0.belt_width = default(double?);
            s0.status = 0;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.row_spacing = (string)null;
            s0.id = (string)null;
            s0.management_unit = (string)null;
            s0.phone = (string)null;
            s0.manager = (string)null;
            s0.pac = (string)null;
            s0.city_name = (string)null;
            s0.county_name = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            forestBeltPointController.Edit( s0);
            Assert.IsNotNull((object)forestBeltPointController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)forestBeltPointController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)forestBeltPointController).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            ForestBeltPointController forestBeltPointController;

            // 测试用例1
            forestBeltPointController = new ForestBeltPointController();
            forestBeltPointController.Delete( (Dictionary<string, object>)null);
            Assert.IsNotNull((object)forestBeltPointController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)forestBeltPointController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)forestBeltPointController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            forestBeltPointController = new ForestBeltPointController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            forestBeltPointController.Delete(dictionary);
            Assert.IsNotNull((object)forestBeltPointController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)forestBeltPointController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)forestBeltPointController).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            ForestBeltPointController forestBeltPointController;
            forestBeltPointController = new ForestBeltPointController();
            forestBeltPointController.Delete((string)null);
            Assert.IsNotNull((object)forestBeltPointController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)forestBeltPointController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)forestBeltPointController).Port);
        }
    }
}