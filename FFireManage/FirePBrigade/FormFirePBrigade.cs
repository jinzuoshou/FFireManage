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

namespace FFireManage.FirePBrigade
{
    public partial class FormFirePBrigade : Form
    {
        private Fire_PBrigade m_FirePBrigade = null;
        private OperationType m_OperationType;
        private FirePBrigadeController m_FirePBrigadeController = null;

        public FormFirePBrigade(OperationType type, Fire_PBrigade firePBrigade = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_FirePBrigade = firePBrigade;
            this.m_FirePBrigadeController = new FirePBrigadeController();

            this.m_FirePBrigadeController.AddEvent += M_ServiceController_AddEvent;
            this.m_FirePBrigadeController.EditEvent += M_ServiceController_EditEvent;
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
                this.Text = "新增专业森林消防队";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑专业森林消防队";
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看专业森林消防队";
            }

            /* 专业森林防火队状态 */
            FirePBrigadeStatus firePBrigateStatus = FirePBrigadeStatus.优秀;
            List<object> firePBrigateStatusList = CommonHelper.GetDataSource<FirePBrigadeStatus>(firePBrigateStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Name";
            this.cbx_status.DataSource = firePBrigateStatusList;

            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_FirePBrigade.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_FirePBrigade.longitude;
                this.coordinatesInputControl1.Latitude = this.m_FirePBrigade.latitude;
                SmartForm.Fill(this.tabPage_baseInfo.Controls, this.m_FirePBrigade);

                this.tbx_note.Text = this.m_FirePBrigade.note;
                this.mediaControl1.MediaFiles = this.m_FirePBrigade.mediaFiles;

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
                dict = m_FirePBrigade.ObjectDescriptionToDict();
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
                this.m_FirePBrigade = new Fire_PBrigade();
            }

            this.m_FirePBrigade.longitude = this.coordinatesInputControl1.Longitude;
            this.m_FirePBrigade.latitude = this.coordinatesInputControl1.Latitude;
            this.m_FirePBrigade.pac = this.pacControl11.LocalPac;
            this.m_FirePBrigade.shape = Converters.LngLatToWKT(this.m_FirePBrigade.longitude, this.m_FirePBrigade.latitude);

            //自动从窗体控件上取值
            m_FirePBrigade = SmartForm.GetEntity<Fire_PBrigade>(this.tabPage_baseInfo.Controls, this.m_FirePBrigade);

            this.m_FirePBrigade.note = this.tbx_note.Text.Trim();
            this.m_FirePBrigade.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                this.m_FirePBrigadeController.Add(this.m_FirePBrigade);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_FirePBrigadeController.Edit(this.m_FirePBrigade);
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
