using System;
using System.Windows.Forms;
using System.Drawing;
using FFireManage.Service;
using System.Collections.Generic;
using FFireManage.Utility;

namespace FFireManage.Monitor
{
    public partial class FormMonitor : Form
    {
        private Fire_ForestRemoteMonitoring m_Monitor = null;
        private OperationType m_OperationType;
        private MonitoringController m_MonitoringController = null;

        public FormMonitor(OperationType type, Fire_ForestRemoteMonitoring monitor =null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_Monitor = monitor;
            this.m_MonitoringController = new MonitoringController();

            this.m_MonitoringController.AddEvent += m_MonitoringController_AddEvent;
            this.m_MonitoringController.EditEvent += m_MonitoringController_EditEvent;
        }

        private void m_MonitoringController_EditEvent(object sender, ServiceEventArgs e)
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

        private void m_MonitoringController_AddEvent(object sender, ServiceEventArgs e)
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
                        MessageBox.Show(this,ex.Message, "提示");
                    }
                    
                }
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void FormMonitoring_Load(object sender, EventArgs e)
        {
            #region 初始化控件内容

            if (m_OperationType == OperationType.Add)
            {
                this.Text = "新增视频监控点";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑视频监控点";
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看视频监控点";
            }

            ChannelType channelType = ChannelType.stream1;
            List<object> channel1TypeList = CommonHelper.GetDataSource<ChannelType>(channelType);
            this.cbxChannel1.DisplayMember = "Name";
            this.cbxChannel1.ValueMember = "Value";
            this.cbxChannel1.DataSource = channel1TypeList;

            List<object> channel2TypeList = CommonHelper.GetDataSource<ChannelType>(channelType);
            this.cbxChannel2.DisplayMember = "Name";
            this.cbxChannel2.ValueMember = "Value";
            this.cbxChannel2.DataSource = channel2TypeList;

            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl1.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl1.Init(this.m_Monitor.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.tbxName.Text = this.m_Monitor.name;
                this.tbxAddress.Text = this.m_Monitor.address;
                this.tbxManager.Text = this.m_Monitor.manager;
                this.tbxPhone.Text = this.m_Monitor.phone;
                this.tbxLongitude.Text = this.m_Monitor.longitude.ToString();
                this.tbxLatitude.Text = this.m_Monitor.latitude.ToString();

                this.tbxHeight.Text = this.m_Monitor.height.ToString("0.00");
                this.tbxElevation.Text = this.m_Monitor.elevation.ToString("0.00");
                this.tbx_h_offset.Text = this.m_Monitor.h_offset.ToString("0.00");
                this.tbx_v_offset.Text = this.m_Monitor.v_offset.ToString("0.00");

                this.tbxIp1.Value = this.m_Monitor.ip;
                this.tbxPort1.Text = this.m_Monitor.Port.ToString();
                this.cbxChannel1.SelectedValue = (int)this.m_Monitor.channel;
                this.tbxUser1.Text = this.m_Monitor.username;
                this.tbxPassword1.Text = this.m_Monitor.password;

                //if (this.m_Monitor.ip2 == null || !string.IsNullOrEmpty(this.m_Monitor.ip2.Trim()))
                //{
                //    this.checkBox1.Checked = true;

                //    this.tbxIp2.Value = this.m_Monitor.ip2;
                //    this.tbxPort2.Text = this.m_Monitor.port2.ToString();
                //    this.cbxChannel2.SelectedValue = (int)this.m_Monitor.channel2;
                //    this.tbxUser2.Text = this.m_Monitor.user2;
                //    this.tbxPassword2.Text = this.m_Monitor.password2;

                //}
                ///* 2016-02-26 qipengfei 添加 */
                //else
                //{
                //    this.checkBox1.Checked = false;
                //}

                if (this.m_OperationType == OperationType.Check)
                {
                    this.btnOK.Enabled = false;
                    this.btnCancel.Text = "关闭(&C)";

                    this.tbxName.Enabled = false;
                    this.tbxAddress.Enabled = false;
                    this.tbxManager.Enabled = false;
                    this.tbxPhone.Enabled = false;
                    this.tbxLongitude.Enabled = false;
                    this.tbxLatitude.Enabled = false;

                    this.tbxHeight.Enabled = false;
                    this.tbxElevation.Enabled = false;
                    this.tbx_h_offset.Enabled = false;
                    this.tbx_v_offset.Enabled = false;

                    this.tbxIp1.Enabled = false;
                    this.tbxPort1.Enabled = false;
                    this.cbxChannel1.Enabled = false;
                    this.tbxUser1.Enabled = false;
                    this.tbxPassword1.Enabled = false;

                    this.checkBox1.Enabled = false;

                    this.tbxIp2.Enabled = false;
                    this.tbxPort2.Enabled = false;
                    this.cbxChannel2.Enabled = false;
                    this.tbxUser2.Enabled = false;
                    this.tbxPassword2.Enabled = false;
                }
            }
            #endregion
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string name = this.tbxName.Text;
            string address = this.tbxAddress.Text;
            string manager = this.tbxManager.Text;
            string phone = this.tbxPhone.Text;
            double longitude = Convert.ToDouble(this.tbxLongitude.Text);
            double latitude = Convert.ToDouble(this.tbxLatitude.Text);

            double height = Convert.ToDouble(this.tbxHeight.Text);
            double elevation = Convert.ToDouble(this.tbxElevation.Text);
            double h_offset = Convert.ToDouble(this.tbx_h_offset.Text);
            double v_offset = Convert.ToDouble(this.tbx_v_offset.Text);
            string deviceid = this.tbx_deviceid.Text.Trim();

            if(this.pacControl1.LocalPac == null || this.pacControl1.LocalPac=="" || this.pacControl1.LocalPac.EndsWith("00"))
            {
                MessageBox.Show(this, "请选择正确的行政区名称", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tabControl1.SelectedTab = this.tabPage2;
                this.pacControl1.CbxCounty.Focus();
                return;
            }
            if(height==0)
            {
                MessageBox.Show(this, "请选择正确的云台高度", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tabControl1.SelectedTab = this.tabPage3;
                this.tbxHeight.Focus();
                this.tbxHeight.SelectAll();
                return;
            }

            #region 可见光


            string ip1 = "";
            int port1 = 0;
            int channel1 = 0;
            string user1 = "";
            string password1 = "";

            ip1 = this.tbxIp1.Value;
            if (string.IsNullOrEmpty(ip1))
            {
                MessageBox.Show(this, "请输入可见光IP地址", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = this.tabPage4;
                this.tbxIp1.Focus();
                return;
            }

            try
            {
                if (string.IsNullOrEmpty(this.tbxPort1.Text))
                {
                    MessageBox.Show(this, "请输入可见光连接端口", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    tabControl1.SelectedTab = this.tabPage4;

                    this.tbxPort1.SelectAll();
                    this.tbxPort1.Focus();

                    return;
                }

                port1 = Convert.ToInt32(this.tbxPort1.Text.Trim());
            }
            catch
            {

            }

            channel1 = Convert.ToInt32(this.cbxChannel1.SelectedValue);

            user1 = this.tbxUser1.Text.Trim();
            if (string.IsNullOrEmpty(user1))
            {
                MessageBox.Show(this, "请输入可见光连接用户名", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tabControl1.SelectedTab = this.tabPage4;

                this.tbxUser1.SelectAll();
                this.tbxUser1.Focus();
                return;
            }

            password1 = this.tbxPassword1.Text.Trim();
            if (string.IsNullOrEmpty(password1))
            {
                MessageBox.Show(this, "请输入可见光连接密码", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tabControl1.SelectedTab = this.tabPage4;

                this.tbxPassword1.SelectAll();
                this.tbxPassword1.Focus();
                return;
            }

            #endregion

            #region 近红外



            string ip2 = " ";
            int port2 = 0;
            int channel2 = 1;
            string user2 = " ";
            string password2 = " ";



            if (this.checkBox1.Checked)
            {

                ip2 = this.tbxIp2.Value;
                if (string.IsNullOrEmpty(ip2))
                {
                    MessageBox.Show(this, "请输入近红外IP地址", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControl1.SelectedTab = this.tabPage5;
                    this.tbxIp2.Focus();
                    return;
                }

                try
                {
                    if (string.IsNullOrEmpty(this.tbxPort2.Text))
                    {
                        MessageBox.Show(this, "请输入可见光连接端口", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        tabControl1.SelectedTab = this.tabPage5;

                        this.tbxPort2.SelectAll();
                        this.tbxPort2.Focus();

                        return;
                    }

                    port2 = Convert.ToInt32(this.tbxPort2.Text.Trim());
                }
                catch
                {

                }

                channel2 = Convert.ToInt32(this.cbxChannel2.SelectedValue);

                user2 = this.tbxUser2.Text.Trim();
                if (string.IsNullOrEmpty(user2))
                {
                    MessageBox.Show(this, "请输入可见光连接用户名", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    tabControl1.SelectedTab = this.tabPage5;

                    this.tbxUser2.SelectAll();
                    this.tbxUser2.Focus();
                    return;
                }

                password2 = this.tbxPassword2.Text.Trim();
                if (string.IsNullOrEmpty(password2))
                {
                    MessageBox.Show(this, "请输入可见光连接密码", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    tabControl1.SelectedTab = this.tabPage5;

                    this.tbxPassword2.SelectAll();
                    this.tbxPassword2.Focus();
                    return;
                }
            }

            #endregion

            if (m_OperationType == OperationType.Add)
            {
                this.m_Monitor = new Fire_ForestRemoteMonitoring();
            }

            m_Monitor.name = name;
            m_Monitor.address = address;
            m_Monitor.manager = manager;
            m_Monitor.phone = phone;
            m_Monitor.pac = this.pacControl1.LocalPac;
            m_Monitor.longitude = longitude;
            m_Monitor.latitude = latitude;
            m_Monitor.shape = GDALHelper.LngLatToWktPoint(this.m_Monitor.longitude, this.m_Monitor.latitude);
            m_Monitor.county = this.pacControl1.CbxCounty.Text;
            m_Monitor.deviceid = "111";

            m_Monitor.height = height;
            m_Monitor.elevation = elevation;
            m_Monitor.h_offset = h_offset;
            m_Monitor.v_offset = v_offset;
            m_Monitor.deviceid = deviceid;


            m_Monitor.ip = ip1;
            m_Monitor.Port = port1;
            m_Monitor.channel = channel1;
            m_Monitor.user_ = user1;
            m_Monitor.username = user1;
            m_Monitor.password = password1;

            if (this.m_OperationType == OperationType.Add)
            {
                //m_Monitor.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                m_Monitor.cre_pers = GlobeHelper.Instance.User.name;

                this.m_MonitoringController.Add(m_Monitor);
            }
            else
            {
                //m_Monitor.modifyTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                m_Monitor.mod_pers = GlobeHelper.Instance.User.name;

                this.m_MonitoringController.Edit(m_Monitor);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = !string.IsNullOrEmpty(tbxName.Text) && !string.IsNullOrEmpty(tbxManager.Text) && !string.IsNullOrEmpty(this.tbxPhone.Text) && !string.IsNullOrEmpty(tbxLongitude.Text) && !string.IsNullOrEmpty(tbxLatitude.Text) && !string.IsNullOrEmpty(tbxAddress.Text) &&
                 !string.IsNullOrEmpty(tbx_h_offset.Text) && !string.IsNullOrEmpty(tbx_v_offset.Text) && !string.IsNullOrEmpty(tbxHeight.Text) && !string.IsNullOrEmpty(tbxElevation.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (!tabControl1.Controls.Contains(tabPage5))
                {
                    tabControl1.Controls.Add(tabPage5);
                }
            }
            else
            {
                if (tabControl1.Controls.Contains(tabPage5))
                {
                    tabControl1.Controls.Remove(tabPage5);
                }
            }
        }
    }

}