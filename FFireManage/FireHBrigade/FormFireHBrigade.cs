﻿using FFireManage.Model;
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
    public partial class FormFireHBrigade : Form
    {
        #region fields
        private Fire_HBrigade m_FirePBrigade = null;
        private OperationType m_OperationType;
        private FireHBrigadeController m_FireHBrigadeController = null;
        #endregion

        #region constructor
        public FormFireHBrigade(OperationType type, Fire_HBrigade firePBrigade = null)
        {
            InitializeComponent();

            this.m_OperationType = type;
            this.m_FirePBrigade = firePBrigade;

            this.m_FireHBrigadeController = new FireHBrigadeController();
            this.m_FireHBrigadeController.AddEvent += M_ServiceController_AddEvent;
            this.m_FireHBrigadeController.EditEvent += M_ServiceController_EditEvent;
            this.m_FireHBrigadeController.AddMediaEvent += M_FireHBrigadeController_AddMediaEvent;
            this.m_FireHBrigadeController.DeleteMediaEvent += M_FireHBrigadeController_DeleteMediaEvent;

            this.mediaControl1.AddEvent += MediaControl1_AddEvent;
            this.mediaControl1.DeleteEvent += MediaControl1_DeleteEvent;
        }
        #endregion

        #region event methods
        private void MediaControl1_DeleteEvent(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (e != null && this.m_OperationType != OperationType.Add)
                {
                    MediaFile content = sender as MediaFile;
                    if (content != null)
                    {
                        this.m_FireHBrigadeController.DeleteMedia(content.id);
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
                        this.m_FireHBrigadeController.AddMedia(this.m_FirePBrigade.id, content);
                    }
                }
            }));
        }

        private void M_FireHBrigadeController_DeleteMediaEvent(object sender, ServiceEventArgs e)
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

        private void M_FireHBrigadeController_AddMediaEvent(object sender, ServiceEventArgs e)
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
                this.Text = "新增专业森林消防队";
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.Text = "编辑专业森林消防队";
                this.mediaControl1.IsMultiselect = false;
            }
            else if (m_OperationType == OperationType.Check)
            {
                this.Text = "查看专业森林消防队";
                this.mediaControl1.MainToolStrip.Visible = false;
            }

            /* 专业森林防火队状态 */
            FireHBrigadeStatus fireHBrigateStatus = FireHBrigadeStatus.优秀;
            List<object> fireForestBeltStatusList = CommonHelper.GetDataSource<FireHBrigadeStatus>(fireHBrigateStatus);
            this.cbx_status.DisplayMember = "Name";
            this.cbx_status.ValueMember = "Name";
            this.cbx_status.DataSource = fireForestBeltStatusList;

            #endregion

            #region 初始化行政区信息
            if (m_OperationType == OperationType.Add)
            {
                this.pacControl11.Init();
            }
            else if (m_OperationType == OperationType.Edit || m_OperationType == OperationType.Check)
            {
                this.pacControl11.Init(this.m_FirePBrigade.pac);
            }

            #endregion

            #region 编辑查看时为控件赋值
            if (this.m_OperationType == OperationType.Edit || this.m_OperationType == OperationType.Check)
            {
                this.coordinatesInputControl1.Longitude = this.m_FirePBrigade.longitude;
                this.coordinatesInputControl1.Latitude = this.m_FirePBrigade.latitude;
                SmartForm.Fill(this.tabPage_baseInfo.Controls, this.m_FirePBrigade);

                this.tbx_note.Text = this.m_FirePBrigade.note;
                this.mediaControl1.MediaFiles = this.m_FirePBrigade.mediaFiles;

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
                dict = m_FirePBrigade.ObjectDescriptionToDict();
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
                this.m_FirePBrigade = new Fire_HBrigade();
            }

            this.m_FirePBrigade.longitude = this.coordinatesInputControl1.Longitude;
            this.m_FirePBrigade.latitude = this.coordinatesInputControl1.Latitude;
            this.m_FirePBrigade.pac = this.pacControl11.LocalPac;
            this.m_FirePBrigade.shape = Converters.LngLatToWKT(this.m_FirePBrigade.longitude, this.m_FirePBrigade.latitude);

            //自动从窗体控件上取值
            m_FirePBrigade = SmartForm.GetEntity<Fire_HBrigade>(this.tabPage_baseInfo.Controls, this.m_FirePBrigade);

            this.m_FirePBrigade.note = this.tbx_note.Text.Trim();
            this.m_FirePBrigade.mediaByteDict = this.mediaControl1.MediaByteDict;

            if (m_OperationType == OperationType.Add)
            {
                this.m_FireHBrigadeController.Add(this.m_FirePBrigade);
            }
            else if (m_OperationType == OperationType.Edit)
            {
                this.m_FireHBrigadeController.Edit(this.m_FirePBrigade);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFireHBrigade_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 释放ImageList中的动态图片资源
            this.mediaControl1.Dispose();
        }
        #endregion

        #region member event
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
