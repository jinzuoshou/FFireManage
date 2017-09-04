using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FFireManage
{
    public enum OperationType
    {
        Add = 1,
        Edit = 2,
        Check = 3
    }

    public enum DeviceType
    {
        Android = 1,
        IOS = 2,
        PC = 3
    }

    public enum DeviceType1
    {
        移动 = 1,
        电脑PC = 2
    }


    /// <summary>
    /// 通道
    /// </summary>
    public enum ChannelType
    {
        stream1 = 1,
        stream2 = 2,
        stream3 = 3,
        stream4 = 4
    }

    public enum LicenseStatus
    {

    }

    /// <summary>
    /// 几何形状
    /// </summary>
    public enum Shape
    {
        点 = 1,
        线 = 2,
        多边形 = 3
    }

    #region 热点
    public enum HotSmokeType
    {
        有 = 0,
        无 = 1
    }
    public enum HotContinuousType
    {
        连续 = 0,
        非连续 = 1

    }
    public enum HotType
    {
        火灾 = 0,
        炼山 = 1,
        农用火 = 2,
        境外火 = 3,
        其他 = 4
    }
    #endregion

    #region 瞭望台
    /// <summary>
    /// 瞭望台状态
    /// </summary>
    public enum WatchTowerStatus
    {
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        较差 = 4,
        报废 = 5
    }

    /// <summary>
    /// 瞭望台类型
    /// </summary>
    public enum WatchTowerType
    {
        铁质了望台 = 1,
        砖瓦了望台 = 2,
        木质了望台 = 3,
        其它了望台 = 4
    }

    /// <summary>
    /// 瞭望台结构
    /// </summary>
    public enum WatchTowerStructure
    {
        一层 = 1,
        两层 = 2,
        三层 = 3,
        四层 = 4,
        四层以上 = 5
    }

    public enum WatchTowerBuildUnit
    {
        林业局 = 1,
        林场 = 2,
        其它 = 3
    }

    #endregion

    #region 无线电台站


    /// <summary>
    /// 无线电台站状态
    /// </summary>
    public enum RadioStationStatus
    {
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        较差 = 4,
        报废 = 5
    }

    #endregion

    #region 森林防火指挥部

    /// <summary>
    /// 森林防火指挥部类型个
    /// </summary>
    public enum FireCommandType
    {
        防火指挥部 = 1,
        森防指所 = 2,
        其它事业机构 = 3
    }

    /// <summary>
    /// 森林防火指挥部机构编制
    /// </summary>
    public enum FireCommandInstitutions
    {
        行政 = 1,
        行政事业 = 2,
        全额拨款事业 = 3,
        差额拨款事业 = 4,
        自收自支事业 = 5,
        未定编 = 6,
        其它 = 7
    }

    /// <summary>
    /// 森林防火指挥部状态
    /// </summary>
    public enum FireCommandStatus
    {
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        较差 = 4,
        报废 = 5
    }

    /// <summary>
    /// 森林防火指挥部级别
    /// </summary>
    public enum FireCommandLevel
    {
        省级 = 1,
        市级 = 2,
        县级 = 3,
        其他 = 4
    }

    #endregion

    #region 防火林带

    /// <summary>
    /// 防火林带状态
    /// </summary>
    public enum FireForestBeltStatus
    {
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        差 = 4,
        废弃 = 5
    }

    /// <summary>
    /// 防火林带类型
    /// </summary>
    public enum FireForestBeltType
    {
        主防火林带 = 1,
        副防火林带 = 2,
        防火隔离带 = 3,
        自然阻隔带 = 4,
        防火道路 = 5,
        其它阻隔带 = 6
    }

    /// <summary>
    /// 防火林带营造单位
    /// </summary>
    public enum FireForestBeltBuildUnit
    {
        林业局 = 1,
        林场 = 2,
        村庄 = 3,
        个体 = 4
    }
    /// <summary>
    /// 防火林带营造位置
    /// </summary>
    public enum FireForestBeltBuildAddr
    {
        边境防火林带 = 1,
        林内防火林 = 2,
        山脚田边 = 3,
        村屯林沿 = 4
    }

    #endregion

    #region 航空灭火蓄水池

    /// <summary>
    /// 航空灭火蓄水池状态
    /// </summary>
    public enum ArtificiallakeStatus
    {
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        差 = 4,
        废弃 = 5
    }

    /// <summary>
    /// 是否有电线索道
    /// </summary>
    public enum ArtificiallakeIsCableway
    {
        是 = 1,
        否 = 2
    }

    /// <summary>
    /// 能否吊桶取水
    /// </summary>
    public enum ArtificiallakeIsTakeWater
    {
        是 = 1,
        否 = 2
    }

    /// <summary>
    /// 航空灭火蓄水池管理单位
    /// </summary>
    public enum ALManagementUnit
    {
        管理单位1 = 1,
        管理单位2 = 2,
        管理单位3 = 3
    }

    #endregion

    #region 林区危险及重要性设备设施

    /// <summary>
    /// 林区危险及重要性设备设施状态
    /// </summary>
    public enum DFacilitiesStatus
    {
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        差 = 4,
        废弃 = 5
    }

    /// <summary>
    /// 林区危险及重要性设备设施形状
    /// </summary>
    public enum DFacilitiesType
    {
        类型1 = 1,
        类型2 = 2,
        类型3 = 3
    }
    #endregion

    #region 停机坪

    /// <summary>
    /// 停机坪状态
    /// </summary>
    public enum TramacStatus
    {
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        差 = 4,
        废弃
    }
    #endregion

    #region 森林防火物资储备库

    /// <summary>
    /// 森林防火物资储备库类型
    /// </summary>
    public enum WarehouseType
    {
        国家级物质储备库 = 1,
        省级物质储备库 = 2,
        地市级物质储备库 = 3,
        县级物质储备库 = 4,
        乡镇级物质储备库 = 5
    }

    /// <summary>
    /// 森林防火物资储备库状态 
    /// </summary>
    public enum WarehouseStatus
    {
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        差 = 4,
        废弃 = 5
    }
    #endregion

    #region 半专业森林消防队

    /// <summary>
    /// 半专业森林消防队状态
    /// </summary>
    public enum FireHBrigadeStatus
    {
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        差 = 4,
        废弃 = 5
    }
    #endregion

    #region 专业森林消防队

    /// <summary>
    /// 专业森林消防队状态
    /// </summary>
    public enum FirePBrigadeStatus
    {
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        差 = 4,
        废弃 = 5
    }
    #endregion

    #region 重点防火单位

    /// <summary>
    /// 重点防火单位状态
    /// </summary>
    public enum FireImportantUnitsStatus
    {
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        差 = 4,
        废弃 = 5
    }

    /// <summary>
    /// 重点防火单位类型
    /// </summary>
    public enum FireImportantUnitsType
    {
        县级防火检查站 = 1,
        林场防火检查站 = 2,
        重点防火企 = 3,
        重点防火场所 = 4,
        消防水源 = 5
    }
    #endregion

    #region 火灾档案
    public enum FireDocumentSlopePosition
    {
        山脊 = 1,
        坡肩 = 2,
        背坡 = 3,
        坡脚 = 4,
        沟谷 = 5
    }

    public enum IsDealWith
    {
        否 = 0,
        是 = 1
    }
    #endregion

    #region 森林防火指挥部
    /// <summary>
    /// 森林防火指挥部机构编制
    /// </summary>
    public enum FireOfficeInstitutions
    {
        行政 = 1,
        行政事业 = 2,
        全额拨款事业 = 3,
        差额拨款事业 = 4,
        自收自支事业 = 5,
        未定编 = 6,
        其它 = 7
    }

    /// <summary>
    /// 森林防火指挥部类型
    /// </summary>
    public enum FireOfficeType
    {
        防火指挥部 = 1,
        森防指所 = 2,
        其它事业机构 = 3
    }

    /// <summary>
    /// 森林防火指挥部级别
    /// </summary>
    public enum FireOfficeLevel
    {
        省级 = 1,
        市级 = 2,
        县级 = 3,
        其它 = 4
    }

    /// <summary>
    /// 森林防火指挥部状态
    /// </summary>
    public enum FireOfficeStatus
    {
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        差 = 4,
        废弃 = 5
    }
    #endregion

    #region 飞机吊桶取水点
    /// <summary>
    /// 是否有电线索道
    /// </summary>
    public enum PWIsCableway
    {
        是 = 1,
        否 = 2
    }
    /// <summary>
    /// 能否吊桶取水
    /// </summary>
    public enum PWIsTakeWater
    {
        是 = 1,
        否 = 2
    }
    /// <summary>
    /// 飞机吊桶取水点管理单位
    /// </summary>
    public enum PWManagementUnit
    {
        管理单位1 = 1,
        管理单位2 = 2,
        管理单位3 = 3
    }
    /// <summary>
    /// 是否有网箱养鱼
    /// </summary>
    public enum PWIsCageFish
    {
        是 = 1,
        否 = 2
    }
    /// <summary>
    /// 飞机吊桶取水点状态
    /// </summary>
    public enum PWStatus
    {
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        差 = 4,
        废弃 = 5
    }
    #endregion

    #region 卫星地面站
    /// <summary>
    /// 卫星地面站状态
    /// </summary>
    public enum SGSStatus
    {
        
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        差 = 4,
        废弃 = 5
    }
    #endregion

    #region 大型警示牌
    public enum WarningBoardsType
    {
        宣传牌 = 1,
        宣传碑 = 2,
        宣传标语 = 3
    }

    public enum WarningBoardsStatus
    {
        优秀 = 1,
        良好 = 2,
        一般 = 3,
        差 = 4,
        废弃 = 5
    }
    #endregion
}



