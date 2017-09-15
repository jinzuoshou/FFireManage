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
    public class Md5HelperTests
    {
        [TestMethod()]
        public void MD5EncryptTest()
        {
            string s;
            //测试用例1
            s = Md5Helper.MD5Encrypt((string)null);
            //测试用例2
            s = Md5Helper.MD5Encrypt("�");
            //测试用例3
            s = Md5Helper.MD5Encrypt("�ࠀ");

        }

        [TestMethod()]
        public void MD5EncryptTest1()
        {
            string s;
            //测试用例1
            s = Md5Helper.MD5Encrypt((string)null, 0);
            //测试用例2
            s = Md5Helper.MD5Encrypt((string)null, 16);
            //测试用例3
            s = Md5Helper.MD5Encrypt("�", 0);
            //测试用例4
            s = Md5Helper.MD5Encrypt("\0", 16);
            //测试用例5
            s = Md5Helper.MD5Encrypt("��", 0);
        }

        [TestMethod()]
        public void MD5EncryptTest2()
        {
            string s;
            //测试用例1
            s = Md5Helper.MD5Encrypt((string)null, (Encoding)null);
            //测试用例2
            s = Md5Helper.MD5Encrypt("\0", (Encoding)null);
            //测试用例3
            s = Md5Helper.MD5Encrypt("\0", Encoding.UTF32);
            //测试用例4
            s = Md5Helper.MD5Encrypt("�", Encoding.UTF8);
            //测试用例5
            s = Md5Helper.MD5Encrypt("\0", Encoding.UTF7);
        }
    }
}