using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using FFireManage.Service;
using FFireManage.Utility;
using System.Net;

namespace FFireManage
{
    public partial class FormLogin : Form
    {
        private LoginController m_LoginController = null;

        public FormLogin()
        {
            InitializeComponent();

            this.m_LoginController = new LoginController();
         

            this.m_LoginController.LoginEvent += new EventHandler(LoginController_LoginEvent);
        }

        private void LoginController_LoginEvent(object sender, EventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated)
                return;

            this.Invoke(new MethodInvoker(delegate()
            {
                if (e != null)
                {
                    string content = sender.ToString();

                    BaseResultInfo<UserInfo> result = JsonHelper.JSONToObject<BaseResultInfo<UserInfo>>(content);

                    if (result != null)
                    {
                        if (result.status == 10000)
                        {
                            UserInfo user = result.obj;

                            GlobeHelper.Instance.User = user;

                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show(result.msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, sender.ToString() + "\r\n" + AppConfigHelper.GetAppConfig("Ip") + ":" + AppConfigHelper.GetAppConfig("Port"));
                }
            }));
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.btnOK.Enabled = !string.IsNullOrEmpty(this.tbxName.Text) && !string.IsNullOrEmpty(this.tbxPassword.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string account = this.tbxName.Text;
            string password = this.tbxPassword.Text;

            string imei = "123456789012345";
            string deviceName = Dns.GetHostName();
            string deviceId = SoftRegister.GetDiskVolumeSerialNumber() + SoftRegister.GetCpuSerialNumber() + SoftRegister.GetMacAddress();
            int deviceType = 3;

            this.m_LoginController.Login(account, deviceType, imei,deviceName,deviceId, password);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = !string.IsNullOrEmpty(this.tbxName.Text) && !string.IsNullOrEmpty(this.tbxPassword.Text);
        }
    }
}
