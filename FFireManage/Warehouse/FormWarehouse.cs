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
    public partial class FormWarehouse : Form
    {
        #region Fields
        private Fire_Warehouse m_Warehouse = null;
        private OperationType m_OperationType;
        private FireWarehouseController m_FireWarehouseController = null;
        #endregion

        #region Constructor
        public FormWarehouse(OperationType type, Fire_Warehouse fireWarehouse = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_Warehouse = fireWarehouse;

            this.m_FireWarehouseController = new FireWarehouseController();
            this.m_FireWarehouseController.AddEvent += M_ServiceController_AddEvent;
            this.m_FireWarehouseController.EditEvent += M_ServiceController_EditEvent;
            this.m_FireWarehouseController.AddMediaEvent += M_FireWarehouseController_AddMediaEvent;
            this.m_FireWarehouseController.DeleteMediaEvent += M_FireWarehouseController_DeleteMediaEvent;

            this.mediaControl1.AddEvent += MediaControl1_AddEvent;
            this.mediaControl1.DeleteEvent += MediaControl1_DeleteEvent;
        }
        #endregion

        #region Event Methods
        private void MediaControl1_DeleteEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null && this.m_OperationType != OperationType.Add)
                {
                    MediaFile content = sender as MediaFile;
                    if (content != null)
                    {
                        this.m_FireWarehouseController.DeleteMedia(content.id);
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
                    Dictionary<string, object> content = sender as Dictionary<string, object>;
                    if (content != null)
                    {
                        this.m_FireWarehouseController.AddMedia(this.m_Warehouse.id, content);
                    }
                }
            }));
        }

        private void M_FireWarehouseController_DeleteMediaEvent(object sender, ServiceEventArgs e)
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

        private void M_FireWarehouseController_AddMediaEvent(object sender, ServiceEventArgs e)
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
                this.Text = "新增森林防火物资储备库";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑森林防火物资储备库";
                this.mediaControl1.IsMultiselect = false;
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看森林防火物资储备库";
                this.mediaControl1.MainToolStrip.Visible = false;
            }

            /* 防火物资储备库类型 */
            WarehouseType warehouseType = WarehouseType.国家级物质储备库;
            List<object> warningBoardsTypeList = CommonHelper.GetDataSource<WarehouseType>(warehouseType);
            this.cmb_type.DisplayMember = "Name";
            this.cmb_type.ValueMember = "Name";
            this.cmb_type.DataSource = warningBoardsTypeList;

            /* 防火物资储备库状态 */
            WarehouseStatus warehouseStatus = WarehouseStatus.优秀;
            List<object> warehouseStatusList = CommonHelper.GetDataSource<WarehouseStatus>(warehouseStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Name";
            this.cbx_status.DataSource = warehouseStatusList;

            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_Warehouse.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_Warehouse.longitude;
                this.coordinatesInputControl1.Latitude = this.m_Warehouse.latitude;
                SmartForm.Fill(this.tabPage_baseInfo.Controls, this.m_Warehouse);

                this.tbx_note.Text = this.m_Warehouse.note;
                this.mediaControl1.MediaFiles = this.m_Warehouse.mediaFiles;

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
                dict = m_Warehouse.ObjectDescriptionToDict();
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
                this.m_Warehouse = new Fire_Warehouse();
            }

            this.m_Warehouse.longitude = this.coordinatesInputControl1.Longitude;
            this.m_Warehouse.latitude = this.coordinatesInputControl1.Latitude;
            this.m_Warehouse.pac = this.pacControl11.LocalPac;
            this.m_Warehouse.shape = Converters.LngLatToWKT(this.m_Warehouse.longitude, this.m_Warehouse.latitude);

            //自动从窗体控件上取值
            m_Warehouse = SmartForm.GetEntity<Fire_Warehouse>(this.tabPage_baseInfo.Controls, this.m_Warehouse);

            this.m_Warehouse.build_year = this.dtp_build_year.Value.ToString("yyyy-MM-dd hh:mm:ss");
            this.m_Warehouse.note = this.tbx_note.Text.Trim();
            this.m_Warehouse.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                this.m_FireWarehouseController.Add(this.m_Warehouse);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_FireWarehouseController.Edit(this.m_Warehouse);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormWarehouse_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mediaControl1.Dispose();
        }
        #endregion

        #region Members Methods
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

        #endregion
    }
}