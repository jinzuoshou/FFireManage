using FFireManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 林火热点
	/// </summary>
	public class Fire_Hot 
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
		/// 编号
		/// </summary>
		public string no { get; set; }

		/// <summary>
		/// 接收卫星
		/// </summary>
		public string satellite { get; set; }

		/// <summary>
		/// 经度
		/// </summary>
		public double longitude { get; set; }

		/// <summary>
		/// 纬度
		/// </summary>
		public double latitude { get; set; }

		/// <summary>
		/// 像素数
		/// </summary>
		public int pixels { get; set; }

		/// <summary>
		/// 有烟否
		/// </summary>
		public int smoke { get; set; }

		/// <summary>
		/// 是否连续林火事件
		/// </summary>
		public int continuous { get; set; }

		/// <summary>
		/// 林火所在地类
		/// </summary>
		public string landtype { get; set; }

		/// <summary>
		/// 林火所在县局
		/// </summary>
		public string county { get; set; }

		/// <summary>
		/// 林火热点类型
		/// </summary>
		public int type { get; set; }

		/// <summary>
		/// 接受时间
		/// </summary>
		public string receiptt { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string note { get; set; }

		/// <summary>
		/// 报告人
		/// </summary>
		public string reporter { get; set; }

		/// <summary>
		/// 报告时间
		/// </summary>
		public string reporttime { get; set; }

		/// <summary>
		/// 处理意见
		/// </summary>
		public string opinion { get; set; }

		/// <summary>
		/// 值班员
		/// </summary>
		public string duty { get; set; }

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
		/// 热点来源
		/// </summary>
		public string source { get; set; }

		/// <summary>
		/// 唯一编号
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// 行政区划代码
		/// </summary>
		public string pac { get; set; }

        /// <summary>
        /// 热点状态
        /// </summary>
        public int status { get; set; }

        [Custom(IsRequired = false)]
        public HotFeedback hotFeedback { get; set; }

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

