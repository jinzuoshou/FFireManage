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
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看防护林带";
            }



            /* 防护林带geometry */
            Shape fireForestBeltShape = Shape.点;
            List<object> fireForestBeltShapeList = CommonHelper.GetDataSource<Shape>(fireForestBeltShape);
            this.cbx_shape.DisplayMember = "Name";
            this.cbx_shape.ValueMember = "Value";
            this.cbx_shape.DataSource = fireForestBeltShapeList;
            this.cbx_shape.SelectedValue = 1;
            this.cbx_shape.Enabled = false;

            /* 防护林带营造单位 */
            FireForestBeltBuildUnit fireForestBeltBuildUnit = FireForestBeltBuildUnit.林业局;
            List<object> fireForestBeltBuildUnitList = CommonHelper.GetDataSource<FireForestBeltBuildUnit>(fireForestBeltBuildUnit);
            this.cbx_buildUnit.DisplayMember = "Name";
            this.cbx_buildUnit.ValueMember = "Value";
            this.cbx_buildUnit.DataSource = fireForestBeltBuildUnitList;

            /* 防护林带放火林带 */
            FireForestBeltType fireForestBeltType = FireForestBeltType.主防火林带;
            List<object> fireForestBeltTypeList = CommonHelper.GetDataSource<FireForestBeltType>(fireForestBeltType);
            this.cbx_type.DisplayMember = "Name";
            this.cbx_type.ValueMember = "Value";
            this.cbx_type.DataSource = fireForestBeltTypeList;

            /* 防护林带营造位置 */
            FireForestBeltBuildAddr fireForestBeltBuildAddr = FireForestBeltBuildAddr.边境防火林带;
            List<object> fireForestBeltBuildAddrList = CommonHelper.GetDataSource<FireForestBeltBuildAddr>(fireForestBeltBuildAddr);
            this.cbx_build_addr.DisplayMember = "Name";
            this.cbx_build_addr.ValueMember = "Value";
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
                this.tbx_name.Text = this.m_FireForestBelt.name;
                if (this.m_FireForestBelt.SHAPE.Contains("POINT"))
                {
                    this.cbx_shape.SelectedValue = 1;
                }
                else if (this.m_FireForestBelt.SHAPE.Contains("LINEstring"))
                {
                    this.cbx_shape.SelectedValue = 2;
                }
                else if (this.m_FireForestBelt.SHAPE.Contains("POLYGON"))
                {
                    this.cbx_shape.SelectedValue = 3;
                }
                this.cbx_type.SelectedText = this.m_FireForestBelt.type;
                this.cbx_status.SelectedValue = (int)this.m_FireForestBelt.status;
                this.cbx_buildUnit.SelectedText = this.m_FireForestBelt.build_unit;
                this.tbx_tree_type.Text = this.m_FireForestBelt.tree_type;
                this.tbx_start_addr.Text = this.m_FireForestBelt.start_addr;
                this.tbx_stop_addr.Text = this.m_FireForestBelt.stop_addr;
                this.cbx_build_addr.Text = this.m_FireForestBelt.build_addr;
                try
                {
                    this.dtp_buildYear.Value = Convert.ToDateTime(this.m_FireForestBelt.build_year);
                }
                catch
                { }
                this.tbx_row_spacing.Text = this.m_FireForestBelt.row_spacing;
                this.tbx_belt_len.Text = this.m_FireForestBelt.belt_len.ToString();
                this.tbx_belt_width.Text = this.m_FireForestBelt.belt_width.ToString();

                this.tbx_note.Text = this.m_FireForestBelt.note;
                this.mediaControl1.MediaFiles = this.m_FireForestBelt.mediaFiles;

                if (this.m_OperationType == OperationType.Check)
                {
                    this.btnOK.Enabled = false;
                    this.btnCancel.Text = "关闭(&C)";

                    this.coordinatesInputControl1.Enabled = false;
                    this.pacControl11.Enabled = false;
                    this.tbx_name.Enabled = false;
                    this.cbx_status.Enabled = false;
                    this.cbx_type.Enabled = false;
                    this.cbx_status.Enabled = false;
                    this.cbx_buildUnit.Enabled = false;
                    this.tbx_tree_type.Enabled = false;
                    this.tbx_start_addr.Enabled = false;
                    this.tbx_stop_addr.Enabled = false;
                    this.cbx_build_addr.Enabled = false;
                    this.dtp_buildYear.Enabled = false;
                    this.tbx_row_spacing.Enabled = false;
                    this.tbx_belt_len.Enabled = false;
                    this.tbx_belt_width.Enabled = false;

                    this.tbx_note.Enabled = false;


                }
            }
            #endregion
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!IsCondition())
                return;
            if (m_OperationType == OperationType.Add)
            {
                this.m_FireForestBelt = new Fire_ForestBeltPoint();
            }
            this.m_FireForestBelt.longitude = this.coordinatesInputControl1.Longitude;
            this.m_FireForestBelt.latitude = this.coordinatesInputControl1.Latitude;
            this.m_FireForestBelt.pac = this.pacControl11.LocalPac;
            this.m_FireForestBelt.name = this.tbx_name.Text;
            if ((int)this.cbx_shape.SelectedValue == 1)
            {
                this.m_FireForestBelt.SHAPE = GDALHelper.LngLatToWktPoint(this.m_FireForestBelt.longitude, this.m_FireForestBelt.latitude);
            }
            this.m_FireForestBelt.type = this.cbx_type.Text;
            this.m_FireForestBelt.status = (int)this.cbx_status.SelectedValue;
            this.m_FireForestBelt.build_unit = this.cbx_buildUnit.Text;
            this.m_FireForestBelt.tree_type = this.tbx_tree_type.Text;
            this.m_FireForestBelt.start_addr = this.tbx_start_addr.Text;
            this.m_FireForestBelt.stop_addr = this.tbx_stop_addr.Text;
            this.m_FireForestBelt.build_addr = this.cbx_build_addr.Text;
            this.m_FireForestBelt.build_year = this.dtp_buildYear.Value.ToString("yyyy-MM-dd hh:mm:ss");
            this.m_FireForestBelt.row_spacing = this.tbx_row_spacing.Text;
           
            this.m_FireForestBelt.belt_len = Convert.ToDouble(this.tbx_belt_len.Text);
            this.m_FireForestBelt.belt_width = Convert.ToDouble(this.tbx_belt_width.Text.Trim());
            
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
            if (this.cbx_type.SelectedValue==null)
            {
                MessageBox.Show(this, "请选择防火林带类型", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.cbx_type.Focus();
                return false;
            }
            if (this.cbx_shape.SelectedValue == null)
            {
                MessageBox.Show(this, "请选择防火林带形状", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.cbx_shape.Focus();
                return false;
            }
            if (this.cbx_status.SelectedValue == null)
            {
                MessageBox.Show(this, "请选择防火林带状态", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.cbx_status.Focus();
                return false;
            }
            if (this.cbx_buildUnit.SelectedValue == null)
            {
                MessageBox.Show(this, "请选择防火林带营造单位", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.cbx_buildUnit.Focus();
                return false;
            }
            if (this.tbx_tree_type.Text.Trim() == "")
            {
                MessageBox.Show(this, "请选择防火林带树种", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_tree_type.Focus();
                return false;
            }
            if (this.tbx_start_addr.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入起始地点", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_start_addr.Focus();
                return false;
            }
            if (this.tbx_stop_addr.Text.Trim() == "")
            {
                MessageBox.Show(this, "请选输入发射频率", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_stop_addr.Focus();
                return false;
            }
            if (this.cbx_build_addr.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入营造位置", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.cbx_build_addr.Focus();
                return false;
            }
            if (this.tbx_row_spacing.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入株行距", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_row_spacing.Focus();
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
    }
}
