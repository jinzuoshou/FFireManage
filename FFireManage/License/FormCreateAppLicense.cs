using FFireManage.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FFireManage.Service;

namespace FFireManage
{
    public partial class FormCreateAppLicense : Form
    {
        private AreaCodeInfo m_Area = null;
        private ServiceController m_ServiceController = null;
        public int Number
        {
            get
            {
                int number = 10;

                try
                {
                    number = Convert.ToInt32(this.tbxNumber.Text);
                }
                catch
                { }

                return number;
            }
        }

        public FormCreateAppLicense(AreaCodeInfo areaCode)
        {
            InitializeComponent();
            this.m_Area = areaCode;
            this.m_ServiceController = new ServiceController();
            this.m_ServiceController.CreateLicenceKeyEvent += M_ServiceController_CreateLicenceKeyEvent;
        }

        private void M_ServiceController_CreateLicenceKeyEvent(object sender, EventArgs e)
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

        private void FormCreateAppLicense_Load(object sender, EventArgs e)
        {
            this.pacControl1.Init(m_Area.code);
            DeviceType1 deviceType = DeviceType1.移动;
            List<object> deviceTypeList = CommonHelper.GetDataSource<DeviceType1>(deviceType);
            this.cbxDeviceType.DisplayMember = "Name";
            this.cbxDeviceType.ValueMember = "Value";
            this.cbxDeviceType.DataSource = deviceTypeList;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string pac = this.pacControl1.LocalPac;
            int number = this.Number;
            int deviceType = Convert.ToInt32(this.cbxDeviceType.SelectedValue);
            if(pac==null || pac=="")
            {
                MessageBox.Show(this, "请选择正确的行政区", "信息提示");
                this.pacControl1.Focus();
                return;
            }
            this.m_ServiceController.CreateLicenseKeyForPost(GlobeHelper.Instance.User.account,pac, number, deviceType);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
