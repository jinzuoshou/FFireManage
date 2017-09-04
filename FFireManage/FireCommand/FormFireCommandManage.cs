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

namespace FFireManage.FireCommand
{
    public partial class FormFireCommandManage : Form
    {
        #region 成员变量
        private Fire_Command currentFireCommand = null;
        private FireCommandController m_FireCommandController = null;
        private List<Fire_Command> m_FireCommandList = null;
        #endregion

        #region 构造函数
        public FormFireCommandManage()
        {
            InitializeComponent();
            this.m_FireCommandController = new FireCommandController();
            this.m_FireCommandController.QueryEvent += m_FireCommandControllerr_QueryEvent;
            this.m_FireCommandController.DeleteEvent += m_FireCommandController_DeleteEvent;
        }
        #endregion

        #region 事件响应
        private void m_FireCommandController_DeleteEvent(object sender, ServiceEventArgs e)
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
                            this.GetFireCommandList(this.navigationControl1.Pac);
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

        private void m_FireCommandControllerr_QueryEvent(object sender, ServiceEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;

                    try
                    {
                        GetListResultInfo<Fire_Command> result = JsonHelper.JSONToObject<GetListResultInfo<Fire_Command>>(content);

                        if (result.rows != null && result.rows.Count > 0)
                        {
                            m_FireCommandList = result.rows;

                            this.pagerControl1.NMax = result.total;
                            this.FillData(m_FireCommandList);
                        }
                        else
                        {
                            this.pagerControl1.NMax = 0;
                            this.FillData(null);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(this,ex.Message, "信息提示");
                    }
                    
                }
                else
                {
                    MessageBox.Show(sender.ToString(), "获取森林防火指挥部列表出错", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }));
        }

        private void FormFireCommand_Load(object sender, EventArgs e)
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
                this.GetFireCommandList(pCode);
            }
        }

        private void CbxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                this.GetFireCommandList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxProvince.ComboBox.SelectedValue != null)
                {
                    var provinceCode = this.navigationControl1.CbxProvince.ComboBox.SelectedValue.ToString();
                    this.GetFireCommandList(provinceCode);
                }
            }
        }

        private void CbxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.CbxCounty.ComboBox.SelectedValue != null)
            {
                string pCode = this.navigationControl1.CbxCounty.ComboBox.SelectedValue.ToString();
                this.GetFireCommandList(pCode);
            }
            else
            {
                if (this.navigationControl1.CbxCity.ComboBox.SelectedValue != null)
                {
                    var cityCode = this.navigationControl1.CbxCity.ComboBox.SelectedValue.ToString();
                    this.GetFireCommandList(cityCode.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormFireCommand pFormFireCommand = new FormFireCommand(OperationType.Add);
            if (pFormFireCommand.ShowDialog(this) == DialogResult.OK)
            {
                this.GetFireCommandList(this.navigationControl1.Pac);
                MessageBox.Show(this, "森林防火指挥部新增成功", "提示");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FormFireCommand pFormFireCommand = new FormFireCommand(OperationType.Edit, this.currentFireCommand);
            if (pFormFireCommand.ShowDialog(this) == DialogResult.OK)
            {
                this.GetFireCommandList(this.navigationControl1.Pac);
                MessageBox.Show(this, "森林防火指挥部修改成功", "提示");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.currentFireCommand != null)
            {
                if (MessageBox.Show(this, "您确定要删除" + this.currentFireCommand.name + "吗？数据删除后不可恢复。", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.m_FireCommandController.Delete(this.currentFireCommand.id);
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string key = this.navigationControl1.TbxSearch.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                this.GetFireCommandList(this.navigationControl1.Pac);
                return;
            }

            if (this.m_FireCommandList == null || this.m_FireCommandList.Count == 0)
                return;

            var tempFireCommands = this.m_FireCommandList.Where<Fire_Command>(u => u.name.Contains(key) ||
            u.director.Contains(key));

            if (tempFireCommands == null)
                return;
            this.FillData(tempFireCommands.ToList<Fire_Command>());
        }

        private void PagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            if (this.navigationControl1.Pac == null || this.navigationControl1.Pac == "")
                this.GetFireCommandList(GlobeHelper.Instance.User.pac);
            else
                this.GetFireCommandList(this.navigationControl1.Pac);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];

                if (item.Tag != null && item.Tag is Fire_Command)
                {
                    this.currentFireCommand = item.Tag as Fire_Command;

                    this.navigationControl1.BtnEdit.Enabled = true;
                    this.navigationControl1.BtnDelete.Enabled = true;
                }
                else
                {
                    this.currentFireCommand = null;

                    this.navigationControl1.BtnDelete.Enabled = false;
                    this.navigationControl1.BtnEdit.Enabled = false;
                }
            }
            else
            {
                this.currentFireCommand = null;

                this.navigationControl1.BtnDelete.Enabled = false;
                this.navigationControl1.BtnEdit.Enabled = false;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if (item.Tag is Fire_Command)
            {
                var fireCommand = item.Tag as Fire_Command;
                FormFireCommand pFormFireCommand = new FormFireCommand(OperationType.Check, fireCommand);
                pFormFireCommand.ShowDialog(this);
            }
        }
        #endregion

        #region 成员函数
        private void FillData(List<Fire_Command> fireCommandList)
        {
            this.pagerControl1.Bind();
            this.pagerControl1.bindingSource.DataSource = fireCommandList;
            this.pagerControl1.bindingNavigator.BindingSource = this.pagerControl1.bindingSource;
            this.listView1.Items.Clear();

            if (fireCommandList != null)
            {

                for (int i = 0; i < fireCommandList.Count; i++)
                {
                    Fire_Command monitor = fireCommandList[i];

                    ListViewItem item = new ListViewItem();

                    item.SubItems.Add(monitor.name);
                    AreaCodeInfo county = null;
                    try
                    {
                        if (this.navigationControl1.AreaList != null)
                            county = this.navigationControl1.AreaList.Where(a => a.code == monitor.pac).First();
                    }
                    catch { }

                    item.SubItems.Add((county == null) ? "" : county.name);
                    item.SubItems.Add(monitor.director);
                    item.SubItems.Add(monitor.longitude.ToString());
                    item.SubItems.Add(monitor.latitude.ToString());

                    item.Tag = monitor;

                    this.listView1.Items.Add(item);
                }
            }
        }

        private void GetFireCommandList(string pac)
        {
            this.m_FireCommandController.Get(
                new Dictionary<string, object>()
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
