using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 森林防火指挥部
	/// </summary>
	public class Fire_Command 
	{
        /// <summary>
        /// objectid
        /// </summary>
        [Custom(IsRequired = false)]
        public int OBJECTID { get; set; }

		/// <summary>
		/// Geometry
		/// </summary>
		public string shape { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 所在地点
		/// </summary>
		public string address { get; set; }

		/// <summary>
		/// 值班电话
		/// </summary>
		public string phone { get; set; }

		/// <summary>
		/// 办公室主任
		/// </summary>
		public string director { get; set; }

		/// <summary>
		/// 主任电话
		/// </summary>
		public string dir_phone { get; set; }

		/// <summary>
		/// 经度
		/// </summary>
		public double longitude { get; set; }

		/// <summary>
		/// 纬度
		/// </summary>
		public double latitude { get; set; }

		/// <summary>
		/// 机构人数
		/// </summary>
		public int num_people { get; set; }

		/// <summary>
		/// 机构编制
		/// </summary>
		public string institutions { get; set; }

		/// <summary>
		/// 类型
		/// </summary>
		public int type { get; set; }

		/// <summary>
		/// 级别
		/// </summary>
		public string level { get; set; }

		/// <summary>
		/// 状态
		/// </summary>
        [Custom(IsEnumValue =true,EnumType  = typeof(FireCommandStatus))]
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
		/// 指挥长
		/// </summary>
		public string commander { get; set; }

		/// <summary>
		/// 指挥长电话
		/// </summary>
		public string commander_phone { get; set; }

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

