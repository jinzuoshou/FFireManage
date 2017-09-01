using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Linq.Expressions;
using FFireManage.Model;
using FFireManage.Service;
using FFireManage.Utility;

namespace FFireManage.Hot
{
    public partial class FormHot : Form
    {
        private Fire_Hot currentHot = null;
        private UserInfo m_User = null;
        private OperationType m_OperationType;
        private HotController m_HotController = null;
        private AreaCodeController m_AreaCodeController = null;
        private List<AreaCodeInfo> m_AreaList = null;

        private string m_Pac = null;

        /// <summary>
        /// 只读属性：获取用户pac（行政区代码）
        /// </summary>
        public string Pac
        {
            get
            {
                if (this.cbx_county.SelectedValue != null)
                {
                    this.m_Pac = this.cbx_county.SelectedValue.ToString();
                }
                else if (this.cbx_city.SelectedValue != null)
                {
                    this.m_Pac = this.cbx_city.SelectedValue.ToString();
                }
                else if (this.cbx_province.SelectedValue != null)
                {
                    this.m_Pac = this.cbx_province.SelectedValue.ToString();
                }
                return this.m_Pac;
            }
            private set { this.m_Pac = value; }
        }

        public FormHot(OperationType type,Fire_Hot hot=null)
        {
            InitializeComponent();
            this.m_OperationType = type;
            this.currentHot = hot;

            this.m_AreaCodeController = new AreaCodeController();
            this.m_AreaCodeController.QueryEvent += m_AreaCodeController_QueryEvent;

            this.m_HotController = new HotController();
            this.m_HotController.AddEvent += m_HotController_AddEvent;
            this.m_HotController.EditEvent += m_HotController_EditEvent;
        }

