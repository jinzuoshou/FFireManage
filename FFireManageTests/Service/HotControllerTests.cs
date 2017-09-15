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
    public class HotControllerTests
    {
        [TestMethod()]
        public void FeedbackTest()
        {
            HotController hotController;

            // 测试用例1
            hotController = new HotController();
            hotController.Feedback((Fire_Hot)null);

            //测试用例2
            hotController = new HotController();
            Fire_Hot s0 = new Fire_Hot();
            s0.OBJECTID = 0;
            s0.shape = (string)null;
            s0.no = (string)null;
            s0.satellite = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.pixels = 0;
            s0.smoke = 0;
            s0.continuous = 0;
            s0.landtype = (string)null;
            s0.county = (string)null;
            s0.type = 0;
            s0.receiptt = (string)null;
            s0.note = (string)null;
            s0.reporter = (string)null;
            s0.reporttime = (string)null;
            s0.opinion = (string)null;
            s0.duty = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.source = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.status = 0;
            s0.hotFeedback = (HotFeedback)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            hotController.Feedback( s0);

            // 测试用例3
            hotController = new HotController();
            s0 = new Fire_Hot();
            s0.OBJECTID = 0;
            s0.shape = (string)null;
            s0.no = (string)null;
            s0.satellite = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.pixels = 0;
            s0.smoke = 0;
            s0.continuous = 0;
            s0.landtype = (string)null;
            s0.county = (string)null;
            s0.type = 0;
            s0.receiptt = (string)null;
            s0.note = (string)null;
            s0.reporter = (string)null;
            s0.reporttime = (string)null;
            s0.opinion = (string)null;
            s0.duty = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.source = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.status = 0;
            HotFeedback s1 = new HotFeedback();
            s1.id = (string)null;
            s1.hot_id = (string)null;
            s1.state = 0;
            s1.description = (string)null;
            s1.initiator = 0;
            s1.initiator_name = (string)null;
            s1.examineUser = default(int?);
            s1.examineUser_name = (string)null;
            s1.createTime = (string)null;
            s1.examineTime = (string)null;
            s1.examineOption = (string)null;
            s1.MediaFileDict = (Dictionary<string, object>)null;
            s1.mediaFiles = (List<MediaFile>)null;
            s0.hotFeedback = s1;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            hotController.Feedback( s0);
            Assert.IsNotNull((object)hotController);
            Assert.IsNull((object)(hotController.FeedbackEvent));
            Assert.IsNull((object)(hotController.AuditEvent));
            Assert.IsNull((object)(hotController.GetDetailsEvent));
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)hotController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)hotController).Port);
        }

        [TestMethod()]
        public void AuditTest()
        {
            HotController hotController;

            // 测试用例1
            hotController = new HotController();
            hotController.Audit((Dictionary<string, object>)null);

            // 测试用例2
            Dictionary<string, object> dictionary;
            hotController = new HotController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            hotController.Audit(dictionary);
            Assert.IsNotNull((object)hotController);
            Assert.IsNull((object)(hotController.FeedbackEvent));
            Assert.IsNull((object)(hotController.AuditEvent));
            Assert.IsNull((object)(hotController.GetDetailsEvent));
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)hotController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)hotController).Port);
        }

        [TestMethod()]
        public void GetDetailsTest()
        {
            HotController hotController;

            // 测试用例1
            hotController = new HotController();
            hotController.GetDetails((Dictionary<string, object>)null);

            // 测试用例2
            Dictionary<string, object> dictionary;
            hotController = new HotController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            hotController.GetDetails(dictionary);
            Assert.IsNotNull((object)hotController);
            Assert.IsNull((object)(hotController.FeedbackEvent));
            Assert.IsNull((object)(hotController.AuditEvent));
            Assert.IsNull((object)(hotController.GetDetailsEvent));
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)hotController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)hotController).Port);
        }

        [TestMethod()]
        public void AddTest()
        {
            HotController hotController;

            // 测试用例1
            hotController = new HotController();
            hotController.Add((Fire_Hot)null);
            Assert.IsNotNull((object)hotController);
            Assert.IsNull((object)(hotController.FeedbackEvent));
            Assert.IsNull((object)(hotController.AuditEvent));
            Assert.IsNull((object)(hotController.GetDetailsEvent));
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)hotController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)hotController).Port);

            // 测试用例2
            hotController = new HotController();
            Fire_Hot s0 = new Fire_Hot();
            s0.OBJECTID = 0;
            s0.shape = (string)null;
            s0.no = (string)null;
            s0.satellite = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.pixels = 0;
            s0.smoke = 0;
            s0.continuous = 0;
            s0.landtype = (string)null;
            s0.county = (string)null;
            s0.type = 0;
            s0.receiptt = (string)null;
            s0.note = (string)null;
            s0.reporter = (string)null;
            s0.reporttime = (string)null;
            s0.opinion = (string)null;
            s0.duty = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.source = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.status = 0;
            s0.hotFeedback = (HotFeedback)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            hotController.Add(s0);
            Assert.IsNotNull((object)hotController);
            Assert.IsNull((object)(hotController.FeedbackEvent));
            Assert.IsNull((object)(hotController.AuditEvent));
            Assert.IsNull((object)(hotController.GetDetailsEvent));
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)hotController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)hotController).Port);
        }

        [TestMethod()]
        public void GetTest()
        {
            HotController hotController;

            // 测试用例1
            hotController = new HotController();
            hotController.Get((Dictionary<string, object>)null);
            Assert.IsNotNull((object)hotController);
            Assert.IsNull((object)(hotController.FeedbackEvent));
            Assert.IsNull((object)(hotController.AuditEvent));
            Assert.IsNull((object)(hotController.GetDetailsEvent));
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)hotController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)hotController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            hotController = new HotController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            hotController.Get(dictionary);
            Assert.IsNotNull((object)hotController);
            Assert.IsNull((object)(hotController.FeedbackEvent));
            Assert.IsNull((object)(hotController.AuditEvent));
            Assert.IsNull((object)(hotController.GetDetailsEvent));
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)hotController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)hotController).Port);
        }

        [TestMethod()]
        public void EditTest()
        {
            HotController hotController;
            
            // 测试用例1
            hotController = new HotController();
            hotController.Edit( (Fire_Hot)null);
            Assert.IsNotNull((object)hotController);
            Assert.IsNull((object)(hotController.FeedbackEvent));
            Assert.IsNull((object)(hotController.AuditEvent));
            Assert.IsNull((object)(hotController.GetDetailsEvent));
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)hotController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)hotController).Port);

            // 测试用例2
            hotController = new HotController();
            Fire_Hot s0 = new Fire_Hot();
            s0.OBJECTID = 0;
            s0.shape = (string)null;
            s0.no = (string)null;
            s0.satellite = (string)null;
            s0.longitude = 0;
            s0.latitude = 0;
            s0.pixels = 0;
            s0.smoke = 0;
            s0.continuous = 0;
            s0.landtype = (string)null;
            s0.county = (string)null;
            s0.type = 0;
            s0.receiptt = (string)null;
            s0.note = (string)null;
            s0.reporter = (string)null;
            s0.reporttime = (string)null;
            s0.opinion = (string)null;
            s0.duty = (string)null;
            s0.cre_time = (string)null;
            s0.cre_pers = (string)null;
            s0.mod_time = (string)null;
            s0.mod_pers = (string)null;
            s0.source = (string)null;
            s0.id = (string)null;
            s0.pac = (string)null;
            s0.status = 0;
            s0.hotFeedback = (HotFeedback)null;
            s0.mediaByteDict = (Dictionary<string, object>)null;
            s0.mediaFiles = (List<MediaFile>)null;
            hotController.Edit(s0);
            Assert.IsNotNull((object)hotController);
            Assert.IsNull((object)(hotController.FeedbackEvent));
            Assert.IsNull((object)(hotController.AuditEvent));
            Assert.IsNull((object)(hotController.GetDetailsEvent));
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)hotController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)hotController).Port);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            HotController hotController;

            // 测试用例1
            hotController = new HotController();
            hotController.Delete( (Dictionary<string, object>)null);
            Assert.IsNotNull((object)hotController);
            Assert.IsNull((object)(hotController.FeedbackEvent));
            Assert.IsNull((object)(hotController.AuditEvent));
            Assert.IsNull((object)(hotController.GetDetailsEvent));
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)hotController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)hotController).Port);

            // 测试用例2
            Dictionary<string, object> dictionary;
            hotController = new HotController();
            dictionary = new Dictionary<string, object>(0);
            dictionary[""] = (object)null;
            hotController.Delete(dictionary);
            Assert.IsNotNull((object)hotController);
            Assert.IsNull((object)(hotController.FeedbackEvent));
            Assert.IsNull((object)(hotController.AuditEvent));
            Assert.IsNull((object)(hotController.GetDetailsEvent));
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)hotController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)hotController).Port);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            HotController hotController;
            hotController = new HotController();
            hotController.Delete( (string)null);
            Assert.IsNotNull((object)hotController);
            Assert.IsNull((object)(hotController.FeedbackEvent));
            Assert.IsNull((object)(hotController.AuditEvent));
            Assert.IsNull((object)(hotController.GetDetailsEvent));
            Assert.AreEqual<string>("127.0.0.1", ((BaseService)hotController).Server);
            Assert.AreEqual<int>(8080, ((BaseService)hotController).Port);
        }
    }
}