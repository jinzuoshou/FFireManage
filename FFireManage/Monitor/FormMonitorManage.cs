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

namespace FFireManage.Monitor
{
    public partial class FormMonitorManage : Form
    {
        #region 成员变量
        private Fire_ForestRemoteMonitoring currentMonitor = null;
        private MonitoringController m_MonitoringController = null;
        private List<Fire_ForestRemoteMonitoring> m_MonitorList = null;
        #endregion

        #region 构造函数
        public FormMonitorManage()
        {
            InitializeComponent();

            this.m_MonitoringController = new MonitoringController();
            this.m_MonitoringController.QueryEvent += m_MonitoringController_QueryEvent;
            this.m_MonitoringController.DeleteEvent += m_MonitoringController_DeleteEvent;
        }
        #endregion

        #region 事件响应

        private void m_MonitoringController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            this.GetMonitorList(this.navigationControl1.Pac);
                        }
                        else
                        {
                            MessageBox.Show(result.msg, "信息提示");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "信息提示");
                    }

                    
                }
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void m_MonitoringController_QueryEvent(object sender, ServiceEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<Fire_ForestRemoteMonitoring> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_ForestRemoteMonitoring>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            m_MonitorList = result.rows;

                            this.pagerControl1.NMax = result.total;
                            this.FillData(m_MonitorList);
                        }
                        else
                        {
                            this.pagerControl1.NMax = 0;
                            this.FillData(null);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "信息提示");
                    }
                    
                }
                else
                {
                    MessageBox.Show(sender.ToString(), "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }));
        }

        private void FormMonitorManage_Load(object sender, EventArgs e)
        {
            this.pagerControl1.PageCurrent = 1;
            this.pagerControl1.Bind();
            this.pagerControl1.PageSize = 5;
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

        private void PagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.Pac == null || this.navigationControl1.Pac == "")
                this.GetMonitorList(GlobeHelper.Instance.User.pac);
            else
                this.GetMonitorList(this.navigationControl1.Pac);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormMonitor pFormAddMonitor = new FormMonitor(OperationType.Add);
            if (pFormAddMonitor.ShowDialog(this) == DialogResult.OK)
            {
                this.GetMonitorList(this.navigationControl1.Pac);
                MessageBox.Show(this, "视频监控点新增成功", "提示");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FormMonitor pFormEditMonitor = new FormMonitor(OperationType.Edit, this.currentMonitor);
            if (pFormEditMonitor.ShowDialog(this) == DialogResult.OK)
            {
                this.GetMonitorList(this.navigationControl1.Pac);
                MessageBox.Show(this, "视频监控点修改成功", "提示");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentMonitor != null)
            {
                if (MessageBox.Show(this, "您确定要删除" + this.currentMonitor.name + "吗？数据删除后不可恢复。", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.m_MonitoringController.Delete(this.currentMonitor.id);
                }
            }
        }

        private void CbxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxProvince.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxProvince.ComboBox.SelectedValue.ToString();
                this.GetMonitorList(pCode);
            }
        }

        private void CbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                this.GetMonitorList(pCode);
            }
            else
            {
                var provinceCode = this.navigationControl1.CbxProvince.ComboBox.SelectedValue.ToString();
                this.GetMonitorList(provinceCode);
            }
        }

        private void CbxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCounty.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCounty.ComboBox.SelectedValue.ToString();
                this.GetMonitorList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
                {
                    var cityCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                    this.GetMonitorList(cityCode.ToString());
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string key = this.navigationControl1.TbxSearch.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                this.GetMonitorList(this.navigationControl1.Pac);
                return;
            }
                
            if (this.m_MonitorList == null || this.m_MonitorList.Count == 0)
                return;

            var tempMonitors = this.m_MonitorList.Where<Fire_ForestRemoteMonitoring>(u => u.name.Contains(key) ||
            u.county.Contains(key) ||
            u.manager.Contains(key)||
            u.address.Contains(key));

            if (tempMonitors == null)
                return;
            this.FillData(tempMonitors.ToList<Fire_ForestRemoteMonitoring>());
        }

        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];

                if (item.Tag != null && item.Tag is Fire_ForestRemoteMonitoring)
                {
                    this.currentMonitor = item.Tag as Fire_ForestRemoteMonitoring;

                    this.navigationControl1.BtnEdit.Enabled = true;
                    this.navigationControl1.BtnDelete.Enabled = true;
                }
                else
                {
                    this.currentMonitor = null;

                    this.navigationControl1.BtnDelete.Enabled = false;
                    this.navigationControl1.BtnEdit.Enabled = false;
                }
            }
            else
            {
                this.currentMonitor = null;

                this.navigationControl1.BtnDelete.Enabled = false;
                this.navigationControl1.BtnEdit.Enabled = false;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if (item.Tag is Fire_ForestRemoteMonitoring)
            {
                var monitor = item.Tag as Fire_ForestRemoteMonitoring;
                FormMonitor pFormHot = new FormMonitor(OperationType.Check, monitor);
                pFormHot.ShowDialog(this);
            }
        }
        #endregion

        #region 成员函数
        private void FillData(List<Fire_ForestRemoteMonitoring> monitorList)
        {
            this.pagerControl1.Bind();
            this.pagerControl1.bindingSource.DataSource = monitorList;
            this.pagerControl1.bindingNavigator.BindingSource = this.pagerControl1.bindingSource;
            this.listView1.Items.Clear();

            if (monitorList != null)
            {

                for (int i = 0; i < monitorList.Count; i++)
                {
                    Fire_ForestRemoteMonitoring monitor = monitorList[i];

                    ListViewItem item = new ListViewItem();

                    item.SubItems.Add(monitor.name);
                    item.SubItems.Add((monitor.county == null) ? "" : monitor.county);
                    item.SubItems.Add(monitor.manager);
                    item.SubItems.Add(monitor.longitude.ToString());
                    item.SubItems.Add(monitor.latitude.ToString());

                    item.Tag = monitor;

                    this.listView1.Items.Add(item);
                }
            }
        }

        private void GetMonitorList(string pac)
        {
            this.m_MonitoringController.Get(new Dictionary<string, object>()
            {
                {"pac",pac },
                {"fetchType",3 },
                {"page", this.pagerControl1.PageCurrent},
                {"rows",this.pagerControl1.PageSize },
                {"sort","id" },
                {"order","desc"}
            });
        }
        #endregion

    }
}
