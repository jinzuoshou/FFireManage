using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FFireManage.Utility
{
    /// <summary>
    /// 图片操作帮助类
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// 正方形裁剪，以图片中心为轴心，截取正方型，然后等比缩放（常用于头像处理）
        /// </summary>
        /// <param name="fromFile">原图Stream对象</param>
        /// <param name="fileSaveUrl">缩略图存放地址</param>
        /// <param name="side">指定的边长（正方形）</param>
        /// <param name="quality">质量（范围1-100）</param>
        public static void CutForSquare(System.IO.Stream fromFile, string fileSaveUrl, int side, int quality)
        {
            //创建目录
            string dir = Path.GetDirectoryName(fileSaveUrl);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            //原始图片（获取原始图片创建对象，并使用流中嵌入的颜色管理信息）
            System.Drawing.Image initImage = System.Drawing.Image.FromStream(fromFile, true);

            //原图宽高均小于模版，不作处理，直接保存
            if (initImage.Width <= side && initImage.Height <= side)
            {
                initImage.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                //原始图片的宽、高
                int initWidth = initImage.Width;
                int initHeight = initImage.Height;

                //非正方型先裁剪为正方型
                if (initWidth != initHeight)
                {
                    //截图对象
                    System.Drawing.Image pickedImage = null;
                    System.Drawing.Graphics pickedG = null;

                    //宽大于高的横图
                    if (initWidth > initHeight)
                    {
                        //对象实例化
                        pickedImage = new System.Drawing.Bitmap(initHeight, initHeight);
                        pickedG = System.Drawing.Graphics.FromImage(pickedImage);
                        //设置质量
                        pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        //定位
                        Rectangle fromR = new Rectangle((initWidth - initHeight) / 2, 0, initHeight, initHeight);
                        Rectangle toR = new Rectangle(0, 0, initHeight, initHeight);
                        //画图
                        pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
                        //重置宽
                        initWidth = initHeight;
                    }
                    //高大于宽的竖图
                    else
                    {
                        //对象实例化
                        pickedImage = new System.Drawing.Bitmap(initWidth, initWidth);
                        pickedG = System.Drawing.Graphics.FromImage(pickedImage);
                        //设置质量
                        pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        //定位
                        Rectangle fromR = new Rectangle(0, (initHeight - initWidth) / 2, initWidth, initWidth);
                        Rectangle toR = new Rectangle(0, 0, initWidth, initWidth);
                        //画图
                        pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
                        //重置高
                        initHeight = initWidth;
                    }

                    //将截图对象赋给原图
                    initImage = (System.Drawing.Image)pickedImage.Clone();
                    //释放截图资源
                    pickedG.Dispose();
                    pickedImage.Dispose();
                }

                //缩略图对象
                System.Drawing.Image resultImage = new System.Drawing.Bitmap(side, side);
                System.Drawing.Graphics resultG = System.Drawing.Graphics.FromImage(resultImage);
                //设置质量
                resultG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                resultG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //用指定背景色清空画布
                resultG.Clear(Color.White);
                //绘制缩略图
                resultG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, side, side), new System.Drawing.Rectangle(0, 0, initWidth, initHeight), System.Drawing.GraphicsUnit.Pixel);

                //关键质量控制
                //获取系统编码类型数组,包含了jpeg,bmp,png,gif,tiff
                ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo ici = null;
                foreach (ImageCodecInfo i in icis)
                {
                    if (i.MimeType == "image/jpeg" || i.MimeType == "image/bmp" || i.MimeType == "image/png" || i.MimeType == "image/gif")
                    {
                        ici = i;
                    }
                }
                EncoderParameters ep = new EncoderParameters(1);
                ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);

                //保存缩略图
                resultImage.Save(fileSaveUrl, ici, ep);

                //释放关键质量控制所用资源
                ep.Dispose();

                //释放缩略图资源
                resultG.Dispose();
                resultImage.Dispose();

                //释放原始图片资源
                initImage.Dispose();
            }
        }

        /// <summary>
        /// 正方形裁剪，以图片中心为轴心，截取正方型，然后等比缩放（常用于头像处理）
        /// </summary>
        /// <param name="initImage">原图对象</param>
        /// <param name="fileSaveUrl">缩略图存放地址</param>
        /// <param name="side">指定的边长（正方形）</param>
        /// <param name="quality">质量（范围1-100）</param>
        public static void CutForSquare(Image initImage, string fileSaveUrl, int side, int quality)
        {

            //原图宽高均小于模版，不作处理，直接保存
            if (initImage.Width <= side && initImage.Height <= side)
            {
                initImage.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                //原始图片的宽、高
                int initWidth = initImage.Width;
                int initHeight = initImage.Height;

                //非正方型先裁剪为正方型
                if (initWidth != initHeight)
                {
                    //截图对象
                    System.Drawing.Image pickedImage = null;
                    System.Drawing.Graphics pickedG = null;

                    //宽大于高的横图
                    if (initWidth > initHeight)
                    {
                        //对象实例化
                        pickedImage = new System.Drawing.Bitmap(initHeight, initHeight);
                        pickedG = System.Drawing.Graphics.FromImage(pickedImage);
                        //设置质量
                        pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        //定位
                        Rectangle fromR = new Rectangle((initWidth - initHeight) / 2, 0, initHeight, initHeight);
                        Rectangle toR = new Rectangle(0, 0, initHeight, initHeight);
                        //画图
                        pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
                        //重置宽
                        initWidth = initHeight;
                    }
                    //高大于宽的竖图
                    else
                    {
                        //对象实例化
                        pickedImage = new System.Drawing.Bitmap(initWidth, initWidth);
                        pickedG = System.Drawing.Graphics.FromImage(pickedImage);
                        //设置质量
                        pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        //定位
                        Rectangle fromR = new Rectangle(0, (initHeight - initWidth) / 2, initWidth, initWidth);
                        Rectangle toR = new Rectangle(0, 0, initWidth, initWidth);
                        //画图
                        pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
                        //重置高
                        initHeight = initWidth;
                    }

                    //将截图对象赋给原图
                    initImage = (System.Drawing.Image)pickedImage.Clone();
                    //释放截图资源
                    pickedG.Dispose();
                    pickedImage.Dispose();
                }

                //缩略图对象
                System.Drawing.Image resultImage = new System.Drawing.Bitmap(side, side);
                System.Drawing.Graphics resultG = System.Drawing.Graphics.FromImage(resultImage);
                //设置质量
                resultG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                resultG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //用指定背景色清空画布
                resultG.Clear(Color.White);
                //绘制缩略图
                resultG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, side, side), new System.Drawing.Rectangle(0, 0, initWidth, initHeight), System.Drawing.GraphicsUnit.Pixel);

                //关键质量控制
                //获取系统编码类型数组,包含了jpeg,bmp,png,gif,tiff
                ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo ici = null;
                foreach (ImageCodecInfo i in icis)
                {
                    if (i.MimeType == "image/jpeg" || i.MimeType == "image/bmp" || i.MimeType == "image/png" || i.MimeType == "image/gif")
                    {
                        ici = i;
                    }
                }
                EncoderParameters ep = new EncoderParameters(1);
                ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);

                //保存缩略图
                resultImage.Save(fileSaveUrl, ici, ep);

                //释放关键质量控制所用资源
                ep.Dispose();

                //释放缩略图资源
                resultG.Dispose();
                resultImage.Dispose();

                //释放原始图片资源
                initImage.Dispose();
            }
        }
        /// <summary>
        /// 指定长度和高度裁剪（自定裁剪）缩放，按模版比例最大范围的裁剪图片并缩放至模版尺寸
        /// </summary>
        /// <param name="fromFile">原图Stream对象</param>
        /// <param name="fileSaveUrl">缩略图存放地址</param>
        /// <param name="maxWidth">最大宽度(单位:px)</param>
        /// <param name="maxHeight">最大高度(单位:px)</param>
        /// <param name="quality">质量（范围0-100）</param>
        public static void CutForCustom(System.IO.Stream fromFile, string fileSaveUrl, int maxWidth, int maxHeight, int quality)
        {
            //从文件获取原始图片，并使用流中嵌入的颜色管理信息
            System.Drawing.Image initImage = System.Drawing.Image.FromStream(fromFile, true);

            //原图宽高均小于模版，不作处理，直接保存
            if (initImage.Width <= maxWidth && initImage.Height <= maxHeight)
            {
                initImage.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                //模版的宽高比例
                double templateRate = (double)maxWidth / maxHeight;
                //原图片的宽高比例
                double initRate = (double)initImage.Width / initImage.Height;

                //原图与模版比例相等，直接缩放
                if (templateRate == initRate)
                {
                    //按模版大小生成最终图片
                    System.Drawing.Image templateImage = new System.Drawing.Bitmap(maxWidth, maxHeight);
                    System.Drawing.Graphics templateG = System.Drawing.Graphics.FromImage(templateImage);
                    templateG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    templateG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    templateG.Clear(Color.White);
                    templateG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, maxWidth, maxHeight), new System.Drawing.Rectangle(0, 0, initImage.Width, initImage.Height), System.Drawing.GraphicsUnit.Pixel);
                    templateImage.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                //原图与模版比例不等，裁剪后缩放
                else
                {
                    //裁剪对象
                    System.Drawing.Image pickedImage = null;
                    System.Drawing.Graphics pickedG = null;

                    //定位
                    Rectangle fromR = new Rectangle(0, 0, 0, 0);//原图裁剪定位
                    Rectangle toR = new Rectangle(0, 0, 0, 0);//目标定位

                    //宽为标准进行裁剪
                    if (templateRate > initRate)
                    {
                        //裁剪对象实例化
                        pickedImage = new System.Drawing.Bitmap(initImage.Width, (int)System.Math.Floor(initImage.Width / templateRate));
                        pickedG = System.Drawing.Graphics.FromImage(pickedImage);

                        //裁剪源定位
                        fromR.X = 0;
                        fromR.Y = (int)System.Math.Floor((initImage.Height - initImage.Width / templateRate) / 2);
                        fromR.Width = initImage.Width;
                        fromR.Height = (int)System.Math.Floor(initImage.Width / templateRate);

                        //裁剪目标定位
                        toR.X = 0;
                        toR.Y = 0;
                        toR.Width = initImage.Width;
                        toR.Height = (int)System.Math.Floor(initImage.Width / templateRate);
                    }
                    //高为标准进行裁剪
                    else
                    {
                        pickedImage = new System.Drawing.Bitmap((int)System.Math.Floor(initImage.Height * templateRate), initImage.Height);
                        pickedG = System.Drawing.Graphics.FromImage(pickedImage);

                        fromR.X = (int)System.Math.Floor((initImage.Width - initImage.Height * templateRate) / 2);
                        fromR.Y = 0;
                        fromR.Width = (int)System.Math.Floor(initImage.Height * templateRate);
                        fromR.Height = initImage.Height;

                        toR.X = 0;
                        toR.Y = 0;
                        toR.Width = (int)System.Math.Floor(initImage.Height * templateRate);
                        toR.Height = initImage.Height;
                    }

                    //设置质量
                    pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    //裁剪
                    pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);

                    //按模版大小生成最终图片
                    System.Drawing.Image templateImage = new System.Drawing.Bitmap(maxWidth, maxHeight);
                    System.Drawing.Graphics templateG = System.Drawing.Graphics.FromImage(templateImage);
                    templateG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    templateG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    templateG.Clear(Color.White);
                    templateG.DrawImage(pickedImage, new System.Drawing.Rectangle(0, 0, maxWidth, maxHeight), new System.Drawing.Rectangle(0, 0, pickedImage.Width, pickedImage.Height), System.Drawing.GraphicsUnit.Pixel);

                    //关键质量控制
                    //获取系统编码类型数组,包含了jpeg,bmp,png,gif,tiff
                    ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo ici = null;
                    foreach (ImageCodecInfo i in icis)
                    {
                        if (i.MimeType == "image/jpeg" || i.MimeType == "image/bmp" || i.MimeType == "image/png" || i.MimeType == "image/gif")
                        {
                            ici = i;
                        }
                    }
                    EncoderParameters ep = new EncoderParameters(1);
                    ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);

                    //保存缩略图
                    templateImage.Save(fileSaveUrl, ici, ep);
                    //templateImage.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);

                    //释放资源
                    templateG.Dispose();
                    templateImage.Dispose();

                    pickedG.Dispose();
                    pickedImage.Dispose();
                }
            }

            //释放资源
            initImage.Dispose();
        }

        /// <summary>
        /// 图片等比例缩放
        /// </summary>
        /// <param name="fromFile">原图Stream对象</param>
        /// <param name="savePath">缩略图存放地址</param>
        /// <param name="targetWidth">指定的最大宽度</param>
        /// <param name="targetHeight">指定的最大高度</param>
        /// <param name="transparent">透明度</param>
        /// <param name="watermarkText">水印文字(为""表示不使用水印)</param>
        /// <param name="watermarkImage">水印图片路径(为""表示不使用水印)</param>
        public static void ZoomAuto(System.IO.Stream fromFile, string savePath, System.Double targetWidth, System.Double targetHeight, bool transparent = true, string watermarkText = "", string watermarkImage = "")
        {
            //创建目录
            string dir = Path.GetDirectoryName(savePath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            //原始图片（获取原始图片创建对象，并使用流中嵌入的颜色管理信息）
            System.Drawing.Image initImage = System.Drawing.Image.FromStream(fromFile, true);

            //原图宽高均小于模版，不作处理，直接保存
            if (initImage.Width <= targetWidth && initImage.Height <= targetHeight)
            {
                //文字水印
                if (watermarkText != "")
                {
                    using (System.Drawing.Graphics gWater = System.Drawing.Graphics.FromImage(initImage))
                    {
                        System.Drawing.Font fontWater = new Font("黑体", 10);
                        System.Drawing.Brush brushWater = new SolidBrush(Color.White);
                        gWater.DrawString(watermarkText, fontWater, brushWater, 10, 10);
                        gWater.Dispose();
                    }
                }

                //透明图片水印
                if (watermarkImage != "")
                {
                    if (File.Exists(watermarkImage))
                    {
                        //获取水印图片
                        using (System.Drawing.Image wrImage = System.Drawing.Image.FromFile(watermarkImage))
                        {
                            //水印绘制条件：原始图片宽高均大于或等于水印图片
                            if (initImage.Width >= wrImage.Width && initImage.Height >= wrImage.Height)
                            {
                                Graphics gWater = Graphics.FromImage(initImage);

                                //透明属性
                                ImageAttributes imgAttributes = new ImageAttributes();
                                ColorMap colorMap = new ColorMap();
                                colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
                                colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
                                ColorMap[] remapTable = { colorMap };
                                imgAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

                                float[][] colorMatrixElements = {
                                   new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  0.0f,  0.0f,  0.5f, 0.0f},//透明度:0.5
                                   new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                };

                                ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);
                                imgAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                                gWater.DrawImage(wrImage, new Rectangle(initImage.Width - wrImage.Width, initImage.Height - wrImage.Height, wrImage.Width, wrImage.Height), 0, 0, wrImage.Width, wrImage.Height, GraphicsUnit.Pixel, imgAttributes);

                                gWater.Dispose();
                            }
                            wrImage.Dispose();
                        }
                    }
                }

                //保存
                initImage.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                //缩略图宽、高计算
                double newWidth = initImage.Width;
                double newHeight = initImage.Height;

                //宽大于高或宽等于高（横图或正方）
                if (initImage.Width > initImage.Height || initImage.Width == initImage.Height)
                {
                    //如果宽大于模版
                    if (initImage.Width > targetWidth)
                    {
                        //宽按模版，高按比例缩放
                        newWidth = targetWidth;
                        newHeight = initImage.Height * (targetWidth / initImage.Width);
                    }
                }
                //高大于宽（竖图）
                else
                {
                    //如果高大于模版
                    if (initImage.Height > targetHeight)
                    {
                        //高按模版，宽按比例缩放
                        newHeight = targetHeight;
                        newWidth = initImage.Width * (targetHeight / initImage.Height);
                    }
                }

                //生成新图
                //新建一个bmp图片
                System.Drawing.Image newImage = new System.Drawing.Bitmap((int)newWidth, (int)newHeight);
                //新建一个画板
                System.Drawing.Graphics newG = System.Drawing.Graphics.FromImage(newImage);

                //设置质量
                newG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                newG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //置背景色
                if (transparent)
                    newG.Clear(Color.Transparent);
                else
                    newG.Clear(Color.White);

                //画图
                newG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, newImage.Width, newImage.Height), new System.Drawing.Rectangle(0, 0, initImage.Width, initImage.Height), System.Drawing.GraphicsUnit.Pixel);

                //文字水印
                if (watermarkText != "")
                {
                    using (System.Drawing.Graphics gWater = System.Drawing.Graphics.FromImage(newImage))
                    {
                        System.Drawing.Font fontWater = new Font("宋体", 10);
                        System.Drawing.Brush brushWater = new SolidBrush(Color.White);
                        gWater.DrawString(watermarkText, fontWater, brushWater, 10, 10);
                        gWater.Dispose();
                    }
                }

                //透明图片水印
                if (watermarkImage != "")
                {
                    if (File.Exists(watermarkImage))
                    {
                        //获取水印图片
                        using (System.Drawing.Image wrImage = System.Drawing.Image.FromFile(watermarkImage))
                        {
                            //水印绘制条件：原始图片宽高均大于或等于水印图片
                            if (newImage.Width >= wrImage.Width && newImage.Height >= wrImage.Height)
                            {
                                Graphics gWater = Graphics.FromImage(newImage);

                                //透明属性
                                ImageAttributes imgAttributes = new ImageAttributes();
                                ColorMap colorMap = new ColorMap();
                                colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
                                colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
                                ColorMap[] remapTable = { colorMap };
                                imgAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

                                float[][] colorMatrixElements = {
                                   new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  0.0f,  0.0f,  0.5f, 0.0f},//透明度:0.5
                                   new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                };

                                ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);
                                imgAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                                gWater.DrawImage(wrImage, new Rectangle(newImage.Width - wrImage.Width, newImage.Height - wrImage.Height, wrImage.Width, wrImage.Height), 0, 0, wrImage.Width, wrImage.Height, GraphicsUnit.Pixel, imgAttributes);
                                gWater.Dispose();
                            }
                            wrImage.Dispose();
                        }
                    }
                }

                //保存缩略图
                try
                {
                    newImage.Save(savePath, initImage.RawFormat);
                }
                catch
                {
                    newImage.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                //释放资源
                newG.Dispose();
                newImage.Dispose();
                initImage.Dispose();
            }
        }

        /// <summary>
        /// 创建规格大小的图像，原图像只能是jpg格式
        /// </summary>
        /// <param name="oPath">原图像绝对路径</param>
        /// <param name="tPath">生成图像绝对路径</param>
        /// <param name="width">生成图像的宽度</param>
        /// <param name="height">生成图像的高度</param>
        /// <param name="quality">质量（范围1-100）</param>
        /// <param name="transparent">图像是否透明（默认透明）</param>
        public static void CreateImage(string oPath, string tPath, int width, int height, int quality, bool transparent = true)
        {
            Bitmap originalBmp = new Bitmap(oPath);
            // 源图像在新图像中的位置   
            int left, top;

            if (originalBmp.Width <= width && originalBmp.Height <= height)
            {
                // 原图像的宽度和高度都小于生成的图片大小   
                left = (int)Math.Round((decimal)(width - originalBmp.Width) / 2);
                top = (int)Math.Round((decimal)(height - originalBmp.Height) / 2);


                // 最终生成的图像   
                Bitmap bmpOut = new Bitmap(width, height);
                using (Graphics graphics = Graphics.FromImage(bmpOut))
                {
                    // 设置高质量插值法   
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    // 清空画布并以白色背景色填充   
                    if (transparent)
                    {
                        graphics.Clear(Color.Transparent);
                    }
                    else
                    {
                        if (originalBmp.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                            graphics.Clear(Color.Transparent);
                        else
                            graphics.Clear(Color.White);
                    }
                    // 把源图画到新的画布上   
                    graphics.DrawImage(originalBmp, left, top);
                }
                bmpOut.Save(tPath);
                bmpOut.Dispose();

                return;
            }


            // 新图片的宽度和高度，如400*200的图像，想要生成160*120的图且不变形，   
            // 那么生成的图像应该是160*80，然后再把160*80的图像画到160*120的画布上   
            int newWidth, newHeight;
            if (width * originalBmp.Height < height * originalBmp.Width)
            {
                newWidth = width;
                newHeight = (int)Math.Round((decimal)originalBmp.Height * width / originalBmp.Width);
                // 缩放成宽度跟预定义的宽度相同的，即left=0，计算top   
                left = 0;
                top = (int)Math.Round((decimal)(height - newHeight) / 2);
            }
            else
            {
                newWidth = (int)Math.Round((decimal)originalBmp.Width * height / originalBmp.Height);
                newHeight = height;
                // 缩放成高度跟预定义的高度相同的，即top=0，计算left   
                left = (int)Math.Round((decimal)(width - newWidth) / 2);
                top = 0;
            }

            // 生成按比例缩放的图，如：160*80的图   
            Bitmap bmpOut2 = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(bmpOut2))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                if (transparent)
                {
                    graphics.FillRectangle(Brushes.Transparent, 0, 0, newWidth, newHeight);
                }
                else
                {
                    if (originalBmp.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                        graphics.FillRectangle(Brushes.Transparent, 0, 0, newWidth, newHeight);
                    else
                        graphics.FillRectangle(Brushes.White, 0, 0, newWidth, newHeight);
                }
                graphics.DrawImage(originalBmp, 0, 0, newWidth, newHeight);
            }
            bmpOut2.Save("tmp.jpg");
            // 再把该图画到预先定义的宽高的画布上，如160*120   
            Bitmap lastbmp = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(lastbmp))
            {
                // 设置高质量插值法 
                //按模版大小生成最终图片
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //关键质量控制
                //获取系统编码类型数组,包含了jpeg,bmp,png,gif,tiff
                ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo ici = null;
                foreach (ImageCodecInfo i in icis)
                {
                    if (i.FormatID == originalBmp.RawFormat.Guid)
                    {
                        ici = i;
                        break;
                    }
                }
                EncoderParameters ep = new EncoderParameters(1);
                ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);

                //graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // 清空画布并以白色背景色填充  
                if (transparent)
                {
                    graphics.Clear(Color.Transparent);
                }
                else
                {
                    if (originalBmp.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                        graphics.Clear(Color.Transparent);
                    else
                        graphics.Clear(Color.White);
                }
                // 把源图画到新的画布上   
                graphics.DrawImage(bmpOut2, left, top);
                //graphics.DrawImage(bmpOut2, new Rectangle(left, top, newWidth, newHeight), new Rectangle(0, 0, newWidth, newHeight), GraphicsUnit.Pixel);

                bmpOut2.Dispose();

                //保存缩略图
                lastbmp.Save(tPath, ici, ep);
                lastbmp.Dispose();
            }
            //lastbmp.Save(tPath);

            //lastbmp.Dispose();

            originalBmp.Dispose();
        }

        /// <summary>
        /// 从远程服务器获取图片
        /// </summary>
        /// <param name="path">图片下载保存后的路径（文件夹）</param>
        /// <param name="url">图片网络地址</param>
        /// <returns>下载后的图片</returns>
        public static Image GetImageByUrl(string path, string url)
        {
            Image image = null;

            int count = 0;

            string saveimage = path + "\\" + System.IO.Path.GetFileName(url);


            if (System.IO.File.Exists(saveimage))
            {
                image = Image.FromFile(saveimage);
            }
            else
            {
                WebClient webClient = new WebClient();

                try
                {
                    webClient.DownloadFile(url, saveimage);
                    image = Image.FromFile(saveimage);

                }
                catch
                {
                    if (System.IO.File.Exists(saveimage))
                    {
                        try
                        {
                            System.IO.File.Delete(saveimage);
                        }
                        catch
                        {

                        }
                    }

                    if (count < 3)
                    {
                        GetImageByUrl(path, url);

                        count++;
                    }

                }
                finally { webClient.Dispose(); }
            }

            return image;
        }

        /// <summary>
        /// 从远程服务器获取头像
        /// </summary>
        /// <param name="path">图片下载保存后的路径（文件夹）</param>
        /// <param name="url">图片网络地址</param>
        /// <returns>处理后的头像文件</returns>
        public static Image GetAvatar(string path, string url)
        {

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            Image img = null;

            string image = path + "\\" + System.IO.Path.GetFileName(url);

            string tempImage = path + "\\" + System.IO.Path.GetFileNameWithoutExtension(url) + "_temp" + System.IO.Path.GetExtension(url);

            string avatar = path + "\\" + System.IO.Path.GetFileNameWithoutExtension(url) + "_avatar" + System.IO.Path.GetExtension(url);


            if (!System.IO.File.Exists(avatar))
            {
                WebClient webClient = new WebClient();
                try
                {
                    webClient.DownloadFile(url, image);
                    int r = 16;//圆角半径
                    int width = 32; int height = 32;//缩略图大小

                    CreateImage(image, tempImage, width, height, 90);

                    img = GetRoundedImage(tempImage, r);

                    img.Save(avatar);

                    img = Image.FromFile(avatar);

                    try
                    {
                        File.Delete(tempImage);
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                }
                finally { webClient.Dispose(); }
            }
            else
            {
                img = Image.FromFile(avatar);
            }

            return img;
        }

        /// <summary>
        /// 创建圆角图片
        /// </summary>
        /// <param name="imgfile">图片地址</param>
        /// <param name="r">圆角半径</param>
        /// <returns>生成的圆角图片</returns>
        public static Image GetRoundedImage(string imgfile, int r)
        {
            string ext = System.IO.Path.GetExtension(imgfile).ToLower();
            if (!(ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".gif" || ext == ".tif" || ext == ".bmp"))
                return null;

            string fileName = imgfile;
            Bitmap srcImg = Image.FromFile(fileName) as Bitmap;
            Bitmap dstImg = new Bitmap(srcImg.Width, srcImg.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Point center1 = new Point(r, r);
            Point center2 = new Point(srcImg.Width - r, r);
            Point center3 = new Point(srcImg.Width - r, srcImg.Height - r);
            Point center4 = new Point(r, srcImg.Height - r);

            for (int x = 0; x < srcImg.Width; x++)
            {
                for (int y = 0; y < srcImg.Height; y++)
                {
                    Color srcColor = srcImg.GetPixel(x, y);
                    if (x <= r && y <= r)
                    {
                        if (IsInCircle(center1, r, new Point(x, y)))
                        {
                            dstImg.SetPixel(x, y, Color.FromArgb(255, srcColor));
                        }
                        else
                        {
                            dstImg.SetPixel(x, y, Color.FromArgb(0, srcColor));
                        }
                    }
                    else if (x >= srcImg.Width - r && y <= r)
                    {
                        if (IsInCircle(center2, r, new Point(x, y)))
                        {
                            dstImg.SetPixel(x, y, Color.FromArgb(255, srcColor));
                        }
                        else
                        {
                            dstImg.SetPixel(x, y, Color.FromArgb(0, srcColor));
                        }
                    }
                    else if (x >= srcImg.Width - r && y >= srcImg.Height - r)
                    {
                        if (IsInCircle(center3, r, new Point(x, y)))
                        {
                            dstImg.SetPixel(x, y, Color.FromArgb(255, srcColor));
                        }
                        else
                        {
                            dstImg.SetPixel(x, y, Color.FromArgb(0, srcColor));
                        }
                    }
                    else if (x <= r && y >= srcImg.Height - r)
                    {
                        if (IsInCircle(center4, r, new Point(x, y)))
                        {
                            dstImg.SetPixel(x, y, Color.FromArgb(255, srcColor));
                        }
                        else
                        {
                            dstImg.SetPixel(x, y, Color.FromArgb(0, srcColor));
                        }
                    }
                    else
                    {
                        dstImg.SetPixel(x, y, Color.FromArgb(255, srcColor));
                    }
                }
            }
            srcImg.Dispose();

            return dstImg;
        }


        /// <summary>
        /// 判断点是否在圆内
        /// </summary>
        /// <param name="center">原点</param>
        /// <param name="r">半径</param>
        /// <param name="other">被判断的点</param>
        /// <returns></returns>
        private static bool IsInCircle(Point center, int r, Point other)
        {
            double xsquare = Math.Pow(other.X - center.X, 2);
            double ysquare = Math.Pow(other.Y - center.Y, 2);
            double rsquare = Math.Pow(r, 2);
            if (xsquare + ysquare <= rsquare)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 将图片文件转成二进制数组
        /// </summary>
        /// <param name="filePath">图片文件路径</param>
        /// <returns></returns>
        public static byte[] ImgToByteArray(string filePath)
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

        /// <summary>
        /// 同步下载图片
        /// </summary>
        /// <param name="url">图片网络地址</param>
        /// <param name="path">图片保存路径</param>
        public static void GetWebImage(string url, string path)
        {
            using (WebClient mywebclient = new WebClient())
            {
                mywebclient.DownloadFile(url, path);
            }
        }

        /// <summary>
        /// 异步下载图片
        /// </summary>
        /// <param name="url">图片网络地址</param>
        /// <param name="path">图片保存路径</param>
        /// <param name="downloadProgressChangedCallback">下载进程回调委托</param>
        /// <param name="downloadFileCompletedCallback">下载结束后回调委托</param>
        /// <param name="callbackData"></param>
        public static void GetWebImage(
            string url,
            string path,
            Action<object, object> downloadProgressChangedCallback,
            Action<object, object> downloadFileCompletedCallback,
            object callbackData)
        {
            try
            {
                WebClient mywebclient = new WebClient();
                mywebclient.DownloadFileAsync(
                    new Uri(url),
                    path,
                    Tuple.Create<List<Action<object, object>>, object>(
                        new List<Action<object, object>>() { downloadProgressChangedCallback, downloadFileCompletedCallback },
                        new object[] { path, callbackData })
                        );

                mywebclient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(mywebclient_DownloadFileCompleted);
                mywebclient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(mywebclient_DownloadProgressChanged);
                //mywebclient.DownloadFile(url, path);
            }
            catch 
            {
            }
        }

        static void mywebclient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Tuple<List<Action<object, object>>, object> callbackFuncData = e.UserState as Tuple<List<Action<object, object>>, object>;
            List<Action<object, object>> callbackfuncList = callbackFuncData.Item1 as List<Action<object, object>>;
            Action<object, object> callbackFunc = callbackfuncList[0];
            object[] callbackArgs = (object[])callbackFuncData.Item2;
            if (callbackArgs != null && callbackArgs.Length > 0)
            {
                object filePath = callbackArgs[0];
                //object info = callbackArgs[1];
                object info = e.ProgressPercentage;
                if (callbackFunc != null)
                {
                    callbackFunc(filePath, info);
                }
            }
            else
            {
                if (callbackFunc != null)
                {
                    callbackFunc(null, null);
                }
            }
        }

        static void mywebclient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    Tuple<List<Action<object, object>>, object> callbackFuncData = e.UserState as Tuple<List<Action<object, object>>, object>;
                    List<Action<object, object>> callbackfuncList = callbackFuncData.Item1 as List<Action<object, object>>;
                    Action<object, object> callbackFunc = callbackfuncList[1];
                    object[] callbackArgs = (object[])callbackFuncData.Item2;
                    if (callbackArgs != null && callbackArgs.Length > 1)
                    {
                        object filePath = callbackArgs[0];
                        object info = callbackArgs[1];
                        if (callbackFunc != null)
                        {
                            callbackFunc(filePath, info);
                        }
                    }
                    else
                    {
                        if (callbackFunc != null)
                        {
                            callbackFunc(null, null);
                        }
                    }
                }
            }
            catch 
            {
            }
            finally
            {
                (sender as WebClient).Dispose();
            }
        }
    }
}
