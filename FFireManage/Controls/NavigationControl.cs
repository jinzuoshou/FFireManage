using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FFireManage.Service;
using FFireManage.Utility;
using FFireManage.Model;

namespace FFireManage.Controls
{
    public partial class NavigationControl : UserControl
    {
        #region 控件只读属性
        /// <summary>
        /// 新增按钮（只读属性）
        /// </summary>
        public ToolStripButton BtnAdd
        {
            get { return this.btnAdd; }
        }

        /// <summary>
        /// 编辑按钮（只读属性）
        /// </summary>
        public ToolStripButton BtnEdit
        {
            get { return this.btnEdit; }
        }

        /// <summary>
        /// 删除按钮（只读属性）
        /// </summary>
        public ToolStripButton BtnDelete
        {
            get { return this.btnDelete; }
        }

        /// <summary>
        /// 省级ComboBox（只读属性）
        /// </summary>
        public ToolStripComboBox CbxProvince
        {
            get { return this.cbxProvince; }
        }

        /// <summary>
        /// 市级ComboBox（只读属性）
        /// </summary>
        public ToolStripComboBox CbxCity
        {
            get { return this.cbxCity; }
        }

        /// <summary>
        /// 县级ComboBox（只读属性）
        /// </summary>
        public ToolStripComboBox CbxCounty
        {
            get { return this.cbxCounty; }
        }

        /// <summary>
        /// 用户类型ComboBox（只读属性）
        /// </summary>
        public ToolStripComboBox CbxUserType
        {
            get { return this.cbxUserType; }
        }

        /// <summary>
        /// 搜索框TextBox（只读属性）
        /// </summary>
        public ToolStripTextBox TbxSearch
        {
            get{return this.tbxSearch;}
        }

        /// <summary>
        /// 搜索按钮（只读属性）
        /// </summary>
        public ToolStripButton BtnSearch
        {
            get{ return this.btnSearch;}
        }

        /// <summary>
        /// 新增、编辑、删除按钮工具栏
        /// </summary>
        public ToolStrip OperateButtonToolStrip
        {
            get { return this.toolStrip2 ; }
        }

        /// <summary>
        /// 行政区管理工具栏
        /// </summary>
        public ToolStrip AreaToolStrip
        {
            get { return this.toolStrip3; }
        }

        /// <summary>
        /// 用户类型工具栏
        /// </summary>
        public ToolStrip UserToolStrip
        {
            get{ return this.toolStrip4;}
        }

        /// <summary>
        /// 搜索工具栏
        /// </summary>
        public ToolStrip SearchToolStrip
        {
            get { return this.toolStrip5; }
        }
        #endregion

        private UserInfo m_User = null;
        private ServiceController m_ServiceController = null;
        private List<AreaCodeInfo> m_AreaList = null;

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

        public List<AreaCodeInfo> AreaList
        {
            get
            {
                return m_AreaList;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public NavigationControl()
        {
            InitializeComponent();
            this.m_ServiceController = new ServiceController();
            this.m_ServiceController.GetAreaCodeListEvent += M_ServiceController_GetAreaCodeListEvent;
        }

        /// <summary>
        /// 初始化程序控件
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

        private void M_ServiceController_GetAreaCodeListEvent(object sender, EventArgs e)
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
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (areaList == null || areaList.Count == 0)
                    return;
                if (this.m_User.pac.Length == 6 && this.m_User.pac.EndsWith("00"))
                {
                    var provinces = areaList.Where<AreaCodeInfo>(u => u.code.EndsWith("0000")).OrderBy<AreaCodeInfo, string>(u => u.code);
                    if (provinces == null)
                        return;

                    this.cbxProvince.ComboBox.DisplayMember = "Name";
                    this.cbxProvince.ComboBox.ValueMember = "Code";
                    this.cbxProvince.ComboBox.DataSource = provinces.ToList<AreaCodeInfo>();
                    this.cbxProvince.Enabled = false;
                }
            }));
            
        }

        private void cbxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (this.m_AreaList == null || this.m_AreaList.Count == 0)
                    return;
                var cities = this.m_AreaList.Where<AreaCodeInfo>(a => a.code.EndsWith("00") && !a.code.EndsWith("0000")).OrderBy<AreaCodeInfo, string>(u => u.code);
                if (cities == null || cities.Count() == 0)
                    return;
                List<AreaCodeInfo> cityList = cities.ToList<AreaCodeInfo>();
                cityList.Insert(0, new AreaCodeInfo()
                {
                    name = "所属市",
                    code = null
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
            }));
        }

        private void cbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (this.m_AreaList == null || this.m_AreaList.Count == 0)
                    return;
                var cityCode = this.cbxCity.ComboBox.SelectedValue;
                List<AreaCodeInfo> countyList = new List<AreaCodeInfo>();
                if (cityCode != null)
                {
                    var counties = this.m_AreaList.Where<AreaCodeInfo>(a => !a.code.EndsWith("00") && cityCode.ToString().Substring(0, 4) == a.code.Substring(0, 4)).OrderBy<AreaCodeInfo, string>(u => u.code);
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
                    name = "所属县",
                    code = null
                });
                this.cbxCounty.ComboBox.DisplayMember = "Name";
                this.cbxCounty.ComboBox.ValueMember = "Code";
                this.cbxCounty.ComboBox.DataSource = countyList;

                if (this.m_User.pac.Length == 6 && !this.m_User.pac.EndsWith("00"))
                {
                    this.cbxCounty.ComboBox.SelectedValue = this.m_User.pac;
                    this.cbxCounty.Enabled = false;
                }
            }));
        }

        private void cbxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (this.cbxCounty.ComboBox.SelectedValue != null)
                {
                    var countyCode = this.cbxCounty.ComboBox.SelectedValue.ToString();
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
            }));
            
        }
    }
}
