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

namespace FFireManage.PlaneWaterPoint
{
    public partial class FormPlaneWaterPoint : Form
    {
        private Fire_Planewaterpoint m_Planewaterpoint = null;
        private OperationType m_OperationType;
        private PlanewaterpointControler m_PlanewaterpointControler = null;

        public FormPlaneWaterPoint(OperationType type, Fire_Planewaterpoint planewaterpoint = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_Planewaterpoint = planewaterpoint;
            this.m_PlanewaterpointControler = new PlanewaterpointControler();

            this.m_PlanewaterpointControler.AddEvent += M_ServiceController_AddEvent;
            this.m_PlanewaterpointControler.EditEvent += M_ServiceController_EditEvent;
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
                this.Text = "新增专业森林消防队";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑专业森林消防队";
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看专业森林消防队";
            }

            /* 飞机吊桶取水点状态 */
            PWType firePWType = PWType.水库;
            List<object> firePWTypeList = CommonHelper.GetDataSource<PWType>(firePWType);
            this.cbx_Type.DisplayMember = "Name";
            this.cbx_Type.ValueMember = "Name";
            this.cbx_Type.DataSource = firePWTypeList;

            /* 飞机吊桶取水点状态 */
            PWStatus firePWStatus = PWStatus.优秀;
            List<object> firePWStatusList = CommonHelper.GetDataSource<PWStatus>(firePWStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Name";
            this.cbx_status.DataSource = firePWStatusList;

            /* 飞机吊桶取水点有无电线索道 */
            PWIsCableway isCableway = PWIsCableway.是;
            List<object> isCablewayList = CommonHelper.GetDataSource<PWIsCableway>(isCableway);
            this.cbx_is_cableway.DisplayMember = "Name";
            this.cbx_is_cableway.ValueMember = "Name";
            this.cbx_is_cableway.DataSource = isCablewayList;

            /* 航飞机吊桶取水点能否吊桶取水 */
            PWIsTakeWater isTakeWater = PWIsTakeWater.是;
            List<object> isTakeWaterList = CommonHelper.GetDataSource<PWIsTakeWater>(isTakeWater);
            this.cbx_is_take_water.DisplayMember = "Name";
            this.cbx_is_take_water.ValueMember = "Name";
            this.cbx_is_take_water.DataSource = isTakeWaterList;

            /* 航飞机吊桶取水点是否有网箱养鱼 */
            PWIsCageFish isCageFish = PWIsCageFish.是;
            List<object> isCageFishList = CommonHelper.GetDataSource<PWIsCageFish>(isCageFish);
            this.cbx_is_cage_fish.DisplayMember = "Name";
            this.cbx_is_cage_fish.ValueMember = "Name";
            this.cbx_is_cage_fish.DataSource = isCageFishList;
            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_Planewaterpoint.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_Planewaterpoint.longitude;
                this.coordinatesInputControl1.Latitude = this.m_Planewaterpoint.latitude;
                SmartForm.Fill(this.tabPage_baseInfo.Controls, this.m_Planewaterpoint);

                this.tbx_note.Text = this.m_Planewaterpoint.note;
                this.mediaControl1.MediaFiles = this.m_Planewaterpoint.mediaFiles;

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
                dict = m_Planewaterpoint.ObjectDescriptionToDict();
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
                this.m_Planewaterpoint = new Fire_Planewaterpoint();
            }

            this.m_Planewaterpoint.longitude = this.coordinatesInputControl1.Longitude;
            this.m_Planewaterpoint.latitude = this.coordinatesInputControl1.Latitude;
            this.m_Planewaterpoint.pac = this.pacControl11.LocalPac;
            this.m_Planewaterpoint.shape = Converters.LngLatToWKT(this.m_Planewaterpoint.longitude, this.m_Planewaterpoint.latitude);

            //自动从窗体控件上取值
            m_Planewaterpoint = SmartForm.GetEntity<Fire_Planewaterpoint>(this.tabPage_baseInfo.Controls, this.m_Planewaterpoint);

            this.m_Planewaterpoint.note = this.tbx_note.Text.Trim();
            this.m_Planewaterpoint.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                this.m_PlanewaterpointControler.Add(this.m_Planewaterpoint);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_PlanewaterpointControler.Edit(this.m_Planewaterpoint);
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
