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
    public partial class FormArtificiallake : Form
    {
        private Fire_Artificiallake m_Artificiallake = null;
        private OperationType m_OperationType;
        private ArtificiallakeController m_ArtificiallakeController = null;

        public FormArtificiallake(OperationType type, Fire_Artificiallake artificiallake = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_Artificiallake = artificiallake;
            this.m_ArtificiallakeController = new ArtificiallakeController();

            this.m_ArtificiallakeController.AddEvent += m_ArtificiallakeController_AddEvent;
            this.m_ArtificiallakeController.EditEvent += m_ArtificiallakeController_EditEvent;
        }

        private void m_ArtificiallakeController_AddEvent(object sender, ServiceEventArgs e)
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

        private void m_ArtificiallakeController_EditEvent(object sender, ServiceEventArgs e)
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

        private void FormArtificiallake_Load(object sender, EventArgs e)
        {
            #region 初始化控件内容

            if (m_OperationType == OperationType.Add)
            {
                this.Text = "新增航空灭火蓄水池";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑航空灭火蓄水池";
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看航空灭火蓄水池";
            }



            /* 航空灭火蓄水池状态 */
            ArtificiallakeStatus artificiallakeStatus = ArtificiallakeStatus.优秀;
            List<object> artificiallakeStatusList = CommonHelper.GetDataSource<ArtificiallakeStatus>(artificiallakeStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Value";
            this.cbx_status.DataSource = artificiallakeStatusList;

            /* 航空灭火蓄水池有无电线索道 */
            ArtificiallakeIsCableway isCableway = ArtificiallakeIsCableway.是;
            List<object> isCablewayList = CommonHelper.GetDataSource<ArtificiallakeIsCableway>(isCableway);
            this.cbx_isCableway.DisplayMember = "Name";
            this.cbx_isCableway.ValueMember = "Name";
            this.cbx_isCableway.DataSource = isCablewayList;

            /* 航空灭火蓄水池能否吊桶取水 */
            ArtificiallakeIsTakeWater isTakeWater = ArtificiallakeIsTakeWater.是;
            List<object> isTakeWaterList = CommonHelper.GetDataSource<ArtificiallakeIsTakeWater>(isTakeWater);
            this.cbx_isTakeWater.DisplayMember = "Name";
            this.cbx_isTakeWater.ValueMember = "Name";
            this.cbx_isTakeWater.DataSource = isTakeWaterList;

            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_Artificiallake.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_Artificiallake.longitude;
                this.coordinatesInputControl1.Latitude = this.m_Artificiallake.latitude;

                SmartForm.Fill(this.tabPage_baseInfo.Controls, this.m_Artificiallake);

                this.tbx_note.Text = this.m_Artificiallake.note;
                this.mediaControl1.MediaFiles = this.m_Artificiallake.mediaFiles;

                if (this.m_OperationType == OperationType.Check)
                {
                    this.btnOK.Enabled = false;
                    this.btnCancel.Text = "关闭(&C)";

                    this.coordinatesInputControl1.Enabled = false;
                    this.pacControl11.Enabled = false;

                    SmartForm.SetControlsEnabled(this.tabPage_baseInfo.Controls, null);

                    this.mediaControl1.MainToolStrip.Visible = false;

                    this.tbx_note.Enabled = false;

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
                dict = m_Artificiallake.ObjectDescriptionToDict();
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
                this.m_Artificiallake = new Fire_Artificiallake();
            }

            if (m_OperationType == OperationType.Add)
            {
                this.m_Artificiallake = new Fire_Artificiallake();
            }
            this.m_Artificiallake.longitude = this.coordinatesInputControl1.Longitude;
            this.m_Artificiallake.latitude = this.coordinatesInputControl1.Latitude;
            this.m_Artificiallake.pac = this.pacControl11.LocalPac;
            this.m_Artificiallake.city_name = this.pacControl11.City;
            this.m_Artificiallake.county_name = this.pacControl11.County;
            this.m_Artificiallake.shape = Converters.LngLatToWKT(this.m_Artificiallake.longitude, this.m_Artificiallake.latitude);

            //自动从窗体控件上取值
            m_Artificiallake = SmartForm.GetEntity<Fire_Artificiallake>(this.tabPage_baseInfo.Controls, this.m_Artificiallake);

            this.m_Artificiallake.note = this.tbx_note.Text.Trim();
            this.m_Artificiallake.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                this.m_ArtificiallakeController.Add(this.m_Artificiallake);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_ArtificiallakeController.Edit(this.m_Artificiallake);
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
                MessageBox.Show(this, "请输入航空灭火蓄水池名称", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_name.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_volume.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的容积量", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_volume.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的容积量", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_volume.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_storage_area.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的蓄水面积", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_storage_area.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的蓄水面积", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_storage_area.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_storage_capacity.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的蓄水容量", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_storage_capacity.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的蓄水容量", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_storage_capacity.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_storage_capacity.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的蓄水容量", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_storage_capacity.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的蓄水容量", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_storage_capacity.Focus();
                return false;
            }
            try
            {
                double num = Convert.ToDouble(this.tbx_maximum_depth.Text.Trim());
                if (num < 0)
                {
                    MessageBox.Show(this, "请输入正确的最大深度", "信息提示");
                    this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                    this.tbx_maximum_depth.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的最大深度", "信息提示");
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                this.tbx_maximum_depth.Focus();
                return false;
            }
            return true;
        }
    }
}
