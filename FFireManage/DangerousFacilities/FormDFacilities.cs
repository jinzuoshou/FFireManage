using FFireManage.Controls;
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

namespace FFireManage.DangerousFacilities
{
    public partial class FormDFacilities : Form
    {
        private Fire_DangerousFacilities m_DangerousFacilities = null;
        private OperationType m_OperationType;
        private ServiceController m_ServiceController = null;

        public FormDFacilities(OperationType type, Fire_DangerousFacilities dangerousFacilities = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_DangerousFacilities = dangerousFacilities;
            this.m_ServiceController = new ServiceController();

            this.m_ServiceController.AddDangerousFacilitiesEvent += M_ServiceController_AddDangerousFacilitiesEvent;
            this.m_ServiceController.EditDangerousFacilitiesEvent += M_ServiceController_EditDangerousFacilitiesEvent;
        }

        private void M_ServiceController_AddDangerousFacilitiesEvent(object sender, EventArgs e)
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

        private void M_ServiceController_EditDangerousFacilitiesEvent(object sender, EventArgs e)
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
                this.Text = "新增林区危险及重要设施";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑林区危险及重要设施";
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看林区危险及重要设施";
            }


            /* 林区危险及重要性设备设施形状 */
            Shape dFacilitiesShape = Shape.点;
            List<object> dFacilitiesShapeList = CommonHelper.GetDataSource<Shape>(dFacilitiesShape);
            this.cbx_shape.DisplayMember = "Name";
            this.cbx_shape.ValueMember = "Value";
            this.cbx_shape.DataSource = dFacilitiesShapeList;
            this.cbx_shape.SelectedValue = 1;
            this.cbx_shape.Enabled = false;

            /* 林区危险及重要性设备设施状态 */
            DFacilitiesStatus dFacilitiesStatus = DFacilitiesStatus.优秀;
            List<object> dFacilitiesStatusList = CommonHelper.GetDataSource<DFacilitiesStatus>(dFacilitiesStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Value";
            this.cbx_status.DataSource = dFacilitiesStatusList;

            /* 林区危险及重要性设备设施类型 */
            DFacilitiesType dFacilitiesType = DFacilitiesType.类型1;
            List<object> dFacilitiesTypeList = CommonHelper.GetDataSource<DFacilitiesType>(dFacilitiesType);
            this.cbx_type.DisplayMember = "Name";
            this.cbx_type.ValueMember = "Value";
            this.cbx_type.DataSource = dFacilitiesTypeList;

            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_DangerousFacilities.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_DangerousFacilities.longitude;
                this.coordinatesInputControl1.Latitude = this.m_DangerousFacilities.latitude;
                this.tbx_name.Text = this.m_DangerousFacilities.name;
                if (this.m_DangerousFacilities.shape.Contains("POINT"))
                {
                    this.cbx_shape.SelectedValue = 1;
                }
                else if (this.m_DangerousFacilities.shape.Contains("LINEstring"))
                {
                    this.cbx_shape.SelectedValue = 2;
                }
                else if (this.m_DangerousFacilities.shape.Contains("POLYGON"))
                {
                    this.cbx_shape.SelectedValue = 3;
                }
                this.cbx_status.SelectedValue = (int)this.m_DangerousFacilities.status;
                this.cbx_type.SelectedValue = (int)this.m_DangerousFacilities.type;
                this.tbx_content.Text = this.m_DangerousFacilities.content;
                this.tbx_manager.Text = this.m_DangerousFacilities.manager;
                this.tbx_phone.Text = this.m_DangerousFacilities.phone;

                this.tbx_note.Text = this.m_DangerousFacilities.note;
                this.mediaControl1.MediaFiles = this.m_DangerousFacilities.mediaFiles;

                if (this.m_OperationType == OperationType.Check)
                {
                    this.btnOK.Enabled = false;
                    this.btnCancel.Text = "关闭(&C)";

                    this.coordinatesInputControl1.Enabled = false;
                    this.pacControl11.Enabled = false;
                    this.tbx_name.Enabled = false;
                    this.tbx_content.Enabled = false;
                    this.cbx_shape.Enabled = false;
                    this.cbx_status.Enabled = false;
                    this.cbx_type.Enabled = false;
                    this.tbx_manager.Enabled = false;
                    this.tbx_phone.Enabled = false;
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
                this.m_DangerousFacilities = new Fire_DangerousFacilities();
            }
            this.m_DangerousFacilities.longitude = this.coordinatesInputControl1.Longitude;
            this.m_DangerousFacilities.latitude = this.coordinatesInputControl1.Latitude;
            this.m_DangerousFacilities.pac = this.pacControl11.LocalPac;
            this.m_DangerousFacilities.name = this.tbx_name.Text;
            if ((int)this.cbx_shape.SelectedValue == 1)
            {
                this.m_DangerousFacilities.shape = GDALHelper.LngLatToWktPoint(this.m_DangerousFacilities.longitude, this.m_DangerousFacilities.latitude);
            }
            this.m_DangerousFacilities.status = (int)this.cbx_status.SelectedValue;
            this.m_DangerousFacilities.type = (int)this.cbx_type.SelectedValue;
            this.m_DangerousFacilities.content = this.tbx_content.Text;
            this.m_DangerousFacilities.manager = this.tbx_manager.Text; ;
            this.m_DangerousFacilities.phone = this.tbx_phone.Text;
            

            this.m_DangerousFacilities.note = this.tbx_note.Text.Trim();
            this.m_DangerousFacilities.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                FormWaitingBox f = new FormWaitingBox((obj, args) =>
                {
                    this.m_ServiceController.AddDangerousFacilitiesForPost(this.m_DangerousFacilities);
                }, 10, "正在提交数据，请耐心等待....", false, false);
                f.ShowDialog(this);
                
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_ServiceController.EditDangerousFacilitiesForPost(this.m_DangerousFacilities);
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
                MessageBox.Show(this, "请输入林区危险及重要性设备设施名称", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_name.Focus();
                return false;
            }
            if (this.cbx_shape.SelectedValue == null)
            {
                MessageBox.Show(this, "请选择形状", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.cbx_shape.Focus();
                return false;
            }
            if (this.cbx_status.SelectedValue == null)
            {
                MessageBox.Show(this, "请选择状态", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.cbx_status.Focus();
                return false;
            }
            if (this.cbx_type.SelectedValue == null)
            {
                MessageBox.Show(this, "请选择类型", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.cbx_type.Focus();
                return false;
            }
            if (this.tbx_content.Text == "")
            {
                MessageBox.Show(this, "请输入重要设施或危险品名称", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_content.Focus();
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
            return true;
        }

    }
}
