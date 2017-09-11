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
        private DangerousFacilitiesController m_DFacilitiesController = null;

        public FormDFacilities(OperationType type, Fire_DangerousFacilities dangerousFacilities = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_DangerousFacilities = dangerousFacilities;
            this.m_DFacilitiesController = new DangerousFacilitiesController();

            this.m_DFacilitiesController.AddEvent += m_DFacilitiesController_AddEvent;
            this.m_DFacilitiesController.EditEvent += m_DFacilitiesController_EditEvent;
        }

        private void m_DFacilitiesController_AddEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content =e.Content;
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

        private void m_DFacilitiesController_EditEvent(object sender, ServiceEventArgs e)
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

            /* 林区危险及重要性设备设施状态 */
            DFacilitiesStatus dFacilitiesStatus = DFacilitiesStatus.优秀;
            List<object> dFacilitiesStatusList = CommonHelper.GetDataSource<DFacilitiesStatus>(dFacilitiesStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Value";
            this.cbx_status.DataSource = dFacilitiesStatusList;

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

                SmartForm.Fill(this.tabPage_baseInfo.Controls, this.m_DangerousFacilities);

                this.mediaControl1.MediaFiles = this.m_DangerousFacilities.mediaFiles;

                if (this.m_OperationType == OperationType.Check)
                {
                    this.btnOK.Enabled = false;
                    this.btnCancel.Text = "关闭(&C)";

                    this.coordinatesInputControl1.Enabled = false;
                    this.pacControl11.Enabled = false;

                    SmartForm.SetControlsEnabled(this.tabPage_baseInfo.Controls, null);
                }
            }
            #endregion
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!IsCondition())
                return;
            IDictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                dict = m_DangerousFacilities.ObjectDescriptionToDict();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (!SmartForm.Validator(this.tabPage_baseInfo.Controls, dict))
            {
                return;
            }
            if (m_OperationType == OperationType.Add)
            {
                this.m_DangerousFacilities = new Fire_DangerousFacilities();
            }
            this.m_DangerousFacilities.longitude = this.coordinatesInputControl1.Longitude;
            this.m_DangerousFacilities.latitude = this.coordinatesInputControl1.Latitude;
            this.m_DangerousFacilities.pac = this.pacControl11.LocalPac;
            //自动从窗体控件上取值
            m_DangerousFacilities = SmartForm.GetEntity<Fire_DangerousFacilities>(this.tabPage_baseInfo.Controls, this.m_DangerousFacilities);
            this.m_DangerousFacilities.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                FormWaitingBox f = new FormWaitingBox((obj, args) =>
                {
                    this.m_DFacilitiesController.Add(this.m_DangerousFacilities);
                }, 10, "正在提交数据，请耐心等待....", false, false);
                f.ShowDialog(this);
                
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_DFacilitiesController.Edit(this.m_DangerousFacilities);
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
            
            return true;
        }

    }
}
