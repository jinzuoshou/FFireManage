using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FFireManage.Model;
using FFireManage.Service;
using FFireManage.Utility;

namespace FFireManage.Hot
{
    public partial class FormHotManage : Form
    {
        #region 成员变量
        private Fire_Hot currentHot = null;
        private ServiceController m_ServiceController = null;
        private List<Fire_Hot> currentHotList = null;
        private ListViewItem currentItem = null;
        #endregion

        #region 构造函数
        public FormHotManage()
        {
            InitializeComponent();

            this.m_ServiceController = new ServiceController();
            this.m_ServiceController.GetHotListEvent+=new EventHandler(m_ServiceController_GetHotListEvent);
            this.m_ServiceController.DeleteHotEvent+=new EventHandler(m_ServiceController_DeleteHotEvent);
        }
        #endregion

        #region 事件响应
        private void m_ServiceController_GetHotListEvent(object sender, EventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = sender.ToString();

                    GetListResultInfo<Fire_Hot> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_Hot>>(content);

                    if (result.rows != null && result.rows.Count > 0)
                    {
                        currentHotList = result.rows;

                        this.pager1.NMax = result.total;
                        this.FillData(currentHotList);
                        
                    }
                    else
                    {
                        this.pager1.NMax = 0;
                        this.FillData(null);
                    }
                }
                else
                {
                    MessageBox.Show(sender.ToString(), "获取热点列表出错", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }));
        }
        private void m_ServiceController_DeleteHotEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = sender.ToString();

                    BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                    if (result.status == 10000)
                    {
                        this.GetHotList(this.navigationControl1.Pac);
                    }
                }
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void FormFormHotManage_Load(object sender, EventArgs e)
        {
            this.pager1.PageCurrent = 1;
            this.pager1.Bind();
            this.pager1.PageSize = 20;
            this.pager1.OnPageChanged += pager1_OnPageChanged;

            this.navigationControl1.UserToolStrip.Visible = false;
            this.navigationControl1.UserToolStrip.Enabled = false;
            this.navigationControl1.SearchToolStrip.Location = new Point(574, 6);
            this.navigationControl1.Init(GlobeHelper.Instance.User);
            this.navigationControl1.BtnAdd.Click+=new EventHandler(BtnAdd_Click);
            this.navigationControl1.BtnEdit.Click+=new EventHandler(BtnEdit_Click);
            this.navigationControl1.BtnDelete.Click+=new EventHandler(BtnDelete_Click);
            this.navigationControl1.CbxProvince.SelectedIndexChanged += CbxProvince_SelectedIndexChanged;
            this.navigationControl1.CbxCity.SelectedIndexChanged += CbxCity_SelectedIndexChanged;
            this.navigationControl1.CbxCounty.SelectedIndexChanged += CbxCounty_SelectedIndexChanged;
            this.navigationControl1.BtnSearch.Click += BtnSearch_Click;
        }

        private void pager1_OnPageChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.Pac == null || this.navigationControl1.Pac == "")
                this.GetHotList(GlobeHelper.Instance.User.pac);
            else
                this.GetHotList(this.navigationControl1.Pac);
        }

        private void CbxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCounty.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCounty.ComboBox.SelectedValue.ToString();
                this.GetHotList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
                {
                    var cityCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                    this.GetHotList(cityCode.ToString());
                }
            }
        }

        private void CbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                this.GetHotList(pCode);
            }
            else
            {
                var provinceCode = this.navigationControl1.CbxProvince.ComboBox.SelectedValue.ToString();
                this.GetHotList(provinceCode);
            }
          
        }

        private void CbxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.navigationControl1.CbxProvince.ComboBox.SelectedValue!=null)
            {
                string pCode = this.navigationControl1.CbxProvince.ComboBox.SelectedValue.ToString();
                this.GetHotList(pCode);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormHot pFormAddHot = new FormHot(OperationType.Add);
            if (pFormAddHot.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.GetHotList(this.navigationControl1.Pac);
                MessageBox.Show(this, "热点添加成功", "提示");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FormHot pFormEditHot = new FormHot(OperationType.Edit,this.currentHot);
            if (pFormEditHot.ShowDialog(this) == DialogResult.OK)
            {
                this.GetHotList(this.navigationControl1.Pac);
                MessageBox.Show(this, "热点修改成功", "提示");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentHot != null)
            {
                if (MessageBox.Show(this, "您确定要删除" + this.currentHot.no + "吗？数据删除后不可恢复。", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.m_ServiceController.DeleteHotForGet(this.currentHot.id);
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string key = this.navigationControl1.TbxSearch.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                this.GetHotList(this.navigationControl1.Pac);
                return;
            }
            if (this.currentHotList == null || this.currentHotList.Count == 0)
                return;

            var tempUsers = this.currentHotList.Where<Fire_Hot>(u => u.no.Contains(key) ||
            u.county.Contains(key) ||
            u.reporter.Contains(key));
            
            if (tempUsers == null)
                return;
            this.FillData(tempUsers.ToList<Fire_Hot>());
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];

                if (item.Tag != null && item.Tag is Fire_Hot)
                {
                    this.currentHot = item.Tag as Fire_Hot;

                    this.navigationControl1.BtnEdit.Enabled = true;
                    this.navigationControl1.BtnDelete.Enabled = true;
                }
                else
                {
                    this.currentHot = null;

                    this.navigationControl1.BtnDelete.Enabled = false;
                    this.navigationControl1.BtnEdit.Enabled = false;
                }
            }
            else
            {
                this.currentHot = null;

                this.navigationControl1.BtnDelete.Enabled = false;
                this.navigationControl1.BtnEdit.Enabled = false;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if (item.Tag is Fire_Hot)
            {
                var hot = item.Tag as Fire_Hot;
                FormHot pFormHot = new FormHot(OperationType.Check, hot);
                pFormHot.ShowDialog(this);
            }
        }
        #endregion

        #region 成员函数
        private void FillData(List<Fire_Hot> hotList)
        {
            this.pager1.Bind();
            this.pager1.bindingSource.DataSource = hotList;
            this.pager1.bindingNavigator.BindingSource = this.pager1.bindingSource;
            this.listView1.Items.Clear();

            if (hotList != null)
            {

                for (int i = 0; i < hotList.Count; i++)
                {
                    Fire_Hot hot = hotList[i];

                    ListViewItem item = new ListViewItem();

                    item.SubItems.Add(hot.no);
                    AreaCodeInfo county = null;
                    try
                    {
                        if (this.navigationControl1.AreaList != null)
                            county = this.navigationControl1.AreaList.Where(a => a.Code == hot.pac).First();
                    }
                    catch { }
                    item.SubItems.Add((hot.county == null && county!=null) ? county.Name : hot.county);
                    item.SubItems.Add(Enum.GetName(typeof(HotType), hot.type));
                    item.SubItems.Add(hot.reporter);
                    item.SubItems.Add(hot.reporttime);

                    item.Tag = hot;

                    this.listView1.Items.Add(item);
                }
            }
        }

        private void GetHotList(string pac)
        {
            this.m_ServiceController.GetHotListForGet(pac,3,(this.pager1.PageCurrent==0)?1:this.pager1.PageCurrent,this.pager1.PageSize, "reporttime", "desc");
        }
        #endregion

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                currentItem = this.listView1.GetItemAt(e.X, e.Y);
                if (currentItem == null)
                    return;
                if(currentItem.Tag is Fire_Hot)
                {
                    Fire_Hot hot = currentItem.Tag as Fire_Hot;
                    if(hot.status==0)
                    {
                        this.MenuItem_Examine.Visible = false;
                    }
                    else if(hot.status==1)
                    {
                        this.MenuItem_Feedback.Visible = false;
                    }
                    else
                    {

                    }
                }
                this.contextMenuStrip1.Show(this, e.Location);
            }
        }

        private void MenuItem_Feedback_Click(object sender, EventArgs e)
        {
            if  (currentItem!=null&& currentItem.Tag is Fire_Hot)
            {
                Fire_Hot hot = currentItem.Tag as Fire_Hot;
                FormHotDetails form = new FormHotDetails(hot, HotOperate.Feedback);
                if(form.ShowDialog() == DialogResult.OK)
                {
                    this.GetHotList(this.navigationControl1.Pac);
                }
            }
        }

        private void MenuItem_Examine_Click(object sender, EventArgs e)
        {
            if (currentItem != null && currentItem.Tag is Fire_Hot)
            {
                Fire_Hot hot = currentItem.Tag as Fire_Hot;
                FormHotDetails form = new FormHotDetails(hot, HotOperate.Examine);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.GetHotList(this.navigationControl1.Pac);
                }
            }
        }
    }
}
