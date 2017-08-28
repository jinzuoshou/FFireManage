using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 停机坪
	/// </summary>
	public class Fire_Tarmac 
	{
        /// <summary>
        /// OBJECTID
        /// </summary>
        [Custom(IsRequired = false)]
        public int OBJECTID { get; set; }

		/// <summary>
		/// SHAPE(Geometry:wkt)
		/// </summary>
		public string SHAPE { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 所在地点
		/// </summary>
		public string address { get; set; }

		/// <summary>
		/// 管理员
		/// </summary>
		public string manager { get; set; }

		/// <summary>
		/// 联系电话
		/// </summary>
		public string phone { get; set; }

		/// <summary>
		/// 编号
		/// </summary>
		public string number { get; set; }

		/// <summary>
		/// 建筑面积
		/// </summary>
		public double build_area { get; set; }

		/// <summary>
		/// 类型
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// 状态
		/// </summary>
		public string status { get; set; }

		/// <summary>
		/// 经度
		/// </summary>
		public double longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double latitude { get; set; }

		/// <summary>
		/// 照片一
		/// </summary>
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
		/// 说明
		/// </summary>
		public string note { get; set; }

		/// <summary>
		/// 唯一编号
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// 建设年度
		/// </summary>
		public string build_year { get; set; }

		/// <summary>
		/// 管理单位
		/// </summary>
		public string management_unit { get; set; }

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

