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
    public class SatelliteGroundStationControlerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            SatelliteGroundStationControler satelliteGroundStationControler;

            // 测试用例1
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            satelliteGroundStationControler.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            satelliteGroundStationControler.Get(dictionary);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);

        }

        [TestMethod()]
        public void AddTest()
        {
            SatelliteGroundStationControler satelliteGroundStationControler;

            // 测试用例1
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            satelliteGroundStationControler.Add((Fire_SatelliteGroundStation)null);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);

            // 测试用例2
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            Fire_SatelliteGroundStation s0 = new Fire_SatelliteGroundStation();
            s0.objectid = 0;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.waveband = (string)null;
            s0.antdiameter = 0;
            s0.ip = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.shape = (string)null;
            s0.status = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            satelliteGroundStationControler.Add(s0);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);

            // 测试用例3
            Dictionary<string, object> dictionary;
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            dictionary = new Dictionary<string, object>();
            dictionary[""] = (object)null;
            s0 = new Fire_SatelliteGroundStation();
            s0.objectid = 0;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.waveband = (string)null;
            s0.antdiameter = 0;
            s0.ip = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.shape = (string)null;
            s0.status = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = dictionary;
            s0.mediaFiles = (List<MediaFile>)null;
            satelliteGroundStationControler.Add(s0);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            SatelliteGroundStationControler satelliteGroundStationControler;

            // 测试用例1
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            satelliteGroundStationControler.Edit((Fire_SatelliteGroundStation)null);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);

            // 测试用例2
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            Fire_SatelliteGroundStation s0 = new Fire_SatelliteGroundStation();
            s0.objectid = 0;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.waveband = (string)null;
            s0.antdiameter = 0;
            s0.ip = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.shape = (string)null;
            s0.status = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            satelliteGroundStationControler.Edit(s0);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            SatelliteGroundStationControler satelliteGroundStationControler;

            // 测试用例1
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            satelliteGroundStationControler.Delete((Dictionary<string, object>)null);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            satelliteGroundStationControler.Delete(dictionary);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);
        }

        [TestMethod()]
        public void AddMediaTest()
        {
            SatelliteGroundStationControler satelliteGroundStationControler;

            // 测试用例1
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            satelliteGroundStationControler.AddMedia(
                          (Dictionary<string, object>)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            satelliteGroundStationControler.AddMedia(
                          dictionary, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest()
        {
            SatelliteGroundStationControler satelliteGroundStationControler;

            // 测试用例1
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            satelliteGroundStationControler.DeleteMedia
                ( (Dictionary<string, object>)null);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            satelliteGroundStationControler.DeleteMedia(dictionary);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            SatelliteGroundStationControler satelliteGroundStationControler;
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            satelliteGroundStationControler.Delete((string)null);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);
        }

        [TestMethod()]
        public void AddMediaTest1()
        {
            SatelliteGroundStationControler satelliteGroundStationControler;
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            satelliteGroundStationControler.AddMedia(
                          (string)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest1()
        {
            SatelliteGroundStationControler satelliteGroundStationControler;
            satelliteGroundStationControler = new SatelliteGroundStationControler();
            satelliteGroundStationControler.DeleteMedia( (string)null);
            Assert.IsNotNull((object)satelliteGroundStationControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)satelliteGroundStationControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)satelliteGroundStationControler).Port);
        }
    }
}