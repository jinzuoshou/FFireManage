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

namespace FFireManage.WatchTower
{
    public partial class FormWatchTowerManage : Form
    {
        #region 字段
        private Fire_Observatory currentWatchTower = null;
        private ServiceController m_ServiceController = null;
        private List<Fire_Observatory> m_WatchTowerList = null;
        #endregion

        #region 构造函数
        public FormWatchTowerManage()
        {
            InitializeComponent();
            this.m_ServiceController = new ServiceController();
            this.m_ServiceController.GetWatchTowerListEvent += new EventHandler(m_ServiceController_GetWatchTowerListEvent);
            this.m_ServiceController.DeleteWatchTowerEvent += new EventHandler(m_ServiceController_DeleteWatchTowerEvent);
        }

        #endregion

        #region 事件响应
        private void m_ServiceController_GetWatchTowerListEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = sender.ToString();

                    GetListResultInfo<Fire_Observatory> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_Observatory>>(content);

                    if (result.rows != null && result.rows.Count > 0)
                    {
                        m_WatchTowerList = result.rows;

                        this.pagerControl1.NMax = result.total;
                        this.FillData(m_WatchTowerList);

                    }
                    else
                    {
                        this.pagerControl1.NMax = 0;
                        this.FillData(null);
                    }
                }
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void m_ServiceController_DeleteWatchTowerEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = sender.ToString();

                    BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                    if (result.status == 10000)
                    {
                        this.GetWatchTowerList(this.navigationControl1.Pac);
                    }
                }
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void FillData(List<Fire_Observatory> m_WatchTowerList)
        {
            this.pagerControl1.Bind();
            this.pagerControl1.bindingSource.DataSource = m_WatchTowerList;
            this.pagerControl1.bindingNavigator.BindingSource = this.pagerControl1.bindingSource;
            this.listView1.Items.Clear();

            if (m_WatchTowerList != null)
            {

                for (int i = 0; i < m_WatchTowerList.Count; i++)
                {
                    Fire_Observatory watchTower = m_WatchTowerList[i];

                    ListViewItem item = new ListViewItem();

                    item.SubItems.Add(watchTower.name);
                    item.SubItems.Add(watchTower.name);
                    AreaCodeInfo county = null;
                    try
                    {
                        if (this.navigationControl1.AreaList != null)
                            county = this.navigationControl1.AreaList.Where(a => a.code == watchTower.pac).First();
                    }
                    catch { }

                    item.SubItems.Add((county == null) ? "" : county.name);
                    item.SubItems.Add(watchTower.manager);
                    item.SubItems.Add(watchTower.longitude.ToString());
                    item.SubItems.Add(watchTower.latitude.ToString());

                    item.Tag = watchTower;

                    this.listView1.Items.Add(item);
                }
            }
        }

        private void FormWatchTowerManage_Load(object sender, EventArgs e)
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
                this.GetWatchTowerList(pCode);
            }
        }

        private void CbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                this.GetWatchTowerList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxProvince.ComboBox.SelectedValue != null)
                {
                    var provinceCode = this.navigationControl1.CbxProvince.ComboBox.SelectedValue.ToString();
                    this.GetWatchTowerList(provinceCode);
                }
            }
        }

        private void CbxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCounty.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCounty.ComboBox.SelectedValue.ToString();
                this.GetWatchTowerList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
                {
                    var cityCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                    this.GetWatchTowerList(cityCode.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormWatchTower pFormWatchTower = new FormWatchTower(OperationType.Add);
            if (pFormWatchTower.ShowDialog(this) == DialogResult.OK)
            {
                this.GetWatchTowerList(this.navigationControl1.Pac);
                MessageBox.Show(this, "瞭望台新增成功", "提示");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FormWatchTower pFormWatchTower = new FormWatchTower(OperationType.Edit, this.currentWatchTower);
            if (pFormWatchTower.ShowDialog(this) == DialogResult.OK)
            {
                this.GetWatchTowerList(this.navigationControl1.Pac);
                MessageBox.Show(this, "瞭望台修改成功", "提示");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentWatchTower != null)
            {
                if (MessageBox.Show(this, "您确定要删除" + this.currentWatchTower.name + "吗？数据删除后不可恢复。", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.m_ServiceController.DeleteWatchTowerForGet(this.currentWatchTower.id);
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string key = this.navigationControl1.TbxSearch.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                this.GetWatchTowerList(this.navigationControl1.Pac);
                return;
            }

            if (this.m_WatchTowerList == null || this.m_WatchTowerList.Count == 0)
                return;

            var tempFireCommands = this.m_WatchTowerList.Where<Fire_Observatory>(u => u.name.Contains(key) ||
            u.manager.Contains(key));

            if (tempFireCommands == null)
                return;
            this.FillData(tempFireCommands.ToList<Fire_Observatory>());
        }
        
        private void PagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.Pac == null || this.navigationControl1.Pac == "")
                this.GetWatchTowerList(GlobeHelper.Instance.User.pac);
            else
                this.GetWatchTowerList(this.navigationControl1.Pac);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];

                if (item.Tag != null && item.Tag is Fire_Observatory)
                {
                    this.currentWatchTower = item.Tag as Fire_Observatory;

                    this.navigationControl1.BtnEdit.Enabled = true;
                    this.navigationControl1.BtnDelete.Enabled = true;
                }
                else
                {
                    this.currentWatchTower = null;

                    this.navigationControl1.BtnDelete.Enabled = false;
                    this.navigationControl1.BtnEdit.Enabled = false;
                }
            }
            else
            {
                this.currentWatchTower = null;

                this.navigationControl1.BtnDelete.Enabled = false;
                this.navigationControl1.BtnEdit.Enabled = false;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if (item.Tag is Fire_Observatory)
            {
                var watchTower = item.Tag as Fire_Observatory;
                FormWatchTower pFormHot = new FormWatchTower(OperationType.Check, watchTower);
                pFormHot.ShowDialog(this);
            }
        }
        #endregion

        #region 成员函数
        private void GetWatchTowerList(string pac)
        {
            this.m_ServiceController.GetWatchTowerListForGet(pac, 3, this.pagerControl1.PageCurrent, this.pagerControl1.PageSize, "id", "desc");
        }
        #endregion
    }
}
