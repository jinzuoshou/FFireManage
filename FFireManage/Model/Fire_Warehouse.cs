using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
    /// <summary>
    /// 森林防火物资储备库
    /// </summary>
    public class Fire_Warehouse
    {
        /// <summary>
        /// objectid
        /// </summary>
        [Custom(IsRequired = false)]
        public int OBJECTID { get; set; }

        /// <summary>
        /// Geometry（wkt）
        /// </summary>
        public string shape { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Custom(IsRequired = true, Description = "名称")]
        public string name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Custom(IsRequired = true, Description = "地址")]
        public string address { get; set; }

        /// <summary>
        /// 值班电话
        /// </summary>
        [Custom(IsRequired = true, Description = "值班电话")]
        public string phone { get; set; }

        /// <summary>
        /// 管理员
        /// </summary>
        [Custom(IsRequired = true, Description = "管理员")]
        public string manager { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double latitude { get; set; }

        /// <summary>
        /// 类型编号
        /// </summary>
        public int typeid { get; set; }

        /// <summary>
        /// 所属编号
        /// </summary>
        public int user_id { get; set; }

        /// <summary>
        /// 物资编号
        /// </summary>
        public int mat_id { get; set; }

        /// <summary>
        /// 建立时间
        /// </summary>
        [Custom(IsRequired = false)]
        public string cre_time { get; set; }

        /// <summary>
        /// 建立人
        /// </summary>
        [Custom(IsRequired = false)]
        public string cre_pers { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Custom(IsRequired = false)]
        public string mod_time { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        [Custom(IsRequired = false)]
        public string mod_pers { get; set; }

        /// <summary>
        /// 建设年度
        /// </summary>
        [Custom(IsRequired = false)]
        public string build_year { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public double build_area { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 照片一
        /// </summary>
        [Custom(IsRequired = false)]
        public string picture1 { get; set; }

        /// <summary>
        /// 照片二
        /// </summary>
        [Custom(IsRequired = false)]
        public string picture2 { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string note { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 唯一编号
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 管理单位
        /// 
        /// </summary>
        public string management_unit { get; set; }

        /// <summary>
        /// 管理单位负责人
        /// </summary>
        public string director { get; set; }

        /// <summary>
        /// 储备类型
        /// </summary>
        public string reserve_type { get; set; }

        /// <summary>
        /// 物资数量
        /// </summary>
        public short quantity { get; set; }

        /// <summary>
        /// 行政区划代码
        /// </summary>
        public string pac { get; set; }

        /// <summary>
        /// 地区 
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 县名
        /// </summary>
        public string county { get; set; }


        /// <summary>
        /// 媒体字典
        /// </summary>
        [Custom(IsRequired = false)]
        public Dictionary<string, object> mediaByteDict { get; set; }

        /// <summary>
        /// 多媒体文件
        /// </summary>
        [Custom(IsRequired = false)]
        public List<MediaFile> mediaFiles { get; set; }


    }
}