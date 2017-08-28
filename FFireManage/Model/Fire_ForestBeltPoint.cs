using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 防火林带
	/// </summary>
	public class Fire_ForestBeltPoint 
	{
		/// <summary>
		/// OBJECTID
		/// </summary>
        [Custom(IsRequired =false)]
		public int OBJECTID { get; set; }

		/// <summary>
		/// SHAPE
		/// </summary>
		public string SHAPE { get; set; }

		/// <summary>
		/// 起始地点
		/// </summary>
		public string start_addr { get; set; }

		/// <summary>
		/// 终止地点
		/// </summary>
		public string stop_addr { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 营造位置
		/// </summary>
		public string build_addr { get; set; }

		/// <summary>
		/// 营造年度
		/// </summary>
		public string build_year { get; set; }

		/// <summary>
		/// 树种
		/// </summary>
		public string tree_type { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 营造单位
        /// </summary>
        public string build_unit { get; set; }

		/// <summary>
		/// 长度
		/// </summary>
		public double belt_len { get; set; }

		/// <summary>
		/// 宽度
		/// </summary>
		public double belt_width { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Custom(IsEnumValue = true,EnumType = typeof(FireForestBeltStatus))]
        public int status { get; set; }

		/// <summary>
		/// 照片一
		/// </summary>
        [Custom(IsRequired =false)]
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
		/// 经度
		/// </summary>
		public double longitude { get; set; }

		/// <summary>
		/// 纬度
		/// </summary>
		public double latitude { get; set; }

		/// <summary>
		/// 株行距
		/// </summary>
		public string row_spacing { get; set; }

		/// <summary>
		/// 唯一编号
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// 管理单位
		/// </summary>
		public string management_unit { get; set; }

		/// <summary>
		/// 管理员电话
		/// </summary>
		public string phone { get; set; }

		/// <summary>
		/// 管理员
		/// </summary>
		public string manager { get; set; }

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

