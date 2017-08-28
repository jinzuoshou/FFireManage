﻿using System;
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
using FFireManage.Model;

namespace FFireManage
{
    public partial class FormUserManage : Form
    {
        private UserInfo m_User = null;
        private ServiceController m_ServiceController = null;
        private List<AreaCodeInfo> m_AreaList = null;
        private UserInfo currentUser;
        private List<UserInfo> m_UserList = null;

        private string m_Pac = string.Empty;
        /// <summary>
        /// 当前所选的行政区代码
        /// </summary>
        public string Pac
        {
            get
            {
                if (this.cbxCounty.ComboBox.SelectedValue != null)
                {
                    this.m_Pac = this.cbxCounty.ComboBox.SelectedValue.ToString();
                }
                else if (this.cbxCity.ComboBox.SelectedValue != null)
                {
                    this.m_Pac = this.cbxCity.ComboBox.SelectedValue.ToString();
                }
                else if (this.cbxProvince.ComboBox.SelectedValue != null)
                {
                    this.m_Pac = this.cbxProvince.ComboBox.SelectedValue.ToString();
                }
                return this.m_Pac;
            }
            private set { this.m_Pac = value; }
        }

        public FormUserManage()
        {
            InitializeComponent();

            this.m_User = GlobeHelper.Instance.User;

            this.m_ServiceController = new ServiceController();
            this.m_ServiceController.GetAreaCodeListEvent += new EventHandler(ServiceController_GetAreaCodeListEvent);

            this.m_ServiceController.GetUserListByPacEvent += new EventHandler(ServiceController_GetUserListByPacEvent);
            this.m_ServiceController.DeleteUserEvent += new EventHandler(ServiceController_DeleteUserEvent);


        }

        public void ServiceController_GetUserListByPacEvent(object sender, EventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate()
            {
                if (e != null)
                {
                    string content = sender.ToString();

                    GetListResultInfo<UserInfo>  result= JsonHelper.JSONToObject<GetListResultInfo<UserInfo>>(content);
                    

                    if (result.rows != null && result.rows.Count > 0)
                    {
                        this.m_UserList = result.rows;

                        this.pagerControl1.NMax = result.total;
                        this.FillData(m_UserList);
                    }
                    else
                    {
                        this.pagerControl1.NMax = 0;
                        this.FillData(null);
                    }
                }
                else
                {
                    MessageBox.Show(sender.ToString(), "获取行政区出错", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }));
        }

        private void ServiceController_DeleteUserEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                if (e != null)
                {
                    string content = sender.ToString();

                    BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                    if (result.status == 10000)
                    {
                        this.GetUsers(this.Pac);
                    }
                }
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private string GetNameByPac(string pac)
        {
            for (int i = 0; i < this.m_AreaList.Count; i++)
            {
                if (this.m_AreaList[i].Code == pac)
                {
                    return this.m_AreaList[i].Name;
                }
            }

            return "";
        }

        private string GetUserTypeName(int userType)
        {
            if (userType == 0)
            {
                return "综合调度平台用户";
            }
            else if (userType == 1)
            {
                return "指挥终端用户";
            }
            else
            {
                return "未知类型用户";
            }
        }

        private void GetUsers(string pac,int fetchType=3)
        {
            this.m_ServiceController.GetUserListByPac(this.Pac, fetchType);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.pagerControl1.PageCurrent = 1;
            this.pagerControl1.Bind();
            this.pagerControl1.PageSize = 20;
            this.pagerControl1.OnPageChanged += pagerControl1_OnPageChanged;
            /*
            fetchType
            0 --- 默认 只查找对应的
            1 --- 只查询下一级
            2 --- 查询所有下一级
            3 --- 查询最低为县级的行政区列表
            */

            this.Init(GlobeHelper.Instance.User);
        }

        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            if (this.Pac == null || this.Pac == "")
                this.GetUsers(GlobeHelper.Instance.User.pac);
            else
                this.GetUsers(this.Pac);
        }

        /// <summary>
        /// 初始化行政区信息
        /// </summary>
        /// <param name="user"></param>
        public void Init(UserInfo user)
        {
            this.m_User = user;
            if (this.m_User.pac.Length == 6 && this.m_User.pac.EndsWith("0000"))
            {
                this.m_ServiceController.GetAreaCodeList(this.m_User.pac, 3);
            }
            else if (this.m_User.pac.Length == 6 && !this.m_User.pac.EndsWith("0000"))
            {
                this.m_ServiceController.GetAreaCodeList(this.m_User.pac.Substring(0, 2) + "0000", 3);
            }
        }

