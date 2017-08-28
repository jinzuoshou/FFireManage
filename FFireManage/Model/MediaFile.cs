using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
    public class MediaFile
    {
        /// <summary>
        /// 文件长度：字节
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// 文件名：不包括扩展名
        /// </summary>
        public string fileName { get; set; }

        /// <summary>
        /// 文件类型
        /// 1：图片，2：视频，3：音频
        /// </summary>
        public int fileType { get; set; }

        /// <summary>
        /// 文件扩展名：（mp4/png/mp3)
        /// </summary>
        public string fileSuffix { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string fileThumbUrl { get; set; }

        /// <summary>
        /// 原图
        /// </summary>
        public string fileUrl { get; set; }

        /// <summary>
        /// 主键guid
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 本地媒体文件路径
        /// </summary>
        public string local_file { get; set; }
    }
}