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

namespace FFireManage
{
    public partial class FormUser : Form
    {
        private UserInfo m_User = null;

        private UserController m_UserController = null;
        private OperationType m_OperationType = OperationType.Add;

        public FormUser()
        {
            InitializeComponent();

            this.m_UserController = new UserController();
            this.m_UserController.EditEvent += m_UserController_EditEvent;
            this.m_UserController.AddEvent += m_UserController_AddEvent;
            
        }

        public FormUser(OperationType type,UserInfo user=null)
            : this()
        {
            this.m_OperationType = type;
            this.m_User = user;
            if (m_OperationType==OperationType.Add)
            {
                this.pacControl1.Init();
            }
            else if(m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl1.Init(this.m_User.pac);
            }
            
        }

        private void m_UserController_EditEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try 
                    {
                        BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                        if (result.status == 10000)
                        {

                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
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

        private void m_UserController_AddEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                        if (result.status == 10000)
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DeviceType deviceType = DeviceType.PC;
            List<object> deviceTypeList = CommonHelper.GetDataSource<DeviceType>(deviceType);
            this.cbxType.DisplayMember = "Name";
            this.cbxType.ValueMember = "Value";
            this.cbxType.DataSource = deviceTypeList;

            if (this.m_User != null)
            {
                this.Text = "用户编辑";

                this.tbxAccount.Text = this.m_User.account;
                this.tbxAccount.ReadOnly = true;

                this.tbxName.Text = this.m_User.name;
                this.tbxPassword.Text = this.m_User.password;
                this.tbxPhone.Text = this.m_User.phone;
                this.cbxType.SelectedValue = Convert.ToInt32(this.m_User.deviceType);

                if (this.m_User.subscriber != null)
                {
                    string[] subscriber_array = this.m_User.subscriber.Split('-');
                    if (subscriber_array.Length == 2)
                    {
                        this.ckbAllowlogin.Checked = Convert.ToBoolean(Convert.ToInt32(subscriber_array[1]));
                    }
                }
                this.btnOK.Enabled = true;

            }
            else
            {
                this.Text = "添加用户";
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.m_User == null)
            {
                this.btnOK.Enabled = !string.IsNullOrEmpty(this.tbxAccount.Text) && !string.IsNullOrEmpty(this.tbxPassword.Text) && !string.IsNullOrEmpty(this.tbxPhone.Text);
            }
            else
            {
                this.btnOK.Enabled = !string.IsNullOrEmpty(this.tbxAccount.Text) && !string.IsNullOrEmpty(this.tbxPhone.Text);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string account = this.tbxAccount.Text;
            string password = this.tbxPassword.Text;
            string name = this.tbxName.Text;
            string phone = this.tbxPhone.Text;

            int type = Convert.ToInt32(Enum.Parse(typeof(DeviceType), this.cbxType.Text));
            int allowlogin = this.ckbAllowlogin.Checked ? 1 : 0;


            if (this.m_User != null && m_OperationType==OperationType.Edit)
            {
                m_User.name = name;
                m_User.password = password;
                m_User.phone = phone;
                m_User.deviceType = type;

                m_User.subscriber = type.ToString() + "-" + allowlogin.ToString();

                this.m_UserController.Edit(m_User);
            }
            else if(m_OperationType == OperationType.Add)
            {
                m_User = new UserInfo();

                m_User.pac = this.pacControl1.LocalPac;
                m_User.account = account;
                m_User.deviceType = type;
                m_User.name = name;
                m_User.password = password;
                m_User.phone = phone;
                m_User.latitude = 0.0;
                m_User.longitude = 0.0;
                m_User.competence = 4;
                m_User.voipAccount = account;
                m_User.voipPassword = account;

                m_User.subscriber = type.ToString() + "-" + allowlogin.ToString();

                this.m_UserController.Add(m_User);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
