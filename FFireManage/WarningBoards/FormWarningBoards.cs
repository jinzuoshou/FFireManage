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

namespace FFireManage.WarningBoards
{
    public partial class FormWarningBoards : Form
    {
        #region Fields
        private Fire_WarningBoards m_FireWarningBoards = null;
        private OperationType m_OperationType;
        private WarningBoardsController m_WarningBoardsController = null;
        #endregion

        #region Constructor
        public FormWarningBoards(OperationType type, Fire_WarningBoards fireWarningBoards = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_FireWarningBoards = fireWarningBoards;

            this.m_WarningBoardsController = new WarningBoardsController();
            this.m_WarningBoardsController.AddEvent += m_WarningBoardsController_AddEvent;
            this.m_WarningBoardsController.EditEvent += m_WarningBoardsController_EditEvent;
            this.m_WarningBoardsController.AddMediaEvent += M_WarningBoardsController_AddMediaEvent;
            this.m_WarningBoardsController.DeleteMediaEvent += M_WarningBoardsController_DeleteMediaEvent;

            this.mediaControl1.AddEvent += MediaControl1_AddEvent;
            this.mediaControl1.DeleteEvent += MediaControl1_DeleteEvent;
        }
        #endregion

        #region Event Methods
        private void MediaControl1_DeleteEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null && this.m_OperationType != OperationType.Add)
                {
                    MediaFile content = sender as MediaFile;
                    if (content != null)
                    {
                        this.m_WarningBoardsController.DeleteMedia(content.id);
                    }
                }
            }));
        }

        private void MediaControl1_AddEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null && this.m_OperationType != OperationType.Add)
                {
                    Dictionary<string, object> content = sender as Dictionary<string, object>;
                    if (content != null)
                    {
                        this.m_WarningBoardsController.AddMedia(this.m_FireWarningBoards.id, content);
                    }
                }
            }));
        }

        private void M_WarningBoardsController_DeleteMediaEvent(object sender, ServiceEventArgs e)
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

        private void M_WarningBoardsController_AddMediaEvent(object sender, ServiceEventArgs e)
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

        private void m_WarningBoardsController_AddEvent(object sender, ServiceEventArgs e)
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

        private void m_WarningBoardsController_EditEvent(object sender, ServiceEventArgs e)
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

        private void FormWarningBoards_Load(object sender, EventArgs e)
        {
            #region 初始化控件内容

            if (m_OperationType == OperationType.Add)
            {
                this.Text = "新增大型警示牌";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑大型警示牌";
                this.mediaControl1.IsMultiselect = false;
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看大型警示牌";
                this.mediaControl1.MainToolStrip.Visible = false;
            }

            /* 大型警示牌类型 */
            WarningBoardsType warningBoardsType = WarningBoardsType.宣传牌;
            List<object> warningBoardsTypeList = CommonHelper.GetDataSource<WarningBoardsType>(warningBoardsType);
            this.cbx_type.DisplayMember = "Name";
            this.cbx_type.ValueMember = "Name";
            this.cbx_type.DataSource = warningBoardsTypeList;

            /* 大型警示牌状态 */
            WarningBoardsStatus warningBoardsStatus = WarningBoardsStatus.优秀;
            List<object> warningBoardsStatusList = CommonHelper.GetDataSource<WarningBoardsStatus>(warningBoardsStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Name";
            this.cbx_status.DataSource = warningBoardsStatusList;

            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_FireWarningBoards.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_FireWarningBoards.longitude;
                this.coordinatesInputControl1.Latitude = this.m_FireWarningBoards.latitude;
                SmartForm.Fill(this.tabPage_baseInfo.Controls, this.m_FireWarningBoards);

                this.tbx_note.Text = this.m_FireWarningBoards.note;
                this.mediaControl1.MediaFiles = this.m_FireWarningBoards.mediaFiles;

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
                dict = m_FireWarningBoards.ObjectDescriptionToDict();
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
                this.m_FireWarningBoards = new Fire_WarningBoards();
            }

            this.m_FireWarningBoards.longitude = this.coordinatesInputControl1.Longitude;
            this.m_FireWarningBoards.latitude = this.coordinatesInputControl1.Latitude;
            this.m_FireWarningBoards.pac = this.pacControl11.LocalPac;
            this.m_FireWarningBoards.SHAPE = Converters.LngLatToWKT(this.m_FireWarningBoards.longitude, this.m_FireWarningBoards.latitude);

            //自动从窗体控件上取值
            m_FireWarningBoards = SmartForm.GetEntity<Fire_WarningBoards>(this.tabPage_baseInfo.Controls, this.m_FireWarningBoards);

            this.m_FireWarningBoards.build_year = this.dtp_build_year.Value.ToString("yyyy-MM-dd hh:mm:ss");
            this.m_FireWarningBoards.note = this.tbx_note.Text.Trim();
            this.m_FireWarningBoards.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                this.m_WarningBoardsController.Add(this.m_FireWarningBoards);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_WarningBoardsController.Edit(this.m_FireWarningBoards);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormWarningBoards_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
        #endregion

        #region Members Methods
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
        #endregion

    }
}
