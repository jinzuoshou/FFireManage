using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFireManage.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFireManage.Utility.Tests
{
    [TestClass()]
    public class SmartFormTests
    {
        [TestMethod()]
        public void GetEntityTest()
        {
            object o;
            //测试用例1 
            o = SmartForm.GetEntity<object>((Control.ControlCollection)null, (object)null);
            //测试用例2 
            object s0 = new object();
            o = SmartForm.GetEntity<object>((Control.ControlCollection)null, s0);
            //测试用例3
            Control.ControlCollection controlCollection;
            controlCollection = new Control.ControlCollection((Control)null);
            o = SmartForm.GetEntity<object>(controlCollection, (object)null);

        }

        [TestMethod()]
        public void FillTest()
        {
            // 测试用例1
            SmartForm.Fill((Control.ControlCollection)null, (object)null);
            // 测试用例2
            object s0 = new object();
            SmartForm.Fill((Control.ControlCollection)null, s0);
            // 测试用例3
            Control.ControlCollection controlCollection;
            controlCollection = new Control.ControlCollection((Control)null);
            SmartForm.Fill(controlCollection, s0);

        }

        [TestMethod()]
        public void ValidatorTest()
        {
            bool b;
            // 测试用例1
            b = SmartForm.Validator
                    ((Control.ControlCollection)null, (IDictionary<string, string>)null);
            // 测试用例2
            Control.ControlCollection controlCollection;
            controlCollection = new Control.ControlCollection((Control)null);
            b = SmartForm.Validator(controlCollection, (IDictionary<string, string>)null);
        }

        [TestMethod()]
        public void SetControlsEnabledTest()
        {
            // 测试用例1 
            SmartForm.SetControlsEnabled((Control.ControlCollection)null, (List<Control>)null);
            // 测试用例2
            Control.ControlCollection controlCollection;
            controlCollection = new Control.ControlCollection((Control)null);
            SmartForm.SetControlsEnabled(controlCollection, (List<Control>)null);

        }

        [TestMethod()]
        public void IsNumericTest()
        {
            bool b;
            // 测试用例1
            b = SmartForm.IsNumeric((string)null);
            // 测试用例2
            b = SmartForm.IsNumeric("");
        }
    

        [TestMethod()]
        public void IsIntTest()
        {
            bool b;
            // 测试用例1
            b = SmartForm.IsInt((string)null);
            // 测试用例2
            b = SmartForm.IsInt("");

        }
    }
}