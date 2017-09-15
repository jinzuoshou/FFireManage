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
    public class FireHBrigadeControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            FireHBrigadeController fireHBrigadeController;
            // 用例测试1
            fireHBrigadeController = new FireHBrigadeController();
            fireHBrigadeController.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);
            // 用例测试2
            Dictionary<string, object> dictionary;
            fireHBrigadeController = new FireHBrigadeController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireHBrigadeController.Get(dictionary);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);
        }

        [TestMethod()]
        public void AddTest()
        {
            FireHBrigadeController fireHBrigadeController;
            // 测试用例1
            fireHBrigadeController = new FireHBrigadeController();
            fireHBrigadeController.Add((Fire_HBrigade)null);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);

            //测试用例2
            fireHBrigadeController = new FireHBrigadeController();
            Fire_HBrigade s0 = new Fire_HBrigade();
            s0.OBJECTID = 0;
            s0.shape = (string)null;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.phone = (string)null;
            s0.manager = (string)null;
            s0.latitude = 0;
            s0.longitude = 0;
            s0.fireengine = default(int?);
            s0.t_car = default(int?);
            s0.n2n3tool = default(int?);
            s0.w_equipm = default(int?);
            s0.pump = default(int?);
            s0.fire_bomb = default(int?);
            s0.wsinjector = default(int?);
            s0.chainsaw = default(int?);
            s0.b_cutter = default(int?);
            s0.w_cannons = default(int?);
            s0.interphone = default(int?);
            s0.zj_radio = default(int?);
            s0.sc_radio = default(int?);
            s0.jd_radio = default(int?);
            s0.cz_radio = default(int?);
            s0.gps = default(int?);
            s0.machetes = default(int?);
            s0.r_clothing = default(int?);
            s0.flashlight = default(int?);
            s0.helmet = default(int?);
            s0.gloves = default(int?);
            s0.fire_shoes = default(int?);
            s0.o_equip = default(int?);
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.dynamotor = default(int?);
            s0.anemometer = default(int?);
            s0.communication_v = default(int?);
            s0.ax = default(int?);
            s0.sleeping_bag = default(int?);
            s0.high_pressure_fex = default(int?);
            s0.fire_shovel = default(int?);
            s0.lighter = default(int?);
            s0.motorcycle = default(int?);
            s0.fire_detectors = default(int?);
            s0.fsf_extinguishers = default(int?);
            s0.base_value = default(int?);
            s0.fire_extinguisher = default(int?);
            s0.status = (string)null;
            s0.tent = default(int?);
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.type = (string)null;
            s0.barracks_area = default(double?);
            s0.base_type = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.nav_handheld = default(short?);
            s0.nav_vehicle = default(short?);
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            fireHBrigadeController.Add(s0);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);

            //测试用例3
            Dictionary<string, object> dictionary;
            fireHBrigadeController = new FireHBrigadeController();
            dictionary = new Dictionary<string, object>();
            dictionary[""] = (object)null;
            s0 = new Fire_HBrigade();
            s0.OBJECTID = 0;
            s0.shape = (string)null;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.phone = (string)null;
            s0.manager = (string)null;
            s0.latitude = 0;
            s0.longitude = 0;
            s0.fireengine = default(int?);
            s0.t_car = default(int?);
            s0.n2n3tool = default(int?);
            s0.w_equipm = default(int?);
            s0.pump = default(int?);
            s0.fire_bomb = default(int?);
            s0.wsinjector = default(int?);
            s0.chainsaw = default(int?);
            s0.b_cutter = default(int?);
            s0.w_cannons = default(int?);
            s0.interphone = default(int?);
            s0.zj_radio = default(int?);
            s0.sc_radio = default(int?);
            s0.jd_radio = default(int?);
            s0.cz_radio = default(int?);
            s0.gps = default(int?);
            s0.machetes = default(int?);
            s0.r_clothing = default(int?);
            s0.flashlight = default(int?);
            s0.helmet = default(int?);
            s0.gloves = default(int?);
            s0.fire_shoes = default(int?);
            s0.o_equip = default(int?);
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.dynamotor = default(int?);
            s0.anemometer = default(int?);
            s0.communication_v = default(int?);
            s0.ax = default(int?);
            s0.sleeping_bag = default(int?);
            s0.high_pressure_fex = default(int?);
            s0.fire_shovel = default(int?);
            s0.lighter = default(int?);
            s0.motorcycle = default(int?);
            s0.fire_detectors = default(int?);
            s0.fsf_extinguishers = default(int?);
            s0.base_value = default(int?);
            s0.fire_extinguisher = default(int?);
            s0.status = (string)null;
            s0.tent = default(int?);
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.type = (string)null;
            s0.barracks_area = default(double?);
            s0.base_type = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.nav_handheld = default(short?);
            s0.nav_vehicle = default(short?);
            s0.pac = (string)null;
            s0.mediaByteDict = dictionary;
            s0.mediaFiles = (List<MediaFile>)null;
            fireHBrigadeController.Add(s0);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            FireHBrigadeController fireHBrigadeController;
            //测试用例1
            fireHBrigadeController = new FireHBrigadeController();
            fireHBrigadeController.Edit((Fire_HBrigade)null);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);
            //测试用例2
            fireHBrigadeController = new FireHBrigadeController();
            Fire_HBrigade s0 = new Fire_HBrigade();
            s0.OBJECTID = 0;
            s0.shape = (string)null;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.phone = (string)null;
            s0.manager = (string)null;
            s0.latitude = 0;
            s0.longitude = 0;
            s0.fireengine = default(int?);
            s0.t_car = default(int?);
            s0.n2n3tool = default(int?);
            s0.w_equipm = default(int?);
            s0.pump = default(int?);
            s0.fire_bomb = default(int?);
            s0.wsinjector = default(int?);
            s0.chainsaw = default(int?);
            s0.b_cutter = default(int?);
            s0.w_cannons = default(int?);
            s0.interphone = default(int?);
            s0.zj_radio = default(int?);
            s0.sc_radio = default(int?);
            s0.jd_radio = default(int?);
            s0.cz_radio = default(int?);
            s0.gps = default(int?);
            s0.machetes = default(int?);
            s0.r_clothing = default(int?);
            s0.flashlight = default(int?);
            s0.helmet = default(int?);
            s0.gloves = default(int?);
            s0.fire_shoes = default(int?);
            s0.o_equip = default(int?);
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.dynamotor = default(int?);
            s0.anemometer = default(int?);
            s0.communication_v = default(int?);
            s0.ax = default(int?);
            s0.sleeping_bag = default(int?);
            s0.high_pressure_fex = default(int?);
            s0.fire_shovel = default(int?);
            s0.lighter = default(int?);
            s0.motorcycle = default(int?);
            s0.fire_detectors = default(int?);
            s0.fsf_extinguishers = default(int?);
            s0.base_value = default(int?);
            s0.fire_extinguisher = default(int?);
            s0.status = (string)null;
            s0.tent = default(int?);
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.type = (string)null;
            s0.barracks_area = default(double?);
            s0.base_type = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.nav_handheld = default(short?);
            s0.nav_vehicle = default(short?);
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            fireHBrigadeController.Edit(s0);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            FireHBrigadeController fireHBrigadeController;
            //用例测试1
            fireHBrigadeController = new FireHBrigadeController();
            fireHBrigadeController.Delete((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);
            // 用力测试2
            Dictionary<string, object> dictionary;
            fireHBrigadeController = new FireHBrigadeController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireHBrigadeController.Delete(dictionary);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);
        }

        [TestMethod()]
        public void AddMediaTest()
        {
            FireHBrigadeController fireHBrigadeController;
            //测试用例1
            fireHBrigadeController = new FireHBrigadeController();
            fireHBrigadeController.AddMedia(
                          (Dictionary<string, object>)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);
            //测试用例2
            Dictionary<string, object> dictionary;
            fireHBrigadeController = new FireHBrigadeController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireHBrigadeController.AddMedia(dictionary, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest()
        {
            FireHBrigadeController fireHBrigadeController;
            //测试用例1
            fireHBrigadeController = new FireHBrigadeController();
            fireHBrigadeController.DeleteMedia((Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);
            //测试用例2
            Dictionary<string, object> dictionary;
            fireHBrigadeController = new FireHBrigadeController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            fireHBrigadeController.DeleteMedia(dictionary);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);
        }
    

        [TestMethod()]
        public void DeleteTest1()
        {
            FireHBrigadeController fireHBrigadeController;
            fireHBrigadeController = new FireHBrigadeController();
            fireHBrigadeController.Delete((string)null);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);
        }

        [TestMethod()]
        public void AddMediaTest1()
        {
            FireHBrigadeController fireHBrigadeController;
            fireHBrigadeController = new FireHBrigadeController();
            fireHBrigadeController.AddMedia
                ( (string)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest1()
        {
            FireHBrigadeController fireHBrigadeController;
            fireHBrigadeController = new FireHBrigadeController();
            fireHBrigadeController.DeleteMedia( (string)null);
            Assert.IsNotNull((object)fireHBrigadeController);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)fireHBrigadeController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)fireHBrigadeController).Port);
        }
    }
}