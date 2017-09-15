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
    public class ObservatoryControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            ObservatoryController observatoryController;

            // 测试用例1
            observatoryController = new ObservatoryController();
            observatoryController.Get( (Dictionary<string, object>)null);
            Assert.IsNotNull((object)observatoryController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)observatoryController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)observatoryController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            observatoryController = new ObservatoryController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            observatoryController.Get(dictionary);
            Assert.IsNotNull((object)observatoryController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)observatoryController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)observatoryController).Port);
        }

        [TestMethod()]
        public void AddTest()
        {
            ObservatoryController observatoryController;

            // 测试用例1
            observatoryController = new ObservatoryController();
            observatoryController.Add( (Fire_Observatory)null);
            Assert.IsNotNull((object)observatoryController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)observatoryController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)observatoryController).Port);

            // 测试用例2
            observatoryController = new ObservatoryController();
            Fire_Observatory s0 = new Fire_Observatory();
            s0.OBJECTID = 0;
            s0.SHAPE = (string)null;
            s0.name = (string)null;
            s0.type = (string)null;
            s0.status = 0;
            s0.telescope = 0;
            s0.interphone = 0;
            s0.compass_instrument = 0;
            s0.telephone = 0;
            s0.radio = 0;
            s0.look_area = 0;
            s0.look_forest_area = 0;
            s0.look_coverage = 0;
            s0.c_area = 0;
            s0.elevation = 0;
            s0.build_year = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.structure = (string)null;
            s0.video_surveillance = (string)null;
            s0.build_unit = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.address = (string)null;
            s0.id = (string)null;
            s0.management_unit = (string)null;
            s0.pac = (string)null;
            s0.city_name = (string)null;
            s0.county_name = (string)null;
            s0.base_type = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            observatoryController.Add(s0);
            Assert.IsNotNull((object)observatoryController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)observatoryController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)observatoryController).Port);

        }

        [TestMethod()]
        public void EditTest()
        {
            ObservatoryController observatoryController;

            // 测试用例1
            observatoryController = new ObservatoryController();
            observatoryController.Edit( (Fire_Observatory)null);
            Assert.IsNotNull((object)observatoryController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)observatoryController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)observatoryController).Port);

            // 测试用例2
            observatoryController = new ObservatoryController();
            Fire_Observatory s0 = new Fire_Observatory();
            s0.OBJECTID = 0;
            s0.SHAPE = (string)null;
            s0.name = (string)null;
            s0.type = (string)null;
            s0.status = 0;
            s0.telescope = 0;
            s0.interphone = 0;
            s0.compass_instrument = 0;
            s0.telephone = 0;
            s0.radio = 0;
            s0.look_area = 0;
            s0.look_forest_area = 0;
            s0.look_coverage = 0;
            s0.c_area = 0;
            s0.elevation = 0;
            s0.build_year = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.structure = (string)null;
            s0.video_surveillance = (string)null;
            s0.build_unit = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.address = (string)null;
            s0.id = (string)null;
            s0.management_unit = (string)null;
            s0.pac = (string)null;
            s0.city_name = (string)null;
            s0.county_name = (string)null;
            s0.base_type = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            observatoryController.Edit(s0);
            Assert.IsNotNull((object)observatoryController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)observatoryController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)observatoryController).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            ObservatoryController observatoryController;

            // 测试用例1
            observatoryController = new ObservatoryController();
            observatoryController.Delete( (Dictionary<string, object>)null);
            Assert.IsNotNull((object)observatoryController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)observatoryController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)observatoryController).Port);

            //测试用例2
            Dictionary<string, object> dictionary;
            observatoryController = new ObservatoryController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            observatoryController.Delete(dictionary);
            Assert.IsNotNull((object)observatoryController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)observatoryController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)observatoryController).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            ObservatoryController observatoryController;
            observatoryController = new ObservatoryController();
            observatoryController.Delete( (string)null);
            Assert.IsNotNull((object)observatoryController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)observatoryController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)observatoryController).Port);
        }
    }
}