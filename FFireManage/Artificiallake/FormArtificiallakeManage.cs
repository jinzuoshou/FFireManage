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

namespace FFireManage.Artificiallake
{
    public partial class FormArtificiallakeManage : Form
    {
        #region 字段
        private Fire_Artificiallake currentArtificiallake = null;
        private ServiceController m_ServiceController = null;
        private List<Fire_Artificiallake> m_ArtificiallakeList = null;
        #endregion

        #region 构造函数
        public FormArtificiallakeManage()
        {
            InitializeComponent();

            this.m_ServiceController = new ServiceController();
            this.m_ServiceController.GetArtificiallakeListEvent += new EventHandler(m_ServiceController_GetArtificiallakeListEvent);
            this.m_ServiceController.DeleteArtificiallakeEvent += new EventHandler(m_ServiceController_DeleteArtificiallakeEvent);
        }
        #endregion

        #region 事件响应
        private void m_ServiceController_GetArtificiallakeListEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = sender.ToString();
                    try
                    {
                        GetListResultInfo<Fire_Artificiallake> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_Artificiallake>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            this.m_ArtificiallakeList = result.rows;

                            this.pagerControl1.NMax = result.total;
                            this.FillData(m_ArtificiallakeList);

                        }
                        else
                        {
                            this.pagerControl1.NMax = 0;
                            this.FillData(null);
                        }
                    }
                    catch
                    {
                        MessageBox.Show(this, sender.ToString(), "提示");
                    }
                }
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void m_ServiceController_DeleteArtificiallakeEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = sender.ToString();

                    BaseResultInfo<string> result = JsonHelper.JSONToObject<BaseResultInfo<string>>(content);

                    if (result.status == 10000)
                    {
                        this.GetArtificiallakeList(this.navigationControl1.Pac);
                    }
                }
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void FormArtificiallakeManage_Load(object sender, EventArgs e)
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
                this.GetArtificiallakeList(pCode);
            }
        }

        private void CbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                this.GetArtificiallakeList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxProvince.ComboBox.SelectedValue != null)
                {
                    var provinceCode = this.navigationControl1.CbxProvince.ComboBox.SelectedValue.ToString();
                    this.GetArtificiallakeList(provinceCode);
                }
            }
        }

        private void CbxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCounty.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCounty.ComboBox.SelectedValue.ToString();
                this.GetArtificiallakeList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
                {
                    var cityCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                    this.GetArtificiallakeList(cityCode.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormArtificiallake pFormArtificiallake = new FormArtificiallake(OperationType.Add);
            if (pFormArtificiallake.ShowDialog(this) == DialogResult.OK)
            {
                this.GetArtificiallakeList(this.navigationControl1.Pac);
                MessageBox.Show(this, "航空灭火蓄水池新增成功", "提示");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FormArtificiallake pFormArtificiallake = new FormArtificiallake(OperationType.Edit, this.currentArtificiallake);
            if (pFormArtificiallake.ShowDialog(this) == DialogResult.OK)
            {
                this.GetArtificiallakeList(this.navigationControl1.Pac);
                MessageBox.Show(this, "航空灭火蓄水池修改成功", "提示");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentArtificiallake != null)
            {
                if (MessageBox.Show(this, "您确定要删除" + this.currentArtificiallake.name + "吗？数据删除后不可恢复。", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.m_ServiceController.DeleteArtificiallakeForGet(this.currentArtificiallake.id);
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string key = this.navigationControl1.TbxSearch.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                this.GetArtificiallakeList(this.navigationControl1.Pac);
                return;
            }

            if (this.m_ArtificiallakeList == null || this.m_ArtificiallakeList.Count == 0)
                return;

            var tempArtificiallakes = this.m_ArtificiallakeList.Where<Fire_Artificiallake>(u => u.name.Contains(key));

            if (tempArtificiallakes == null)
                return;
            this.FillData(tempArtificiallakes.ToList<Fire_Artificiallake>());
        }

        private void PagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.Pac == null || this.navigationControl1.Pac == "")
                this.GetArtificiallakeList(GlobeHelper.Instance.User.pac);
            else
                this.GetArtificiallakeList(this.navigationControl1.Pac);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];

                if (item.Tag != null && item.Tag is Fire_Artificiallake)
                {
                    this.currentArtificiallake = item.Tag as Fire_Artificiallake;

                    this.navigationControl1.BtnEdit.Enabled = true;
                    this.navigationControl1.BtnDelete.Enabled = true;
                }
                else
                {
                    this.currentArtificiallake = null;

                    this.navigationControl1.BtnDelete.Enabled = false;
                    this.navigationControl1.BtnEdit.Enabled = false;
                }
            }
            else
            {
                this.currentArtificiallake = null;

                this.navigationControl1.BtnDelete.Enabled = false;
                this.navigationControl1.BtnEdit.Enabled = false;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if (item.Tag is Fire_Artificiallake)
            {
                var artificiallake = item.Tag as Fire_Artificiallake;
                FormArtificiallake pFormArtificiallake = new FormArtificiallake(OperationType.Check, artificiallake);
                pFormArtificiallake.ShowDialog(this);
            }
        }
        #endregion

        #region 成员函数
        private void FillData(List<Fire_Artificiallake> artificiallakeList)
        {
            this.pagerControl1.Bind();
            this.pagerControl1.bindingSource.DataSource = artificiallakeList;
            this.pagerControl1.bindingNavigator.BindingSource = this.pagerControl1.bindingSource;
            this.listView1.Items.Clear();

            if (artificiallakeList != null)
            {
                for (int i = 0; i < artificiallakeList.Count; i++)
                {
                    Fire_Artificiallake artificiallake = artificiallakeList[i];

                    ListViewItem item = new ListViewItem();

                    item.SubItems.Add(artificiallake.name);
                    AreaCodeInfo county = null;
                    try
                    {
                        if (this.navigationControl1.AreaList != null)
                            county = this.navigationControl1.AreaList.Where(a => a.Code == artificiallake.pac).First();
                    }
                    catch { }

                    item.SubItems.Add((county == null) ? "" : county.Name);
                    item.SubItems.Add(artificiallake.manager);
                    item.SubItems.Add(artificiallake.longitude.ToString());
                    item.SubItems.Add(artificiallake.latitude.ToString());

                    item.Tag = artificiallake;

                    this.listView1.Items.Add(item);
                }
            }
        }

        private void GetArtificiallakeList(string pac)
        {
            this.m_ServiceController.GetArtificiallakeListForGet(pac, 3, this.pagerControl1.PageCurrent, this.pagerControl1.PageSize, "id", "desc");
        }
        #endregion
    }
}
