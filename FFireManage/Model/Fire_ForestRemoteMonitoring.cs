using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 林火远程监控点
	/// </summary>
	public class Fire_ForestRemoteMonitoring 
	{
		/// <summary>
		/// objectid
		/// </summary>
        [Custom(IsRequired =false)]
		public int objectid { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 地址
		/// </summary>
		public string address { get; set; }

		/// <summary>
		/// 管理员
		/// </summary>
		public string manager { get; set; }

		/// <summary>
		/// 管理员电话
		/// </summary>
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
		/// 所属县局
		/// </summary>
		public string county { get; set; }

		/// <summary>
		/// 设备编号
		/// </summary>
		public string deviceid { get; set; }

		/// <summary>
		/// 视频服务器IP地址
		/// </summary>
		public string ip { get; set; }

		/// <summary>
		/// 云台图片
		/// </summary>
		public byte[] image { get; set; }

		/// <summary>
		/// 云台高度,塔高
		/// </summary>
		public double height { get; set; }

		/// <summary>
		/// 云台当前所处地海拔
		/// </summary>
		public double elevation { get; set; }

		/// <summary>
		/// 云台水平角纠正值
		/// </summary>
		public double h_offset { get; set; }

		/// <summary>
		/// 云台俯仰角纠正值
		/// </summary>
		public double v_offset { get; set; }

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
		/// 登录用户
		/// </summary>
		public string user_ { get; set; }

		/// <summary>
		/// 登录密码
		/// </summary>
		public string password { get; set; }

		/// <summary>
		/// city
		/// </summary>
		public string city { get; set; }

		/// <summary>
		/// 通道
		/// </summary>
		public double channel { get; set; }

		/// <summary>
		/// 端口
		/// </summary>
		public int Port { get; set; }

		/// <summary>
		/// 照片一
		/// </summary>
		public string picture1 { get; set; }

		/// <summary>
		/// 照片二
		/// </summary>
		public string picture2 { get; set; }

		/// <summary>
		/// 视频
		/// </summary>
		public string video { get; set; }

		/// <summary>
		/// 说明
		/// </summary>
		public string note { get; set; }

		/// <summary>
		/// 登录用户
		/// </summary>
		public string username { get; set; }

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

