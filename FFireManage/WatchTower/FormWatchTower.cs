using FFireManage.Model;
using FFireManage.Service;
using FFireManage.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFireManage.WatchTower
{
    public partial class FormWatchTower : Form
    {
        private Fire_Observatory m_WatchTower = null;
        private OperationType m_OperationType;
        private ObservatoryController m_ObservatoryController = null;

        public FormWatchTower(OperationType type, Fire_Observatory watchTower = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_WatchTower = watchTower;
            this.m_ObservatoryController = new ObservatoryController();

            this.m_ObservatoryController.AddEvent += m_ObservatoryController_AddEvent;
            this.m_ObservatoryController.EditEvent += m_ObservatoryController_EditEvent;
        }

        private void m_ObservatoryController_AddEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                        if (result.status == 10000)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show(this, result.msg, "提示");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "提示");
                    }
                    
                }
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void m_ObservatoryController_EditEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    try
                    {
                        BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                        if (result.status == 10000)
                        {

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(this, result.msg, "提示");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "提示");
                    }
                    
                }
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void FormWatchTower_Load(object sender, EventArgs e)
        {
            #region 初始化控件内容

            if (m_OperationType == OperationType.Add)
            {
                this.Text = "新增瞭望台";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑瞭望台";
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看瞭望台";
            }

            /* 瞭望台类型 */
            WatchTowerType watchTowerType = WatchTowerType.铁质了望台;
            List<object> watchTowerTypeList = CommonHelper.GetDataSource<WatchTowerType>(watchTowerType);
            this.cbx_type.DisplayMember = "Name";
            this.cbx_type.ValueMember = "Value";
            this.cbx_type.DataSource = watchTowerTypeList;


            /* 瞭望台形状 */
            Shape watchTowerShape = Shape.点;
            List<object> watchTowerShapeList = CommonHelper.GetDataSource<Shape>(watchTowerShape);
            this.cbx_shape.DisplayMember = "Name";
            this.cbx_shape.ValueMember = "Value";
            this.cbx_shape.DataSource = watchTowerShapeList;
            this.cbx_shape.SelectedValue = 1;
            this.cbx_shape.Enabled = false;

            /* 瞭望台状态 */
            WatchTowerStatus watchTowerStatus = WatchTowerStatus.优秀;
            List<object> watchTowerStatusList = CommonHelper.GetDataSource<WatchTowerStatus>(watchTowerStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Value";
            this.cbx_status.DataSource = watchTowerStatusList;

            /* 瞭望台结构 */
            WatchTowerStructure watchTowerStructure = WatchTowerStructure.一层;
            List<object> watchTowerStructureList = CommonHelper.GetDataSource<WatchTowerStructure>(watchTowerStructure);
            this.cbx_structure.DisplayMember = "Name";
            this.cbx_structure.ValueMember = "Value";
            this.cbx_structure.DataSource = watchTowerStructureList;

            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_WatchTower.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_WatchTower.longitude;
                this.coordinatesInputControl1.Latitude = this.m_WatchTower.latitude;
                this.tbx_name.Text = this.m_WatchTower.name;
                if (this.m_WatchTower.SHAPE.Contains("POINT"))
                {
                    this.cbx_shape.SelectedValue = 1;
                }
                else if (this.m_WatchTower.SHAPE.Contains("LINEstring"))
                {
                    this.cbx_shape.SelectedValue = 2;
                }
                else if(this.m_WatchTower.SHAPE.Contains("POLYGON"))
                {
                    this.cbx_shape.SelectedValue = 3;
                }

                this.cbx_type.SelectedValue = this.m_WatchTower.type;
                this.cbx_status.SelectedValue = (int)this.m_WatchTower.status;
                this.tbx_manager.Text = this.m_WatchTower.manager;
                this.tbx_phone.Text = this.m_WatchTower.phone;
                this.tbx_look_area.Text = this.m_WatchTower.look_area.ToString();
                this.tbx_look_forest_area.Text = this.m_WatchTower.look_forest_area.ToString();
                this.tbx_look_coverage.Text = this.m_WatchTower.look_coverage.ToString();
                this.tbx_c_area.Text = this.m_WatchTower.c_area.ToString();
                this.tbx_telescope.Text = this.m_WatchTower.telescope.ToString();
                this.tbx_interphone.Text = this.m_WatchTower.interphone.ToString();
                this.tbx_compass_instrument.Text = this.m_WatchTower.compass_instrument.ToString();
                this.tbx_telephone.Text = this.m_WatchTower.telephone.ToString();
                this.tbx_elevation.Text = this.m_WatchTower.elevation.ToString();
                this.tbx_radio.Text = this.m_WatchTower.radio.ToString();
                this.cbx_structure.SelectedText = this.m_WatchTower.structure;
                this.tbx_build_unit.Text = this.m_WatchTower.build_unit;
                try
                {
                    this.dtp_build_year.Value = Convert.ToDateTime(this.m_WatchTower.build_year);
                }
                catch
                { }
                this.tbx_video_surveillance.Text = this.m_WatchTower.video_surveillance;

                this.tbx_note.Text = this.m_WatchTower.note;
                this.mediaControl1.MediaFiles = this.m_WatchTower.mediaFiles;

                if (this.m_OperationType == OperationType.Check)
                {
                    this.btnOK.Enabled = false;
                    this.btnCancel.Text = "关闭(&C)";

                    this.coordinatesInputControl1.Enabled = false;
                    this.pacControl11.Enabled = false;
                    this.tbx_name.Enabled = false;
                    
                    
                    this.cbx_status.Enabled = false;
                    this.cbx_type.Enabled = false;
                    this.cbx_status.Enabled = false;
                    this.tbx_manager.Enabled = false;
                    this.tbx_phone.Enabled = false;
                    this.tbx_look_area.Enabled = false;
                    this.tbx_look_forest_area.Enabled = false;
                    this.tbx_look_coverage.Enabled = false;
                    this.tbx_c_area.Enabled = false;
                    this.tbx_telescope.Enabled = false;
                    this.tbx_interphone.Enabled = false;
                    this.tbx_compass_instrument.Enabled = false;
                    this.tbx_telephone.Enabled = false;
                    this.tbx_elevation.Enabled = false;
                    this.tbx_radio.Enabled = false;
                    this.cbx_structure.Enabled = false;
                    this.tbx_build_unit.Enabled = false;
                    this.dtp_build_year.Enabled = false;
                    this.tbx_video_surveillance.Enabled = false;
                    this.tbx_note.Enabled = false;

                }
            }
            #endregion
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!IsCondition())
                return;
            if (m_OperationType == OperationType.Add)
            {
                this.m_WatchTower = new Fire_Observatory();
            }
            this.m_WatchTower.longitude = this.coordinatesInputControl1.Longitude;
            this.m_WatchTower.latitude = this.coordinatesInputControl1.Latitude;
            this.m_WatchTower.pac = this.pacControl11.LocalPac;
            this.m_WatchTower.name = this.tbx_name.Text;
            if((int)this.cbx_shape.SelectedValue==1)
            {
                this.m_WatchTower.SHAPE = GDALHelper.LngLatToWktPoint(this.m_WatchTower.longitude, this.m_WatchTower.latitude);
            }

            this.m_WatchTower.type = this.cbx_type.Text;
            this.m_WatchTower.status = (int)this.cbx_status.SelectedValue;
            this.m_WatchTower.manager = this.tbx_manager.Text;
            this.m_WatchTower.phone = this.tbx_phone.Text;
            this.m_WatchTower.look_area = Convert.ToDouble(this.tbx_look_area.Text.Trim());
            this.m_WatchTower.look_forest_area = Convert.ToDouble(this.tbx_look_forest_area.Text.Trim());
            this.m_WatchTower.look_coverage = Convert.ToDouble(this.tbx_look_coverage.Text.Trim());
            this.m_WatchTower.c_area = Convert.ToDouble(this.tbx_c_area.Text.Trim());
            this.m_WatchTower.telescope = Convert.ToInt32(this.tbx_telescope.Text.Trim());
            this.m_WatchTower.interphone = Convert.ToInt32(this.tbx_interphone.Text.Trim());
            this.m_WatchTower.compass_instrument = Convert.ToInt32(this.tbx_compass_instrument.Text.Trim());
            this.m_WatchTower.telephone = Convert.ToInt32(this.tbx_telephone.Text.Trim());
            this.m_WatchTower.elevation = Convert.ToDouble(this.tbx_elevation.Text.Trim());
            this.m_WatchTower.radio = Convert.ToInt32(this.tbx_radio.Text.Trim());
            this.m_WatchTower.structure = this.cbx_structure.Text;
            this.m_WatchTower.build_unit = this.tbx_build_unit.Text;
            this.m_WatchTower.build_year = this.dtp_build_year.Value.ToString("yyyy-MM-dd hh:mm:ss");
            this.m_WatchTower.video_surveillance = this.tbx_video_surveillance.Text;
            this.m_WatchTower.note = this.tbx_note.Text.Trim();
            this.m_WatchTower.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                this.m_ObservatoryController.Add(this.m_WatchTower);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_ObservatoryController.Edit(this.m_WatchTower);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 判断是否满足数据提交条件
        /// </summary>
        /// <returns></returns>
        private bool IsCondition()
        {
            if (this.coordinatesInputControl1.Longitude == 0 || this.coordinatesInputControl1.Latitude == 0)
            {
                MessageBox.Show(this, "请输入正确的经纬度信息", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_location;
                this.coordinatesInputControl1.Focus();
                return false;
            }
            if (this.pacControl11.LocalPac == null || this.pacControl11.LocalPac.EndsWith("00"))
            {
                MessageBox.Show(this, "请选择正确的行政区", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_location;
                this.pacControl11.Focus();
                return false;
            }
            if (this.tbx_name.Text == "")
            {
                MessageBox.Show(this, "请输入瞭望台名称", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_name.Focus();
                return false;
            }
            if (this.tbx_manager.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入管理员", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_manager.Focus();
                return false;
            }
            if (this.tbx_phone.Text.Trim() == "")
            {
                MessageBox.Show(this, "请选输入电话", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_phone.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_look_area.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的瞭望面积", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_look_area.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的瞭望面积", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_look_area.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_look_forest_area.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的瞭望森林面积", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_look_forest_area.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的森林瞭望面积", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_look_forest_area.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_look_coverage.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的瞭望覆盖率", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_look_coverage.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的瞭望覆盖率", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_look_coverage.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_c_area.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的建筑面积", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_c_area.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的建筑面积", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_c_area.Focus();
                return false;
            }
            try
            {
                int num = Convert.ToInt32(this.tbx_telescope.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的望远镜数量", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_telescope.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的望远镜数量", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_telescope.Focus();
                return false;
            }
            try
            {
                int num = Convert.ToInt32(this.tbx_telescope.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的望远镜数量", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_telescope.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的望远镜数量", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_telescope.Focus();
                return false;
            }
            try
            {
                int num = Convert.ToInt32(this.tbx_interphone.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的对讲机数量", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_interphone.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的对讲机数量", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_interphone.Focus();
                return false;
            }

            try
            {
                int num = Convert.ToInt32(this.tbx_compass_instrument.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的罗盘仪数量", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_compass_instrument.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的罗盘仪数量", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_compass_instrument.Focus();
                return false;
            }
            try
            {
                int num = Convert.ToInt32(this.tbx_telephone.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的有线电话数量", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_telephone.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的有线电话数量", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_telephone.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_elevation.Text.Trim());
                
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的海拔", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_elevation.Focus();
                return false;
            }
            try
            {
                int num = Convert.ToInt32(this.tbx_radio.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的无线电话数量", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_radio.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的无线电话数量", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_radio.Focus();
                return false;
            }
            if(this.tbx_build_unit.Text.Trim()=="")
            {
                MessageBox.Show(this, "请输入修建单位", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_build_unit.Focus();
                return false;
            }

            return true;
        }
    }
}
