namespace FFireManage.FireForestBelt
{
    partial class FormFireForestBelt
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
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbx_mamagement_unit = new System.Windows.Forms.TextBox();
            this.tbx_mamager = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_build_addr = new System.Windows.Forms.ComboBox();
            this.tbx_tree_type = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_build_unit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_row_spacing = new System.Windows.Forms.TextBox();
            this.tbx_stop_addr = new System.Windows.Forms.TextBox();
            this.tbx_start_addr = new System.Windows.Forms.TextBox();
            this.dtp_build_year = new System.Windows.Forms.DateTimePicker();
            this.tbx_belt_len = new FFireManage.Controls.NTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbx_phone = new FFireManage.Controls.NTextBox();
            this.tbx_belt_width = new FFireManage.Controls.NTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbx_status = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbx_type = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(596, 353);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage_location
            // 
            this.tabPage_location.Controls.Add(this.groupBox1);
            this.tabPage_location.Controls.Add(this.pacControl11);
            this.tabPage_location.Location = new System.Drawing.Point(4, 26);
            this.tabPage_location.Name = "tabPage_location";
            this.tabPage_location.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_location.Size = new System.Drawing.Size(588, 323);
            this.tabPage_location.TabIndex = 2;
            this.tabPage_location.Text = "位置信息";
            this.tabPage_location.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.coordinatesInputControl1);
            this.groupBox1.Location = new System.Drawing.Point(36, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 165);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "经纬度坐标";
            // 
            // coordinatesInputControl1
            // 
            this.coordinatesInputControl1.Latitude = 0D;
            this.coordinatesInputControl1.Location = new System.Drawing.Point(6, 14);
            this.coordinatesInputControl1.Longitude = 0D;
            this.coordinatesInputControl1.MaximumSize = new System.Drawing.Size(300, 140);
            this.coordinatesInputControl1.MinimumSize = new System.Drawing.Size(300, 140);
            this.coordinatesInputControl1.Name = "coordinatesInputControl1";
            this.coordinatesInputControl1.Size = new System.Drawing.Size(300, 140);
            this.coordinatesInputControl1.TabIndex = 0;
            // 
            // pacControl11
            // 
            this.pacControl11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pacControl11.Location = new System.Drawing.Point(36, 202);
            this.pacControl11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pacControl11.Name = "pacControl11";
            this.pacControl11.Size = new System.Drawing.Size(529, 38);
            this.pacControl11.TabIndex = 11;
            // 
            // tabPage_baseInfo
            // 
            this.tabPage_baseInfo.AutoScroll = true;
            this.tabPage_baseInfo.Controls.Add(this.label13);
            this.tabPage_baseInfo.Controls.Add(this.label12);
            this.tabPage_baseInfo.Controls.Add(this.tbx_mamagement_unit);
            this.tabPage_baseInfo.Controls.Add(this.tbx_mamager);
            this.tabPage_baseInfo.Controls.Add(this.label2);
            this.tabPage_baseInfo.Controls.Add(this.cbx_build_addr);
            this.tabPage_baseInfo.Controls.Add(this.tbx_tree_type);
            this.tabPage_baseInfo.Controls.Add(this.label4);
            this.tabPage_baseInfo.Controls.Add(this.cbx_build_unit);
            this.tabPage_baseInfo.Controls.Add(this.label3);
            this.tabPage_baseInfo.Controls.Add(this.tbx_row_spacing);
            this.tabPage_baseInfo.Controls.Add(this.tbx_stop_addr);
            this.tabPage_baseInfo.Controls.Add(this.tbx_start_addr);
            this.tabPage_baseInfo.Controls.Add(this.dtp_build_year);
            this.tabPage_baseInfo.Controls.Add(this.tbx_belt_len);
            this.tabPage_baseInfo.Controls.Add(this.label17);
            this.tabPage_baseInfo.Controls.Add(this.tbx_phone);
            this.tabPage_baseInfo.Controls.Add(this.tbx_belt_width);
            this.tabPage_baseInfo.Controls.Add(this.label18);
            this.tabPage_baseInfo.Controls.Add(this.label10);
            this.tabPage_baseInfo.Controls.Add(this.label8);
            this.tabPage_baseInfo.Controls.Add(this.cbx_status);
            this.tabPage_baseInfo.Controls.Add(this.label11);
            this.tabPage_baseInfo.Controls.Add(this.cbx_type);
            this.tabPage_baseInfo.Controls.Add(this.label9);
            this.tabPage_baseInfo.Controls.Add(this.label7);
            this.tabPage_baseInfo.Controls.Add(this.label5);
            this.tabPage_baseInfo.Controls.Add(this.label6);
            this.tabPage_baseInfo.Controls.Add(this.tbx_name);
            this.tabPage_baseInfo.Controls.Add(this.label1);
            this.tabPage_baseInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPage_baseInfo.Name = "tabPage_baseInfo";
            this.tabPage_baseInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_baseInfo.Size = new System.Drawing.Size(588, 323);
            this.tabPage_baseInfo.TabIndex = 0;
            this.tabPage_baseInfo.Text = "基本信息";
            this.tabPage_baseInfo.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 232);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 17);
            this.label13.TabIndex = 79;
            this.label13.Text = "管理单位:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 17);
            this.label12.TabIndex = 78;
            this.label12.Text = "管理员电话:";
            // 
            // tbx_mamagement_unit
            // 
            this.tbx_mamagement_unit.AccessibleName = "mamagement_unit";
            this.tbx_mamagement_unit.Location = new System.Drawing.Point(88, 229);
            this.tbx_mamagement_unit.Name = "tbx_mamagement_unit";
            this.tbx_mamagement_unit.Size = new System.Drawing.Size(185, 23);
            this.tbx_mamagement_unit.TabIndex = 77;
            // 
            // tbx_mamager
            // 
            this.tbx_mamager.AccessibleDescription = "length:^.{0,7}$:{0}1~8";
            this.tbx_mamager.AccessibleName = "manager";
            this.tbx_mamager.Location = new System.Drawing.Point(377, 18);
            this.tbx_mamager.Name = "tbx_mamager";
            this.tbx_mamager.Size = new System.Drawing.Size(185, 23);
            this.tbx_mamager.TabIndex = 77;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 76;
            this.label2.Text = "管理员:";
            // 
            // cbx_build_addr
            // 
            this.cbx_build_addr.AccessibleName = "build_addr";
            this.cbx_build_addr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_build_addr.Location = new System.Drawing.Point(377, 138);
            this.cbx_build_addr.Name = "cbx_build_addr";
            this.cbx_build_addr.Size = new System.Drawing.Size(185, 25);
            this.cbx_build_addr.TabIndex = 75;
            // 
            // tbx_tree_type
            // 
            this.tbx_tree_type.AccessibleDescription = "length:^.{0,49}$:{0}1~50";
            this.tbx_tree_type.AccessibleName = "tree_type";
            this.tbx_tree_type.Location = new System.Drawing.Point(87, 109);
            this.tbx_tree_type.Name = "tbx_tree_type";
            this.tbx_tree_type.Size = new System.Drawing.Size(185, 23);
            this.tbx_tree_type.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 73;
            this.label4.Text = "树种:";
            // 
            // cbx_build_unit
            // 
            this.cbx_build_unit.AccessibleName = "build_unit";
            this.cbx_build_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_build_unit.FormattingEnabled = true;
            this.cbx_build_unit.Location = new System.Drawing.Point(377, 78);
            this.cbx_build_unit.Name = "cbx_build_unit";
            this.cbx_build_unit.Size = new System.Drawing.Size(185, 25);
            this.cbx_build_unit.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 71;
            this.label3.Text = "营造单位:";
            // 
            // tbx_row_spacing
            // 
            this.tbx_row_spacing.AccessibleDescription = "length:^.{0,49}$:{0}1~50";
            this.tbx_row_spacing.AccessibleName = "row_spacing";
            this.tbx_row_spacing.Location = new System.Drawing.Point(377, 169);
            this.tbx_row_spacing.Name = "tbx_row_spacing";
            this.tbx_row_spacing.Size = new System.Drawing.Size(185, 23);
            this.tbx_row_spacing.TabIndex = 67;
            // 
            // tbx_stop_addr
            // 
            this.tbx_stop_addr.AccessibleDescription = "length:^.{0,49}$:{0}1~50";
            this.tbx_stop_addr.AccessibleName = "stop_addr";
            this.tbx_stop_addr.Location = new System.Drawing.Point(87, 138);
            this.tbx_stop_addr.Name = "tbx_stop_addr";
            this.tbx_stop_addr.Size = new System.Drawing.Size(185, 23);
            this.tbx_stop_addr.TabIndex = 65;
            // 
            // tbx_start_addr
            // 
            this.tbx_start_addr.AccessibleDescription = "length:^.{0,49}$:{0}1~50";
            this.tbx_start_addr.AccessibleName = "start_addr";
            this.tbx_start_addr.Location = new System.Drawing.Point(377, 109);
            this.tbx_start_addr.Name = "tbx_start_addr";
            this.tbx_start_addr.Size = new System.Drawing.Size(185, 23);
            this.tbx_start_addr.TabIndex = 64;
            // 
            // dtp_build_year
            // 
            this.dtp_build_year.AccessibleName = "build_year";
            this.dtp_build_year.Location = new System.Drawing.Point(87, 169);
            this.dtp_build_year.Name = "dtp_build_year";
            this.dtp_build_year.Size = new System.Drawing.Size(185, 23);
            this.dtp_build_year.TabIndex = 59;
            // 
            // tbx_belt_len
            // 
            this.tbx_belt_len.AccessibleDescription = "length:^.{0,7}$:{0}1~8";
            this.tbx_belt_len.AccessibleName = "belt_len";
            this.tbx_belt_len.Location = new System.Drawing.Point(88, 198);
            this.tbx_belt_len.MaxLength = 8;
            this.tbx_belt_len.Name = "tbx_belt_len";
            this.tbx_belt_len.Size = new System.Drawing.Size(185, 23);
            this.tbx_belt_len.TabIndex = 52;
            this.tbx_belt_len.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(45, 203);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 17);
            this.label17.TabIndex = 51;
            this.label17.Text = "长度:";
            // 
            // tbx_phone
            // 
            this.tbx_phone.AccessibleDescription = "length:^.{0,29}$:{0}1~30";
            this.tbx_phone.AccessibleName = "phone";
            this.tbx_phone.Location = new System.Drawing.Point(87, 47);
            this.tbx_phone.Name = "tbx_phone";
            this.tbx_phone.Size = new System.Drawing.Size(185, 23);
            this.tbx_phone.TabIndex = 48;
            // 
            // tbx_belt_width
            // 
            this.tbx_belt_width.AccessibleDescription = "length:^.{0,7}$:{0}1~8";
            this.tbx_belt_width.AccessibleName = "belt_width";
            this.tbx_belt_width.Location = new System.Drawing.Point(377, 198);
            this.tbx_belt_width.MaxLength = 8;
            this.tbx_belt_width.Name = "tbx_belt_width";
            this.tbx_belt_width.Size = new System.Drawing.Size(185, 23);
            this.tbx_belt_width.TabIndex = 48;
            this.tbx_belt_width.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(333, 203);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 17);
            this.label18.TabIndex = 47;
            this.label18.Text = "宽度:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(321, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 17);
            this.label10.TabIndex = 38;
            this.label10.Text = "株行距:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(334, 51);
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
            this.cbx_status.Location = new System.Drawing.Point(87, 78);
            this.cbx_status.Name = "cbx_status";
            this.cbx_status.Size = new System.Drawing.Size(185, 25);
            this.cbx_status.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 31;
            this.label11.Text = "状态:";
            // 
            // cbx_type
            // 
            this.cbx_type.AccessibleName = "type";
            this.cbx_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_type.FormattingEnabled = true;
            this.cbx_type.Location = new System.Drawing.Point(377, 47);
            this.cbx_type.Name = "cbx_type";
            this.cbx_type.Size = new System.Drawing.Size(185, 25);
            this.cbx_type.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(310, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "营造位置:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "营造年份:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "终止地点:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(310, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "起始地点:";
            // 
            // tbx_name
            // 
            this.tbx_name.AccessibleDescription = "required;length:^.{0,49}$:{0}1~50";
            this.tbx_name.AccessibleName = "name";
            this.tbx_name.Location = new System.Drawing.Point(87, 18);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(185, 23);
            this.tbx_name.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "名称:";
            // 
            // tabPage_note
            // 
            this.tabPage_note.Controls.Add(this.tbx_note);
            this.tabPage_note.Location = new System.Drawing.Point(4, 26);
            this.tabPage_note.Name = "tabPage_note";
            this.tabPage_note.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_note.Size = new System.Drawing.Size(588, 323);
            this.tabPage_note.TabIndex = 3;
            this.tabPage_note.Text = "说明";
            this.tabPage_note.UseVisualStyleBackColor = true;
            // 
            // tbx_note
            // 
            this.tbx_note.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_note.Location = new System.Drawing.Point(3, 3);
            this.tbx_note.Multiline = true;
            this.tbx_note.Name = "tbx_note";
            this.tbx_note.Size = new System.Drawing.Size(582, 317);
            this.tbx_note.TabIndex = 13;
            // 
            // tabPage_mediaInfo
            // 
            this.tabPage_mediaInfo.Controls.Add(this.mediaControl1);
            this.tabPage_mediaInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPage_mediaInfo.Name = "tabPage_mediaInfo";
            this.tabPage_mediaInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_mediaInfo.Size = new System.Drawing.Size(588, 323);
            this.tabPage_mediaInfo.TabIndex = 1;
            this.tabPage_mediaInfo.Text = "多媒体文件";
            this.tabPage_mediaInfo.UseVisualStyleBackColor = true;
            // 
            // mediaControl1
            // 
            this.mediaControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaControl1.Location = new System.Drawing.Point(3, 3);
            this.mediaControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mediaControl1.MediaFiles = null;
            this.mediaControl1.Name = "mediaControl1";
            this.mediaControl1.Size = new System.Drawing.Size(582, 317);
            this.mediaControl1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(467, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(371, 380);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormFireForestBelt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 418);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormFireForestBelt";
            this.Text = "新增防火林带";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormFireForestBelt_FormClosed);
            this.Load += new System.EventHandler(this.FormFireForestBelt_Load);
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
        private System.Windows.Forms.TextBox tbx_stop_addr;
        private System.Windows.Forms.TextBox tbx_start_addr;
        private Controls.NTextBox tbx_belt_len;
        private System.Windows.Forms.Label label17;
        private Controls.NTextBox tbx_belt_width;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbx_status;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbx_type;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage_note;
        private System.Windows.Forms.TextBox tbx_note;
        private System.Windows.Forms.TabPage tabPage_mediaInfo;
        private System.Windows.Forms.ComboBox cbx_build_unit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_tree_type;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_build_addr;
        private System.Windows.Forms.TextBox tbx_row_spacing;
        private System.Windows.Forms.DateTimePicker dtp_build_year;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private Controls.MediaControl mediaControl1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbx_mamager;
        private System.Windows.Forms.Label label2;
        private Controls.NTextBox tbx_phone;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbx_mamagement_unit;
    }
}