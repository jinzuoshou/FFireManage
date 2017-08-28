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
    public partial class PACControl1 : UserControl
    {
        private ServiceController m_ServiceController = null;
        private List<AreaCodeInfo> m_AreaList = null;
        private string m_AccountPac = null;
        private string m_LocalPac = null;

        /// <summary>
        /// 只读属性：获取用户pac（行政区代码）
        /// </summary>
        public string LocalPac
        {
            get
            {
                if(this.cbxCounty.SelectedValue!=null)
                {
                    this.m_LocalPac = this.cbxCounty.SelectedValue.ToString();
                }
                else if(this.cbxCity.SelectedValue!=null)
                {
                    this.m_LocalPac = this.cbxCity.SelectedValue.ToString();
                }
                else if (this.cbxProvince.SelectedValue != null)
                {
                    this.m_LocalPac = this.cbxProvince.SelectedValue.ToString();
                }
                return this.m_LocalPac;
            }
            private set { this.m_LocalPac = value; }
        }

        private string county=null;
        public string County
        {
            get
            {
                if (this.cbxCounty.SelectedValue != null)
                {
                    this.county = this.cbxCounty.SelectedValue.ToString();
                }
                return this.county;
            }
            private set { this.county = value; }
        }

        private string city;
        public string City
        {
            get
            {
                if (this.cbxCity.SelectedValue != null)
                {
                    this.city = this.cbxCity.SelectedValue.ToString();
                }
                return this.city;
            }
            private set { this.city = value; }
        }

        private string province;
        public string Province
        {
            get
            {
                if (this.cbxProvince.SelectedValue != null)
                {
                    this.province = this.cbxProvince.SelectedValue.ToString();
                }
                return this.province;
            }
            private set { this.province = value; }
        }


        public PACControl1()
        {
            InitializeComponent();
            this.m_ServiceController = new ServiceController();
            this.m_ServiceController.GetAreaCodeListEvent += M_ServiceController_GetAreaCodeListEvent;
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

        public void Init(string pac=null)
        {
            this.m_AccountPac = GlobeHelper.Instance.User.pac;
            this.m_LocalPac = pac;
            if(this.m_AccountPac.Length == 6 && this.m_AccountPac.EndsWith("0000"))
            {
                this.m_ServiceController.GetAreaCodeList(this.m_AccountPac, 3);
            }
            else if(this.m_AccountPac.Length == 6 && !this.m_AccountPac.EndsWith("0000"))
            {
                this.m_ServiceController.GetAreaCodeList(this.m_AccountPac.Substring(0, 2) + "0000", 3);
            }
        }

        private void LoadProvince(List<AreaCodeInfo> areaList)
        {
            if (areaList == null || areaList.Count == 0)
                return;
            if (this.m_AccountPac.Length == 6 && this.m_AccountPac.EndsWith("00"))
            {
                var provinces = areaList.Where<AreaCodeInfo>(u => u.Code.EndsWith("0000")).OrderBy<AreaCodeInfo,string>(u=>u.Code);
                if (provinces == null)
                    return;
                
                this.cbxProvince.DisplayMember = "Name";
                this.cbxProvince.ValueMember = "Code";
                this.cbxProvince.DataSource = provinces.ToList<AreaCodeInfo>();
                this.cbxProvince.Enabled = false;
            }
        }

        private void cbxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_AreaList == null || this.m_AreaList.Count == 0)
                return;
            var cities = this.m_AreaList.Where<AreaCodeInfo>(a => a.Code.EndsWith("00") && !a.Code.EndsWith("0000")).OrderBy<AreaCodeInfo, string>(u => u.Code);
            if (cities == null || cities.Count()==0)
                return;
            List<AreaCodeInfo> cityList = cities.ToList<AreaCodeInfo>();
            cityList.Insert(0, new AreaCodeInfo()
            {
                Name = "",
                Code = null
            });
            
            this.cbxCity.DisplayMember = "Name";
            this.cbxCity.ValueMember = "Code";
            this.cbxCity.DataSource = cityList;
            
            if (this.m_LocalPac != null)
            {
                if (m_LocalPac.Substring(2, 4) != "0000" && m_LocalPac.Substring(4, 2) == "00")
                {
                    this.cbxCity.SelectedValue = m_LocalPac;
                    this.cbxCity.Enabled = false;
                }
                else if (m_LocalPac.Substring(4, 2) != "00")
                {
                    this.cbxCity.SelectedValue = m_LocalPac.Substring(0, 4) + "00";
                    this.cbxCity.Enabled = false;
                }
            }
            else
            {
                if (this.m_AccountPac.EndsWith("00") && !this.m_AccountPac.EndsWith("0000"))
                {
                    this.cbxCity.SelectedValue = this.m_AccountPac;
                    this.cbxCity.Enabled = false;
                }
                else if (!this.m_AccountPac.EndsWith("00"))
                {
                    this.cbxCity.SelectedValue = this.m_AccountPac.Substring(0, 4) + "00";
                    this.cbxCity.Enabled = false;
                }
            }
        }

        private void cbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_AreaList == null || this.m_AreaList.Count == 0)
                return;
            var cityCode = this.cbxCity.SelectedValue;
            List<AreaCodeInfo> countyList = new List<AreaCodeInfo>();
            if (cityCode!=null)
            {
                var counties = this.m_AreaList.Where<AreaCodeInfo>(a => !a.Code.EndsWith("00") && cityCode.ToString().Substring(0,4)==a.Code.Substring(0,4)).OrderBy<AreaCodeInfo, string>(u => u.Code);
                if (counties != null)
                    countyList = counties.ToList<AreaCodeInfo>();
            }
            
            countyList.Insert(0, new AreaCodeInfo()
            {
                Name="",
                Code=null
            });
            this.cbxCounty.DisplayMember = "Name";
            this.cbxCounty.ValueMember = "Code";
            this.cbxCounty.DataSource = countyList;
            if (this.m_LocalPac != null)
            {
                if (this.m_LocalPac.Substring(4, 2) != "00")
                {
                    this.cbxCounty.SelectedValue = this.m_LocalPac;
                    this.cbxCounty.Enabled = false;
                }
            }
            else
            {
                if (this.m_AccountPac.Length == 6 && !this.m_AccountPac.EndsWith("00"))
                {
                    this.cbxCounty.SelectedValue = this.m_AccountPac;
                    this.cbxCounty.Enabled = false;
                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
