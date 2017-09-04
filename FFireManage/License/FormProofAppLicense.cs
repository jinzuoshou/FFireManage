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
    public partial class FormProofAppLicense : Form
    {
        private LicenseController m_ServiceController = null;
        public FormProofAppLicense()
        {
            InitializeComponent();

            this.m_ServiceController = new LicenseController();
            this.m_ServiceController.ProofLicenseEvent += M_ImeiController_ProofLicenseEvent;
        }

        private void M_ImeiController_ProofLicenseEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = sender.ToString();
                    BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                    if (result.status == 10000)
                    {
                        MessageBox.Show(this, "MEI已被注册", "提示");
                        //this.DialogResult = DialogResult.OK;
                    }
                    else if(result.status== 60001)
                    {
                        MessageBox.Show(this, "IMEI不存在/未被注册", "提示");
                    }
                    else if (result.status == 60002)
                    {
                        MessageBox.Show(this, "IMEI已经过期 ", "提示");
                    }
                    else if (result.status == 60003)
                    {
                        MessageBox.Show(this, "IMEI已注销 ", "提示");
                    }
                    else
                    {
                        MessageBox.Show(this, result.msg, "提示");
                    }
                }
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string imei = this.tbxImei.Text.Trim();
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
            this.m_ServiceController.ProofLicense(imei);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
