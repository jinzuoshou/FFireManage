using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 森林防火办公室
	/// </summary>
	public class Fire_Office 
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
        [Custom(Description ="森林防火办公室名称")]
		public string name { get; set; }

        /// <summary>
        /// 所在地点
        /// </summary>
        [Custom(Description = "所在地点")]
        public string address { get; set; }

        /// <summary>
        /// 值班电话
        /// </summary>
        [Custom(Description = "值班电话")]
        public string phone { get; set; }

        /// <summary>
        /// 办公室主任
        /// </summary>
        [Custom(Description = "办公室主任")]
        public string director { get; set; }

        /// <summary>
        /// 主任电话
        /// </summary>
        [Custom(Description = "主任电话")]
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
		public string type { get; set; }

		/// <summary>
		/// 级别
		/// </summary>
		public string level { get; set; }

		/// <summary>
		/// 状态
		/// </summary>
		public string status { get; set; }

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
        public string cre_pers { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Custom(IsRequired = false)]
        public string mod_time { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        public string mod_pers { get; set; }

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

