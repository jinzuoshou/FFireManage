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

namespace FFireManage.SatelliteGroundStation
{
    public partial class FormSatelliteGroundStation : Form
    {
        private Fire_SatelliteGroundStation m_SatelliteGroundStation = null;
        private OperationType m_OperationType;
        private SatelliteGroundStationControler m_SatelliteGroundStationControler = null;

        public FormSatelliteGroundStation(OperationType type, Fire_SatelliteGroundStation satelliteGroundStation = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_SatelliteGroundStation = satelliteGroundStation;
            this.m_SatelliteGroundStationControler = new SatelliteGroundStationControler();

            this.m_SatelliteGroundStationControler.AddEvent += M_ServiceController_AddEvent;
            this.m_SatelliteGroundStationControler.EditEvent += M_ServiceController_EditEvent;
            this.m_SatelliteGroundStationControler.AddMediaEvent += M_SatelliteGroundStationControler_AddMediaEvent;
            this.m_SatelliteGroundStationControler.DeleteMediaEvent += M_SatelliteGroundStationControler_DeleteMediaEvent;

            this.mediaControl1.AddEvent += MediaControl1_AddEvent;
            this.mediaControl1.DeleteEvent += MediaControl1_DeleteEvent;
        }

        private void M_SatelliteGroundStationControler_DeleteMediaEvent(object sender, ServiceEventArgs e)
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

        private void M_SatelliteGroundStationControler_AddMediaEvent(object sender, ServiceEventArgs e)
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

        private void MediaControl1_DeleteEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null && this.m_OperationType != OperationType.Add)
                {
                    MediaFile content = sender as MediaFile;
                    if (content != null)
                    {
                        this.m_SatelliteGroundStationControler.DeleteMedia(content.id);
                    }
                }
            }));
        }

        private void MediaControl1_AddEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null && this.m_OperationType != OperationType.Add)
                {
                    Dictionary<string,object> content = sender as Dictionary<string, object>;
                    if (content != null)
                    {
                        this.m_SatelliteGroundStationControler.AddMedia(this.m_SatelliteGroundStation.id, content);
                    }
                }
            }));
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
                this.Text = "新增卫星地面站";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑卫星地面站";
                this.mediaControl1.IsMultiselect = false;
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看卫星地面站";
                this.mediaControl1.MainToolStrip.Visible = false;
            }
                     

            /* 卫星地面站状态 */
           SGSStatus fireSGSStatus = SGSStatus.优秀;
            List<object> firePWStatusList = CommonHelper.GetDataSource<SGSStatus>(fireSGSStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Name";
            this.cbx_status.DataSource = firePWStatusList;
            #endregion 

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_SatelliteGroundStation.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_SatelliteGroundStation.longitude;
                this.coordinatesInputControl1.Latitude = this.m_SatelliteGroundStation.latitude;
                SmartForm.Fill(this.tabPage_baseInfo.Controls, this.m_SatelliteGroundStation);

                this.tbx_note.Text = this.m_SatelliteGroundStation.note;
                this.mediaControl1.MediaFiles = this.m_SatelliteGroundStation.mediaFiles;

                if (this.m_OperationType == OperationType.Check)
                {
                    this.btnOK.Enabled = false;
                    this.btnCancel.Text = "关闭(&C)";

                    this.coordinatesInputControl1.Enabled = false;
                    this.pacControl11.Enabled = false;
                    SmartForm.SetControlsEnabled(this.tabPage_baseInfo.Controls,null);

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
            IDictionary<string, string> dict = new Dictionary<string,string>();
            try
            {
                this.tabControl1.SelectedTab = this.tabPage_baseInfo;
                dict = m_SatelliteGroundStation.ObjectDescriptionToDict();
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
                this.m_SatelliteGroundStation = new Fire_SatelliteGroundStation();
            }

            this.m_SatelliteGroundStation.longitude = this.coordinatesInputControl1.Longitude;
            this.m_SatelliteGroundStation.latitude = this.coordinatesInputControl1.Latitude;
            this.m_SatelliteGroundStation.pac = this.pacControl11.LocalPac;
            this.m_SatelliteGroundStation.shape = Converters.LngLatToWKT(this.m_SatelliteGroundStation.longitude, this.m_SatelliteGroundStation.latitude);

            //自动从窗体控件上取值
            m_SatelliteGroundStation = SmartForm.GetEntity<Fire_SatelliteGroundStation>(this.tabPage_baseInfo.Controls, this.m_SatelliteGroundStation);

            this.m_SatelliteGroundStation.note = this.tbx_note.Text.Trim();
            this.m_SatelliteGroundStation.mediaByteDict = this.mediaControl1.MediaByteDict;           

            if (m_OperationType == OperationType.Add)
            {
                this.m_SatelliteGroundStationControler.Add(this.m_SatelliteGroundStation);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_SatelliteGroundStationControler.Edit(this.m_SatelliteGroundStation);
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

        private void FormSatelliteGroundStation_FormClosed(object sender, FormClosedEventArgs e)
        {
            //释放加载资源
            int i = -1;
            foreach (Image img in this.mediaControl1.LargeImageList.Images)
            {
                i++;
                if (i > 4)
                {
                    img.Dispose();
                }
            }
        }
    }
}
