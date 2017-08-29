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

namespace FFireManage.DangerousFacilities
{
    public partial class FormDFacilitiesManage : Form
    {
        #region 字段
        private Fire_DangerousFacilities currentDFacilities = null;
        private DangerousFacilitiesController m_DFacilitiesController = null;
        private List<Fire_DangerousFacilities> m_DFacilitiesList = null;
        #endregion

        #region 构造函数
        public FormDFacilitiesManage()
        {
            InitializeComponent();

            this.m_DFacilitiesController = new DangerousFacilitiesController();
            this.m_DFacilitiesController.QueryEvent += m_DFacilitiesController_QueryEvent;
            this.m_DFacilitiesController.DeleteEvent += m_DFacilitiesController_DeleteEvent;
        }
        #endregion

        #region 事件响应
        private void m_DFacilitiesController_QueryEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<Fire_DangerousFacilities> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_DangerousFacilities>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            this.m_DFacilitiesList = result.rows;

                            this.pagerControl1.NMax = result.total;
                            this.FillData(m_DFacilitiesList);

                        }
                        else
                        {
                            this.pagerControl1.NMax = 0;
                            this.FillData(null);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(this,ex.Message, "提示");
                    }
                    
                }
                else
                {
                    MessageBox.Show(this, sender.ToString(), "提示");
                }
            }));
        }

        private void m_DFacilitiesController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            this.GetDFacilitiesList(this.navigationControl1.Pac);
                        }
                    }
                    catch(Exception ex)
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
                this.GetDFacilitiesList(pCode);
            }
        }

        private void CbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                this.GetDFacilitiesList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxProvince.ComboBox.SelectedValue != null)
                {
                    var provinceCode = this.navigationControl1.CbxProvince.ComboBox.SelectedValue.ToString();
                    this.GetDFacilitiesList(provinceCode);
                }
            }
        }

        private void CbxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCounty.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCounty.ComboBox.SelectedValue.ToString();
                this.GetDFacilitiesList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
                {
                    var cityCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                    this.GetDFacilitiesList(cityCode.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormDFacilities pFormDFacilities = new FormDFacilities(OperationType.Add);
            if (pFormDFacilities.ShowDialog(this) == DialogResult.OK)
            {
                this.GetDFacilitiesList(this.navigationControl1.Pac);
                MessageBox.Show(this, "林区危险及重要性设备设施新增成功", "提示");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FormDFacilities pFormDFacilities = new FormDFacilities(OperationType.Edit, this.currentDFacilities);
            if (pFormDFacilities.ShowDialog(this) == DialogResult.OK)
            {
                this.GetDFacilitiesList(this.navigationControl1.Pac);
                MessageBox.Show(this, "林区危险及重要性设备设施修改成功", "提示");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentDFacilities != null)
            {
                if (MessageBox.Show(this, "您确定要删除" + this.currentDFacilities.name + "吗？数据删除后不可恢复。", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.m_DFacilitiesController.Delete(this.currentDFacilities.id);
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string key = this.navigationControl1.TbxSearch.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                this.GetDFacilitiesList(this.navigationControl1.Pac);
                return;
            }

            if (this.m_DFacilitiesList == null || this.m_DFacilitiesList.Count == 0)
                return;

            var tempArtificiallakes = this.m_DFacilitiesList.Where<Fire_DangerousFacilities>(u => u.name.Contains(key));

            if (tempArtificiallakes == null)
                return;
            this.FillData(tempArtificiallakes.ToList<Fire_DangerousFacilities>());
        }

        private void PagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.Pac == null || this.navigationControl1.Pac == "")
                this.GetDFacilitiesList(GlobeHelper.Instance.User.pac);
            else
                this.GetDFacilitiesList(this.navigationControl1.Pac);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];

                if (item.Tag != null && item.Tag is Fire_DangerousFacilities)
                {
                    this.currentDFacilities = item.Tag as Fire_DangerousFacilities;

                    this.navigationControl1.BtnEdit.Enabled = true;
                    this.navigationControl1.BtnDelete.Enabled = true;
                }
                else
                {
                    this.currentDFacilities = null;

                    this.navigationControl1.BtnDelete.Enabled = false;
                    this.navigationControl1.BtnEdit.Enabled = false;
                }
            }
            else
            {
                this.currentDFacilities = null;

                this.navigationControl1.BtnDelete.Enabled = false;
                this.navigationControl1.BtnEdit.Enabled = false;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if (item.Tag is Fire_DangerousFacilities)
            {
                var dFacilities = item.Tag as Fire_DangerousFacilities;
                FormDFacilities pFormDFacilities = new FormDFacilities(OperationType.Check, dFacilities);
                pFormDFacilities.ShowDialog(this);
            }
        }
        #endregion

        #region 成员函数
        private void FillData(List<Fire_DangerousFacilities> dFacilitiesList)
        {
            this.pagerControl1.Bind();
            this.pagerControl1.bindingSource.DataSource = dFacilitiesList;
            this.pagerControl1.bindingNavigator.BindingSource = this.pagerControl1.bindingSource;
            this.listView1.Items.Clear();

            if (dFacilitiesList != null)
            {
                for (int i = 0; i < dFacilitiesList.Count; i++)
                {
                    Fire_DangerousFacilities dFacilities = dFacilitiesList[i];

                    ListViewItem item = new ListViewItem();

                    item.SubItems.Add(dFacilities.name);
                    AreaCodeInfo county = null;
                    try
                    {
                        if (this.navigationControl1.AreaList != null)
                            county = this.navigationControl1.AreaList.Where(a => a.Code == dFacilities.pac).First();
                    }
                    catch { }

                    item.SubItems.Add((county == null) ? "" : county.Name);
                    item.SubItems.Add(dFacilities.manager);
                    item.SubItems.Add(dFacilities.longitude.ToString());
                    item.SubItems.Add(dFacilities.latitude.ToString());

                    item.Tag = dFacilities;

                    this.listView1.Items.Add(item);
                }
            }
        }

        private void GetDFacilitiesList(string pac)
        {
            this.m_DFacilitiesController.Get(new Dictionary<string, object>()
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
