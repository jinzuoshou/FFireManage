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

namespace FFireManage.FireDocument
{
    public partial class FormFireDocument : Form
    {
        #region private fields
        private Fire_Document m_FireDocument = null;
        private OperationType m_OperationType;
        private FireDocumentController m_FireDocumentController = null;
        #endregion

        #region constructor
        public FormFireDocument(OperationType type, Fire_Document fireDocument = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_FireDocument = fireDocument;

            this.m_FireDocumentController = new FireDocumentController();
            this.m_FireDocumentController.AddEvent += M_ServiceController_AddEvent;
            this.m_FireDocumentController.EditEvent += M_ServiceController_EditEvent;
            this.m_FireDocumentController.AddMediaEvent += M_FireDocumentController_AddMediaEvent;
            this.m_FireDocumentController.DeleteMediaEvent += M_FireDocumentController_DeleteMediaEvent;

            this.mediaControl1.AddEvent += MediaControl1_AddEvent;
            this.mediaControl1.DeleteEvent += MediaControl1_DeleteEvent;
        }


        #endregion

        #region event methods

        private void MediaControl1_DeleteEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null && this.m_OperationType != OperationType.Add)
                {
                    MediaFile content = sender as MediaFile;
                    if (content != null)
                    {
                        this.m_FireDocumentController.DeleteMedia(content.id);
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
                        this.m_FireDocumentController.AddMedia(this.m_FireDocument.id, content);
                    }
                }
            }));
        }

        private void M_FireDocumentController_DeleteMediaEvent(object sender, ServiceEventArgs e)
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

        private void M_FireDocumentController_AddMediaEvent(object sender, ServiceEventArgs e)
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

        private void FormFireDocument_Load(object sender, EventArgs e)
        {
            #region 初始化控件内容

            if (m_OperationType == OperationType.Add)
            {
                this.Text = "新增火灾档案";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑火灾档案";
                this.mediaControl1.IsMultiselect = false;
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看火灾档案";
                this.mediaControl1.MainToolStrip.Visible = false;
            }

            /* 坡位 */
            FireDocumentSlopePosition fireDSlopePosition = FireDocumentSlopePosition.山脊;
            List<object> fireDSlopePositionList = CommonHelper.GetDataSource<FireDocumentSlopePosition>(fireDSlopePosition);
            this.cbx_slope_position.DisplayMember = "Name";
            this.cbx_slope_position.ValueMember = "Name";
            this.cbx_slope_position.DataSource = fireDSlopePositionList;

            /* 是否已处理 */
            IsDealWith isDealWith = IsDealWith.否;
            List<object> isDealWithList = CommonHelper.GetDataSource<IsDealWith>(isDealWith);
            this.cbx_IsDealWith.DisplayMember = "Name";
            this.cbx_IsDealWith.ValueMember = "Value";
            this.cbx_IsDealWith.DataSource = isDealWithList;
            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_FireDocument.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = (this.m_FireDocument.longitude==null)?0:(double)this.m_FireDocument.longitude;
                this.coordinatesInputControl1.Latitude = (this.m_FireDocument.latitude == null) ? 0 : (double)this.m_FireDocument.latitude;
                this.tbx_town_name.Text = (this.m_FireDocument.town_name==null)?"":this.m_FireDocument.town_name;
                this.tbx_village_name.Text = (this.m_FireDocument.village_name == null) ? "" : this.m_FireDocument.village_name;
                SmartForm.Fill(this.tabPage_baseInfo.Controls, this.m_FireDocument);

                this.tbx_description.Text = this.m_FireDocument.description;
                this.mediaControl1.MediaFiles = this.m_FireDocument.mediaFiles;

                if (this.m_OperationType == OperationType.Check)
                {
                    this.btnOK.Enabled = false;
                    this.btnCancel.Text = "关闭(&C)";

                    this.coordinatesInputControl1.Enabled = false;
                    this.pacControl11.Enabled = false;
                    this.tbx_town_name.Enabled = false;
                    this.tbx_village_name.Enabled = false;

                    SmartForm.SetControlsEnabled(this.tabPage_baseInfo.Controls,null);

                    this.tbx_description.Enabled = false;


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
                dict = m_FireDocument.ObjectDescriptionToDict();
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
                this.m_FireDocument = new Fire_Document();
            }

            this.m_FireDocument.longitude = this.coordinatesInputControl1.Longitude;
            this.m_FireDocument.latitude = this.coordinatesInputControl1.Latitude;
            this.m_FireDocument.pac = this.pacControl11.LocalPac;
            this.m_FireDocument.code = this.m_FireDocument.pac;
            this.m_FireDocument.province = this.pacControl11.Province;
            this.m_FireDocument.city = this.pacControl11.City;
            this.m_FireDocument.county = this.pacControl11.County;
            this.m_FireDocument.town_name = this.tbx_town_name.Text.Trim();
            this.m_FireDocument.village_name = this.tbx_village_name.Text.Trim();
            this.m_FireDocument.shape = Converters.LngLatToWKT((double)this.m_FireDocument.longitude, (double)this.m_FireDocument.latitude);

            //自动从窗体控件上取值
            m_FireDocument = SmartForm.GetEntity<Fire_Document>(this.tabPage_baseInfo.Controls, this.m_FireDocument);

            this.m_FireDocument.description = this.tbx_description.Text.Trim();
            this.m_FireDocument.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                this.m_FireDocumentController.Add(this.m_FireDocument);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_FireDocumentController.Edit(this.m_FireDocument);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFireDocument_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mediaControl1.Dispose();
        }
        #endregion

        #region members methods
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
            if (this.tbx_town_name.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入乡镇名", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_location;
                this.tbx_town_name.Focus();
                return false;
            }
            if (this.tbx_village_name.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入村名", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_location;
                this.tbx_village_name.Focus();
                return false;
            }
            return true;
        }
        #endregion

    }
}
