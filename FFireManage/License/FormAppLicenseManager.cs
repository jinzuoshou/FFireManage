using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FFireManage.Service;
using FFireManage.Utility;
using FFireManage.Model;
using FFireManage.License;

namespace FFireManage
{
    public partial class FormAppLicenseManager : Form
    {
        private ServiceController m_ServiceController = null;
        private LicenceInfo current_Licence = null;
        private AreaCodeInfo current_AreaCode = null;

        public FormAppLicenseManager()
        {
            InitializeComponent();

            this.m_ServiceController = new ServiceController();
            this.m_ServiceController.GetAreaCodeListEvent += new EventHandler(ServiceController_GetAreaCodeListEvent);

            this.m_ServiceController.GetLicenceListByPacEvent += new EventHandler(ServiceController_GetLicenceListByPacEvent);

            this.m_ServiceController.DeleteLicenseEvent += new EventHandler(ImeiController_DeleteEvent);
            this.m_ServiceController.LogoutLicenseEvent += M_ImeiController_LogoutLicenseEvent;
        }

        private void M_ImeiController_LogoutLicenseEvent(object sender, EventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = sender.ToString();
                    if (this.current_AreaCode != null)
                    {
                        string pac = this.current_AreaCode.Code;
                        this.m_ServiceController.GetLicenceListByPac(pac, 1000, 0);
                    }
                }
                else
                {
                    MessageBox.Show(sender.ToString(), "注销许可出错", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }));
        }

        private void ImeiController_DeleteEvent(object sender, EventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate()
            {
                if (e != null)
                {
                    string content = sender.ToString();
                    if (this.current_AreaCode != null)
                    {
                        string pac = this.current_AreaCode.Code;

                        this.m_ServiceController.GetLicenceListByPac(pac, 1000, 0);
                    }
                }
                else
                {
                    MessageBox.Show(sender.ToString(), "删除许可出错", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }));
        }

        public void ServiceController_GetLicenceListByPacEvent(object sender, EventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate()
            {
                if (e != null)
                {
                    string content = sender.ToString();

                    GetListResultInfo<LicenceInfo> result = JsonHelper.JSONToObject<GetListResultInfo<LicenceInfo>>(content);
                    
                    if (result != null && result.rows != null && result.rows.Count > 0)
                    {
                        List<LicenceInfo> licenceList = result.rows;

                        this.FillData(licenceList);
                    }
                    else
                    {
                        this.FillData(null);
                    }
                }
                else
                {
                    MessageBox.Show(sender.ToString(), "获取许可列表出错", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }));
        }

        public void FillData(List<LicenceInfo> licenceList)
        {
            this.listView1.Items.Clear();

            if (licenceList != null)
            {
                for (int i = 0; i < licenceList.Count; i++)
                {
                    LicenceInfo licence = licenceList[i];

                    ListViewItem item = new ListViewItem();

                    item.SubItems.Add(licence.id.ToString());
                    item.SubItems.Add(licence.key);
                    item.SubItems.Add(licence.imei);
                    item.SubItems.Add(licence.status.ToString());
                    item.SubItems.Add(licence.founder);

                    item.SubItems.Add(licence.createTime);

                    item.Tag = licence;

                    this.listView1.Items.Add(item);

                }

                this.lblCount.Text = "当前总共" + licenceList.Count + "条记录";
            }
            else
            {
                this.lblCount.Text = "";
            }
        }

        public void ServiceController_GetAreaCodeListEvent(object sender, EventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new MethodInvoker(delegate()
            {
                if (e != null)
                {
                    string content = sender.ToString();

                    GetListResultInfo<AreaCodeInfo> result = JsonHelper.JSONToObject<GetListResultInfo<AreaCodeInfo>>(content);

                    if (result.rows != null && result.rows.Count > 0)
                    {
                        List<AreaCodeInfo> areaCodeList = result.rows;

                        this.LoadAreaList(areaCodeList);

                    }
                }
                else
                {
                    MessageBox.Show(sender.ToString(), "获取行政区出错", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }));
        }

        private void LoadAreaList(List<AreaCodeInfo> areaCodeList)
        {
            if (areaCodeList == null)
                return;

            var provinces = areaCodeList.Where(a => a.Code.EndsWith("0000"));
            if (provinces == null)
                return;
            provinces.ToList().ForEach(provine =>
                {
                    TreeNode provinceNode = new TreeNode(provine.Name);
                    provinceNode.Tag = provine;
                    var cities = areaCodeList.Where(a => a.Code.EndsWith("00") && a.Code != provine.Code);
                    if (cities == null)
                        return;
                    cities.ToList().ForEach(city =>
                    {
                        TreeNode cityNode = new TreeNode(city.Name);
                        cityNode.Tag = city;
                        provinceNode.Nodes.Add(cityNode);

                        var counties = areaCodeList.Where(a => !a.Code.EndsWith("00") && a.Code.Substring(0,4)+"00"==city.Code);
                        if (counties == null)
                            return;
                        counties.ToList().ForEach(county =>
                        {
                            TreeNode countyNode = new TreeNode(county.Name);
                            countyNode.Tag = county;
                            cityNode.Nodes.Add(countyNode);
                        });
                    });
                    provinceNode.ExpandAll();
                    this.treeView1.Nodes.Add(provinceNode);
                });
        }

        private void FormAppLicenseManager_Load(object sender, EventArgs e)
        {
            this.lblCount.Text = "";

            string pac = GlobeHelper.Instance.User.pac;

            /*
            fetchType
            0 --- 默认 只查找对应的
            1 --- 只查询下一级
            2 --- 查询所有下一级
            3 --- 查询最低为县级的行政区列表
            */

            this.m_ServiceController.GetAreaCodeList(pac, 3);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode treeNode = e.Node;

            if (treeNode != null && treeNode.Tag != null)
            {
                AreaCodeInfo areaCode = treeNode.Tag as AreaCodeInfo;

                this.current_AreaCode = areaCode;

                if (areaCode != null)
                {
                    string pac = areaCode.Code;

                    this.m_ServiceController.GetLicenceListByPac(pac, 1000, 0);
                }
                this.btnAdd.Enabled = true;
            }
            else
            {
                this.btnAdd.Enabled = false;

                this.current_AreaCode = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormCreateAppLicense pFormCreateAppLicense = new FormCreateAppLicense(this.current_AreaCode);
            if (pFormCreateAppLicense.ShowDialog(this) == DialogResult.OK)
            {
                if (this.current_AreaCode == null)
                    this.m_ServiceController.GetLicenceListByPac(GlobeHelper.Instance.User.pac, 1000, 1);
                else
                    this.m_ServiceController.GetLicenceListByPac(this.current_AreaCode.Code, 1000, 1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (current_Licence == null)
                return;
            FormUpdateAppLicense pFormUpdateAppLicense = new FormUpdateAppLicense(this.current_Licence);
            if (pFormUpdateAppLicense.ShowDialog(this) == DialogResult.OK)
            {
                if (this.current_AreaCode == null)
                    this.m_ServiceController.GetLicenceListByPac(GlobeHelper.Instance.User.pac, 1000, 1);
                else
                    this.m_ServiceController.GetLicenceListByPac(this.current_AreaCode.Code, 1000, 1);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (this.current_Licence == null)
                return;
            FormRegisterAppLicense formRegister = new FormRegisterAppLicense(this.current_Licence);
            if (formRegister.ShowDialog(this) == DialogResult.OK)
            {
                if (this.current_AreaCode == null)
                    this.m_ServiceController.GetLicenceListByPac(GlobeHelper.Instance.User.pac, 1000, 1);
                else
                    this.m_ServiceController.GetLicenceListByPac(this.current_AreaCode.Code, 1000, 1);
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (this.current_Licence != null)
            {
                if (MessageBox.Show(this, string.Format("您确定要注销授权码为{0}、设备序列号为{1}的许可吗",this.current_Licence.key,this.current_Licence.imei), "注销提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==DialogResult.Yes)
                {
                    this.m_ServiceController.LogoutLicenseForPost(this.current_Licence.key,this.current_Licence.imei);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.current_Licence != null)
            {
                if (MessageBox.Show(this, string.Format("您确定要删除授权码为{0}、设备序列号为{1}的许可吗?数据删除后不可恢复。", this.current_Licence.key, this.current_Licence.imei), "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.m_ServiceController.DeleteLicenseForGet(this.current_Licence.id);
                }
            }

        }

        private void btnProof_Click(object sender, EventArgs e)
        {
            FormProofAppLicense formProof = new FormProofAppLicense();
            formProof.ShowDialog(this);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];

                if (item.Tag != null && item.Tag is LicenceInfo)
                {
                    this.current_Licence = item.Tag as LicenceInfo;

                    if (this.current_Licence.imei == "")
                    {
                        this.btnRegister.Enabled = true;
                        this.btnUpdate.Enabled = false;
                        this.btnLogout.Enabled = false;
                    }
                    else
                    {
                        this.btnRegister.Enabled = false;
                        this.btnUpdate.Enabled = true;
                        this.btnLogout.Enabled = true;
                    }
                    this.btnDelete.Enabled = true;
                }
                else
                {
                    this.current_Licence = null;

                    this.btnUpdate.Enabled = false;
                    this.btnRegister.Enabled = false;
                    this.btnLogout.Enabled = false;
                    this.btnDelete.Enabled = false;
                }
            }
            else
            {
                this.current_Licence = null;

                this.btnUpdate.Enabled = false;
                this.btnRegister.Enabled = false;
                this.btnLogout.Enabled = false;
                this.btnDelete.Enabled = false;
            }
        }

        
    }
}
