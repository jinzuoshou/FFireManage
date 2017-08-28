using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 专业森林消防队
	/// </summary>
	public class Fire_PBrigade 
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
        [Custom(Description = "名称")]
		public string name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Custom(Description = "地址")]
        public string address { get; set; }

        /// <summary>
        /// 值班电话
        /// </summary>
        [Custom(Description = "值班电话")]
        public string phone { get; set; }

        /// <summary>
        /// 管理员
        /// </summary>
        [Custom(Description = "管理员")]
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
        [Custom(IsRequired =false)]
		public string mod_time { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        [Custom(IsRequired = false)]
        public string mod_pers { get; set; }

		/// <summary>
		/// 发电机
		/// </summary>
		public int dynamotor { get; set; }

		/// <summary>
		/// 风速仪器等
		/// </summary>
		public int anemometer { get; set; }

		/// <summary>
		/// 通信车
		/// </summary>
		public int communication_v { get; set; }

		/// <summary>
		/// 大斧
		/// </summary>
		public int ax { get; set; }

		/// <summary>
		/// 睡袋
		/// </summary>
		public int sleeping_bag { get; set; }

		/// <summary>
		/// 高压细水雾灭火机
		/// </summary>
		public int high_pressure_fex { get; set; }

		/// <summary>
		/// 消防铲
		/// </summary>
		public int fire_shovel { get; set; }

		/// <summary>
		/// 点火器
		/// </summary>
		public int lighter { get; set; }

		/// <summary>
		/// 摩托车
		/// </summary>
		public int motorcycle { get; set; }

		/// <summary>
		/// 余火探测仪
		/// </summary>
		public int fire_detectors { get; set; }

		/// <summary>
		/// 风水灭火机
		/// </summary>
		public int fsf_extinguishers { get; set; }

		/// <summary>
		/// 基地产值
		/// </summary>
		public int base_value { get; set; }

		/// <summary>
		/// 灭火水车
		/// </summary>
		public int fire_extinguisher { get; set; }

		/// <summary>
		/// 状态
		/// </summary>
		public int status { get; set; }

		/// <summary>
		/// 帐篷
		/// </summary>
		public int tent { get; set; }

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
		/// 类型
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// 营房面积
		/// </summary>
		public double barracks_area { get; set; }

		/// <summary>
		/// 基地类型
		/// </summary>
		public string base_type { get; set; }

		/// <summary>
		/// 说明
		/// </summary>
		public string note { get; set; }

		/// <summary>
		/// 唯一编号
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// 导航手持终端数量
		/// </summary>
		public short nav_handheld { get; set; }

		/// <summary>
		/// 导航车载终端数量
		/// </summary>
		public short nav_vehicle { get; set; }

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

