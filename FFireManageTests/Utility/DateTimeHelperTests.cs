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
    public class DateTimeHelperTests
    {
        [TestMethod()]
        public void GetTimeTest()
        {
            //测试用例1 
            DateTime dt;
            dt = DateTimeHelper.GetTime((string)null);
            //测试用例2
            dt = DateTimeHelper.GetTime("");
            //测试用例3
            dt = DateTimeHelper.GetTime("\0");
            //测试用例4
            dt = DateTimeHelper.GetTime("2");
            //测试用例5
            dt = DateTimeHelper.GetTime("-");
            //测试用例6
            dt = DateTimeHelper.GetTime("-2");

        }

        [TestMethod()]
        public void GetTimeTest1()
        {
            DateTime dt;
            //测试用例1
            dt = DateTimeHelper.GetTime(0L);
            //测试用例2
            dt = DateTimeHelper.GetTime(702590788466790624L);
            //测试用例3
            dt = DateTimeHelper.GetTime(576456663537616213L);

        }

        [TestMethod()]
        public void ConvertDateTimeIntTest()
        {
            long l;
            l = DateTimeHelper.ConvertDateTimeInt(default(DateTime));
        }
    }
}