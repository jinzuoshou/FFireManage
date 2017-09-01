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

namespace FFireManage.FireForestBelt
{
    public partial class FormFireForestBeltManage : Form
    {
        #region 字段
        private Fire_ForestBeltPoint currentFireForestBelt = null;
        private ForestBeltPointController m_ForestBeltController = null;
        private List<Fire_ForestBeltPoint> m_FireForestBeltList = null;
        #endregion

        #region 构造函数
        public FormFireForestBeltManage()
        {
            InitializeComponent();

            this.m_ForestBeltController = new ForestBeltPointController();
            this.m_ForestBeltController.QueryEvent += m_ForestBeltController_QueryEvent;
            this.m_ForestBeltController.DeleteEvent += m_ForestBeltController_DeleteEvent;
        }
        #endregion

        #region 事件响应
        private void m_ForestBeltController_QueryEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    try
                    {
                        GetListResultInfo<Fire_ForestBeltPoint> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_ForestBeltPoint>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            this.m_FireForestBeltList = result.rows;

                            this.pagerControl1.NMax = result.total;
                            this.FillData(m_FireForestBeltList);

                        }
                        else
                        {
                            this.pagerControl1.NMax = 0;
                            this.FillData(null);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "信息提示");
                    }
                }
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void m_ForestBeltController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            this.GetFireForestBeltList(this.navigationControl1.Pac);
                        }
                        else
                        {
                            MessageBox.Show(this, result.msg, "信息提示");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "信息提示");
                    }
                   
                }
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void FormFireForestBeltManage_Load(object sender, EventArgs e)
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
                this.GetFireForestBeltList(pCode);
            }
        }

        private void CbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                this.GetFireForestBeltList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxProvince.ComboBox.SelectedValue != null)
                {
                    var provinceCode = this.navigationControl1.CbxProvince.ComboBox.SelectedValue.ToString();
                    this.GetFireForestBeltList(provinceCode);
                }
            }
        }

        private void CbxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCounty.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCounty.ComboBox.SelectedValue.ToString();
                this.GetFireForestBeltList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
                {
                    var cityCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                    this.GetFireForestBeltList(cityCode.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormFireForestBelt pFormFireForestBelt = new FormFireForestBelt(OperationType.Add);
            if (pFormFireForestBelt.ShowDialog(this) == DialogResult.OK)
            {
                this.GetFireForestBeltList(this.navigationControl1.Pac);
                MessageBox.Show(this, "防火林带新增成功", "提示");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FormFireForestBelt pFormFireForestBelt = new FormFireForestBelt(OperationType.Edit, this.currentFireForestBelt);
            if (pFormFireForestBelt.ShowDialog(this) == DialogResult.OK)
            {
                this.GetFireForestBeltList(this.navigationControl1.Pac);
                MessageBox.Show(this, "防火林带修改成功", "提示");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentFireForestBelt != null)
            {
                if (MessageBox.Show(this, "您确定要删除" + this.currentFireForestBelt.name + "吗？数据删除后不可恢复。", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.m_ForestBeltController.Delete(this.currentFireForestBelt.id);
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string key = this.navigationControl1.TbxSearch.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                this.GetFireForestBeltList(this.navigationControl1.Pac);
                return;
            }

            if (this.m_FireForestBeltList == null || this.m_FireForestBeltList.Count == 0)
                return;

            var tempFireForestBelts = this.m_FireForestBeltList.Where<Fire_ForestBeltPoint>(u => u.name.Contains(key));

            if (tempFireForestBelts == null)
                return;
            this.FillData(tempFireForestBelts.ToList<Fire_ForestBeltPoint>());
        }

        private void PagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.Pac == null || this.navigationControl1.Pac == "")
                this.GetFireForestBeltList(GlobeHelper.Instance.User.pac);
            else
                this.GetFireForestBeltList(this.navigationControl1.Pac);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];

                if (item.Tag != null && item.Tag is Fire_ForestBeltPoint)
                {
                    this.currentFireForestBelt = item.Tag as Fire_ForestBeltPoint;

                    this.navigationControl1.BtnEdit.Enabled = true;
                    this.navigationControl1.BtnDelete.Enabled = true;
                }
                else
                {
                    this.currentFireForestBelt = null;

                    this.navigationControl1.BtnDelete.Enabled = false;
                    this.navigationControl1.BtnEdit.Enabled = false;
                }
            }
            else
            {
                this.currentFireForestBelt = null;

                this.navigationControl1.BtnDelete.Enabled = false;
                this.navigationControl1.BtnEdit.Enabled = false;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if (item.Tag is Fire_ForestBeltPoint)
            {
                var fireForestBelt = item.Tag as Fire_ForestBeltPoint;
                FormFireForestBelt pFormFireForestBelt = new FormFireForestBelt(OperationType.Check, fireForestBelt);
                pFormFireForestBelt.ShowDialog(this);
            }
        }
        #endregion

        #region 成员函数
        private void FillData(List<Fire_ForestBeltPoint> fireForestBeltList)
        {
            this.pagerControl1.Bind();
            this.pagerControl1.bindingSource.DataSource = fireForestBeltList;
            this.pagerControl1.bindingNavigator.BindingSource = this.pagerControl1.bindingSource;
            this.listView1.Items.Clear();

            if (fireForestBeltList != null)
            {
                for (int i = 0; i < fireForestBeltList.Count; i++)
                {
                    Fire_ForestBeltPoint fireForestBelt = fireForestBeltList[i];

                    ListViewItem item = new ListViewItem();

                    item.SubItems.Add(fireForestBelt.name);
                    AreaCodeInfo county = null;
                    try
                    {
                        if (this.navigationControl1.AreaList != null)
                            county = this.navigationControl1.AreaList.Where(a => a.code == fireForestBelt.pac).First();
                    }
                    catch { }

                    item.SubItems.Add((county == null) ? "" : county.name);
                    item.SubItems.Add(fireForestBelt.build_unit);
                    item.SubItems.Add(fireForestBelt.longitude.ToString());
                    item.SubItems.Add(fireForestBelt.latitude.ToString());

                    item.Tag = fireForestBelt;

                    this.listView1.Items.Add(item);
                }
            }
        }

        private void GetFireForestBeltList(string pac)
        {
            this.m_ForestBeltController.Get(new Dictionary<string, object>()
                {
                    {"pac",pac },
                    {"fetchType",3},
                    {"page", this.pagerControl1.PageCurrent},
                    {"rows",this.pagerControl1.PageSize },
                    {"sort","id"},
                    {"order","desc"}
                });
        }
        #endregion
    }
}
