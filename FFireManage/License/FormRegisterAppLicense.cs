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
    public partial class FormRegisterAppLicense : Form
    {
        private LicenceInfo m_License = null;
        private ServiceController m_ServiceController = null;
        public FormRegisterAppLicense(LicenceInfo license)
        {
            InitializeComponent();
            this.m_License = license;

            this.m_ServiceController = new ServiceController();
            this.m_ServiceController.RegisterLicenseEvent += M_ImeiController_RegisterLicenseEvent;
        }
        private void FormRegisterAppLicense_Load(object sender, EventArgs e)
        {
            DeviceType deviceType = DeviceType.Android;
            List<Object> deviceTypeList = CommonHelper.GetDataSource<DeviceType>(deviceType);
            this.cbxDeviceType.DisplayMember = "Name";
            this.cbxDeviceType.ValueMember = "Value";
            this.cbxDeviceType.DataSource = deviceTypeList;
            this.tbxKey.Text = this.m_License.key;
        }

        private void M_ImeiController_RegisterLicenseEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = sender.ToString();
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
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string key = this.tbxKey.Text.Trim();
            string imei = this.tbxImei.Text.Trim();
            int device = (int)(this.cbxDeviceType.SelectedValue);
            if(imei=="")
            {
                MessageBox.Show(this, "设备序列号不能为空！", "信息提示");
                this.tbxImei.Focus();
                return;
            }
            else if(imei.Length!=15)
            {
                MessageBox.Show(this, "请输入15位数字的设备序列号！", "信息提示");
                this.tbxImei.Focus();
                this.tbxImei.SelectAll();
                return;
            }
            this.m_ServiceController.RegisterLicenseForPost(key, imei, device);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
