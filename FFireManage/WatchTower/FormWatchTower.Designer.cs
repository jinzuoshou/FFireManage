namespace FFireManage.WatchTower
{
    partial class FormWatchTower
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_location = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.coordinatesInputControl1 = new FFireManage.Controls.CoordinatesInputControl();
            this.pacControl11 = new FFireManage.Controls.PACControl1();
            this.tabPage_baseInfo = new System.Windows.Forms.TabPage();
            this.cbx_structure = new System.Windows.Forms.ComboBox();
            this.tbx_video_surveillance = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.dtp_build_year = new System.Windows.Forms.DateTimePicker();
            this.tbx_build_unit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbx_status = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbx_type = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_manager = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_shape = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_look_area = new FFireManage.Controls.NTextBox();
            this.tbx_look_forest_area = new FFireManage.Controls.NTextBox();
            this.tbx_look_coverage = new FFireManage.Controls.NTextBox();
            this.tbx_c_area = new FFireManage.Controls.NTextBox();
            this.tbx_telescope = new FFireManage.Controls.NTextBox();
            this.tbx_interphone = new FFireManage.Controls.NTextBox();
            this.tbx_compass_instrument = new FFireManage.Controls.NTextBox();
            this.tbx_telephone = new FFireManage.Controls.NTextBox();
            this.tbx_phone = new FFireManage.Controls.NTextBox();
            this.tbx_elevation = new FFireManage.Controls.NTextBox();
            this.tbx_radio = new FFireManage.Controls.NTextBox();
            this.tabPage_note = new System.Windows.Forms.TabPage();
            this.tbx_note = new System.Windows.Forms.TextBox();
            this.tabPage_mediaInfo = new System.Windows.Forms.TabPage();
            this.mediaControl1 = new FFireManage.Controls.MediaControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage_location.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_baseInfo.SuspendLayout();
            this.tabPage_note.SuspendLayout();
            this.tabPage_mediaInfo.SuspendLayout();
            this.SuspendLayout();
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
            this.tabControl1.Location = new System.Drawing.Point(6, 13);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(742, 449);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage_location
            // 
            this.tabPage_location.Controls.Add(this.groupBox1);
            this.tabPage_location.Controls.Add(this.pacControl11);
            this.tabPage_location.Location = new System.Drawing.Point(4, 26);
            this.tabPage_location.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_location.Name = "tabPage_location";
            this.tabPage_location.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_location.Size = new System.Drawing.Size(734, 419);
            this.tabPage_location.TabIndex = 2;
            this.tabPage_location.Text = "位置信息";
            this.tabPage_location.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.coordinatesInputControl1);
            this.groupBox1.Location = new System.Drawing.Point(55, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(419, 234);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "经纬度坐标";
            // 
            // coordinatesInputControl1
            // 
            this.coordinatesInputControl1.Latitude = 0D;
            this.coordinatesInputControl1.Location = new System.Drawing.Point(31, 16);
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
            this.pacControl11.Location = new System.Drawing.Point(55, 285);
            this.pacControl11.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.pacControl11.Name = "pacControl11";
            this.pacControl11.Size = new System.Drawing.Size(644, 54);
            this.pacControl11.TabIndex = 13;
            // 
            // tabPage_baseInfo
            // 
            this.tabPage_baseInfo.AutoScroll = true;
            this.tabPage_baseInfo.Controls.Add(this.cbx_structure);
            this.tabPage_baseInfo.Controls.Add(this.tbx_video_surveillance);
            this.tabPage_baseInfo.Controls.Add(this.label21);
            this.tabPage_baseInfo.Controls.Add(this.dtp_build_year);
            this.tabPage_baseInfo.Controls.Add(this.tbx_build_unit);
            this.tabPage_baseInfo.Controls.Add(this.label12);
            this.tabPage_baseInfo.Controls.Add(this.label20);
            this.tabPage_baseInfo.Controls.Add(this.label19);
            this.tabPage_baseInfo.Controls.Add(this.label17);
            this.tabPage_baseInfo.Controls.Add(this.label18);
            this.tabPage_baseInfo.Controls.Add(this.label14);
            this.tabPage_baseInfo.Controls.Add(this.label15);
            this.tabPage_baseInfo.Controls.Add(this.label10);
            this.tabPage_baseInfo.Controls.Add(this.label13);
            this.tabPage_baseInfo.Controls.Add(this.label8);
            this.tabPage_baseInfo.Controls.Add(this.cbx_status);
            this.tabPage_baseInfo.Controls.Add(this.label11);
            this.tabPage_baseInfo.Controls.Add(this.cbx_type);
            this.tabPage_baseInfo.Controls.Add(this.label9);
            this.tabPage_baseInfo.Controls.Add(this.label7);
            this.tabPage_baseInfo.Controls.Add(this.label5);
            this.tabPage_baseInfo.Controls.Add(this.label6);
            this.tabPage_baseInfo.Controls.Add(this.label4);
            this.tabPage_baseInfo.Controls.Add(this.tbx_manager);
            this.tabPage_baseInfo.Controls.Add(this.label3);
            this.tabPage_baseInfo.Controls.Add(this.cbx_shape);
            this.tabPage_baseInfo.Controls.Add(this.label2);
            this.tabPage_baseInfo.Controls.Add(this.tbx_name);
            this.tabPage_baseInfo.Controls.Add(this.label1);
            this.tabPage_baseInfo.Controls.Add(this.tbx_look_area);
            this.tabPage_baseInfo.Controls.Add(this.tbx_look_forest_area);
            this.tabPage_baseInfo.Controls.Add(this.tbx_look_coverage);
            this.tabPage_baseInfo.Controls.Add(this.tbx_c_area);
            this.tabPage_baseInfo.Controls.Add(this.tbx_telescope);
            this.tabPage_baseInfo.Controls.Add(this.tbx_interphone);
            this.tabPage_baseInfo.Controls.Add(this.tbx_compass_instrument);
            this.tabPage_baseInfo.Controls.Add(this.tbx_telephone);
            this.tabPage_baseInfo.Controls.Add(this.tbx_phone);
            this.tabPage_baseInfo.Controls.Add(this.tbx_elevation);
            this.tabPage_baseInfo.Controls.Add(this.tbx_radio);
            this.tabPage_baseInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPage_baseInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_baseInfo.Name = "tabPage_baseInfo";
            this.tabPage_baseInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_baseInfo.Size = new System.Drawing.Size(734, 419);
            this.tabPage_baseInfo.TabIndex = 0;
            this.tabPage_baseInfo.Text = "基本信息";
            this.tabPage_baseInfo.UseVisualStyleBackColor = true;
            // 
            // cbx_structure
            // 
            this.cbx_structure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_structure.FormattingEnabled = true;
            this.cbx_structure.Location = new System.Drawing.Point(101, 339);
            this.cbx_structure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_structure.Name = "cbx_structure";
            this.cbx_structure.Size = new System.Drawing.Size(215, 25);
            this.cbx_structure.TabIndex = 62;
            // 
            // tbx_video_surveillance
            // 
            this.tbx_video_surveillance.Location = new System.Drawing.Point(439, 382);
            this.tbx_video_surveillance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_video_surveillance.Name = "tbx_video_surveillance";
            this.tbx_video_surveillance.Size = new System.Drawing.Size(215, 23);
            this.tbx_video_surveillance.TabIndex = 61;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(364, 388);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 17);
            this.label21.TabIndex = 60;
            this.label21.Text = "视频监测:";
            // 
            // dtp_build_year
            // 
            this.dtp_build_year.Location = new System.Drawing.Point(101, 382);
            this.dtp_build_year.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtp_build_year.Name = "dtp_build_year";
            this.dtp_build_year.Size = new System.Drawing.Size(215, 23);
            this.dtp_build_year.TabIndex = 59;
            // 
            // tbx_build_unit
            // 
            this.tbx_build_unit.Location = new System.Drawing.Point(439, 339);
            this.tbx_build_unit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_build_unit.Name = "tbx_build_unit";
            this.tbx_build_unit.Size = new System.Drawing.Size(215, 23);
            this.tbx_build_unit.TabIndex = 58;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(364, 345);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 17);
            this.label12.TabIndex = 57;
            this.label12.Text = "修建单位:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(23, 387);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 17);
            this.label20.TabIndex = 55;
            this.label20.Text = "建设时间:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(51, 344);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 17);
            this.label19.TabIndex = 53;
            this.label19.Text = "结构:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(47, 303);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 17);
            this.label17.TabIndex = 51;
            this.label17.Text = "海拔:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(340, 303);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 17);
            this.label18.TabIndex = 47;
            this.label18.Text = "无线电话数量:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 260);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 17);
            this.label14.TabIndex = 42;
            this.label14.Text = "罗盘仪数量:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(340, 260);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 17);
            this.label15.TabIndex = 39;
            this.label15.Text = "有线电话数量:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 17);
            this.label10.TabIndex = 38;
            this.label10.Text = "望远镜数量:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(352, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 17);
            this.label13.TabIndex = 35;
            this.label13.Text = "对讲机数量:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 17);
            this.label8.TabIndex = 34;
            this.label8.Text = "类型:";
            // 
            // cbx_status
            // 
            this.cbx_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_status.FormattingEnabled = true;
            this.cbx_status.Location = new System.Drawing.Point(439, 57);
            this.cbx_status.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_status.Name = "cbx_status";
            this.cbx_status.Size = new System.Drawing.Size(215, 25);
            this.cbx_status.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(388, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 31;
            this.label11.Text = "状态:";
            // 
            // cbx_type
            // 
            this.cbx_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_type.FormattingEnabled = true;
            this.cbx_type.Location = new System.Drawing.Point(101, 57);
            this.cbx_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_type.Name = "cbx_type";
            this.cbx_type.Size = new System.Drawing.Size(215, 25);
            this.cbx_type.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "瞭望覆盖率:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(364, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "建筑面积:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "瞭望森林面积:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "瞭望面积:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "电话:";
            // 
            // tbx_manager
            // 
            this.tbx_manager.Location = new System.Drawing.Point(101, 97);
            this.tbx_manager.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_manager.Name = "tbx_manager";
            this.tbx_manager.Size = new System.Drawing.Size(215, 23);
            this.tbx_manager.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "管理员:";
            // 
            // cbx_shape
            // 
            this.cbx_shape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_shape.FormattingEnabled = true;
            this.cbx_shape.Location = new System.Drawing.Point(439, 18);
            this.cbx_shape.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_shape.Name = "cbx_shape";
            this.cbx_shape.Size = new System.Drawing.Size(215, 25);
            this.cbx_shape.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "几何形状:";
            // 
            // tbx_name
            // 
            this.tbx_name.Location = new System.Drawing.Point(101, 18);
            this.tbx_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(215, 23);
            this.tbx_name.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "名称:";
            // 
            // tbx_look_area
            // 
            this.tbx_look_area.Location = new System.Drawing.Point(101, 134);
            this.tbx_look_area.Name = "tbx_look_area";
            this.tbx_look_area.Size = new System.Drawing.Size(215, 23);
            this.tbx_look_area.TabIndex = 64;
            // 
            // tbx_look_forest_area
            // 
            this.tbx_look_forest_area.Location = new System.Drawing.Point(439, 134);
            this.tbx_look_forest_area.Name = "tbx_look_forest_area";
            this.tbx_look_forest_area.Size = new System.Drawing.Size(215, 23);
            this.tbx_look_forest_area.TabIndex = 0;
            // 
            // tbx_look_coverage
            // 
            this.tbx_look_coverage.Location = new System.Drawing.Point(101, 172);
            this.tbx_look_coverage.Name = "tbx_look_coverage";
            this.tbx_look_coverage.Size = new System.Drawing.Size(215, 23);
            this.tbx_look_coverage.TabIndex = 0;
            // 
            // tbx_c_area
            // 
            this.tbx_c_area.Location = new System.Drawing.Point(439, 172);
            this.tbx_c_area.Name = "tbx_c_area";
            this.tbx_c_area.Size = new System.Drawing.Size(215, 23);
            this.tbx_c_area.TabIndex = 65;
            // 
            // tbx_telescope
            // 
            this.tbx_telescope.Location = new System.Drawing.Point(101, 211);
            this.tbx_telescope.Name = "tbx_telescope";
            this.tbx_telescope.Size = new System.Drawing.Size(215, 23);
            this.tbx_telescope.TabIndex = 0;
            // 
            // tbx_interphone
            // 
            this.tbx_interphone.Location = new System.Drawing.Point(439, 211);
            this.tbx_interphone.Name = "tbx_interphone";
            this.tbx_interphone.Size = new System.Drawing.Size(215, 23);
            this.tbx_interphone.TabIndex = 66;
            // 
            // tbx_compass_instrument
            // 
            this.tbx_compass_instrument.Location = new System.Drawing.Point(101, 255);
            this.tbx_compass_instrument.Name = "tbx_compass_instrument";
            this.tbx_compass_instrument.Size = new System.Drawing.Size(215, 23);
            this.tbx_compass_instrument.TabIndex = 67;
            // 
            // tbx_telephone
            // 
            this.tbx_telephone.Location = new System.Drawing.Point(439, 255);
            this.tbx_telephone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_telephone.Name = "tbx_telephone";
            this.tbx_telephone.Size = new System.Drawing.Size(215, 23);
            this.tbx_telephone.TabIndex = 63;
            // 
            // tbx_phone
            // 
            this.tbx_phone.Location = new System.Drawing.Point(439, 97);
            this.tbx_phone.Name = "tbx_phone";
            this.tbx_phone.Size = new System.Drawing.Size(215, 23);
            this.tbx_phone.TabIndex = 0;
            // 
            // tbx_elevation
            // 
            this.tbx_elevation.Location = new System.Drawing.Point(101, 298);
            this.tbx_elevation.Name = "tbx_elevation";
            this.tbx_elevation.Size = new System.Drawing.Size(215, 23);
            this.tbx_elevation.TabIndex = 0;
            // 
            // tbx_radio
            // 
            this.tbx_radio.Location = new System.Drawing.Point(439, 298);
            this.tbx_radio.Name = "tbx_radio";
            this.tbx_radio.Size = new System.Drawing.Size(215, 23);
            this.tbx_radio.TabIndex = 0;
            // 
            // tabPage_note
            // 
            this.tabPage_note.Controls.Add(this.tbx_note);
            this.tabPage_note.Location = new System.Drawing.Point(4, 26);
            this.tabPage_note.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_note.Name = "tabPage_note";
            this.tabPage_note.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_note.Size = new System.Drawing.Size(734, 419);
            this.tabPage_note.TabIndex = 3;
            this.tabPage_note.Text = "说明";
            this.tabPage_note.UseVisualStyleBackColor = true;
            // 
            // tbx_note
            // 
            this.tbx_note.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_note.Location = new System.Drawing.Point(3, 4);
            this.tbx_note.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_note.Multiline = true;
            this.tbx_note.Name = "tbx_note";
            this.tbx_note.Size = new System.Drawing.Size(728, 411);
            this.tbx_note.TabIndex = 13;
            // 
            // tabPage_mediaInfo
            // 
            this.tabPage_mediaInfo.Controls.Add(this.mediaControl1);
            this.tabPage_mediaInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPage_mediaInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_mediaInfo.Name = "tabPage_mediaInfo";
            this.tabPage_mediaInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_mediaInfo.Size = new System.Drawing.Size(734, 419);
            this.tabPage_mediaInfo.TabIndex = 1;
            this.tabPage_mediaInfo.Text = "多媒体文件";
            this.tabPage_mediaInfo.UseVisualStyleBackColor = true;
            // 
            // mediaControl1
            // 
            this.mediaControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaControl1.Location = new System.Drawing.Point(3, 4);
            this.mediaControl1.Name = "mediaControl1";
            this.mediaControl1.Size = new System.Drawing.Size(728, 411);
            this.mediaControl1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(625, 490);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(513, 490);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 35);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormWatchTower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 558);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormWatchTower";
            this.Text = "新增瞭望台";
            this.Load += new System.EventHandler(this.FormWatchTower_Load);
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

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_location;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.CoordinatesInputControl coordinatesInputControl1;
        private Controls.PACControl1 pacControl11;
        private System.Windows.Forms.TabPage tabPage_baseInfo;
        private System.Windows.Forms.ComboBox cbx_status;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbx_type;
        private System.Windows.Forms.Label label9;
        private Controls.NTextBox tbx_look_coverage;
        private Controls.NTextBox tbx_c_area;
        private System.Windows.Forms.Label label7;
        private Controls.NTextBox tbx_look_forest_area;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Controls.NTextBox tbx_phone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_manager;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_shape;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage_mediaInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private Controls.NTextBox tbx_look_area;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private Controls.NTextBox tbx_telescope;
        private Controls.NTextBox tbx_interphone;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private Controls.NTextBox tbx_compass_instrument;
        private Controls.NTextBox tbx_telephone;
        private System.Windows.Forms.Label label15;
        private Controls.NTextBox tbx_radio;
        private System.Windows.Forms.Label label18;
        private Controls.NTextBox tbx_elevation;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tabPage_note;
        private System.Windows.Forms.TextBox tbx_note;
        private System.Windows.Forms.TextBox tbx_build_unit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtp_build_year;
        private System.Windows.Forms.TextBox tbx_video_surveillance;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbx_structure;
        private Controls.MediaControl mediaControl1;
    }
}