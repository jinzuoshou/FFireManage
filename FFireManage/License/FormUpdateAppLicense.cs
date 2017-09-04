using FFireManage.Service;
using FFireManage.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FFireManage.License
{
    public partial class FormUpdateAppLicense : Form
    {
        private LicenceInfo m_License = null;
        private LicenseController m_LicenseController = null;

        public FormUpdateAppLicense(LicenceInfo license)
        {
            InitializeComponent();
            this.m_License = license;

            this.m_LicenseController = new LicenseController();
            this.m_LicenseController.EditEvent += m_LicenseController_EditEvent;
        }

        private void m_LicenseController_EditEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = sender.ToString();
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

        private void FormUpdateAppLicense_Load(object sender, EventArgs e)
        {
            this.pacControl1.Init(this.m_License.pac);
            this.tbxKey.Text = this.m_License.key;
            this.tbxImei.Text = this.m_License.imei;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string key = this.tbxKey.Text.Trim();
            string imei = this.tbxImei.Text.Trim();
            string pac = (this.pacControl1.LocalPac);
            if(pac==null || pac=="")
            {
                MessageBox.Show(this, "请选择行政区！", "信息提示");
                this.pacControl1.Focus();
                return;
            }
            if (imei == "")
            {
                MessageBox.Show(this, "设备序列号不能为空！", "信息提示");
                this.tbxImei.Focus();
                return;
            }
            else if (imei.Length != 15)
            {
                MessageBox.Show(this, "请输入15位数字的设备序列号！", "信息提示");
                this.tbxImei.Focus();
                this.tbxImei.SelectAll();
                return;
            }
            this.m_LicenseController.Update(m_License.id,imei, pac,key);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
