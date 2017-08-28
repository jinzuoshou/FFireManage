using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 防火林带(线)
	/// </summary>
	public class Fire_ForestBelt 
	{
		/// <summary>
		/// objectid
		/// </summary>
		public int objectid { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 权属
		/// </summary>
		public string ownership { get; set; }

		/// <summary>
		/// 林带类型
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// 宽度
		/// </summary>
		public double wide { get; set; }

		/// <summary>
		/// 长度
		/// </summary>
		public double length { get; set; }

		/// <summary>
		/// 树种
		/// </summary>
		public string species { get; set; }

		/// <summary>
		/// 修建时间
		/// </summary>
		public string build_time { get; set; }

		/// <summary>
		/// 面积
		/// </summary>
		public double beltarea { get; set; }

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
		/// shape_Length
		/// </summary>
		public double shape_Length { get; set; }

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

