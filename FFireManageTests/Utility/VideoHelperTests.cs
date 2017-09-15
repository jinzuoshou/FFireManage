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
    public class VideoHelperTests
    {
        [TestMethod()]
        public void ScreenshotTest()
        {
            VideoHelper.Screenshot((string)null, (string)null, (string)null, 0, 0);
        }

        [TestMethod()]
        public void VideoToByteArrayTest()
        {
            byte[] bs;
            bs = VideoHelper.VideoToByteArray((string)null);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void VideoSnapshotsTest()
        {
            VideoHelper.VideoSnapshots((string)null, (string)null, 0, 0);
        }
    }
}