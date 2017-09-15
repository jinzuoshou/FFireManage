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
    public class SoftRegisterTests
    {
        [TestMethod()]
        public void GetDiskVolumeSerialNumberTest()
        {
            string s;
            s = SoftRegister.GetDiskVolumeSerialNumber();
        }

        [TestMethod()]
        public void GetCpuSerialNumberTest()
        {
            string s;
            s = SoftRegister.GetCpuSerialNumber();
        }

        [TestMethod()]
        public void GetMacAddressTest()
        {
            string s;
            s = SoftRegister.GetMacAddress();
        }
    }
}