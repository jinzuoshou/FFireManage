using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 无线电台站
	/// </summary>
	public class Fire_RadioStation 
	{
        /// <summary>
        /// objectid
        /// </summary>
        [Custom(IsRequired = false)]
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
		/// 使用单位
		/// </summary>
		public string units { get; set; }

		/// <summary>
		/// 电台呼号
		/// </summary>
		public string num_radio { get; set; }

		/// <summary>
		/// 电台名称
		/// </summary>
		public string radioname { get; set; }

		/// <summary>
		/// 电台型号
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// 电台编码
		/// </summary>
		public string coding { get; set; }

		/// <summary>
		/// 接受频率
		/// </summary>
		public string r_frequenc { get; set; }

		/// <summary>
		/// 发射频率
		/// </summary>
		public string l_frequenc { get; set; }

		/// <summary>
		/// 发射功率
		/// </summary>
		public string power { get; set; }

		/// <summary>
		/// 天线高度
		/// </summary>
		public Nullable<double> height { get; set; }

		/// <summary>
		/// 建立时间
		/// </summary>
		public string cre_time { get; set; }

		/// <summary>
		/// 建立人
		/// </summary>
		public string cre_pers { get; set; }

		/// <summary>
		/// 最后修改时间
		/// </summary>
		public string mod_time { get; set; }

		/// <summary>
		/// 修改者
		/// </summary>
		public string mod_pers { get; set; }

		/// <summary>
		/// Geometry
		/// </summary>
		public string shape { get; set; }

		/// <summary>
		/// 照片一
		/// </summary>
		public string picture1 { get; set; }

		/// <summary>
		/// 照片二
		/// </summary>
		public string picture2 { get; set; }

		/// <summary>
		/// 视频
		/// </summary>
		public string video { get; set; }

		/// <summary>
		/// 状态
		/// </summary>
        [Custom(IsEnumValue =true,EnumType = typeof(RadioStationStatus))]
		public int status { get; set; }

		/// <summary>
		/// 类型
		/// </summary>
		public string d_type { get; set; }

		/// <summary>
		/// 说明
		/// </summary>
		public string note { get; set; }

		/// <summary>
		/// 建站时间
		/// </summary>
		public string build_year { get; set; }

		/// <summary>
		/// 唯一编号
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// 行政区划代码
		/// </summary>
		public string pac { get; set; }

        /// <summary>
        /// 海拔
        /// </summary>
        public Nullable<double> elevation { get; set; }

        /// <summary>
        /// 县名
        /// </summary>
        public string county { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        public string city { get; set; }

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

