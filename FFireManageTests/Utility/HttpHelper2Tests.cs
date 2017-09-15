using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFireManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage.Tests
{
    [TestClass()]
    public class HttpHelper2Tests
    {
        [TestMethod()]
        public void HttpGetTest()
        {
            string s;
            bool b = false;
            //测试用例1
            s = HttpHelper2.HttpGet((string)null, (string)null, out b);
            //测试用例2
            s = HttpHelper2.HttpGet((string)null, "", out b);
            //测试用例3
            s = HttpHelper2.HttpGet((string)null, "Ā", out b);
            //测试用例4
            s = HttpHelper2.HttpGet("", (string)null, out b);
            //测试用例5
            s = HttpHelper2.HttpGet("", "", out b);
            //测试用例6
            s = HttpHelper2.HttpGet((string)null, ":", out b);
            //测试用例7
            s = HttpHelper2.HttpGet((string)null, "%", out b);
            //测试用例8
            s = HttpHelper2.HttpGet(":\0\0", (string)null, out b);
            //测试用例9
            s = HttpHelper2.HttpGet((string)null, "x", out b);
            //测试用例10
            s = HttpHelper2.HttpGet(" ", (string)null, out b);
            //测试用例11
            s = HttpHelper2.HttpGet("P|\0", (string)null, out b);
            //测试用例12
            s = HttpHelper2.HttpGet("P|\0", (string)null, out b);
            //测试用例13
            s = HttpHelper2.HttpGet("/\\\\", (string)null, out b);
            //测试用例14
            s = HttpHelper2.HttpGet("%\0\0\0\0\0", (string)null, out b);
            //测试用例15
            s = HttpHelper2.HttpGet("%%\0\0\0\0", (string)null, out b);
            //测试用例16
            s = HttpHelper2.HttpGet("%A\0\0\0\0", (string)null, out b);
            //测试用例17
            s = HttpHelper2.HttpGet("%AD\0\0\0", (string)null, out b);
            //测试用例18
            s = HttpHelper2.HttpGet("%0D\0\0\0", (string)null, out b);
            //测试用例19
            s = HttpHelper2.HttpGet("%2d\0\0\0", (string)null, out b);
            //测试用例20
            s = HttpHelper2.HttpGet("%73\0\0\0", (string)null, out b);
            //测试用例21
            s = HttpHelper2.HttpGet("%31\0\0\0", (string)null, out b);
            //测试用例22
            s = HttpHelper2.HttpGet("\\\\/", (string)null, out b);
            //测试用例23
            s = HttpHelper2.HttpGet("\0\0:", (string)null, out b);
            //测试用例24
            s = HttpHelper2.HttpGet("xn: ", (string)null, out b);
            //测试用例25
            s = HttpHelper2.HttpGet("/\0::", (string)null, out b);
            //测试用例26
            s = HttpHelper2.HttpGet("x0::", (string)null, out b);
            //测试用例27
            s = HttpHelper2.HttpGet("x0:<", (string)null, out b);
            //测试用例28
            s = HttpHelper2.HttpGet("x0:?", (string)null, out b);
            //测试用例29
            s = HttpHelper2.HttpGet("x0:#", (string)null, out b);
            //测试用例30
            s = HttpHelper2.HttpGet("x0:^", (string)null, out b);
            //测试用例31
            s = HttpHelper2.HttpGet("x0:.", (string)null, out b);
            //测试用例32
            s = HttpHelper2.HttpGet("x0:\"", (string)null, out b);
            //测试用例33
            s = HttpHelper2.HttpGet("x0:/", (string)null, out b);
            //测试用例34
            s = HttpHelper2.HttpGet("x0:\0", (string)null, out b);
            //测试用例35
            s = HttpHelper2.HttpGet("x0:!", (string)null, out b);
            //测试用例36
            s = HttpHelper2.HttpGet("x0:_", (string)null, out b);
            //测试用例37
            s = HttpHelper2.HttpGet("x1:\0", (string)null, out b);
            //测试用例38
            s = HttpHelper2.HttpGet("x0:>", (string)null, out b);
            //测试用例39
            s = HttpHelper2.HttpGet("x0:\\", (string)null, out b);
            //测试用例40
            s = HttpHelper2.HttpGet("x0:{", (string)null, out b);
            //测试用例41
            s = HttpHelper2.HttpGet("x0:~", (string)null, out b);
            //测试用例42
            s = HttpHelper2.HttpGet("x0:[", (string)null, out b);
            //测试用例43      
            s = HttpHelper2.HttpGet("x0:", (string)null, out b);
        }

        [TestMethod()]
        public void HttpPostTest()
        {
            string s;
            bool b = false;
            //测试用例1
            s = HttpHelper2.HttpPost((string)null, (string)null, out b);
            //测试用例2
            s = HttpHelper2.HttpPost((string)null, "", out b);
            //测试用例3
            s = HttpHelper2.HttpPost("", "", out b);
            //测试用例4
            s = HttpHelper2.HttpPost("Ā", "", out b);
            //测试用例5
            s = HttpHelper2.HttpPost(":", "", out b);
            //测试用例6
            s = HttpHelper2.HttpPost(" ", "", out b);
            //测试用例7
            s = HttpHelper2.HttpPost((string)null, "�ࠀ\0", out b);
            //测试用例8
            s = HttpHelper2.HttpPost("k|\0", "�ࠀ\0", out b);
            //测试用例9
            s = HttpHelper2.HttpPost(" ", "�ࠀ\0", out b);
            //测试用例10
            s = HttpHelper2.HttpPost("|\0", "�ࠀ\0", out b);
            //测试用例11
            s = HttpHelper2.HttpPost("///", "�ࠀ\0", out b);
            //测试用例12
            s = HttpHelper2.HttpPost("\0\0", "�ࠀ\0", out b);
            //测试用例13
            s = HttpHelper2.HttpPost("/\\/", "�ࠀ\0", out b);
            //测试用例14
            s = HttpHelper2.HttpPost("/\\\\", "�ࠀ\0", out b);
            //测试用例15
            s = HttpHelper2.HttpPost("P|\\", "�ࠀ\0", out b);
            //测试用例16
            s = HttpHelper2.HttpPost("b|\\", "�ࠀ\0", out b);
            //测试用例17
            s = HttpHelper2.HttpPost(" \0\0\0\0\0", "", out b);
            //测试用例18
            s = HttpHelper2.HttpPost("x", "", out b);
            //测试用例19
            s = HttpHelper2.HttpPost("\0\0:", "�ࠀ\0", out b);
            //测试用例20
            s = HttpHelper2.HttpPost("a0: ", "�ࠀ\0", out b);
            //测试用例21
            s = HttpHelper2.HttpPost("b0:\r", "�ࠀ\0", out b);
            //测试用例22
            s = HttpHelper2.HttpPost("b0:\r", "�ࠀ\0", out b);
            //测试用例23
            s = HttpHelper2.HttpPost("r0:\r", "�ࠀ\0", out b);
            //测试用例24
            s = HttpHelper2.HttpPost("w1: ", "�ࠀ\0", out b);
        }
    }
}