        private void ServiceController_GetAreaCodeListEvent(object sender, EventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = sender.ToString();

                    GetListResultInfo<AreaCodeInfo> result = JsonHelper.JSONToObject<GetListResultInfo<AreaCodeInfo>>(content);

                    if (result.rows != null && result.rows.Count > 0)
                    {
                        m_AreaList = result.rows;

                        this.LoadProvince(m_AreaList);
                    }
                }
                else
                {
                    MessageBox.Show(sender.ToString(), "获取行政区出错", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }));
        }

        private void LoadProvince(List<AreaCodeInfo> areaList)
        {
            if (areaList == null || areaList.Count == 0)
                return;
            if (this.m_User.pac.Length == 6 && this.m_User.pac.EndsWith("00"))
            {
                var provinces = areaList.Where<AreaCodeInfo>(u => u.Code.EndsWith("0000")).OrderBy<AreaCodeInfo, string>(u => u.Code);
                if (provinces == null)
                    return;

                this.cbxProvince.ComboBox.DisplayMember = "Name";
                this.cbxProvince.ComboBox.ValueMember = "Code";
                this.cbxProvince.ComboBox.DataSource = provinces.ToList<AreaCodeInfo>();
                this.cbxProvince.Enabled = false;
            }
        }

        private void cbxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_AreaList == null || this.m_AreaList.Count == 0)
                return;
            if(this.cbxProvince.ComboBox.SelectedValue!=null)
            {
                string pCode = this.cbxProvince.ComboBox.SelectedValue.ToString();
                this.GetUsers(pCode);
            }
            var cities = this.m_AreaList.Where<AreaCodeInfo>(a => a.Code.EndsWith("00") && !a.Code.EndsWith("0000")).OrderBy<AreaCodeInfo, string>(u => u.Code);
            if (cities == null || cities.Count() == 0)
                return;
            List<AreaCodeInfo> cityList = cities.ToList<AreaCodeInfo>();
            cityList.Insert(0, new AreaCodeInfo()
            {
                Name = "所属市",
                Code = null
            });

            this.cbxCity.ComboBox.DisplayMember = "Name";
            this.cbxCity.ComboBox.ValueMember = "Code";
            this.cbxCity.ComboBox.DataSource = cityList;


            if (this.m_User.pac.EndsWith("00") && !this.m_User.pac.EndsWith("0000"))
            {
                this.cbxCity.ComboBox.SelectedValue = this.m_User.pac;
                this.cbxCity.Enabled = false;
            }
            else if (!this.m_User.pac.EndsWith("00"))
            {
                this.cbxCity.ComboBox.SelectedValue = this.m_User.pac.Substring(0, 4) + "00";
                this.cbxCity.Enabled = false;
            }
        }

        private void cbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_AreaList == null || this.m_AreaList.Count == 0)
                return;
            var cityCode = this.cbxCity.ComboBox.SelectedValue;
            List<AreaCodeInfo> countyList = new List<AreaCodeInfo>();
            if (cityCode != null)
            {
                this.GetUsers(cityCode.ToString());
                var counties = this.m_AreaList.Where<AreaCodeInfo>(a => !a.Code.EndsWith("00") && cityCode.ToString().Substring(0, 4) == a.Code.Substring(0, 4)).OrderBy<AreaCodeInfo, string>(u => u.Code);
                if (counties != null)
                    countyList = counties.ToList<AreaCodeInfo>();

                List<object> UserTypeList = new List<object>()
                {
                    new {Code="",Name="所属角色"},
                    new {Code=(cityCode!=null)?cityCode.ToString():null,Name="市级管理组"},
                    new {Code=(cityCode!=null)?cityCode.ToString():null,Name="市级用户组"},
                };
                this.cbxUserType.ComboBox.DisplayMember = "Name";
                this.cbxUserType.ComboBox.ValueMember = "Code";
                this.cbxUserType.ComboBox.DataSource = UserTypeList;
            }
            else
            {
                var provinceCode = this.cbxProvince.ComboBox.SelectedValue.ToString();
                this.GetUsers(provinceCode);
                List<object> UserTypeList = new List<object>()
                {
                    new {Code="",Name="所属角色"},
                    new {Code=(provinceCode!=null)?provinceCode:null,Name="省级管理组"},
                    new {Code=(provinceCode!=null)?provinceCode:null,Name="省级用户组"},
                };
                this.cbxUserType.ComboBox.DisplayMember = "Name";
                this.cbxUserType.ComboBox.ValueMember = "Code";
                this.cbxUserType.ComboBox.DataSource = UserTypeList;
            }

            countyList.Insert(0, new AreaCodeInfo()
            {
                Name = "所属县",
                Code = null
            });
            this.cbxCounty.ComboBox.DisplayMember = "Name";
            this.cbxCounty.ComboBox.ValueMember = "Code";
            this.cbxCounty.ComboBox.DataSource = countyList;

            if (this.m_User.pac.Length == 6 && !this.m_User.pac.EndsWith("00"))
            {
                this.cbxCounty.ComboBox.SelectedValue = this.m_User.pac;
                this.cbxCounty.Enabled = false;
            }
        }

        private void cbxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxCounty.ComboBox.SelectedValue != null)
            {
                var countyCode = this.cbxCounty.ComboBox.SelectedValue.ToString();
                this.GetUsers(countyCode.ToString());
                List<object> UserTypeList = new List<object>()
                {
                    new {Code="",Name="所属角色"},
                    new {Code=(countyCode!=null)?countyCode:null,Name="县级管理组"},
                    new {Code=(countyCode!=null)?countyCode:null,Name="县级用户组"},
                };
                this.cbxUserType.ComboBox.DisplayMember = "Name";
                this.cbxUserType.ComboBox.ValueMember = "Code";
                this.cbxUserType.ComboBox.DataSource = UserTypeList;
            }
            else
            {
                if(this.cbxCity.ComboBox.SelectedValue!=null)
                {
                    var cityCode = this.cbxCity.ComboBox.SelectedValue.ToString();
                    this.GetUsers(cityCode.ToString());
                }
            }
        }

        private void FillData(List<UserInfo> userList)
        {
            this.pagerControl1.Bind();
            this.pagerControl1.bindingSource.DataSource = userList;
            this.pagerControl1.bindingNavigator.BindingSource = this.pagerControl1.bindingSource;
            this.listView1.Items.Clear();

            if (userList != null)
            {
                for (int i = 0; i < userList.Count; i++)
                {
                    UserInfo user = userList[i];

                    ListViewItem item = new ListViewItem();

                    item.SubItems.Add(user.account);
                    item.SubItems.Add(user.name);
                    item.SubItems.Add(GetNameByPac(user.pac));
                    item.SubItems.Add(user.phone);
                    item.SubItems.Add(GetUserTypeName(user.accountType));

                    item.Tag = user;

                    this.listView1.Items.Add(item);
                }
            }
        }

        #region Button_Click

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormUser pFormAddUser = new FormUser(OperationType.Add);
            if (pFormAddUser.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.GetUsers(this.Pac);

                MessageBox.Show(this, "用户注册成功", "提示");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.currentUser != null)
            {
                FormUser pFormUser = new FormUser(OperationType.Edit,this.currentUser);
                if (pFormUser.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.GetUsers(this.Pac);
                    MessageBox.Show(this, "用户编辑成功", "提示");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentUser != null)
            {
                if (MessageBox.Show(this, "您确定要删除" + this.currentUser.account + "吗？数据删除后不可恢复。", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.m_ServiceController.DeleteUserForGet(this.currentUser.id);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.tbxSearch.Text.Trim() == "")
            {
                this.GetUsers(this.Pac);
                return;
            }
                
            if (this.m_UserList == null || this.m_UserList.Count == 0)
                return;
            string key = this.tbxSearch.Text.Trim();
            var tempUsers = this.m_UserList.Where<UserInfo>(u => u.name.Contains(key) 
                                                       || u.account.Contains(key));
            if (tempUsers == null)
                return;
            this.FillData(tempUsers.ToList<UserInfo>());
        }

        #endregion

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];

                if (item.Tag != null && item.Tag is UserInfo)
                {
                    this.currentUser = item.Tag as UserInfo;

                    this.btnEdit.Enabled = true;
                    this.btnDelete.Enabled = true;
                }
                else
                {
                    this.currentUser = null;

                    this.btnEdit.Enabled = false;
                    this.btnDelete.Enabled = false;
                }
            }
            else
            {
                this.currentUser = null;

                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
            }
        }

        private void cbxUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbxUserType.SelectedIndex == 0)
            //{
            //    string pac = this.GetCurrentPac();

            //    this.m_ServiceController.GetUserListByPac(pac, 3);
            //}
            //else if (cbxUserType.SelectedIndex > 0)
            //{
            //    string pac = this.GetCurrentPac();

            //    this.m_ServiceController.GetUserListByPac(pac, 0);
            //}
        }

        
    }
}
