using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFireManage.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFireManage.Utility.Tests
{
    [TestClass()]
    public class CommonHelperTests
    {
        [TestMethod()]
        public void ObjectToDictTest()
        {
            
            Dictionary<string, object> dictionary;
            //测试用例1 object=null 
            dictionary = CommonHelper.ObjectToDict((object)null);

            //测试用例2
            object s0 = new object();
            dictionary = CommonHelper.ObjectToDict(s0);

        }

        [TestMethod()]
        public void GetDataSourceTest()
        {
            List<object> list;
            list = CommonHelper.GetDataSource<int>(0);
        }

        [TestMethod()]
        public void ObjectDescriptionToDictTest()
        {
            IDictionary<string, string> iDictionary;
            iDictionary = CommonHelper.ObjectDescriptionToDict<object>((object)null);
            object s0 = new object();
            iDictionary = CommonHelper.ObjectDescriptionToDict<object>(s0);
        }

        [TestMethod()]
        public void IsNumbericTest()
        {
            //测试用例1  
            bool b;
            b = CommonHelper.IsNumberic("\0");
            //测试用例2
            b = CommonHelper.IsNumberic("0\0");
            //测试用例3 
            b = CommonHelper.IsNumberic(":");
            //测试用例4
            b = CommonHelper.IsNumberic("-\0");
            //测试用例5
            b = CommonHelper.IsNumberic("00\0");
            //测试用例6
            b = CommonHelper.IsNumberic("00");
            //测试用例7
            b = CommonHelper.IsNumberic("-");
            //测试用例8
            b = CommonHelper.IsNumberic("");
            //测试用例9
            b = CommonHelper.IsNumberic("0");
            //测试用例10
            b = CommonHelper.IsNumberic("");
            //测试用例11
            b = CommonHelper.IsNumberic(null);
        }
    }
}