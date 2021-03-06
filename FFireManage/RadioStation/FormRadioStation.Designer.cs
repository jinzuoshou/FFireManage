﻿namespace FFireManage.RadioStation
{
    partial class FormRadioStation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_location = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.coordinatesInputControl1 = new FFireManage.Controls.CoordinatesInputControl();
            this.pacControl11 = new FFireManage.Controls.PACControl1();
            this.tabPage_baseInfo = new System.Windows.Forms.TabPage();
            this.tbx_address = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbx_units = new System.Windows.Forms.TextBox();
            this.tbx_power = new System.Windows.Forms.TextBox();
            this.tbx_l_frequenc = new System.Windows.Forms.TextBox();
            this.tbx_r_frequenc = new System.Windows.Forms.TextBox();
            this.tbx_coding = new System.Windows.Forms.TextBox();
            this.tbx_radioname = new System.Windows.Forms.TextBox();
            this.tbx_num_radio = new System.Windows.Forms.TextBox();
            this.tbx_type = new System.Windows.Forms.TextBox();
            this.dtp_build_year = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbx_status = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbx_d_type = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_manager = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_elevation = new FFireManage.Controls.NTextBox();
            this.tbx_height = new FFireManage.Controls.NTextBox();
            this.tbx_phone = new FFireManage.Controls.NTextBox();
            this.tabPage_note = new System.Windows.Forms.TabPage();
            this.tbx_note = new System.Windows.Forms.TextBox();
            this.tabPage_mediaInfo = new System.Windows.Forms.TabPage();
            this.mediaControl1 = new FFireManage.Controls.MediaControl();
            this.tabControl1.SuspendLayout();
            this.tabPage_location.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_baseInfo.SuspendLayout();
            this.tabPage_note.SuspendLayout();
            this.tabPage_mediaInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(558, 433);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 35);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(446, 433);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 35);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_location);
            this.tabControl1.Controls.Add(this.tabPage_baseInfo);
            this.tabControl1.Controls.Add(this.tabPage_note);
            this.tabControl1.Controls.Add(this.tabPage_mediaInfo);
            this.tabControl1.Location = new System.Drawing.Point(1, 8);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 402);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage_location
            // 
            this.tabPage_location.Controls.Add(this.groupBox1);
            this.tabPage_location.Controls.Add(this.pacControl11);
            this.tabPage_location.Location = new System.Drawing.Point(4, 26);
            this.tabPage_location.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_location.Name = "tabPage_location";
            this.tabPage_location.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_location.Size = new System.Drawing.Size(692, 372);
            this.tabPage_location.TabIndex = 2;
            this.tabPage_location.Text = "位置信息";
            this.tabPage_location.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.coordinatesInputControl1);
            this.groupBox1.Location = new System.Drawing.Point(42, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(426, 234);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "经纬度坐标";
            // 
            // coordinatesInputControl1
            // 
            this.coordinatesInputControl1.Latitude = 0D;
            this.coordinatesInputControl1.Location = new System.Drawing.Point(7, 20);
            this.coordinatesInputControl1.Longitude = 0D;
            this.coordinatesInputControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.coordinatesInputControl1.MaximumSize = new System.Drawing.Size(350, 198);
            this.coordinatesInputControl1.MinimumSize = new System.Drawing.Size(350, 198);
            this.coordinatesInputControl1.Name = "coordinatesInputControl1";
            this.coordinatesInputControl1.Size = new System.Drawing.Size(350, 198);
            this.coordinatesInputControl1.TabIndex = 0;
            // 
            // pacControl11
            // 
            this.pacControl11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pacControl11.Location = new System.Drawing.Point(42, 286);
            this.pacControl11.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.pacControl11.Name = "pacControl11";
            this.pacControl11.Size = new System.Drawing.Size(617, 54);
            this.pacControl11.TabIndex = 11;
            // 
            // tabPage_baseInfo
            // 
            this.tabPage_baseInfo.AutoScroll = true;
            this.tabPage_baseInfo.Controls.Add(this.tbx_address);
            this.tabPage_baseInfo.Controls.Add(this.label15);
            this.tabPage_baseInfo.Controls.Add(this.tbx_units);
            this.tabPage_baseInfo.Controls.Add(this.tbx_power);
            this.tabPage_baseInfo.Controls.Add(this.tbx_l_frequenc);
            this.tabPage_baseInfo.Controls.Add(this.tbx_r_frequenc);
            this.tabPage_baseInfo.Controls.Add(this.tbx_coding);
            this.tabPage_baseInfo.Controls.Add(this.tbx_radioname);
            this.tabPage_baseInfo.Controls.Add(this.tbx_num_radio);
            this.tabPage_baseInfo.Controls.Add(this.tbx_type);
            this.tabPage_baseInfo.Controls.Add(this.dtp_build_year);
            this.tabPage_baseInfo.Controls.Add(this.label12);
            this.tabPage_baseInfo.Controls.Add(this.label20);
            this.tabPage_baseInfo.Controls.Add(this.label17);
            this.tabPage_baseInfo.Controls.Add(this.label18);
            this.tabPage_baseInfo.Controls.Add(this.label14);
            this.tabPage_baseInfo.Controls.Add(this.label10);
            this.tabPage_baseInfo.Controls.Add(this.label13);
            this.tabPage_baseInfo.Controls.Add(this.label8);
            this.tabPage_baseInfo.Controls.Add(this.cbx_status);
            this.tabPage_baseInfo.Controls.Add(this.label11);
            this.tabPage_baseInfo.Controls.Add(this.tbx_d_type);
            this.tabPage_baseInfo.Controls.Add(this.label9);
            this.tabPage_baseInfo.Controls.Add(this.label7);
            this.tabPage_baseInfo.Controls.Add(this.label5);
            this.tabPage_baseInfo.Controls.Add(this.label6);
            this.tabPage_baseInfo.Controls.Add(this.label4);
            this.tabPage_baseInfo.Controls.Add(this.tbx_manager);
            this.tabPage_baseInfo.Controls.Add(this.label3);
            this.tabPage_baseInfo.Controls.Add(this.tbx_name);
            this.tabPage_baseInfo.Controls.Add(this.label1);
            this.tabPage_baseInfo.Controls.Add(this.tbx_elevation);
            this.tabPage_baseInfo.Controls.Add(this.tbx_height);
            this.tabPage_baseInfo.Controls.Add(this.tbx_phone);
            this.tabPage_baseInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPage_baseInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_baseInfo.Name = "tabPage_baseInfo";
            this.tabPage_baseInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_baseInfo.Size = new System.Drawing.Size(692, 372);
            this.tabPage_baseInfo.TabIndex = 0;
            this.tabPage_baseInfo.Text = "基本信息";
            this.tabPage_baseInfo.UseVisualStyleBackColor = true;
            // 
            // tbx_address
            // 
            this.tbx_address.AccessibleDescription = "length:^.{0,79}$:{0}1~80";
            this.tbx_address.AccessibleName = "address";
            this.tbx_address.Location = new System.Drawing.Point(439, 24);
            this.tbx_address.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_address.Name = "tbx_address";
            this.tbx_address.Size = new System.Drawing.Size(215, 23);
            this.tbx_address.TabIndex = 72;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(389, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 17);
            this.label15.TabIndex = 71;
            this.label15.Text = "地址:";
            // 
            // tbx_units
            // 
            this.tbx_units.AccessibleName = "units";
            this.tbx_units.Location = new System.Drawing.Point(439, 240);
            this.tbx_units.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_units.Name = "tbx_units";
            this.tbx_units.Size = new System.Drawing.Size(215, 23);
            this.tbx_units.TabIndex = 70;
            // 
            // tbx_power
            // 
            this.tbx_power.AccessibleName = "power";
            this.tbx_power.Location = new System.Drawing.Point(101, 212);
            this.tbx_power.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_power.Name = "tbx_power";
            this.tbx_power.Size = new System.Drawing.Size(215, 23);
            this.tbx_power.TabIndex = 69;
            // 
            // tbx_l_frequenc
            // 
            this.tbx_l_frequenc.AccessibleName = "l_frequenc";
            this.tbx_l_frequenc.Location = new System.Drawing.Point(439, 178);
            this.tbx_l_frequenc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_l_frequenc.Name = "tbx_l_frequenc";
            this.tbx_l_frequenc.Size = new System.Drawing.Size(215, 23);
            this.tbx_l_frequenc.TabIndex = 68;
            // 
            // tbx_r_frequenc
            // 
            this.tbx_r_frequenc.AccessibleName = "r_frequenc";
            this.tbx_r_frequenc.Location = new System.Drawing.Point(101, 181);
            this.tbx_r_frequenc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_r_frequenc.Name = "tbx_r_frequenc";
            this.tbx_r_frequenc.Size = new System.Drawing.Size(215, 23);
            this.tbx_r_frequenc.TabIndex = 67;
            // 
            // tbx_coding
            // 
            this.tbx_coding.AccessibleName = "coding";
            this.tbx_coding.Location = new System.Drawing.Point(439, 150);
            this.tbx_coding.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_coding.Name = "tbx_coding";
            this.tbx_coding.Size = new System.Drawing.Size(215, 23);
            this.tbx_coding.TabIndex = 66;
            // 
            // tbx_radioname
            // 
            this.tbx_radioname.AccessibleName = "radioname";
            this.tbx_radioname.Location = new System.Drawing.Point(439, 119);
            this.tbx_radioname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_radioname.Name = "tbx_radioname";
            this.tbx_radioname.Size = new System.Drawing.Size(215, 23);
            this.tbx_radioname.TabIndex = 65;
            // 
            // tbx_num_radio
            // 
            this.tbx_num_radio.AccessibleName = "num_radio";
            this.tbx_num_radio.Location = new System.Drawing.Point(101, 119);
            this.tbx_num_radio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_num_radio.Name = "tbx_num_radio";
            this.tbx_num_radio.Size = new System.Drawing.Size(215, 23);
            this.tbx_num_radio.TabIndex = 64;
            // 
            // tbx_type
            // 
            this.tbx_type.AccessibleName = "type";
            this.tbx_type.Location = new System.Drawing.Point(101, 150);
            this.tbx_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_type.Name = "tbx_type";
            this.tbx_type.Size = new System.Drawing.Size(215, 23);
            this.tbx_type.TabIndex = 63;
            // 
            // dtp_build_year
            // 
            this.dtp_build_year.AccessibleName = "build_year";
            this.dtp_build_year.Location = new System.Drawing.Point(101, 273);
            this.dtp_build_year.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtp_build_year.Name = "dtp_build_year";
            this.dtp_build_year.Size = new System.Drawing.Size(215, 23);
            this.dtp_build_year.TabIndex = 59;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(366, 244);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 17);
            this.label12.TabIndex = 57;
            this.label12.Text = "使用单位:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(30, 278);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 17);
            this.label20.TabIndex = 55;
            this.label20.Text = "建设时间:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(389, 212);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 17);
            this.label17.TabIndex = 51;
            this.label17.Text = "海拔:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(30, 249);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 17);
            this.label18.TabIndex = 47;
            this.label18.Text = "天线高度:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 215);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 17);
            this.label14.TabIndex = 42;
            this.label14.Text = "发射功率:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 38;
            this.label10.Text = "接收频率:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(366, 183);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 17);
            this.label13.TabIndex = 35;
            this.label13.Text = "发射频率:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 17);
            this.label8.TabIndex = 34;
            this.label8.Text = "类型:";
            // 
            // cbx_status
            // 
            this.cbx_status.AccessibleName = "status";
            this.cbx_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_status.FormattingEnabled = true;
            this.cbx_status.Location = new System.Drawing.Point(439, 55);
            this.cbx_status.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_status.Name = "cbx_status";
            this.cbx_status.Size = new System.Drawing.Size(215, 25);
            this.cbx_status.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(389, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 31;
            this.label11.Text = "状态:";
            // 
            // tbx_d_type
            // 
            this.tbx_d_type.AccessibleName = "d_type";
            this.tbx_d_type.Location = new System.Drawing.Point(101, 58);
            this.tbx_d_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_d_type.Name = "tbx_d_type";
            this.tbx_d_type.Size = new System.Drawing.Size(215, 23);
            this.tbx_d_type.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "电台类型:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(365, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "电台编号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(365, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "电台名称:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "电台呼号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "电话:";
            // 
            // tbx_manager
            // 
            this.tbx_manager.AccessibleName = "manager";
            this.tbx_manager.Location = new System.Drawing.Point(101, 91);
            this.tbx_manager.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_manager.Name = "tbx_manager";
            this.tbx_manager.Size = new System.Drawing.Size(215, 23);
            this.tbx_manager.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "管理员:";
            // 
            // tbx_name
            // 
            this.tbx_name.AccessibleDescription = "required;length:^.{0,49}$:{0}1~50";
            this.tbx_name.AccessibleName = "name";
            this.tbx_name.Location = new System.Drawing.Point(101, 25);
            this.tbx_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(215, 23);
            this.tbx_name.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "名称:";
            // 
            // tbx_elevation
            // 
            this.tbx_elevation.AccessibleName = "elevation";
            this.tbx_elevation.Location = new System.Drawing.Point(439, 209);
            this.tbx_elevation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_elevation.Name = "tbx_elevation";
            this.tbx_elevation.Size = new System.Drawing.Size(215, 23);
            this.tbx_elevation.TabIndex = 52;
            // 
            // tbx_height
            // 
            this.tbx_height.AccessibleName = "height";
            this.tbx_height.Location = new System.Drawing.Point(101, 243);
            this.tbx_height.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_height.Name = "tbx_height";
            this.tbx_height.Size = new System.Drawing.Size(215, 23);
            this.tbx_height.TabIndex = 48;
            // 
            // tbx_phone
            // 
            this.tbx_phone.AccessibleName = "phone";
            this.tbx_phone.Location = new System.Drawing.Point(439, 88);
            this.tbx_phone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_phone.Name = "tbx_phone";
            this.tbx_phone.Size = new System.Drawing.Size(215, 23);
            this.tbx_phone.TabIndex = 18;
            // 
            // tabPage_note
            // 
            this.tabPage_note.Controls.Add(this.tbx_note);
            this.tabPage_note.Location = new System.Drawing.Point(4, 26);
            this.tabPage_note.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_note.Name = "tabPage_note";
            this.tabPage_note.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_note.Size = new System.Drawing.Size(692, 372);
            this.tabPage_note.TabIndex = 3;
            this.tabPage_note.Text = "说明";
            this.tabPage_note.UseVisualStyleBackColor = true;
            // 
            // tbx_note
            // 
            this.tbx_note.AccessibleName = "note";
            this.tbx_note.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_note.Location = new System.Drawing.Point(3, 4);
            this.tbx_note.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_note.Multiline = true;
            this.tbx_note.Name = "tbx_note";
            this.tbx_note.Size = new System.Drawing.Size(686, 364);
            this.tbx_note.TabIndex = 13;
            // 
            // tabPage_mediaInfo
            // 
            this.tabPage_mediaInfo.Controls.Add(this.mediaControl1);
            this.tabPage_mediaInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPage_mediaInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_mediaInfo.Name = "tabPage_mediaInfo";
            this.tabPage_mediaInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_mediaInfo.Size = new System.Drawing.Size(692, 372);
            this.tabPage_mediaInfo.TabIndex = 1;
            this.tabPage_mediaInfo.Text = "多媒体文件";
            this.tabPage_mediaInfo.UseVisualStyleBackColor = true;
            // 
            // mediaControl1
            // 
            this.mediaControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaControl1.Location = new System.Drawing.Point(3, 4);
            this.mediaControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mediaControl1.MediaFiles = null;
            this.mediaControl1.Name = "mediaControl1";
            this.mediaControl1.Size = new System.Drawing.Size(686, 364);
            this.mediaControl1.TabIndex = 0;
            // 
            // FormRadioStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 504);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormRadioStation";
            this.Text = "新增无限电台站";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRadioStation_FormClosed);
            this.Load += new System.EventHandler(this.FormRadioStation_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_location.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage_baseInfo.ResumeLayout(false);
            this.tabPage_baseInfo.PerformLayout();
            this.tabPage_note.ResumeLayout(false);
            this.tabPage_note.PerformLayout();
            this.tabPage_mediaInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_location;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.CoordinatesInputControl coordinatesInputControl1;
        private Controls.PACControl1 pacControl11;
        private System.Windows.Forms.TabPage tabPage_baseInfo;
        private System.Windows.Forms.TextBox tbx_type;
        private System.Windows.Forms.DateTimePicker dtp_build_year;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label20;
        private Controls.NTextBox tbx_elevation;
        private System.Windows.Forms.Label label17;
        private Controls.NTextBox tbx_height;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbx_status;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbx_d_type;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Controls.NTextBox tbx_phone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_manager;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage_note;
        private System.Windows.Forms.TextBox tbx_note;
        private System.Windows.Forms.TabPage tabPage_mediaInfo;
        private System.Windows.Forms.TextBox tbx_radioname;
        private System.Windows.Forms.TextBox tbx_num_radio;
        private System.Windows.Forms.TextBox tbx_coding;
        private System.Windows.Forms.TextBox tbx_r_frequenc;
        private System.Windows.Forms.TextBox tbx_l_frequenc;
        private System.Windows.Forms.TextBox tbx_power;
        private System.Windows.Forms.TextBox tbx_units;
        private Controls.MediaControl mediaControl1;
        private System.Windows.Forms.TextBox tbx_address;
        private System.Windows.Forms.Label label15;
    }
}