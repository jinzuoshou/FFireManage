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

namespace FFireManage.FireWarehouse
{
    public partial class FormWarehouseManage : Form
    {
        #region 字段
        private Fire_Warehouse currentFire_Warehouse = null;
        private FireWarehouseController m_FireWarehouseController = null;
        private List<Fire_Warehouse> m_Fire_WarehouseList = null;
        #endregion

        #region 构造函数
        public FormWarehouseManage()
        {
            InitializeComponent();

            this.m_FireWarehouseController = new FireWarehouseController();
            this.m_FireWarehouseController.QueryEvent += m_ServiceController_QueryEvent;
            this.m_FireWarehouseController.DeleteEvent += m_ServiceController_DeleteEvent;
        }
        #endregion

        #region 事件响应
        private void m_ServiceController_QueryEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<Fire_Warehouse> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_Warehouse>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            this.m_Fire_WarehouseList = result.rows;

                            this.pagerControl1.NMax = result.total;
                            this.FillData(m_Fire_WarehouseList);

                        }
                        else
                        {
                            this.pagerControl1.NMax = 0;
                            this.FillData(null);
                        }
                    }
                    catch ( Exception ex)
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

        private void m_ServiceController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            this.GetFireWarehouseList(this.navigationControl1.Pac);
                        }
                        else
                        {
                            MessageBox.Show(this, e.Message, "提示");
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

        }

        private void CbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                this.GetFireWarehouseList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxProvince.ComboBox.SelectedValue != null)
                {
                    var provinceCode = this.navigationControl1.CbxProvince.ComboBox.SelectedValue.ToString();
                    this.GetFireWarehouseList(provinceCode);
                }
            }
        }

        private void CbxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCounty.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCounty.ComboBox.SelectedValue.ToString();
                this.GetFireWarehouseList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
                {
                    var cityCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                    this.GetFireWarehouseList(cityCode.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormWarehouse pFormFireWarehouse = new FormWarehouse(OperationType.Add);
            if (pFormFireWarehouse.ShowDialog(this) == DialogResult.OK)
            {
                this.GetFireWarehouseList(this.navigationControl1.Pac);
                MessageBox.Show(this, "专业森林消防队新增成功", "提示");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FormWarehouse pFormFireWarehouse = new FormWarehouse(OperationType.Edit, this.currentFire_Warehouse);
            if (pFormFireWarehouse.ShowDialog(this) == DialogResult.OK)
            {
                this.GetFireWarehouseList(this.navigationControl1.Pac);
                MessageBox.Show(this, "专业森林消防队修改成功", "提示");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentFire_Warehouse != null)
            {
                if (MessageBox.Show(this, "您确定要删除" + this.currentFire_Warehouse.name + "吗？数据删除后不可恢复。", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.m_FireWarehouseController.Delete(this.currentFire_Warehouse.id);
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string key = this.navigationControl1.TbxSearch.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                this.GetFireWarehouseList(this.navigationControl1.Pac);
                return;
            }

            if (this.m_Fire_WarehouseList == null || this.m_Fire_WarehouseList.Count == 0)
                return;

            var tempFireWarehouses = this.m_Fire_WarehouseList.Where<Fire_Warehouse>(u => u.name.Contains(key));

            if (tempFireWarehouses == null)
                return;
            this.FillData(tempFireWarehouses.ToList<Fire_Warehouse>());
        }

        private void PagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.Pac == null || this.navigationControl1.Pac == "")
                this.GetFireWarehouseList(GlobeHelper.Instance.User.pac);
            else
                this.GetFireWarehouseList(this.navigationControl1.Pac);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];

                if (item.Tag != null && item.Tag is Fire_Warehouse)
                {
                    this.currentFire_Warehouse = item.Tag as Fire_Warehouse;

                    this.navigationControl1.BtnEdit.Enabled = true;
                    this.navigationControl1.BtnDelete.Enabled = true;
                }
                else
                {
                    this.currentFire_Warehouse = null;

                    this.navigationControl1.BtnDelete.Enabled = false;
                    this.navigationControl1.BtnEdit.Enabled = false;
                }
            }
            else
            {
                this.currentFire_Warehouse = null;

                this.navigationControl1.BtnDelete.Enabled = false;
                this.navigationControl1.BtnEdit.Enabled = false;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if (item.Tag is Fire_PBrigade)
            {
                var fireWarehouse = item.Tag as Fire_Warehouse;
                FormWarehouse pFormFireForestBelt = new FormWarehouse(OperationType.Check, fireWarehouse);
                pFormFireForestBelt.ShowDialog(this);
            }
        }
        #endregion

        #region 成员函数
        private void FillData(List<Fire_Warehouse> fireWarehouseList)
        {
            this.pagerControl1.Bind();
            this.pagerControl1.bindingSource.DataSource = fireWarehouseList;
            this.pagerControl1.bindingNavigator.BindingSource = this.pagerControl1.bindingSource;
            this.listView1.Items.Clear();

            if (fireWarehouseList != null)
            {
                for (int i = 0; i < fireWarehouseList.Count; i++)
                {
                    Fire_Warehouse fireWarehouse = fireWarehouseList[i];

                    ListViewItem item = new ListViewItem();

                    item.SubItems.Add(fireWarehouse.name);
                    AreaCodeInfo county = null;
                    try
                    {
                        if (this.navigationControl1.AreaList != null)
                            county = this.navigationControl1.AreaList.Where(a => a.code == fireWarehouse.pac).First();
                    }
                    catch { }

                    item.SubItems.Add((county == null) ? "" : county.name);
                    item.SubItems.Add(fireWarehouse.manager);
                    item.SubItems.Add(fireWarehouse.longitude.ToString());
                    item.SubItems.Add(fireWarehouse.latitude.ToString());

                    item.Tag = fireWarehouse;

                    this.listView1.Items.Add(item);
                }
            }
        }

        private void GetFireWarehouseList(string pac)
        {
            this.m_FireWarehouseController.Get(new Dictionary<string, object>()
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