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

namespace FFireManage.FireOffice
{
    public partial class FormFireOffice : Form
    {
        private Fire_Office m_FireOffice = null;
        private OperationType m_OperationType;
        private FireOfficeController m_FireOfficeController = null;

        public FormFireOffice(OperationType type, Fire_Office fireOffice = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_FireOffice = fireOffice;
            this.m_FireOfficeController = new FireOfficeController();

            this.m_FireOfficeController.AddEvent += M_ServiceController_AddEvent;
            this.m_FireOfficeController.EditEvent += M_ServiceController_EditEvent;
        }

        private void M_ServiceController_AddEvent(object sender, ServiceEventArgs e)
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
                    catch (Exception ex)
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

        private void M_ServiceController_EditEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    try
                    {
                        BaseResultInfo<object> result = JsonHelper.JSONToObject<BaseResultInfo<object>>(content);

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

        private void FormFireForestBelt_Load(object sender, EventArgs e)
        {
            #region 初始化控件内容

            if (m_OperationType == OperationType.Add)
            {
                this.Text = "新增森林防火办公室";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑森林防火办公室";
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看森林防火办公室";
            }

            /* 森林防火办公室状态 */
            FireOfficeStatus fireOfficeStatus = FireOfficeStatus.优秀;
            List<object> fireOfficeStatusList = CommonHelper.GetDataSource<FireOfficeStatus>(fireOfficeStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Name";
            this.cbx_status.DataSource = fireOfficeStatusList;

            /* 森林防火办公室类型 */
            FireOfficeType fireOfficeType = FireOfficeType.防火指挥部;
            List<object> fireOfficeTypeList = CommonHelper.GetDataSource<FireOfficeType>(fireOfficeType);
            this.cbx_type.DisplayMember = "Name";
            this.cbx_type.ValueMember = "Name";
            this.cbx_type.DataSource = fireOfficeTypeList;

            /* 森林防火办公室级别 */
            FireOfficeLevel fireOfficeLevel = FireOfficeLevel.省级;
            List<object> fireOfficeLevelList = CommonHelper.GetDataSource<FireOfficeLevel>(fireOfficeLevel);
            this.cbx_level.DisplayMember = "Name";
            this.cbx_level.ValueMember = "Name";
            this.cbx_level.DataSource = fireOfficeLevelList;

            /* 森林防火办公室机构编制 */
            FireOfficeInstitutions fireOfficeInstitutions = FireOfficeInstitutions.行政;
            List<object> fireOfficeInstitutionsList = CommonHelper.GetDataSource<FireOfficeInstitutions>(fireOfficeInstitutions);
            this.cbx_institutions.DisplayMember = "Name";
            this.cbx_institutions.ValueMember = "Name";
            this.cbx_institutions.DataSource = fireOfficeLevelList;

            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_FireOffice.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_FireOffice.longitude;
                this.coordinatesInputControl1.Latitude = this.m_FireOffice.latitude;
                SmartForm.Fill(this.tabPage_baseInfo.Controls, this.m_FireOffice);

                this.tbx_note.Text = this.m_FireOffice.note;
                this.mediaControl1.MediaFiles = this.m_FireOffice.mediaFiles;

                if (this.m_OperationType == OperationType.Check)
                {
                    this.btnOK.Enabled = false;
                    this.btnCancel.Text = "关闭(&C)";

                    this.coordinatesInputControl1.Enabled = false;
                    this.pacControl11.Enabled = false;
                    SmartForm.SetControlsEnabled(this.tabPage_baseInfo.Controls,null);

                    this.tbx_note.Enabled = false;


                }
            }
            #endregion
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!IsCondition())
                return;
            IDictionary<string, string> dict = new Dictionary<string,string>();
            try
            {
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                dict = m_FireOffice.ObjectDescriptionToDict();
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
                this.m_FireOffice = new Fire_Office();
            }

            this.m_FireOffice.longitude = this.coordinatesInputControl1.Longitude;
            this.m_FireOffice.latitude = this.coordinatesInputControl1.Latitude;
            this.m_FireOffice.pac = this.pacControl11.LocalPac;
            this.m_FireOffice.shape = Converters.LngLatToWKT(this.m_FireOffice.longitude, this.m_FireOffice.latitude);

            //自动从窗体控件上取值
            m_FireOffice = SmartForm.GetEntity<Fire_Office>(this.tabPage_baseInfo.Controls, this.m_FireOffice);

            this.m_FireOffice.note = this.tbx_note.Text.Trim();
            this.m_FireOffice.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                this.m_FireOfficeController.Add(this.m_FireOffice);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_FireOfficeController.Edit(this.m_FireOffice);
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
            return true;
        }
    }
}
