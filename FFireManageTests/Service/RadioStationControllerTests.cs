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
    public class RadioStationControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            RadioStationController radioStationController;

            // 用例测试1
            radioStationController = new RadioStationController();
            radioStationController.Get( (Dictionary<string, object>)null);
            Assert.IsNotNull((object)radioStationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)radioStationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)radioStationController).Port);

            // 用例测试2
            Dictionary<string, object> dictionary;
            radioStationController = new RadioStationController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            radioStationController.Get(dictionary);
            Assert.IsNotNull((object)radioStationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)radioStationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)radioStationController).Port);
        }

        [TestMethod()]
        public void AddTest()
        {
            RadioStationController radioStationController;
            
            // 测试用例1
            radioStationController = new RadioStationController();
            radioStationController.Add( (Fire_RadioStation)null);
            Assert.IsNotNull((object)radioStationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)radioStationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)radioStationController).Port);

            // 测试用例2
            radioStationController = new RadioStationController();
            Fire_RadioStation s0 = new Fire_RadioStation();
            s0.objectid = 0;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.units = (string)null;
            s0.num_radio = (string)null;
            s0.radioname = (string)null;
            s0.type = (string)null;
            s0.coding = (string)null;
            s0.r_frequenc = (string)null;
            s0.l_frequenc = (string)null;
            s0.power = (string)null;
            s0.height = default(double?);
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.shape = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.status = 0;
            s0.d_type = (string)null;
            s0.note = (string)null;
            s0.build_year = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.elevation = default(double?);
            s0.county = (string)null;
            s0.city = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            radioStationController.Add(s0);
            Assert.IsNotNull((object)radioStationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)radioStationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)radioStationController).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            RadioStationController radioStationController;

            // 测试用例1
            radioStationController = new RadioStationController();
            radioStationController.Edit( (Fire_RadioStation)null);
            Assert.IsNotNull((object)radioStationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)radioStationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)radioStationController).Port);

            //测试用例2
            radioStationController = new RadioStationController();
            Fire_RadioStation s0 = new Fire_RadioStation();
            s0.objectid = 0;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.units = (string)null;
            s0.num_radio = (string)null;
            s0.radioname = (string)null;
            s0.type = (string)null;
            s0.coding = (string)null;
            s0.r_frequenc = (string)null;
            s0.l_frequenc = (string)null;
            s0.power = (string)null;
            s0.height = default(double?);
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.shape = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.status = 0;
            s0.d_type = (string)null;
            s0.note = (string)null;
            s0.build_year = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.elevation = default(double?);
            s0.county = (string)null;
            s0.city = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            radioStationController.Edit(s0);
            Assert.IsNotNull((object)radioStationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)radioStationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)radioStationController).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            RadioStationController radioStationController;

            // 测试用例1
            radioStationController = new RadioStationController();
            radioStationController.Delete( (Dictionary<string, object>)null);
            Assert.IsNotNull((object)radioStationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)radioStationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)radioStationController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            radioStationController = new RadioStationController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            radioStationController.Delete(dictionary);
            Assert.IsNotNull((object)radioStationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)radioStationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)radioStationController).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            RadioStationController radioStationController;
            radioStationController = new RadioStationController();
            radioStationController.Delete((string)null);
            Assert.IsNotNull((object)radioStationController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)radioStationController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)radioStationController).Port);
        }
    }
}