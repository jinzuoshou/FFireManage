using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage.Model
{
    public class GridUserTableInfo
    {
        /// <summary>
        /// guid  唯一值
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public Nullable<int> gender { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public Nullable<int> age { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public string post { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string organization { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public Nullable<int> type { get; set; }

        /// <summary>
        /// 行政区划代码
        /// </summary>
        public string pac { get; set; }

        [Custom(IsRequired = false)]
        public Dictionary<string,object> mediaByteDict { get; set; }

        /// <summary>
        /// 媒体文件
        /// </summary>
        [Custom(IsRequired = false)]
        public List<MediaFile> photo { get; set; }
    }
}
