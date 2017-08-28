using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 乡镇扑火应急队
	/// </summary>
	public class Fire_TBrigade 
	{
        /// <summary>
        /// objectid
        /// </summary>
        [Custom(IsRequired = false)]
        public int objectid { get; set; }

		/// <summary>
		/// 队伍编号
		/// </summary>
		public string no { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 地址
		/// </summary>
		public string address { get; set; }

		/// <summary>
		/// 值班电话
		/// </summary>
		public string phone { get; set; }

		/// <summary>
		/// 队长
		/// </summary>
		public string leader { get; set; }

		/// <summary>
		/// 经度
		/// </summary>
		public double longitude { get; set; }

		/// <summary>
		/// 纬度
		/// </summary>
		public double latitude { get; set; }

		/// <summary>
		/// 人数
		/// </summary>
		public int num_people { get; set; }

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
		/// 唯一编号
		/// </summary>
		public string id { get; set; }

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

