using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFireManage.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using Microsoft.Pex.Framework.Generated;

namespace FFireManage.Utility.Tests
{
    [TestClass()]
    public class ImageHelperTests
    {
        [TestMethod()]
        public void CutForSquareTest()
        {
            ImageHelper.CutForSquare((Stream)null, (string)null, 0, 0);
        }

        [TestMethod()]
        public void CutForSquareTest1()
        {
            ImageHelper.CutForSquare((Image)null, (string)null, 0, 0);
        }

        [TestMethod()]
        public void CutForCustomTest()
        {
            //测试用例1
            ImageHelper.CutForCustom((Stream)null, (string)null, 0, 0, 0);
            //测试用例2
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                MemoryStream memoryStream;
                byte[] bs = new byte[0];
                memoryStream = new MemoryStream(bs, false);
                disposables.Add((IDisposable)memoryStream);
                ImageHelper.CutForCustom((Stream)memoryStream, (string)null, 0, 0, 0);
                disposables.Dispose();
            }

            //测试用例3
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                MemoryStream memoryStream;
                byte[] bs = new byte[100];
                memoryStream = new MemoryStream(bs, false);
                disposables.Add((IDisposable)memoryStream);
                ImageHelper.CutForCustom((Stream)memoryStream, (string)null, 0, 0, 0);
                disposables.Dispose();
            }
            //测试用例4
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                MemoryStream memoryStream;
                byte[] bs = new byte[1];
                memoryStream = new MemoryStream(bs, false);
                disposables.Add((IDisposable)memoryStream);
                ImageHelper.CutForCustom((Stream)memoryStream, (string)null, 0, 0, 0);
                disposables.Dispose();
            }
        }

        [TestMethod()]
        public void ZoomAutoTest()
        {
            ImageHelper.ZoomAuto((Stream)null, (string)null, 0, 0, false, (string)null, (string)null);
        }

        [TestMethod()]
        public void CreateImageTest()
        {
            ImageHelper.CreateImage((string)null, (string)null, 0, 0, 0, false);
        }

        [TestMethod()]
        [Ignore]
        [PexDescription("\u6d4b\u8bd5\u72b6\u6001\u662f: path bounds exceeded")]
        public void GetImageByUrlTest()
        {
            //测试用例1
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                Image image;
                image = ImageHelper.GetImageByUrl((string)null, (string)null);
                disposables.Add((IDisposable)image);

                image = ImageHelper.GetImageByUrl((string)null, "");
                disposables.Add((IDisposable)image);

                image = ImageHelper.GetImageByUrl((string)null, "\0");
                disposables.Add((IDisposable)image);

                disposables.Dispose();
            }         
        }

        [TestMethod()]
        public void GetAvatarTest()
        {
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                Image image;
                image = ImageHelper.GetAvatar((string)null, (string)null);
                disposables.Add((IDisposable)image);
                disposables.Dispose();
            }
        }

        [TestMethod()]
        public void GetRoundedImageTest()
        {
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                Image image;
                image = ImageHelper.GetRoundedImage((string)null, 0);
                disposables.Add((IDisposable)image);
                disposables.Dispose();
            }
        }

        [TestMethod()]
        public void ImgToByteArrayTest()
        {
            byte[] bs;
            bs = ImageHelper.ImgToByteArray((string)null);
        }

        [TestMethod()]
        public void GetWebImageTest()
        {
            //测试用例1
            ImageHelper.GetWebImage((string)null, (string)null);
            //测试用例2
            ImageHelper.GetWebImage("", (string)null);
            //测试用例3
            ImageHelper.GetWebImage("\0", (string)null);
            //测试用例4
            ImageHelper.GetWebImage("\0\0", (string)null);
            //测试用例5
            ImageHelper.GetWebImage(":", (string)null);
            //测试用例6
            ImageHelper.GetWebImage(":\0\0", (string)null);
            //测试用例7
            ImageHelper.GetWebImage(" ", (string)null);
            //测试用例8
            ImageHelper.GetWebImage(" ", (string)null);
            //测试用例9
            ImageHelper.GetWebImage("  ", (string)null);
            //测试用例10
            ImageHelper.GetWebImage("\0::", (string)null);
            //测试用例11
            ImageHelper.GetWebImage("k::", (string)null);
            //测试用例12
            ImageHelper.GetWebImage("x:\\", (string)null);
            //测试用例13
            ImageHelper.GetWebImage("x:\\", "x:\\");
            //测试用例14
            ImageHelper.GetWebImage("H:\\", (string)null);
            //测试用例15
            ImageHelper.GetWebImage("H:\\", "H:\\");
            //测试用例16
            ImageHelper.GetWebImage("x:\\xn--", (string)null);
        }

        [TestMethod()]
        public void GetWebImageTest1()
        {
            //测试用例1
            ImageHelper.GetWebImage((string)null, (string)null,
                    (Action<object, object>)null, (Action<object, object>)null, (object)null);
            //测试用例2
            ImageHelper.GetWebImage("", (string)null,
                     (Action<object, object>)null, (Action<object, object>)null, (object)null);
            //测试用例3
            ImageHelper.GetWebImage("Ā", "Ā",
                    (Action<object, object>)null, (Action<object, object>)null, (object)null);
            //测试用例4
            ImageHelper.GetWebImage(":%\0\0", (string)null,
                    (Action<object, object>)null, (Action<object, object>)null, (object)null);
            //测试用例5
            ImageHelper.GetWebImage(":%0D\0", (string)null,
                    (Action<object, object>)null, (Action<object, object>)null, (object)null);
            //测试用例6
            ImageHelper.GetWebImage(":%aD", (string)null,
                     (Action<object, object>)null, (Action<object, object>)null, (object)null);
        }
    }
}