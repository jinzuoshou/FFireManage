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
    public class PlanewaterpointControlerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            PlanewaterPointControler planewaterpointControler;

            // 用例测试1
            planewaterpointControler = new PlanewaterPointControler();
            planewaterpointControler.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)planewaterpointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)planewaterpointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)planewaterpointControler).Port);

            // 用例测试2
            Dictionary<string, object> dictionary;
            planewaterpointControler = new PlanewaterPointControler();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            planewaterpointControler.Get(dictionary);
            Assert.IsNotNull((object)planewaterpointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)planewaterpointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)planewaterpointControler).Port);
        }

        [TestMethod()]
        public void AddTest()
        {
            PlanewaterPointControler planewaterpointControler;

            // 用例测试1
            planewaterpointControler = new PlanewaterPointControler();
            planewaterpointControler.Add((Fire_Planewaterpoint)null);
            Assert.IsNotNull((object)planewaterpointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)planewaterpointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)planewaterpointControler).Port);

            // 用例测试2
            planewaterpointControler = new PlanewaterPointControler();
            Fire_Planewaterpoint s0 = new Fire_Planewaterpoint();
            s0.objectid = 0;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.shape = (string)null;
            s0.type = (string)null;
            s0.status = (string)null;
            s0.storage_area = 0;
            s0.storage_capacity = 0;
            s0.maximum_depth = 0;
            s0.management_unit = (string)null;
            s0.traffic_condition = (string)null;
            s0.is_cableway = (string)null;
            s0.is_cage_fish = (string)null;
            s0.is_take_water = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.number = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            planewaterpointControler.Add( s0);
            Assert.IsNotNull((object)planewaterpointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)planewaterpointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)planewaterpointControler).Port);

            // 用例测试3

            Dictionary<string, object> dictionary;
            planewaterpointControler = new PlanewaterPointControler();
            dictionary = new Dictionary<string, object>();
            dictionary[""] = (object)null;
             s0 = new Fire_Planewaterpoint();
            s0.objectid = 0;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.shape = (string)null;
            s0.type = (string)null;
            s0.status = (string)null;
            s0.storage_area = 0;
            s0.storage_capacity = 0;
            s0.maximum_depth = 0;
            s0.management_unit = (string)null;
            s0.traffic_condition = (string)null;
            s0.is_cableway = (string)null;
            s0.is_cage_fish = (string)null;
            s0.is_take_water = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.number = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = dictionary;
            s0.mediaFiles = (List<MediaFile>)null;
            planewaterpointControler.Add( s0);
            Assert.IsNotNull((object)planewaterpointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)planewaterpointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)planewaterpointControler).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            PlanewaterPointControler planewaterpointControler;

            // 测试用例1
            planewaterpointControler = new PlanewaterPointControler();
            planewaterpointControler.Edit((Fire_Planewaterpoint)null);
            Assert.IsNotNull((object)planewaterpointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)planewaterpointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)planewaterpointControler).Port);

            //测试用例2
            planewaterpointControler = new PlanewaterPointControler();
            Fire_Planewaterpoint s0 = new Fire_Planewaterpoint();
            s0.objectid = 0;
            s0.name = (string)null;
            s0.address = (string)null;
            s0.manager = (string)null;
            s0.phone = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.shape = (string)null;
            s0.type = (string)null;
            s0.status = (string)null;
            s0.storage_area = 0;
            s0.storage_capacity = 0;
            s0.maximum_depth = 0;
            s0.management_unit = (string)null;
            s0.traffic_condition = (string)null;
            s0.is_cableway = (string)null;
            s0.is_cage_fish = (string)null;
            s0.is_take_water = (string)null;
            s0.picture1 = (string)null;
            s0.picture2 = (string)null;
            s0.video = (string)null;
            s0.note = (string)null;
            s0.id = (string)null;
            s0.number = (string)null;
            s0.pac = (string)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            planewaterpointControler.Edit(s0);
            Assert.IsNotNull((object)planewaterpointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)planewaterpointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)planewaterpointControler).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            PlanewaterPointControler planewaterpointControler;

            // 测试用例1
            planewaterpointControler = new PlanewaterPointControler();
            planewaterpointControler.Delete((Dictionary<string, object>)null);
            Assert.IsNotNull((object)planewaterpointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)planewaterpointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)planewaterpointControler).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            planewaterpointControler = new PlanewaterPointControler();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            planewaterpointControler.Delete(dictionary);
            Assert.IsNotNull((object)planewaterpointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)planewaterpointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)planewaterpointControler).Port);
        }

        [TestMethod()]
        public void AddMediaTest()
        {
            PlanewaterPointControler PlanewaterPointControler;

            // 测试用例1
            PlanewaterPointControler = new PlanewaterPointControler();
            PlanewaterPointControler.AddMedia(
                          (Dictionary<string, object>)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)PlanewaterPointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)PlanewaterPointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)PlanewaterPointControler).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            PlanewaterPointControler = new PlanewaterPointControler();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            PlanewaterPointControler.AddMedia
                ( dictionary, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)PlanewaterPointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)PlanewaterPointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)PlanewaterPointControler).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest()
        {
            PlanewaterPointControler planewaterpointControler;

            //测试用例1
            planewaterpointControler = new PlanewaterPointControler();
            planewaterpointControler.DeleteMedia((Dictionary<string, object>)null);
            Assert.IsNotNull((object)planewaterpointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)planewaterpointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)planewaterpointControler).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            planewaterpointControler = new PlanewaterPointControler();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            planewaterpointControler.DeleteMedia(dictionary);
            Assert.IsNotNull((object)planewaterpointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)planewaterpointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)planewaterpointControler).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            PlanewaterPointControler planewaterpointControler;
            planewaterpointControler = new PlanewaterPointControler();
            planewaterpointControler.Delete((string)null);
            Assert.IsNotNull((object)planewaterpointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)planewaterpointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)planewaterpointControler).Port);
        }

        [TestMethod()]
        public void AddMediaTest1()
        {
            PlanewaterPointControler planewaterpointControler;
            planewaterpointControler = new PlanewaterPointControler();
            planewaterpointControler.AddMedia
                ((string)null, (Dictionary<string, object>)null);
            Assert.IsNotNull((object)planewaterpointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)planewaterpointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)planewaterpointControler).Port);
        }

        [TestMethod()]
        public void DeleteMediaTest1()
        {
            PlanewaterPointControler planewaterpointControler;
            planewaterpointControler = new PlanewaterPointControler();
            planewaterpointControler.DeleteMedia( (string)null);
            Assert.IsNotNull((object)planewaterpointControler);
            Assert.AreEqual<string>
                ("127.0.0.1", ((BaseService)planewaterpointControler).Server);
            Assert.AreEqual<int>(8080, ((BaseService)planewaterpointControler).Port);
        }
    }
}