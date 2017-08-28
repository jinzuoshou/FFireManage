using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 森林防火设备设施
	/// </summary>
	public class Fire_Equipment 
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
		/// 地址
		/// </summary>
		public string address { get; set; }

		/// <summary>
		/// 值班电话
		/// </summary>
		public string phone { get; set; }

		/// <summary>
		/// 管理员
		/// </summary>
		public string manager { get; set; }

		/// <summary>
		/// 经度
		/// </summary>
		public double latitude { get; set; }

		/// <summary>
		/// 纬度
		/// </summary>
		public double longitude { get; set; }

		/// <summary>
		/// 消防车
		/// </summary>
		public int fireengine { get; set; }

		/// <summary>
		/// 运兵车辆
		/// </summary>
		public int t_car { get; set; }

		/// <summary>
		/// 二号工具
		/// </summary>
		public int n2n3tool { get; set; }

		/// <summary>
		/// 风力灭火机
		/// </summary>
		public int w_equipm { get; set; }

		/// <summary>
		/// 灭火水泵
		/// </summary>
		public int pump { get; set; }

		/// <summary>
		/// 灭火弹
		/// </summary>
		public int fire_bomb { get; set; }

		/// <summary>
		/// 水雾喷射器
		/// </summary>
		public int wsinjector { get; set; }

		/// <summary>
		/// 油锯
		/// </summary>
		public int chainsaw { get; set; }

		/// <summary>
		/// 割灌机
		/// </summary>
		public int b_cutter { get; set; }

		/// <summary>
		/// 灭火水枪
		/// </summary>
		public int w_cannons { get; set; }

		/// <summary>
		/// 对讲机
		/// </summary>
		public int interphone { get; set; }

		/// <summary>
		/// 中继台
		/// </summary>
		public int zj_radio { get; set; }

		/// <summary>
		/// 手持台
		/// </summary>
		public int sc_radio { get; set; }

		/// <summary>
		/// 基地台
		/// </summary>
		public int jd_radio { get; set; }

		/// <summary>
		/// 车载台
		/// </summary>
		public int cz_radio { get; set; }

		/// <summary>
		/// GPS定位仪
		/// </summary>
		public int gps { get; set; }

		/// <summary>
		/// 砍刀
		/// </summary>
		public int machetes { get; set; }

		/// <summary>
		/// 阻燃服、防火服
		/// </summary>
		public int r_clothing { get; set; }

		/// <summary>
		/// 手电筒
		/// </summary>
		public int flashlight { get; set; }

		/// <summary>
		/// 头盔
		/// </summary>
		public int helmet { get; set; }

		/// <summary>
		/// 手套
		/// </summary>
		public int gloves { get; set; }

		/// <summary>
		/// 扑火鞋
		/// </summary>
		public int fire_shoes { get; set; }

		/// <summary>
		/// 其它灭火工具
		/// </summary>
		public int o_equip { get; set; }

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

