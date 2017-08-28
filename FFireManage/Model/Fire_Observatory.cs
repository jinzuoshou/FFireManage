using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 了望台
	/// </summary>
	public class Fire_Observatory 
	{
        /// <summary>
        /// OBJECTID
        /// </summary>
        [Custom(IsRequired = false)]
        public int OBJECTID { get; set; }

		/// <summary>
		/// SHAPE
		/// </summary>
		public string SHAPE { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 类型
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// 状态
		/// </summary>
        [Custom(IsEnumValue =true,EnumType =  typeof(WatchTowerStatus))]
		public int status { get; set; }

		/// <summary>
		/// 望远镜
		/// </summary>
		public int telescope { get; set; }

		/// <summary>
		/// 对讲机
		/// </summary>
		public int interphone { get; set; }

		/// <summary>
		/// 罗盘仪
		/// </summary>
		public int compass_instrument { get; set; }

		/// <summary>
		/// 有线电话
		/// </summary>
		public int telephone { get; set; }

		/// <summary>
		/// 无线电
		/// </summary>
		public int radio { get; set; }

		/// <summary>
		/// 了望面积
		/// </summary>
		public double look_area { get; set; }

		/// <summary>
		/// 了望森林面积
		/// </summary>
		public double look_forest_area { get; set; }

		/// <summary>
		/// 了望覆盖率
		/// </summary>
		public double look_coverage { get; set; }

		/// <summary>
		/// 建筑面积
		/// </summary>
		public double c_area { get; set; }

		/// <summary>
		/// 海拔
		/// </summary>
		public double elevation { get; set; }

		/// <summary>
		/// 建设年度
		/// </summary>
		public string build_year { get; set; }

		/// <summary>
		/// 管理员
		/// </summary>
		public string manager { get; set; }

		/// <summary>
		/// 联系电话
		/// </summary>
		public string phone { get; set; }

		/// <summary>
		/// 结构
		/// </summary>
		public string structure { get; set; }

		/// <summary>
		/// 视频监测
		/// </summary>
		public string video_surveillance { get; set; }

		/// <summary>
		/// 修建单位
		/// </summary>
		public string build_unit { get; set; }

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
		/// 说明
		/// </summary>
		public string note { get; set; }

		/// <summary>
		/// 地址
		/// </summary>
		public string address { get; set; }

		/// <summary>
		/// 唯一编号
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// 管理单位
		/// </summary>
		public string management_unit { get; set; }

		/// <summary>
		/// 行政区划代码
		/// </summary>
		public string pac { get; set; }

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

