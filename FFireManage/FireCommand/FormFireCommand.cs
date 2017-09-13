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

namespace FFireManage.FireCommand
{
    public partial class FormFireCommand : Form
    {
        private Fire_Command m_FireCommand = null;
        private OperationType m_OperationType;
        private FireCommandController m_FireCommandController = null;

        public FormFireCommand(OperationType type, Fire_Command fireCommand = null)
        {
            InitializeComponent();
            this.m_OperationType = type;
            this.m_FireCommand = fireCommand;
            this.m_FireCommandController = new FireCommandController();

            this.m_FireCommandController.AddEvent += m_FireCommandController_AddEvent;
            this.m_FireCommandController.EditEvent += m_FireCommandController_EditEvent;
        }

        private void m_FireCommandController_EditEvent(object sender, ServiceEventArgs e)
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

        private void m_FireCommandController_AddEvent(object sender, ServiceEventArgs e)
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

        private void FormFireCommand_Load(object sender, EventArgs e)
        {
            #region 初始化控件内容

            if (m_OperationType == OperationType.Add)
            {
                this.Text = "新增森林防火指挥部";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑森林防火指挥部";
                this.mediaControl1.IsMultiselect = false;
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看森林防火指挥部";
                this.mediaControl1.MainToolStrip.Visible = false;
            }

            /* 森林防火指挥部类型 */
            FireCommandType fireCommandType = FireCommandType.其它事业机构;
            List<object> fireCommandTypeList = CommonHelper.GetDataSource<FireCommandType>(fireCommandType);
            this.cbx_type.DisplayMember = "Name";
            this.cbx_type.ValueMember = "Name";
            this.cbx_type.DataSource = fireCommandTypeList;

            /* 森林防火指挥部机构编制 */
            FireCommandInstitutions fireCommandInstitutions = FireCommandInstitutions.行政;
            List<object> fireCommandInstitutionsList = CommonHelper.GetDataSource<FireCommandInstitutions>(fireCommandInstitutions);
            this.cbx_institutions.DisplayMember = "Name";
            this.cbx_institutions.ValueMember = "Name";
            this.cbx_institutions.DataSource = fireCommandInstitutionsList;

            /* 森林防火指挥部形状 */
            FireCommandLevel fireCommandLevel = FireCommandLevel.省级;
            List<object> fireCommandShapeList = CommonHelper.GetDataSource<FireCommandLevel>(fireCommandLevel);
            this.cbx_level.DisplayMember = "Name";
            this.cbx_level.ValueMember = "Name";
            this.cbx_level.DataSource = fireCommandShapeList;

            /* 森林防火指挥部状态 */
            FireCommandStatus fireCommandStatus = FireCommandStatus.优秀;
            List<object> fireCommandStatusList = CommonHelper.GetDataSource<FireCommandStatus>(fireCommandStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Value";
            this.cbx_status.DataSource = fireCommandStatusList;

            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_FireCommand.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_FireCommand.longitude;
                this.coordinatesInputControl1.Latitude = this.m_FireCommand.latitude;

                SmartForm.Fill(this.tabPage_baseInfo.Controls, this.m_FireCommand);

                this.mediaControl1.MediaFiles = this.m_FireCommand.mediaFiles;

                if (this.m_OperationType == OperationType.Check)
                {
                    this.btnOK.Enabled = false;
                    this.btnCancel.Text = "关闭(&C)";

                    SmartForm.SetControlsEnabled(this.tabPage_baseInfo.Controls, null);

                    this.pacControl11.Enabled = false;


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
                dict = this.m_FireCommand.ObjectDescriptionToDict();
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
                this.m_FireCommand = new Fire_Command();
            }
            this.m_FireCommand.longitude = this.coordinatesInputControl1.Longitude;
            this.m_FireCommand.latitude = this.coordinatesInputControl1.Latitude;
            this.m_FireCommand.pac=this.pacControl11.LocalPac;

            //自动从窗体控件上取值
            m_FireCommand = SmartForm.GetEntity<Fire_Command>(this.tabPage_baseInfo.Controls, this.m_FireCommand);

            this.m_FireCommand.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                this.m_FireCommandController.Add(this.m_FireCommand);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_FireCommandController.Edit(this.m_FireCommand);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
            if (this.tbx_name.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入森林防火指挥部名称", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_name.Focus();
                return false;
            }
            return true;
        }
    }
}
