using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage.Model
{
    public class FireSituation
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int state { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 值班人员
        /// </summary>
        public string duty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string occupation { get; set; }

        /// <summary>
        /// 上报人
        /// </summary>
        public string reporter { get; set; }

        /// <summary>
        /// 火情类型
        /// </summary>
        public int fireType { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int age { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public int area { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public int latitude { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public int longitude { get; set; }

        /// <summary>
        /// 灭火情况
        /// </summary>
        public int fireFighting { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string place { get; set; }

        /// <summary>
        /// 火情id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 媒体文件
        /// </summary>
        [Custom(IsRequired = false)]
        public List<MediaFile> mediaFiles { get; set; }

        /// <summary>
        /// 媒体文件字典
        /// </summary>
        [Custom(IsRequired = false)]
        public Dictionary<string,object> MediaFileDict { get; set; }
    }
}
