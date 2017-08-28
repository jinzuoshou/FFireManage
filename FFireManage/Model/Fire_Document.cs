using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
	/// <summary>
	/// 火灾档案
	/// </summary>
	public class Fire_Document 
	{
		/// <summary>
		/// objectid
		/// </summary>
		public int OBJECTID { get; set; }

		/// <summary>
		/// Geometry
		/// </summary>
		public string shape { get; set; }

		/// <summary>
		/// 市
		/// </summary>
		public string city { get; set; }

		/// <summary>
		/// 县
		/// </summary>
		public string county { get; set; }

		/// <summary>
		/// 火灾编号
		/// </summary>
		public string no { get; set; }

		/// <summary>
		/// 热点编号
		/// </summary>
		public string hotid { get; set; }

		/// <summary>
		/// 火灾名称
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// 起火地点
		/// </summary>
		public string address { get; set; }

		/// <summary>
		/// 经度
		/// </summary>
		public double longitude { get; set; }

		/// <summary>
		/// 纬度
		/// </summary>
		public double latitude { get; set; }

		/// <summary>
		/// 起火时间
		/// </summary>
		public string s_time { get; set; }

		/// <summary>
		/// 发现时间
		/// </summary>
		public string f_time { get; set; }

		/// <summary>
		/// 扑灭时间
		/// </summary>
		public string e_time { get; set; }

		/// <summary>
		/// 延续时间
		/// </summary>
		public double duration { get; set; }

		/// <summary>
		/// 火灾类型
		/// </summary>
		public string firetype { get; set; }

		/// <summary>
		/// 起火原因
		/// </summary>
		public string cause { get; set; }

		/// <summary>
		/// 火场总面积
		/// </summary>
		public double firearea { get; set; }

		/// <summary>
		/// 受害天然林
		/// </summary>
		public double nf_area { get; set; }

		/// <summary>
		/// 受害人工林
		/// </summary>
		public double af_proport { get; set; }

		/// <summary>
		/// 林种
		/// </summary>
		public string t_categ { get; set; }

		/// <summary>
		/// 龄组
		/// </summary>
		public string ta_categ { get; set; }

		/// <summary>
		/// 优势树种
		/// </summary>
		public string d_categ { get; set; }

		/// <summary>
		/// 树种组成
		/// </summary>
		public string treeform { get; set; }

		/// <summary>
		/// 损失林木
		/// </summary>
		public double woodloss { get; set; }

		/// <summary>
		/// 损失林木_成林蓄积
		/// </summary>
		public double iwoodloss { get; set; }

		/// <summary>
		/// 损失林木_幼林株数
		/// </summary>
		public double saplloss { get; set; }

		/// <summary>
		/// 人员伤亡_轻伤
		/// </summary>
		public int inj_minor { get; set; }

		/// <summary>
		/// 人员伤亡_重伤
		/// </summary>
		public int inj_severe { get; set; }

		/// <summary>
		/// 人员伤亡_死亡
		/// </summary>
		public int inj_death { get; set; }

		/// <summary>
		/// 火场指挥员
		/// </summary>
		public string conductor { get; set; }

		/// <summary>
		/// 火场指挥员职务
		/// </summary>
		public string con_post { get; set; }

		/// <summary>
		/// 出动专业队
		/// </summary>
		public int brigade { get; set; }

		/// <summary>
		/// 出动森警
		/// </summary>
		public int for_police { get; set; }

		/// <summary>
		/// 出动军队
		/// </summary>
		public int army { get; set; }

		/// <summary>
		/// 出动武警
		/// </summary>
		public int arm_police { get; set; }

		/// <summary>
		/// 出动群众
		/// </summary>
		public int masses { get; set; }

		/// <summary>
		/// 出动飞机架次
		/// </summary>
		public int plane { get; set; }

		/// <summary>
		/// 机型
		/// </summary>
		public string planetype { get; set; }

		/// <summary>
		/// 飞行时间
		/// </summary>
		public double flighttime { get; set; }

		/// <summary>
		/// 飞行费
		/// </summary>
		public double flightcost { get; set; }

		/// <summary>
		/// 机降架次
		/// </summary>
		public int planefall { get; set; }

		/// <summary>
		/// 机降人次
		/// </summary>
		public int fallpeople { get; set; }

		/// <summary>
		/// 化灭架次
		/// </summary>
		public int p_chemical { get; set; }

		/// <summary>
		/// 吊桶次数
		/// </summary>
		public int p_bucket { get; set; }

		/// <summary>
		/// 出动车辆_指挥车
		/// </summary>
		public int commandcar { get; set; }

		/// <summary>
		/// 出动车辆_运输车
		/// </summary>
		public int trans_car { get; set; }

		/// <summary>
		/// 出动车辆_装甲车
		/// </summary>
		public int armoredcar { get; set; }

		/// <summary>
		/// 出动车辆_其它车辆
		/// </summary>
		public int othercar { get; set; }

		/// <summary>
		/// 携带电台_短波
		/// </summary>
		public int shortwave { get; set; }

		/// <summary>
		/// 携带电台_超短波
		/// </summary>
		public int uswave { get; set; }

		/// <summary>
		/// 出动风力灭火机
		/// </summary>
		public int windequip { get; set; }

		/// <summary>
		/// 出动水枪
		/// </summary>
		public int watergun { get; set; }

		/// <summary>
		/// 二、三号工具
		/// </summary>
		public int n2n3tool { get; set; }

		/// <summary>
		/// 其他工具
		/// </summary>
		public int otherequip { get; set; }

		/// <summary>
		/// 扑火经费
		/// </summary>
		public double fightcost { get; set; }

		/// <summary>
		/// 其他损失折款
		/// </summary>
		public double otherloss { get; set; }

		/// <summary>
		/// 肇事者姓名
		/// </summary>
		public string wrecker { get; set; }

		/// <summary>
		/// 肇事者年龄
		/// </summary>
		public int wreckerage { get; set; }

		/// <summary>
		/// 肇事者职业
		/// </summary>
		public string wreckerpro { get; set; }

		/// <summary>
		/// 肇事者单位
		/// </summary>
		public string wreckerunit { get; set; }

		/// <summary>
		/// 肇事者行政处分
		/// </summary>
		public string wapunish { get; set; }

		/// <summary>
		/// 肇事者刑事处罚
		/// </summary>
		public string wcpunish { get; set; }

		/// <summary>
		/// 领导行政处分
		/// </summary>
		public string hapunish { get; set; }

		/// <summary>
		/// 领导刑事处罚
		/// </summary>
		public string hcpunish { get; set; }

		/// <summary>
		/// 气温
		/// </summary>
		public double tempera { get; set; }

		/// <summary>
		/// 湿度
		/// </summary>
		public double humidity { get; set; }

		/// <summary>
		/// 风向
		/// </summary>
		public string winddir { get; set; }

		/// <summary>
		/// 风力
		/// </summary>
		public string windpower { get; set; }

		/// <summary>
		/// 风速
		/// </summary>
		public double windspeed { get; set; }

		/// <summary>
		/// 降雨量
		/// </summary>
		public double rainfall { get; set; }

		/// <summary>
		/// 火情简介或说明
		/// </summary>
		public string description { get; set; }

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
		/// 唯一编号
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// 省
		/// </summary>
		public string province { get; set; }

		/// <summary>
		/// 乡镇名
		/// </summary>
		public string town_name { get; set; }

		/// <summary>
		/// 村名
		/// </summary>
		public string village_name { get; set; }

		/// <summary>
		/// 海拔
		/// </summary>
		public double elevation { get; set; }

		/// <summary>
		/// 坡向
		/// </summary>
		public string aspect { get; set; }

		/// <summary>
		/// 坡位
		/// </summary>
		public string slope_position { get; set; }

		/// <summary>
		/// 坡度
		/// </summary>
		public double slope { get; set; }

		/// <summary>
		/// 地类
		/// </summary>
		public string land_type { get; set; }

		/// <summary>
		/// 前线指挥姓名
		/// </summary>
		public string front_command_name { get; set; }

		/// <summary>
		/// 前线指挥职务
		/// </summary>
		public string front_command_post { get; set; }

		/// <summary>
		/// 后方指挥姓名
		/// </summary>
		public string rear_command_name { get; set; }

		/// <summary>
		/// 后方指挥职务
		/// </summary>
		public string rear_command_post { get; set; }

		/// <summary>
		/// 干部人数
		/// </summary>
		public int cadre { get; set; }

		/// <summary>
		/// 森林公安人数
		/// </summary>
		public int for_cop { get; set; }

		/// <summary>
		/// 专业扑火队人数
		/// </summary>
		public int brigade_people { get; set; }

		/// <summary>
		/// 半专业扑火队人数
		/// </summary>
		public int hbrigade_people { get; set; }

		/// <summary>
		/// 半专业扑火队
		/// </summary>
		public int hbrigade { get; set; }

		/// <summary>
		/// 出动车辆_通讯车
		/// </summary>
		public int communication_car { get; set; }

		/// <summary>
		/// 出动车辆_保障车
		/// </summary>
		public int support_car { get; set; }

		/// <summary>
		/// 出动车辆_高压水车
		/// </summary>
		public int hpw_tanker { get; set; }

		/// <summary>
		/// 出动车辆_推土机
		/// </summary>
		public int bulldozer { get; set; }

		/// <summary>
		/// 对讲机数量
		/// </summary>
		public int interphone { get; set; }

		/// <summary>
		/// 卫星电话数量
		/// </summary>
		public int satellitephone { get; set; }

		/// <summary>
		/// 其它通讯工具数量
		/// </summary>
		public int other_communication { get; set; }

		/// <summary>
		/// 导航手持终端数量
		/// </summary>
		public int nav_handheld { get; set; }

		/// <summary>
		/// 导航车载终端数量
		/// </summary>
		public int nav_vehicle { get; set; }

		/// <summary>
		/// 高压细水雾灭火机
		/// </summary>
		public int high_pressure_fex { get; set; }

		/// <summary>
		/// 灭火水泵数量
		/// </summary>
		public int pump { get; set; }

		/// <summary>
		/// 人工增雨
		/// </summary>
		public double artificial_rain { get; set; }

		/// <summary>
		/// 灭火弹数量
		/// </summary>
		public int fire_bombs { get; set; }

		/// <summary>
		/// 割灌机数量
		/// </summary>
		public int b_cutter { get; set; }

		/// <summary>
		/// 油锯数量
		/// </summary>
		public int chainsaw { get; set; }

		/// <summary>
		/// 相机数量
		/// </summary>
		public int camera1 { get; set; }

		/// <summary>
		/// 摄像机数量
		/// </summary>
		public int camera2 { get; set; }

		/// <summary>
		/// 案件处理
		/// </summary>
		public string caseInfo { get; set; }

		/// <summary>
		/// 肇事方式
		/// </summary>
		public string wayofaccident { get; set; }

		/// <summary>
		/// 天气状况
		/// </summary>
		public string weather { get; set; }

		/// <summary>
		/// 最高气温
		/// </summary>
		public double high_tempera { get; set; }

		/// <summary>
		/// 最低气温
		/// </summary>
		public double low_tempera { get; set; }

		/// <summary>
		/// 最低湿度
		/// </summary>
		public double low_humidity { get; set; }

		/// <summary>
		/// 信息所属行政区代码
		/// </summary>
		public string code { get; set; }

		/// <summary>
		/// 受害森林面积
		/// </summary>
		public double forestarea { get; set; }

		/// <summary>
		/// 受害新造林地面积
		/// </summary>
		public double newforestarea { get; set; }

		/// <summary>
		/// 出动扑火人工（工日）
		/// </summary>
		public int artificialfireout { get; set; }

		/// <summary>
		/// 出动车辆总计
		/// </summary>
		public int totavehiclenumber { get; set; }

		/// <summary>
		/// 其中汽车
		/// </summary>
		public int carnumber { get; set; }

		/// <summary>
		/// 出动飞机（架次）
		/// </summary>
		public int planeoutnumber { get; set; }

		/// <summary>
		/// 固定翼飞机数量
		/// </summary>
		public int WingAirPlaneNumber { get; set; }

		/// <summary>
		/// 固定翼飞机飞行时间
		/// </summary>
		public int WingAirPlaneTime { get; set; }

		/// <summary>
		/// 直升机数量
		/// </summary>
		public int HelicopterNumber { get; set; }

		/// <summary>
		/// 直升机飞行时间
		/// </summary>
		public int HelicopterTime { get; set; }

		/// <summary>
		/// 无人机数量
		/// </summary>
		public int WuRenJiNumber { get; set; }

		/// <summary>
		/// 无人机飞行时间
		/// </summary>
		public int WuRenjiTime { get; set; }

		/// <summary>
		/// 是否处理（0.否、1.是）
		/// </summary>
		public int IsDealWith { get; set; }

		/// <summary>
		/// 已处理人数
		/// </summary>
		public int ProcessedNumber { get; set; }

		/// <summary>
		/// 刑事处罚人数
		/// </summary>
		public int CriminalNumber { get; set; }

		/// <summary>
		/// 行政处罚人数
		/// </summary>
		public int APenaltyNumber { get; set; }

		/// <summary>
		/// 行政处分人数
		/// </summary>
		public int ASanctionNumber { get; set; }

		/// <summary>
		/// 纪律处分人数
		/// </summary>
		public int RecordDispositionNumber { get; set; }

		/// <summary>
		/// 上报人
		/// </summary>
		public string Reporter { get; set; }

		/// <summary>
		/// 上报时间
		/// </summary>
		public string ReportTime { get; set; }

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

