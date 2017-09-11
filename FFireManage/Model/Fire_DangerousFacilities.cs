using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 林区危险及重要设施
	/// </summary>
	public class Fire_DangerousFacilities 
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
        [Custom(Description = "管理员")]
        public string manager { get; set; }

        /// <summary>
        /// 管理员电话
        /// </summary>
        [Custom(Description = "管理员电话")]
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
        /// 类型
        /// </summary>
        [Custom(Description = "类型")]
        public string type { get; set; }

        /// <summary>
        /// 重要设施或危险品名称
        /// </summary>
        [Custom(Description = "重要设施或危险品名称")]
        public string content { get; set; }

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
        [Custom(IsEnumValue =true,EnumType  = typeof(DFacilitiesStatus))]
		public int status { get; set; }

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
        [Custom(Description = "说明")]
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

