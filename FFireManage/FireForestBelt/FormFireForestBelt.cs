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
    public partial class FormFireForestBelt : Form
    {
        private Fire_ForestBeltPoint m_FireForestBelt = null;
        private OperationType m_OperationType;
        private ForestBeltPointController m_ForestBeltController = null;

        public FormFireForestBelt(OperationType type, Fire_ForestBeltPoint fireForestBelt = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_FireForestBelt = fireForestBelt;
            this.m_ForestBeltController = new ForestBeltPointController();

            this.m_ForestBeltController.AddEvent += m_ForestBeltControllerr_AddEvent;
            this.m_ForestBeltController.EditEvent += m_ForestBeltController_EditEvent;
        }

        private void m_ForestBeltControllerr_AddEvent(object sender, ServiceEventArgs e)
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
                            this.DialogResult = DialogResult.OK;
                            this.Close();
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

        private void m_ForestBeltController_EditEvent(object sender, ServiceEventArgs e)
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

                            this.DialogResult = DialogResult.OK;
                            this.Close();
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

        private void FormFireForestBelt_Load(object sender, EventArgs e)
        {
            #region 初始化控件内容

            if (m_OperationType == OperationType.Add)
            {
                this.Text = "新增防护林带";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑防护林带";
                this.mediaControl1.IsMultiselect = false;
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看防护林带";
                this.mediaControl1.MainToolStrip.Visible = false;
            }

            /* 防护林带营造单位 */
            FireForestBeltBuildUnit fireForestBeltBuildUnit = FireForestBeltBuildUnit.林业局;
            List<object> fireForestBeltBuildUnitList = CommonHelper.GetDataSource<FireForestBeltBuildUnit>(fireForestBeltBuildUnit);
            this.cbx_build_unit.DisplayMember = "Name";
            this.cbx_build_unit.ValueMember = "Name";
            this.cbx_build_unit.DataSource = fireForestBeltBuildUnitList;

            /* 防护林带放火林带 */
            FireForestBeltType fireForestBeltType = FireForestBeltType.主防火林带;
            List<object> fireForestBeltTypeList = CommonHelper.GetDataSource<FireForestBeltType>(fireForestBeltType);
            this.cbx_type.DisplayMember = "Name";
            this.cbx_type.ValueMember = "Name";
            this.cbx_type.DataSource = fireForestBeltTypeList;

            /* 防护林带营造位置 */
            FireForestBeltBuildAddr fireForestBeltBuildAddr = FireForestBeltBuildAddr.边境防火林带;
            List<object> fireForestBeltBuildAddrList = CommonHelper.GetDataSource<FireForestBeltBuildAddr>(fireForestBeltBuildAddr);
            this.cbx_build_addr.DisplayMember = "Name";
            this.cbx_build_addr.ValueMember = "Name";
            this.cbx_build_addr.DataSource = fireForestBeltBuildAddrList;


            /* 防护林带状态 */
            FireForestBeltStatus fireForestBeltStatus = FireForestBeltStatus.优秀;
            List<object> fireForestBeltStatusList = CommonHelper.GetDataSource<FireForestBeltStatus>(fireForestBeltStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Value";
            this.cbx_status.DataSource = fireForestBeltStatusList;


            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_FireForestBelt.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_FireForestBelt.longitude;
                this.coordinatesInputControl1.Latitude = this.m_FireForestBelt.latitude;

                SmartForm.Fill(this.tabPage_baseInfo.Controls, this.m_FireForestBelt);

                this.tbx_note.Text = this.m_FireForestBelt.note;
                this.mediaControl1.MediaFiles = this.m_FireForestBelt.mediaFiles;

                if (this.m_OperationType == OperationType.Check)
                {
                    this.btnOK.Enabled = false;
                    this.btnCancel.Text = "关闭(&C)";

                    this.coordinatesInputControl1.Enabled = false;
                    this.pacControl11.Enabled = false;

                    SmartForm.SetControlsEnabled(this.tabPage_baseInfo.Controls, null);

                    this.tbx_note.Enabled = false;

                    this.mediaControl1.MainToolStrip.Visible = false;
                }
            }
            #endregion
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!IsCondition())
                return;
            IDictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                dict = m_FireForestBelt.ObjectDescriptionToDict();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (!SmartForm.Validator(this.tabPage_baseInfo.Controls, dict))
            {
                return;
            }
            if (m_OperationType == OperationType.Add)
            {
                this.m_FireForestBelt = new Fire_ForestBeltPoint();
            }
            this.m_FireForestBelt.longitude = this.coordinatesInputControl1.Longitude;
            this.m_FireForestBelt.latitude = this.coordinatesInputControl1.Latitude;
            this.m_FireForestBelt.pac = this.pacControl11.LocalPac;
            this.m_FireForestBelt.city_name = this.pacControl11.City;
            this.m_FireForestBelt.county_name = this.pacControl11.County;
            this.m_FireForestBelt.SHAPE = Converters.LngLatToWKT(this.m_FireForestBelt.longitude, this.m_FireForestBelt.latitude);

            //自动从窗体控件上取值
            this.m_FireForestBelt = SmartForm.GetEntity<Fire_ForestBeltPoint>(this.tabPage_baseInfo.Controls, this.m_FireForestBelt);

            this.m_FireForestBelt.build_year = this.dtp_build_year.Value.ToString("yyyy-MM-dd hh:mm:ss");
            this.m_FireForestBelt.note = this.tbx_note.Text.Trim();
            this.m_FireForestBelt.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                this.m_ForestBeltController.Add(this.m_FireForestBelt);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_ForestBeltController.Edit(this.m_FireForestBelt);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 判断是否满足数据提交条件
        /// </summary>
        /// <returns></returns>
        public bool IsCondition()
        {
            if (this.coordinatesInputControl1.Longitude == 0 || this.coordinatesInputControl1.Latitude == 0)
            {
                MessageBox.Show(this, "请输入正确的经纬度信息", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_location;
                this.coordinatesInputControl1.Focus();
                return false;
            }
            if (this.pacControl11.LocalPac == null || this.pacControl11.LocalPac.EndsWith("00"))
            {
                MessageBox.Show(this, "请选择正确的行政区", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_location;
                this.pacControl11.Focus();
                return false;
            }
            if (this.tbx_name.Text == "")
            {
                MessageBox.Show(this, "请输入防火林带名称", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_name.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_belt_len.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的防火林带长度", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_belt_len.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的防火林带长度", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_belt_len.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_belt_width.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的防火林带宽度", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_belt_width.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的防火林带宽度", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_belt_width.Focus();
                return false;
            }
            return true;
        }

        private void FormFireForestBelt_FormClosed(object sender, FormClosedEventArgs e)
        {
            //释放ImageList加载的图片资源
            this.mediaControl1.Dispose();
        }
    }
}
