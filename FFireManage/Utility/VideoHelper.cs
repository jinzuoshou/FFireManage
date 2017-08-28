using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using AForge.Video.FFMPEG;
using System.Drawing;

namespace FFireManage.Utility
{
    /// <summary>
    /// 视频帮助类
    /// </summary>
    public static class VideoHelper
    {
        /// <summary>
        /// 创建视频缩略图
        /// </summary>
        /// <param name="ffmepg">ffmepg程序路径</param>
        /// <param name="videoPath">视频路径</param>
        /// <param name="thumbImagePath">缩略图路径</param>
        /// <param name="thubWidth">缩略图宽度</param>
        /// <param name="thubHeight">缩略图高度</param>
        public static void Screenshot(string ffmepg, string videoPath, string thumbImagePath, int thubWidth, int thubHeight)
        {
            Process process = new Process();
            try
            {
                //创建目录
                string dirPath = Path.GetDirectoryName(thumbImagePath);
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);

                
                //截图开始
                process.StartInfo.FileName = ffmepg;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;//不创建进程窗口 
                //process.StartInfo.Arguments = " -i " + videoPath + string.Format(" -y -f image2 -ss 0.8 -t 0.001 -s {0}x{1} ", thubWidth, thubHeight) + thumbImagePath;
                process.StartInfo.Arguments = string.Format(" -i \"{1}\" -ss {2} -vframes 1 -r 1 -ac 1 -ab 2 -s {3}*{4} -f image2 \"{5}\"", ffmepg, videoPath, 1, thubWidth, thubHeight, thumbImagePath);

                process.Start();
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(ffmpegProcess_Exited);
                Thread.Sleep(3000);

            }
            catch 
            {

            }
            finally
            {
                process.Dispose();
                process.Close();//关闭进程
            }

        }

        /// <summary>
        /// ffmpeg进程退出时触发
        /// </summary>
        private static void ffmpegProcess_Exited(object sender, EventArgs e)
        {
            Process p = sender as Process;
            if (p != null)
            {
                int code = p.ExitCode;

                p.Dispose();
                p.Close();
            }
        }

        /// <summary>
        /// 将视频文件转换成二进制数组
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static byte[] VideoToByteArray(string filePath)
        {
            try
            {
                byte[] buffur = null;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    buffur = new byte[fs.Length];
                    fs.Read(buffur, 0, (int)fs.Length);
                }
                return buffur;
            }
            catch
            {
                return null;
            }
        }

        private static object lockData=new object();

        /// <summary>
        /// 截取视频缩略图
        /// </summary>
        /// <param name="videoPath">视频路径</param>
        /// <param name="thumbImagePath">缩略图文件路径</param>
        /// <param name="thubWidth">缩略图指定的边长（正方形）</param>
        /// <param name="thubQuality">缩略图质量</param>
        public static void VideoSnapshots(string videoPath, string thumbImagePath, int thubWidth, int thubQuality)
        {
            VideoFileReader reader = new VideoFileReader();
            try
            {
                lock (lockData)
                {
                    reader.Open(videoPath);
                }
                Bitmap bitMap = reader.ReadVideoFrame();
                //创建目录
                string dirPath = Path.GetDirectoryName(thumbImagePath);
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);
                ImageHelper.CutForSquare(bitMap, thumbImagePath, thubWidth, thubQuality);

            }
            finally
            {
                reader.Dispose();
                reader.Close();
            }

        }
    }
}