        private void m_AreaCodeController_QueryEvent(object sender, ServiceEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<AreaCodeInfo> result = JsonHelper.JSONToObject<GetListResultInfo<AreaCodeInfo>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            m_AreaList = result.rows;

                            this.LoadProvince(m_AreaList);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this,ex.Message, "信息提示");
                    }
                }
                else
                {
                    MessageBox.Show(sender.ToString(), "获取行政区出错", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }));
        }

        private void FormFireHot_Load(object sender, EventArgs e)
        {
            #region 初始化控件内容

            if(m_OperationType==OperationType.Add)
            {
                this.Text = "新增热点";
            }
            else if(m_OperationType==OperationType.Edit)
            {
                this.Text = "编辑热点";
            }
            else if(m_OperationType==OperationType.Check)
            {
                this.Text = "查看热点";
            }

            HotSmokeType smokeType = HotSmokeType.无;
            List<object> smokeTypeList = CommonHelper.GetDataSource<HotSmokeType>(smokeType);
            this.cbx_smoke.DisplayMember = "Name";
            this.cbx_smoke.ValueMember = "Value";
            this.cbx_smoke.DataSource = smokeTypeList;

            HotContinuousType continuousType = HotContinuousType.非连续;
            List<object> scontinuousTypeList = CommonHelper.GetDataSource<HotContinuousType>(continuousType);
            this.cbx_continuous.DisplayMember = "Name";
            this.cbx_continuous.ValueMember = "Value";
            this.cbx_continuous.DataSource = scontinuousTypeList;

            HotType hotType=HotType.其他;
            List<object> hotTypeList = CommonHelper.GetDataSource<HotType>(hotType);
            this.cbx_type.DisplayMember = "Name";
            this.cbx_type.ValueMember = "Value";
            this.cbx_type.DataSource = hotTypeList;

            this.tbx_cre_pers.Text = GlobeHelper.Instance.User.name;
            #endregion

            //初始化行政区数据
            this.Init(GlobeHelper.Instance.User);

            #region 编辑、查看时为控件赋值
            if(this.currentHot!=null && this.m_OperationType!=OperationType.Add)
            {
                this.coordinatesInputControl1.Longitude = this.currentHot.longitude;
                this.coordinatesInputControl1.Latitude = this.currentHot.latitude;
                this.tbx_no.Text = this.currentHot.no;
                this.tbx_pixels.Text = this.currentHot.pixels.ToString();
                this.tbx_satellite.Text = this.currentHot.satellite;
                this.cbx_smoke.SelectedValue = this.currentHot.smoke;
                this.cbx_continuous.SelectedValue = this.currentHot.continuous;
                this.tbx_landType.Text = this.currentHot.landtype;
                this.dateTimePicker_receiptTime.Value = (this.currentHot.receiptt == "" || this.currentHot.receiptt ==null) ? DateTime.Now : Convert.ToDateTime(this.currentHot.receiptt);
                this.dateTimePicker_reportTime.Value = (this.currentHot.reporttime == "" || this.currentHot.reporttime == null) ? DateTime.Now : Convert.ToDateTime(this.currentHot.reporttime);
                if (this.currentHot.pac != null && this.currentHot.pac != "")
                {
                    this.cbx_province.SelectedValue = this.currentHot.pac.Substring(0, 2) + "0000";
                    this.cbx_city.SelectedValue = this.currentHot.pac.Substring(0, 4) + "00";
                    this.cbx_county.SelectedValue = this.currentHot.pac;
                }
                this.tbx_duty.Text = this.currentHot.duty;
                this.tbx_reporter.Text = this.currentHot.reporter;
                this.cbx_type.SelectedValue = this.currentHot.type;
                this.tbx_opinion.Text = this.currentHot.opinion;
                this.tbx_note.Text = this.currentHot.note;
                this.tbx_cre_pers.Text = this.currentHot.cre_pers;
                if(this.m_OperationType==OperationType.Check)
                {
                    this.btnOK.Visible = false;
                }
            }
            #endregion
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
                this.m_AreaCodeController.GetList(this.m_User.pac, 3);
            }
            else if (this.m_User.pac.Length == 6 && !this.m_User.pac.EndsWith("0000"))
            {
                this.m_AreaCodeController.GetList(this.m_User.pac.Substring(0, 2) + "0000", 3);
            }
        }
        private void LoadProvince(List<AreaCodeInfo> areaList)
        {
            if (areaList == null || areaList.Count == 0)
                return;
            if (this.m_User.pac.Length == 6 && this.m_User.pac.EndsWith("00"))
            {
                var provinces = areaList.Where<AreaCodeInfo>(u => u.code.EndsWith("0000")).OrderBy<AreaCodeInfo, string>(u => u.code);
                if (provinces == null)
                    return;

                this.cbx_province.DisplayMember = "Name";
                this.cbx_province.ValueMember = "Code";
                this.cbx_province.DataSource = provinces.ToList<AreaCodeInfo>();
                this.cbx_province.Enabled = false;
            }
        }
        private void cbx_province_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_AreaList == null || this.m_AreaList.Count == 0)
                return;
            var cities = this.m_AreaList.Where<AreaCodeInfo>(a => a.code.EndsWith("00") && !a.code.EndsWith("0000")).OrderBy<AreaCodeInfo, string>(u => u.code);
            if (cities == null || cities.Count() == 0)
                return;
            List<AreaCodeInfo> cityList = cities.ToList<AreaCodeInfo>();

            this.cbx_city.DisplayMember = "Name";
            this.cbx_city.ValueMember = "Code";
            this.cbx_city.DataSource = cityList;

            if (this.currentHot != null && this.currentHot.pac != null)
            {
                if (currentHot.pac.Substring(2, 4) != "0000" && currentHot.pac.Substring(4, 2) == "00")
                {
                    this.cbx_city.SelectedValue = currentHot.pac;
                    this.cbx_city.Enabled = false;
                }
                else if (currentHot.pac.Substring(4, 2) != "00")
                {
                    this.cbx_city.SelectedValue = currentHot.pac.Substring(0, 4) + "00";
                    this.cbx_city.Enabled = false;
                }
            }

            else
            {
                if (this.m_User.pac.EndsWith("00") && !this.m_User.pac.EndsWith("0000"))
                {
                    this.cbx_city.SelectedValue = this.m_User.pac;
                    this.cbx_city.Enabled = false;
                }
                else if (!this.m_User.pac.EndsWith("00"))
                {
                    this.cbx_city.SelectedValue = this.m_User.pac.Substring(0, 4) + "00";
                    this.cbx_city.Enabled = false;
                }
            }
        }

        private void cbx_city_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_AreaList == null || this.m_AreaList.Count == 0)
                return;
            var cityCode = this.cbx_city.SelectedValue;
            List<AreaCodeInfo> countyList = new List<AreaCodeInfo>();
            if (cityCode != null)
            {
                var counties = this.m_AreaList.Where<AreaCodeInfo>(a => !a.code.EndsWith("00") && cityCode.ToString().Substring(0, 4) == a.code.Substring(0, 4)).OrderBy<AreaCodeInfo, string>(u => u.code);
                if (counties != null)
                    countyList = counties.ToList<AreaCodeInfo>();
            }

            this.cbx_county.DisplayMember = "Name";
            this.cbx_county.ValueMember = "Code";
            this.cbx_county.DataSource = countyList;

            if (this.currentHot!=null && this.currentHot.pac != null)
            {
                if (this.currentHot.pac.Substring(4, 2) != "00")
                {
                    this.cbx_county.SelectedValue = this.currentHot.pac;
                    this.cbx_county.Enabled = false;
                }
            }
            else
            {
                if (this.m_User.pac.Length == 6 && !this.m_User.pac.EndsWith("00"))
                {
                    this.cbx_county.SelectedValue = this.m_User.pac;
                    this.cbx_county.Enabled = false;
                }
            }
        }

        private void cbx_country_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.coordinatesInputControl1.Longitude==0 || this.coordinatesInputControl1.Latitude==0)
            {
                MessageBox.Show(this, "请输入正确的经纬度信息", "信息提示");
                this.coordinatesInputControl1.Focus();
                return;
            }
            if(this.tbx_no.Text=="")
            {
                MessageBox.Show(this, "请输入热点编号", "信息提示");
                this.tbx_no.Focus();
                return;
            }
            if(this.tbx_pixels.Text=="")
            {
                MessageBox.Show(this, "请输入热点像素", "信息提示");
                this.tbx_pixels.Focus();
                return;
            }
            if(this.Pac==null &&this.Pac=="" && this.Pac.EndsWith("00"))
            {
                MessageBox.Show(this, "请选择正确的行政区", "信息提示");
                this.cbx_county.Focus();
                return;
            }
            if(this.tbx_reporter.Text=="")
            {
                MessageBox.Show(this, "请输入上报人", "信息提示");
                this.tbx_reporter.Focus();
                return;
            }
            if (m_OperationType == OperationType.Add)
            {
                this.currentHot = new Fire_Hot();
            }

            this.currentHot.longitude = this.coordinatesInputControl1.Longitude;
            this.currentHot.latitude = this.coordinatesInputControl1.Latitude;
            this.currentHot.no = this.tbx_no.Text;
            this.currentHot.pixels = Convert.ToInt32(this.tbx_pixels.Text);
            this.currentHot.satellite = this.tbx_satellite.Text;
            this.currentHot.smoke = Convert.ToInt32(this.cbx_smoke.SelectedValue);
            this.currentHot.continuous = Convert.ToInt32(this.cbx_continuous.SelectedValue);
            this.currentHot.landtype = this.tbx_landType.Text;
            this.currentHot.receiptt = this.dateTimePicker_receiptTime.Value.ToString("yyyy-MM-dd hh:mm:ss");
            this.currentHot.reporttime = this.dateTimePicker_reportTime.Value.ToString("yyyy-MM-dd hh:mm:ss");
            this.currentHot.county = this.cbx_county.Text;
            this.currentHot.pac = this.Pac;
            this.currentHot.duty = this.tbx_duty.Text;
            this.currentHot.reporter = this.tbx_reporter.Text;
            this.currentHot.type = Convert.ToInt32(this.cbx_type.SelectedValue);
            this.currentHot.opinion = this.tbx_opinion.Text;
            this.currentHot.cre_pers = this.tbx_cre_pers.Text;
            this.currentHot.note = this.tbx_note.Text;

            if (m_OperationType==OperationType.Add)
            {
                this.currentHot.status = 0;
                this.m_HotController.Add(this.currentHot);
            }
            else if(m_OperationType==OperationType.Edit)
            { 
                this.m_HotController.Edit(this.currentHot);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void m_HotController_EditEvent(object sender, ServiceEventArgs e)
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

        private void m_HotController_AddEvent(object sender, ServiceEventArgs e)
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

    }
}