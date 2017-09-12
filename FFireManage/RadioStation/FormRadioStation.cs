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

namespace FFireManage.RadioStation
{
    public partial class FormRadioStation : Form
    {
        private Fire_RadioStation m_RadioStation = null;
        private OperationType m_OperationType;
        private RadioStationController m_RadioStationController = null;

        public FormRadioStation(OperationType type, Fire_RadioStation radioStation = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_RadioStation = radioStation;
            this.m_RadioStationController = new RadioStationController();

            this.m_RadioStationController.AddEvent += m_RadioStationController_AddEvent;
            this.m_RadioStationController.EditEvent += m_RadioStationController_EditEvent;
        }

        private void m_RadioStationController_AddEvent(object sender, ServiceEventArgs e)
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

        private void m_RadioStationController_EditEvent(object sender, ServiceEventArgs e)
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

        private void FormRadioStation_Load(object sender, EventArgs e)
        {
            #region 初始化控件内容

            if (m_OperationType == OperationType.Add)
            {
                this.Text = "新增无线电台站";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑无线电台站";
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看无线电台站";
            }

            /* 瞭望台状态 */
            RadioStationStatus radioStationStatus = RadioStationStatus.优秀;
            List<object> watchTowerStatusList = CommonHelper.GetDataSource<RadioStationStatus>(radioStationStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Value";
            this.cbx_status.DataSource = watchTowerStatusList;


            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_RadioStation.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_RadioStation.longitude;
                this.coordinatesInputControl1.Latitude = this.m_RadioStation.latitude;

                //窗体自动赋值
                SmartForm.Fill(this.tabPage_baseInfo.Controls, this.m_RadioStation);

                this.tbx_note.Text = this.m_RadioStation.note;
                this.mediaControl1.MediaFiles = this.m_RadioStation.mediaFiles;

                if (this.m_OperationType == OperationType.Check)
                {
                    this.btnOK.Enabled = false;
                    this.btnCancel.Text = "关闭(&C)";

                    this.coordinatesInputControl1.Enabled = false;
                    this.pacControl11.Enabled = false;

                    SmartForm.SetControlsEnabled(this.tabPage_baseInfo.Controls, null);

                    this.tbx_note.Enabled = false;

                    this.mediaControl1.MainToolStrip.Visible = false;
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
                dict = m_RadioStation.ObjectDescriptionToDict();
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
                this.m_RadioStation = new Fire_RadioStation();
            }
            this.m_RadioStation.longitude = this.coordinatesInputControl1.Longitude;
            this.m_RadioStation.latitude = this.coordinatesInputControl1.Latitude;
            this.m_RadioStation.pac = this.pacControl11.LocalPac;
            this.m_RadioStation.city = this.pacControl11.City;
            this.m_RadioStation.county = this.pacControl11.County;
            this.m_RadioStation.shape = Converters.LngLatToWKT(this.m_RadioStation.longitude, this.m_RadioStation.latitude);

            //自动从窗体控件上取值
            this.m_RadioStation = SmartForm.GetEntity<Fire_RadioStation>(this.tabPage_baseInfo.Controls, this.m_RadioStation);

            this.m_RadioStation.build_year = this.dtp_build_year.Value.ToString("yyyy-MM-dd hh:mm:ss");
            this.m_RadioStation.note = this.tbx_note.Text.Trim();
            this.m_RadioStation.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                this.m_RadioStationController.Add(this.m_RadioStation);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_RadioStationController.Edit(this.m_RadioStation);
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
                MessageBox.Show(this, "请输入无线电台站名称", "信息提示");
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
            if (this.tbx_num_radio.Text.Trim() == "")
            {
                MessageBox.Show(this, "请选输入电台呼号", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_num_radio.Focus();
                return false;
            }
            if (this.tbx_radioname.Text.Trim() == "")
            {
                MessageBox.Show(this, "请选输入电台名称", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_radioname.Focus();
                return false;
            }
            if (this.tbx_coding.Text.Trim() == "")
            {
                MessageBox.Show(this, "请选输入电台编号", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_coding.Focus();
                return false;
            }
            if (this.tbx_r_frequenc.Text.Trim() == "")
            {
                MessageBox.Show(this, "请选输入接收频率", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_r_frequenc.Focus();
                return false;
            }
            if (this.tbx_l_frequenc.Text.Trim() == "")
            {
                MessageBox.Show(this, "请选输入发射频率", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_l_frequenc.Focus();
                return false;
            }
            if (this.tbx_power.Text.Trim() == "")
            {
                MessageBox.Show(this, "请选输入发射功率", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_power.Focus();
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
                double num = Convert.ToDouble(this.tbx_height.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的天线高度", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_height.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的天线高度", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_height.Focus();
                return false;
            }
            return true;
        }
    }
}
