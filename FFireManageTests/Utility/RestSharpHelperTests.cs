using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFireManage.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Pex.Framework.Generated;

namespace FFireManage.Utility.Tests
{
    [TestClass()]
    public class RestSharpHelperTests
    {
        [TestMethod()]        
        public void HttpGetTest()
        {
            string s;
            bool b = false;
            //测试用例1
            s = RestSharpHelper.HttpGet((string)null, (string)null, (Dictionary<string, object>)null,
                    out b, (Dictionary<string, object>)null,
                    (Dictionary<string, string>)null, (object)null);
            Assert.AreEqual<bool>(false, b);
            //测试用例2
            s = RestSharpHelper.HttpGet("", (string)null, (Dictionary<string, object>)null,
                    out b, (Dictionary<string, object>)null,
                    (Dictionary<string, string>)null, (object)null);
            Assert.AreEqual<bool>(false, b);           
            //测试用例3
            s = RestSharpHelper.HttpGet(":xn--%\0\0", (string)null, (Dictionary<string, object>)null,
                     out b, (Dictionary<string, object>)null,
                     (Dictionary<string, string>)null, (object)null);
            Assert.AreEqual<bool>(false, b);
            //测试用例4
            s = RestSharpHelper.HttpGet("/\\/", (string)null, (Dictionary<string, object>)null,
                   out b, (Dictionary<string, object>)null,
                   (Dictionary<string, string>)null, (object)null);
            Assert.AreEqual<bool>(false, b);
            //测试用例5
            s = RestSharpHelper.HttpGet("\0\0:", (string)null, (Dictionary<string, object>)null,
                    out b, (Dictionary<string, object>)null,
                    (Dictionary<string, string>)null, (object)null);
            Assert.AreEqual<bool>(false, b);
            //测试用例6
            s = RestSharpHelper.HttpGet("x0: ", (string)null, (Dictionary<string, object>)null,
                   out b, (Dictionary<string, object>)null,
                   (Dictionary<string, string>)null, (object)null);
            Assert.AreEqual<bool>(true, b);
            //测试用例7
            s = RestSharpHelper.HttpGet("xA:‏", (string)null, (Dictionary<string, object>)null,
                     out b, (Dictionary<string, object>)null,
                     (Dictionary<string, string>)null, (object)null);
            Assert.AreEqual<bool>(true, b);

        }

        [TestMethod()]       
        public void HttpPostTest()
        {
            string s;
            bool b = false;
            //测试用例1
            s = RestSharpHelper.HttpPost((string)null, (string)null, (Dictionary<string, object>)null,
                      out b, (Dictionary<string, object>)null,
                      (Dictionary<string, string>)null, (object)null);
            Assert.AreEqual<bool>(false, b);
            //测试用例2
            s = RestSharpHelper.HttpPost("", (string)null, (Dictionary<string, object>)null,
                      out b, (Dictionary<string, object>)null,
                      (Dictionary<string, string>)null, (object)null);
            Assert.AreEqual<bool>(false, b);
           
            //测试用例3
            s = RestSharpHelper.HttpPost(":xn--%\0\0", (string)null, (Dictionary<string, object>)null,
                      out b, (Dictionary<string, object>)null,
                      (Dictionary<string, string>)null, (object)null);
            Assert.AreEqual<bool>(false, b);
            //测试用例4
            s = RestSharpHelper.HttpPost("/\\/", (string)null, (Dictionary<string, object>)null,
                      out b, (Dictionary<string, object>)null,
                      (Dictionary<string, string>)null, (object)null);
            Assert.AreEqual<bool>(false, b);
            //测试用例5
            s = RestSharpHelper.HttpPost("\0\0:", (string)null, (Dictionary<string, object>)null,
                     out b, (Dictionary<string, object>)null,
                     (Dictionary<string, string>)null, (object)null);
            Assert.AreEqual<bool>(false, b);
            //测试用例6
            s = RestSharpHelper.HttpPost("x0: ", (string)null, (Dictionary<string, object>)null,
                      out b, (Dictionary<string, object>)null,
                      (Dictionary<string, string>)null, (object)null);
            Assert.AreEqual<bool>(true, b);
        }
    }
}