using FFireManage.Model;
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

namespace FFireManage.Hot
{
    public partial class FormHotDetails : Form
    {
        private Fire_Hot currentHot = null;
        private HotOperate hotOperate;
        private HotController hotControler = null;
        private List<AreaCodeInfo> m_AreaList = null;
        private ServiceController m_ServiceController = null;
        private UserInfo m_User = null;

        public FormHotDetails(Fire_Hot hot,HotOperate hotOperate)
        {
            InitializeComponent();

            this.currentHot = hot;
            this.hotOperate = hotOperate;

            this.hotControler = new HotController();
            this.hotControler.GetDetailsEvent += new EventHandler<ServiceEventArgs>(HotControler_GetDetailsEvent);
            this.hotControler.AuditEvent += new EventHandler<ServiceEventArgs>(HotControler_AuditEvent);
            this.hotControler.FeedbackEvent += new EventHandler<ServiceEventArgs>(HotControler_FeedbackEvent);

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

        private void HotControler_FeedbackEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    try
                    {
                        BaseResultInfo<object> result = JsonHelper.JSONToObject<BaseResultInfo<object>>(content);

                        if (result.status == 10000)
                        {
                            MessageBox.Show(this, "添加热点反馈信息成功", "提示");
                            this.DialogResult = DialogResult.OK;
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

        private void HotControler_AuditEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    try
                    {
                        BaseResultInfo<object> result = JsonHelper.JSONToObject<BaseResultInfo<object>>(content);

                        if (result.status == 10000)
                        {
                            MessageBox.Show(this, "热点反馈审核成功", "提示");
                            this.DialogResult = DialogResult.OK;
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

        private void HotControler_GetDetailsEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    try
                    {
                        if(content.Contains("\"examineUser\":\"\""))
                        {
                            content = content.Replace("\"examineUser\":\"\"", "\"examineUser\":0");
                        }
                        BaseResultInfo<Fire_Hot> result = JsonHelper.JSONToObject<BaseResultInfo<Fire_Hot>>(content);

                        if (result.status == 10000 && result.obj!=null)
                        {
                            FillDetails(result.obj);
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

        private void FillDetails(Fire_Hot hot)
        {
            if (this.hotOperate == HotOperate.Feedback)
            {
                this.panel_feedback.Visible = false;
                this.tabControl1.TabPages.Remove(this.tabPage_ExamineInfo);
                this.btnExamine.Visible = false;
            }
            else
            {
                this.tbx_hly_name.Text = this.currentHot.hotFeedback.initiator_name;
                try
                {
                    this.dtp_createTime.Value = Convert.ToDateTime(this.currentHot.hotFeedback.createTime);
                }
                catch { }
                this.tbx_HotDetails.Text = this.currentHot.hotFeedback.description;
                if(this.currentHot.hotFeedback.mediaFiles!=null)
                    this.mediaControl1.MediaFiles = this.currentHot.hotFeedback.mediaFiles;
                this.tbx_hly_name.Enabled = false;
                this.dtp_createTime.Enabled = false;
                this.tbx_HotDetails.Enabled = false;


                if (this.hotOperate == HotOperate.Examine)
                {
                    this.label_county_name.Visible = false;
                    this.tbx_county_name.Visible = false;
                    this.label_examineTime.Visible = false;
                    this.dtp_ExamineTime.Visible = false;
                    this.btnFeedback.Visible = false;
                }
                else
                {
                    this.tbx_county_name.Text = this.currentHot.hotFeedback.examineUser_name;
                    try
                    {
                        this.dtp_ExamineTime.Value = Convert.ToDateTime(this.currentHot.hotFeedback.examineTime);
                    }
                    catch { }
                    this.tbx_county_option.Text = this.currentHot.hotFeedback.examineOption;

                    this.tbx_county_name.Enabled = false;
                    this.dtp_ExamineTime.Enabled = false;
                    this.tbx_county_option.Enabled = false;
                    this.btnFeedback.Visible = false;
                    this.btnExamine.Visible = false;
                }
            }
            
        }

        private void FormHotDetails_Load(object sender, EventArgs e)
        {
            #region 初始化控件内容
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

            HotType hotType = HotType.其他;
            List<object> hotTypeList = CommonHelper.GetDataSource<HotType>(hotType);
            this.cbx_type.DisplayMember = "Name";
            this.cbx_type.ValueMember = "Value";
            this.cbx_type.DataSource = hotTypeList;
            #endregion

            //初始化行政区数据
            this.Init(GlobeHelper.Instance.User);

            #region 编辑、查看时为控件赋值
            if (this.currentHot != null)
            {
                this.coordinatesInputControl11.Longitude = this.currentHot.longitude;
                this.coordinatesInputControl11.Latitude = this.currentHot.latitude;
                this.tbx_no.Text = this.currentHot.no;
                this.tbx_pixels.Text = this.currentHot.pixels.ToString();
                this.tbx_satellite.Text = this.currentHot.satellite;
                this.cbx_smoke.SelectedValue = this.currentHot.smoke;
                this.cbx_continuous.SelectedValue = this.currentHot.continuous;
                this.tbx_landType.Text = this.currentHot.landtype;
                this.dateTimePicker_receiptTime.Value = (this.currentHot.receiptt == "" || this.currentHot.receiptt == null) ? DateTime.Now : Convert.ToDateTime(this.currentHot.receiptt);
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
                
            }
            #endregion

            this.hotControler.GetDetails(new Dictionary<string, object>()
                {
                    {"id",this.currentHot.id }
                });

            if (hotOperate != HotOperate.Feedback)
            {
                this.hotControler.GetDetails(new Dictionary<string, object>()
                {
                    {"id",this.currentHot.id }
                });
            }
            else
            {
                this.panel_feedback.Visible = false;
                this.tabControl1.TabPages.Remove(this.tabPage_ExamineInfo);
                this.btnExamine.Visible = false;
            }

        }

        #region 初始化行政区数据
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

            if (this.currentHot != null && this.currentHot.pac != null)
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
        #endregion

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            if(this.tbx_HotDetails.Text.Trim()=="")
            {
                MessageBox.Show(this,"请输入反馈详情", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbx_HotDetails.Focus();
                return;
            }
            HotFeedback feedback = new HotFeedback()
            {
                description = this.tbx_HotDetails.Text.Trim(),
                initiator = 94,
                MediaFileDict = this.mediaControl1.MediaByteDict
            };
            this.currentHot.hotFeedback = feedback;
            this.hotControler.Feedback(currentHot);
        }

        private void btnExamine_Click(object sender, EventArgs e)
        {
            if (this.tbx_county_option.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入审核意见", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbx_HotDetails.Focus();
                return;
            }
            int state = 0;
            if (GlobeHelper.Instance.User.pac.EndsWith("0000"))
                state = 4;
            else if (!GlobeHelper.Instance.User.pac.EndsWith("00"))
                state = 2;
            else
                state = 3;
            this.hotControler.Audit(new Dictionary<string, object>()
           {
               {"id",this.currentHot.hotFeedback.id },
               {"state",state },
               {"user_county_id",GlobeHelper.Instance.User.id },
               {"county_option",this.tbx_county_option.Text.Trim() }
           });

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public enum HotOperate
    {
        Feedback=1,
        Examine=2,
        Details=3
    }
}
