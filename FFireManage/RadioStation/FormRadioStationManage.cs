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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFireManage.RadioStation
{
    public partial class FormRadioStationManage : Form
    {
        #region 字段
        private Fire_RadioStation currentRadioStation = null;
        private RadioStationController m_RadioStationController = null;
        private List<Fire_RadioStation> m_RadioStationList = null;
        #endregion

        #region 构造函数
        public FormRadioStationManage()
        {
            InitializeComponent();

            this.m_RadioStationController = new RadioStationController();
            this.m_RadioStationController.QueryEvent += (m_RadioStationController_QueryEvent);
            this.m_RadioStationController.DeleteEvent += (m_RadioStationController_DeleteEvent);
        }
        #endregion

        #region 事件响应

        private void m_RadioStationController_QueryEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    try
                    {
                        GetListResultInfo<Fire_RadioStation> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_RadioStation>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            m_RadioStationList = result.rows;

                            this.pagerControl1.NMax = result.total;
                            this.FillData(m_RadioStationList);

                        }
                        else
                        {
                            this.pagerControl1.NMax = 0;
                            this.FillData(null);
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

        private void m_RadioStationController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            this.GetRadioStationList(this.navigationControl1.Pac);
                        }
                        else
                        {
                            MessageBox.Show(this,result.msg, "提示");
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

        private void FormRadioStationManage_Load(object sender, EventArgs e)
        {
            this.pagerControl1.PageCurrent = 1;
            this.pagerControl1.Bind();
            this.pagerControl1.PageSize = 20;
            this.pagerControl1.OnPageChanged += PagerControl1_OnPageChanged;

            this.navigationControl1.UserToolStrip.Visible = false;
            this.navigationControl1.UserToolStrip.Enabled = false;
            this.navigationControl1.SearchToolStrip.Location = new Point(574, 6);

            this.navigationControl1.Init(GlobeHelper.Instance.User);
            this.navigationControl1.BtnAdd.Click += new EventHandler(BtnAdd_Click);
            this.navigationControl1.BtnEdit.Click += new EventHandler(BtnEdit_Click);
            this.navigationControl1.BtnDelete.Click += new EventHandler(BtnDelete_Click);
            this.navigationControl1.CbxProvince.SelectedIndexChanged += CbxProvince_SelectedIndexChanged;
            this.navigationControl1.CbxCity.SelectedIndexChanged += CbxCity_SelectedIndexChanged;
            this.navigationControl1.CbxCounty.SelectedIndexChanged += CbxCounty_SelectedIndexChanged;
            this.navigationControl1.BtnSearch.Click += BtnSearch_Click;
        }

        private void CbxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxProvince.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxProvince.ComboBox.SelectedValue.ToString();
                this.GetRadioStationList(pCode);
            }
        }

        private void CbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                this.GetRadioStationList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxProvince.ComboBox.SelectedValue != null)
                {
                    var provinceCode = this.navigationControl1.CbxProvince.ComboBox.SelectedValue.ToString();
                    this.GetRadioStationList(provinceCode);
                }
            }
        }

        private void CbxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCounty.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCounty.ComboBox.SelectedValue.ToString();
                this.GetRadioStationList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
                {
                    var cityCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                    this.GetRadioStationList(cityCode.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormRadioStation pFormRadioStation = new FormRadioStation(OperationType.Add);
            if (pFormRadioStation.ShowDialog(this) == DialogResult.OK)
            {
                this.GetRadioStationList(this.navigationControl1.Pac);
                MessageBox.Show(this, "无线电台站新增成功", "提示");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FormRadioStation pFormRadioStation = new FormRadioStation(OperationType.Edit, this.currentRadioStation);
            if (pFormRadioStation.ShowDialog(this) == DialogResult.OK)
            {
                this.GetRadioStationList(this.navigationControl1.Pac);
                MessageBox.Show(this, "无线电台站修改成功", "提示");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentRadioStation != null)
            {
                if (MessageBox.Show(this, "您确定要删除" + this.currentRadioStation.name + "吗？数据删除后不可恢复。", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.m_RadioStationController.Delete(this.currentRadioStation.id);
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string key = this.navigationControl1.TbxSearch.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                this.GetRadioStationList(this.navigationControl1.Pac);
                return;
            }

            if (this.m_RadioStationList == null || this.m_RadioStationList.Count == 0)
                return;

            var tempRadioStations = this.m_RadioStationList.Where<Fire_RadioStation>(u => u.name.Contains(key) ||
            u.manager.Contains(key));

            if (tempRadioStations == null)
                return;
            this.FillData(tempRadioStations.ToList<Fire_RadioStation>());
        }

        private void PagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.Pac == null || this.navigationControl1.Pac == "")
                this.GetRadioStationList(GlobeHelper.Instance.User.pac);
            else
                this.GetRadioStationList(this.navigationControl1.Pac);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];

                if (item.Tag != null && item.Tag is Fire_RadioStation)
                {
                    this.currentRadioStation = item.Tag as Fire_RadioStation;

                    this.navigationControl1.BtnEdit.Enabled = true;
                    this.navigationControl1.BtnDelete.Enabled = true;
                }
                else
                {
                    this.currentRadioStation = null;

                    this.navigationControl1.BtnDelete.Enabled = false;
                    this.navigationControl1.BtnEdit.Enabled = false;
                }
            }
            else
            {
                this.currentRadioStation = null;

                this.navigationControl1.BtnDelete.Enabled = false;
                this.navigationControl1.BtnEdit.Enabled = false;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if (item.Tag is Fire_RadioStation)
            {
                var radioStation = item.Tag as Fire_RadioStation;
                FormRadioStation pFormHot = new FormRadioStation(OperationType.Check, radioStation);
                pFormHot.ShowDialog(this);
            }
        }
        #endregion

        #region 成员函数
        private void GetRadioStationList(string pac)
        {
            this.m_RadioStationController.Get(new Dictionary<string, object>()
            {
                {"pac",pac },
                {"fetchType",3 },
                {"page", this.pagerControl1.PageCurrent},
                {"rows",this.pagerControl1.PageSize },
                {"sort","id" },
                {"order","desc"}
            });
        }
        private void FillData(List<Fire_RadioStation> radioStationList)
        {
            this.pagerControl1.Bind();
            this.pagerControl1.bindingSource.DataSource = radioStationList;
            this.pagerControl1.bindingNavigator.BindingSource = this.pagerControl1.bindingSource;
            this.listView1.Items.Clear();

            if (radioStationList != null)
            {
                for (int i = 0; i < radioStationList.Count; i++)
                {
                    Fire_RadioStation radioStation = radioStationList[i];

                    ListViewItem item = new ListViewItem();

                    item.SubItems.Add(radioStation.name);
                    AreaCodeInfo county = null;
                    try
                    {
                        if (this.navigationControl1.AreaList != null)
                            county = this.navigationControl1.AreaList.Where(a => a.code == radioStation.pac).First();
                    }
                    catch { }
                    
                    item.SubItems.Add((county == null) ? "" : county.name);
                    item.SubItems.Add(radioStation.manager);
                    item.SubItems.Add(radioStation.longitude.ToString());
                    item.SubItems.Add(radioStation.latitude.ToString());

                    item.Tag = radioStation;

                    this.listView1.Items.Add(item);
                }
            }
        }
        #endregion

    }
}
