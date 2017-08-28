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

namespace FFireManage.FireImportantUnits
{
    public partial class FormFireImportantUnits : Form
    {
        private Fire_ImportantUnits m_FireImportantUnits = null;
        private OperationType m_OperationType;
        private FireImportantUnitsController m_FireIUnitsController = null;

        public FormFireImportantUnits(OperationType type, Fire_ImportantUnits fireImportantUnits = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_FireImportantUnits = fireImportantUnits;
            this.m_FireIUnitsController = new FireImportantUnitsController();

            this.m_FireIUnitsController.AddEvent += M_ServiceController_AddEvent;
            this.m_FireIUnitsController.EditEvent += M_ServiceController_EditEvent;
        }

        private void M_ServiceController_AddEvent(object sender, ServiceEventArgs e)
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

        private void M_ServiceController_EditEvent(object sender, ServiceEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null)
                {
                    string content = e.Content;
                    try
                    {
                        BaseResultInfo<object> result = JsonHelper.JSONToObject<BaseResultInfo<object>>(content);

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
                this.Text = "新增重点防火单位";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑重点防火单位";
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看重点防火单位";
            }

            FireImportantUnitsType fireIUnitsType = FireImportantUnitsType.县级防火检查站;
            List<object> fireIUnitsTypeList = CommonHelper.GetDataSource<FireImportantUnitsType>(fireIUnitsType);
            this.cbx_type.DisplayMember = "Name";
            this.cbx_type.ValueMember = "Name";
            this.cbx_type.DataSource = fireIUnitsTypeList;

            /* 专业森林防火队状态 */
            FireHBrigadeStatus fireHBrigateStatus = FireHBrigadeStatus.优秀;
            List<object> fireForestBeltStatusList = CommonHelper.GetDataSource<FireHBrigadeStatus>(fireHBrigateStatus);
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
                this.pacControl11.Init(this.m_FireImportantUnits.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_FireImportantUnits.longitude;
                this.coordinatesInputControl1.Latitude = this.m_FireImportantUnits.latitude;
                SmartForm.Fill(this.tabPage_baseInfo.Controls, this.m_FireImportantUnits);

                this.tbx_note.Text = this.m_FireImportantUnits.note;
                this.mediaControl1.MediaFiles = this.m_FireImportantUnits.mediaFiles;

                if (this.m_OperationType == OperationType.Check)
                {
                    this.btnOK.Enabled = false;
                    this.btnCancel.Text = "关闭(&C)";

                    this.coordinatesInputControl1.Enabled = false;
                    this.pacControl11.Enabled = false;
                    SmartForm.SetControlsEnabled(this.tabPage_baseInfo.Controls,null);

                    this.tbx_note.Enabled = false;


                }
            }
            #endregion
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!IsCondition())
                return;
            IDictionary<string, string> dict = new Dictionary<string,string>();
            try
            {
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                dict = m_FireImportantUnits.ObjectDescriptionToDict();
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
                this.m_FireImportantUnits = new Fire_ImportantUnits();
            }

            this.m_FireImportantUnits.longitude = this.coordinatesInputControl1.Longitude;
            this.m_FireImportantUnits.latitude = this.coordinatesInputControl1.Latitude;
            this.m_FireImportantUnits.pac = this.pacControl11.LocalPac;
            this.m_FireImportantUnits.SHAPE = Converters.LngLatToWKT(this.m_FireImportantUnits.longitude, this.m_FireImportantUnits.latitude);

            //自动从窗体控件上取值
            m_FireImportantUnits = SmartForm.GetEntity<Fire_ImportantUnits>(this.tabPage_baseInfo.Controls, this.m_FireImportantUnits);

            this.m_FireImportantUnits.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                this.m_FireIUnitsController.Add(this.m_FireImportantUnits);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_FireIUnitsController.Edit(this.m_FireImportantUnits);
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
            return true;
        }
    }
}
