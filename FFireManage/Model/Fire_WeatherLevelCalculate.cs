using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 气象等级计算
	/// </summary>
	public class Fire_WeatherLevelCalculate 
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
		/// Temperature
		/// </summary>
		public float Temperature { get; set; }

		/// <summary>
		/// Humidity
		/// </summary>
		public float Humidity { get; set; }

		/// <summary>
		/// WindSpeed
		/// </summary>
		public float WindSpeed { get; set; }

		/// <summary>
		/// Rainfall
		/// </summary>
		public float Rainfall { get; set; }

		/// <summary>
		/// ID
		/// </summary>
		public string ID { get; set; }

		/// <summary>
		/// value
		/// </summary>
		public short value { get; set; }

		/// <summary>
		/// Name
		/// </summary>
		public string Name { get; set; }

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

