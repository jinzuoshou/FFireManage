using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 航空灭火蓄水池
	/// </summary>
	public class Fire_Artificiallake 
	{
        /// <summary>
        /// objectid
        /// </summary>
        [Custom(IsRequired =false)]
        public int objectid { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
        [Custom(Description = "名称")]
		public string name { get; set; }

		/// <summary>
		/// 地址
		/// </summary>
        [Custom(Description = "地址")]
		public string address { get; set; }

		/// <summary>
		/// 管理员
		/// </summary>
		public string manager { get; set; }

		/// <summary>
		/// 管理员电话
		/// </summary>
		public string phone { get; set; }

		/// <summary>
		/// 经度
		/// </summary>
		public double longitude { get; set; }

		/// <summary>
		/// 纬度
		/// </summary>
		public double latitude { get; set; }

		/// <summary>
		/// 容积量
		/// </summary>
		public double volume { get; set; }

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
		/// Geometry
		/// </summary>
		public string shape { get; set; }

		/// <summary>
		/// 状态
		/// </summary>
        [Custom(EnumType =typeof(ArtificiallakeStatus))]
		public int status { get; set; }

		/// <summary>
		/// 蓄水面积
		/// </summary>
		public double storage_area { get; set; }

		/// <summary>
		/// 蓄水容量
		/// </summary>
		public double storage_capacity { get; set; }

		/// <summary>
		/// 最大深度
		/// </summary>
		public double maximum_depth { get; set; }

		/// <summary>
		/// 管理单位
		/// </summary>
		public int management_unit { get; set; }

		/// <summary>
		/// 交通情况
		/// </summary>
		public string traffic_condition { get; set; }

		/// <summary>
		/// 是否有电线索道
		/// </summary>
		public string is_cableway { get; set; }

		/// <summary>
		/// 能否吊桶取水
		/// </summary>
		public string is_take_water { get; set; }

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
        /// 视频
        /// </summary>
        [Custom(IsRequired = false)]
        public string video { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string note { get; set; }

		/// <summary>
		/// 唯一编号
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// 行政区划代码
		/// </summary>
		public string pac { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        public string city_name { get; set; }

        /// <summary>
        /// 县名
        /// </summary>
        public string county_name { get; set; }

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

