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

namespace FFireManage.Artificiallake
{
    public partial class FormArtificiallake : Form
    {
        private Fire_Artificiallake m_Artificiallake = null;
        private OperationType m_OperationType;
        private ServiceController m_ServiceController = null;

        public FormArtificiallake(OperationType type, Fire_Artificiallake artificiallake = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_Artificiallake = artificiallake;
            this.m_ServiceController = new ServiceController();

            this.m_ServiceController.AddArtificiallakeEvent += M_ServiceController_AddArtificiallakeEvent;
            this.m_ServiceController.EditArtificiallakeEvent += M_ServiceController_EditArtificiallakeEvent;
        }

        private void M_ServiceController_AddArtificiallakeEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = sender.ToString();
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
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void M_ServiceController_EditArtificiallakeEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = sender.ToString();
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
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void FormArtificiallake_Load(object sender, EventArgs e)
        {
            #region 初始化控件内容

            if (m_OperationType == OperationType.Add)
            {
                this.Text = "新增航空灭火蓄水池";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑航空灭火蓄水池";
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看航空灭火蓄水池";
            }


            /* 航空灭火蓄水池形状 */
            Shape artificiallakeShape = Shape.点;
            List<object> artificiallakeShapeList = CommonHelper.GetDataSource<Shape>(artificiallakeShape);
            this.cbx_shape.DisplayMember = "Name";
            this.cbx_shape.ValueMember = "Value";
            this.cbx_shape.DataSource = artificiallakeShapeList;

            /* 航空灭火蓄水池状态 */
            ArtificiallakeStatus artificiallakeStatus = ArtificiallakeStatus.优秀;
            List<object> artificiallakeStatusList = CommonHelper.GetDataSource<ArtificiallakeStatus>(artificiallakeStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Value";
            this.cbx_status.DataSource = artificiallakeStatusList;

            /* 航空灭火蓄水池有无电线索道 */
            ArtificiallakeIsCableway isCableway = ArtificiallakeIsCableway.是;
            List<object> isCablewayList = CommonHelper.GetDataSource<ArtificiallakeIsCableway>(isCableway);
            this.cbx_isCableway.DisplayMember = "Name";
            this.cbx_isCableway.ValueMember = "Name";
            this.cbx_isCableway.DataSource = isCablewayList;

            /* 航空灭火蓄水池能否吊桶取水 */
            ArtificiallakeIsTakeWater isTakeWater = ArtificiallakeIsTakeWater.是;
            List<object> isTakeWaterList = CommonHelper.GetDataSource<ArtificiallakeIsTakeWater>(isTakeWater);
            this.cbx_isTakeWater.DisplayMember = "Name";
            this.cbx_isTakeWater.ValueMember = "Name";
            this.cbx_isTakeWater.DataSource = isTakeWaterList;

            /* 航空灭火蓄水池管理单位 */
            ALManagementUnit aLManagementUnit = ALManagementUnit.管理单位1;
            List<object> aLManagementUnitList = CommonHelper.GetDataSource<ALManagementUnit>(aLManagementUnit);
            this.cbx_managementUnit.DisplayMember = "Name";
            this.cbx_managementUnit.ValueMember = "Value";
            this.cbx_managementUnit.DataSource = aLManagementUnitList;

            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_Artificiallake.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_Artificiallake.longitude;
                this.coordinatesInputControl1.Latitude = this.m_Artificiallake.latitude;
                this.tbx_name.Text = this.m_Artificiallake.name;
                if (this.m_Artificiallake.shape.Contains("POINT"))
                {
                    this.cbx_shape.SelectedValue = 1;
                    this.cbx_shape.Enabled = false;
                }
                else if (this.m_Artificiallake.shape.Contains("LINEstring"))
                {
                    this.cbx_shape.SelectedValue = 2;
                    this.cbx_shape.Enabled = false;
                }
                else if (this.m_Artificiallake.shape.Contains("POLYGON"))
                {
                    this.cbx_shape.SelectedValue = 3;
                    this.cbx_shape.Enabled = false;
                }
                this.cbx_status.SelectedValue = (int)this.m_Artificiallake.status;
                this.cbx_managementUnit.SelectedValue = (int)this.m_Artificiallake.management_unit;
                this.cbx_isTakeWater.SelectedValue = this.m_Artificiallake.is_take_water;
                this.tbx_manager.Text = this.m_Artificiallake.manager;
                this.tbx_phone.Text = this.m_Artificiallake.phone;
                this.tbx_volume.Text = this.m_Artificiallake.volume.ToString();
                this.tbx_storageArea.Text = this.m_Artificiallake.storage_area.ToString();
                this.tbx_storageCapacity.Text = this.m_Artificiallake.storage_capacity.ToString();
                this.tbx_maximumDepth.Text = this.m_Artificiallake.maximum_depth.ToString();
                this.tbx_trafficCondition.Text = this.m_Artificiallake.traffic_condition;

                this.tbx_note.Text = this.m_Artificiallake.note;
                this.mediaControl1.MediaFiles = this.m_Artificiallake.mediaFiles;

                if (this.m_OperationType == OperationType.Check)
                {
                    this.btnOK.Enabled = false;
                    this.btnCancel.Text = "关闭(&C)";

                    this.coordinatesInputControl1.Enabled = false;
                    this.pacControl11.Enabled = false;
                    this.tbx_name.Enabled = false;
                    this.cbx_status.Enabled = false;
                    this.cbx_managementUnit.Enabled = false;
                    this.cbx_isTakeWater.Enabled = false;
                    this.tbx_manager.Enabled = false;
                    this.tbx_phone.Enabled = false;
                    this.tbx_volume.Enabled = false;
                    this.tbx_storageArea.Enabled = false;
                    this.tbx_storageCapacity.Enabled = false;
                    this.tbx_maximumDepth.Enabled = false;
                    this.tbx_trafficCondition.Enabled = false;

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
                this.m_Artificiallake = new Fire_Artificiallake();
            }
            this.m_Artificiallake.name = this.tbx_name.Text;
            this.m_Artificiallake.longitude = this.coordinatesInputControl1.Longitude;
            this.m_Artificiallake.latitude = this.coordinatesInputControl1.Latitude;
            this.m_Artificiallake.pac = this.pacControl11.LocalPac;
            if ((int)this.cbx_shape.SelectedValue == 1)
            {
                this.m_Artificiallake.shape = GDALHelper.LngLatToWktPoint(this.m_Artificiallake.longitude, this.m_Artificiallake.latitude);
            }
            this.m_Artificiallake.status = (int)this.cbx_status.SelectedValue;
            this.m_Artificiallake.is_cableway = this.cbx_isCableway.SelectedValue.ToString();
            this.m_Artificiallake.is_take_water = this.cbx_isTakeWater.SelectedValue.ToString();
            this.m_Artificiallake.manager = this.tbx_manager.Text; ;
            this.m_Artificiallake.phone = this.tbx_phone.Text;
            this.m_Artificiallake.volume = Convert.ToDouble(this.tbx_volume.Text);
            this.m_Artificiallake.storage_area = Convert.ToDouble(this.tbx_storageArea.Text.Trim());
            this.m_Artificiallake.storage_capacity = Convert.ToDouble(this.tbx_storageCapacity.Text.Trim());
            this.m_Artificiallake.maximum_depth = Convert.ToDouble(this.tbx_maximumDepth.Text.Trim());
            this.m_Artificiallake.management_unit = (int)this.cbx_managementUnit.SelectedValue;
            this.m_Artificiallake.traffic_condition = this.tbx_trafficCondition.Text.Trim();

            this.m_Artificiallake.note = this.tbx_note.Text.Trim();
            this.m_Artificiallake.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                this.m_ServiceController.AddArtificiallakeForPost(this.m_Artificiallake);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_ServiceController.EditArtificiallakeForPost(this.m_Artificiallake);
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
        public bool IsCondition()
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
                MessageBox.Show(this, "请输入航空灭火蓄水池名称", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_name.Focus();
                return false;
            }
            if (this.cbx_shape.SelectedValue == null)
            {
                MessageBox.Show(this, "请选择航空灭火蓄水池形状", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.cbx_shape.Focus();
                return false;
            }
            if (this.cbx_status.SelectedValue == null)
            {
                MessageBox.Show(this, "请选择航空灭火蓄水池状态", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.cbx_status.Focus();
                return false;
            }
            if (this.cbx_isCableway.SelectedValue == null)
            {
                MessageBox.Show(this, "请选择航空灭火蓄水池是否有电线索道", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.cbx_isCableway.Focus();
                return false;
            }
            if (this.cbx_isTakeWater.SelectedValue == null)
            {
                MessageBox.Show(this, "请选择航空灭火蓄水池能否吊桶取水", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.cbx_isTakeWater.Focus();
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
                MessageBox.Show(this, "请选输入管理员电话", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_phone.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_volume.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的容积量", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_volume.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的容积量", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_volume.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_storageArea.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的蓄水面积", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_storageArea.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的蓄水面积", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_storageArea.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_storageCapacity.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的蓄水容量", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_storageCapacity.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的蓄水容量", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_storageCapacity.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_storageCapacity.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的蓄水容量", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_storageCapacity.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的蓄水容量", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_storageCapacity.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_maximumDepth.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的最大深度", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_maximumDepth.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的最大深度", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_maximumDepth.Focus();
                return false;
            }
            if (this.cbx_managementUnit.SelectedValue == null)
            {
                MessageBox.Show(this, "请选择航空灭火蓄水池管理单位", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.cbx_managementUnit.Focus();
                return false;
            }
            if(this.tbx_trafficCondition.Text.Trim()=="")
            {
                MessageBox.Show(this, "请输入交通情况", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_trafficCondition.Focus();
                return false;
            }
            return true;
        }
    }
}
