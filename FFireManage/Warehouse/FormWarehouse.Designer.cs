namespace FFireManage.FireWarehouse
{
    partial class FormWarehouse
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
            this.ntx_typeid = new FFireManage.Controls.NTextBox();
            this.ntx_build_area = new FFireManage.Controls.NTextBox();
            this.ntx_quantity = new FFireManage.Controls.NTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbx_user_id = new FFireManage.Controls.NTextBox();
            this.txt_mat_id = new System.Windows.Forms.TextBox();
            this.txt_reserve_type = new System.Windows.Forms.TextBox();
            this.txt_director = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_management_unit = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmb_type = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_build_year = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_phone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbx_manager = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_address = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbx_status = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
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
            this.tabControl1.Size = new System.Drawing.Size(730, 475);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage_location
            // 
            this.tabPage_location.Controls.Add(this.groupBox1);
            this.tabPage_location.Controls.Add(this.pacControl11);
            this.tabPage_location.Location = new System.Drawing.Point(4, 26);
            this.tabPage_location.Name = "tabPage_location";
            this.tabPage_location.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_location.Size = new System.Drawing.Size(722, 445);
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
            this.tabPage_baseInfo.Controls.Add(this.ntx_typeid);
            this.tabPage_baseInfo.Controls.Add(this.ntx_build_area);
            this.tabPage_baseInfo.Controls.Add(this.ntx_quantity);
            this.tabPage_baseInfo.Controls.Add(this.label15);
            this.tabPage_baseInfo.Controls.Add(this.tbx_user_id);
            this.tabPage_baseInfo.Controls.Add(this.txt_mat_id);
            this.tabPage_baseInfo.Controls.Add(this.txt_reserve_type);
            this.tabPage_baseInfo.Controls.Add(this.txt_director);
            this.tabPage_baseInfo.Controls.Add(this.label14);
            this.tabPage_baseInfo.Controls.Add(this.txt_management_unit);
            this.tabPage_baseInfo.Controls.Add(this.label13);
            this.tabPage_baseInfo.Controls.Add(this.cmb_type);
            this.tabPage_baseInfo.Controls.Add(this.label10);
            this.tabPage_baseInfo.Controls.Add(this.label9);
            this.tabPage_baseInfo.Controls.Add(this.label7);
            this.tabPage_baseInfo.Controls.Add(this.label6);
            this.tabPage_baseInfo.Controls.Add(this.label5);
            this.tabPage_baseInfo.Controls.Add(this.label4);
            this.tabPage_baseInfo.Controls.Add(this.dtp_build_year);
            this.tabPage_baseInfo.Controls.Add(this.label3);
            this.tabPage_baseInfo.Controls.Add(this.tbx_phone);
            this.tabPage_baseInfo.Controls.Add(this.label8);
            this.tabPage_baseInfo.Controls.Add(this.tbx_manager);
            this.tabPage_baseInfo.Controls.Add(this.label2);
            this.tabPage_baseInfo.Controls.Add(this.tbx_address);
            this.tabPage_baseInfo.Controls.Add(this.label12);
            this.tabPage_baseInfo.Controls.Add(this.cbx_status);
            this.tabPage_baseInfo.Controls.Add(this.label11);
            this.tabPage_baseInfo.Controls.Add(this.tbx_name);
            this.tabPage_baseInfo.Controls.Add(this.label1);
            this.tabPage_baseInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPage_baseInfo.Name = "tabPage_baseInfo";
            this.tabPage_baseInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_baseInfo.Size = new System.Drawing.Size(722, 445);
            this.tabPage_baseInfo.TabIndex = 0;
            this.tabPage_baseInfo.Text = "基本信息";
            this.tabPage_baseInfo.UseVisualStyleBackColor = true;
            // 
            // ntx_typeid
            // 
            this.ntx_typeid.AccessibleName = "typeid";
            this.ntx_typeid.Location = new System.Drawing.Point(425, 110);
            this.ntx_typeid.MaxLength = 4;
            this.ntx_typeid.Name = "ntx_typeid";
            this.ntx_typeid.Size = new System.Drawing.Size(220, 23);
            this.ntx_typeid.TabIndex = 180;
            this.ntx_typeid.Text = "0";
            // 
            // ntx_build_area
            // 
            this.ntx_build_area.AccessibleName = "build_area";
            this.ntx_build_area.Location = new System.Drawing.Point(86, 110);
            this.ntx_build_area.MaxLength = 8;
            this.ntx_build_area.Name = "ntx_build_area";
            this.ntx_build_area.Size = new System.Drawing.Size(220, 23);
            this.ntx_build_area.TabIndex = 179;
            this.ntx_build_area.Text = "0";
            // 
            // ntx_quantity
            // 
            this.ntx_quantity.AccessibleName = "quantity";
            this.ntx_quantity.Location = new System.Drawing.Point(425, 189);
            this.ntx_quantity.MaxLength = 4;
            this.ntx_quantity.Name = "ntx_quantity";
            this.ntx_quantity.Size = new System.Drawing.Size(220, 23);
            this.ntx_quantity.TabIndex = 178;
            this.ntx_quantity.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(357, 189);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 17);
            this.label15.TabIndex = 177;
            this.label15.Text = "物资数量:";
            // 
            // tbx_user_id
            // 
            this.tbx_user_id.AccessibleName = "user_id";
            this.tbx_user_id.Location = new System.Drawing.Point(425, 147);
            this.tbx_user_id.MaxLength = 4;
            this.tbx_user_id.Name = "tbx_user_id";
            this.tbx_user_id.Size = new System.Drawing.Size(220, 23);
            this.tbx_user_id.TabIndex = 176;
            this.tbx_user_id.Text = "0";
            // 
            // txt_mat_id
            // 
            this.txt_mat_id.AccessibleDescription = "length:^.{0,3}$:{0}1~4";
            this.txt_mat_id.AccessibleName = "mat_id";
            this.txt_mat_id.Location = new System.Drawing.Point(87, 147);
            this.txt_mat_id.Name = "txt_mat_id";
            this.txt_mat_id.Size = new System.Drawing.Size(220, 23);
            this.txt_mat_id.TabIndex = 174;
            // 
            // txt_reserve_type
            // 
            this.txt_reserve_type.AccessibleDescription = "length:^.{0,49}$:{0}1~50";
            this.txt_reserve_type.AccessibleName = "reserve_type";
            this.txt_reserve_type.Location = new System.Drawing.Point(85, 188);
            this.txt_reserve_type.Name = "txt_reserve_type";
            this.txt_reserve_type.Size = new System.Drawing.Size(220, 23);
            this.txt_reserve_type.TabIndex = 172;
            // 
            // txt_director
            // 
            this.txt_director.AccessibleDescription = "length:^.{0,49}$:{0}1~50";
            this.txt_director.AccessibleName = "director";
            this.txt_director.Location = new System.Drawing.Point(425, 232);
            this.txt_director.Name = "txt_director";
            this.txt_director.Size = new System.Drawing.Size(220, 23);
            this.txt_director.TabIndex = 171;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(344, 235);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 17);
            this.label14.TabIndex = 170;
            this.label14.Text = "单位负责人:";
            // 
            // txt_management_unit
            // 
            this.txt_management_unit.AccessibleDescription = "required;length:^.{0,29}$:{0}1~30";
            this.txt_management_unit.AccessibleName = "management_unit";
            this.txt_management_unit.Location = new System.Drawing.Point(86, 229);
            this.txt_management_unit.Name = "txt_management_unit";
            this.txt_management_unit.Size = new System.Drawing.Size(220, 23);
            this.txt_management_unit.TabIndex = 169;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 232);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 17);
            this.label13.TabIndex = 168;
            this.label13.Text = "管理单位:";
            // 
            // cmb_type
            // 
            this.cmb_type.AccessibleName = "type";
            this.cmb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_type.FormattingEnabled = true;
            this.cmb_type.Location = new System.Drawing.Point(86, 72);
            this.cmb_type.Name = "cmb_type";
            this.cmb_type.Size = new System.Drawing.Size(220, 25);
            this.cmb_type.TabIndex = 167;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 166;
            this.label10.Text = "建设年度:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(357, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 17);
            this.label9.TabIndex = 165;
            this.label9.Text = "类型编号:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 164;
            this.label7.Text = "所属编号:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 163;
            this.label6.Text = "物资编号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 162;
            this.label5.Text = "面积:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 161;
            this.label4.Text = "储备类型:";
            // 
            // dtp_build_year
            // 
            this.dtp_build_year.AccessibleName = "build_year";
            this.dtp_build_year.Location = new System.Drawing.Point(88, 264);
            this.dtp_build_year.Name = "dtp_build_year";
            this.dtp_build_year.Size = new System.Drawing.Size(220, 23);
            this.dtp_build_year.TabIndex = 160;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 82;
            this.label3.Text = "类型:";
            // 
            // tbx_phone
            // 
            this.tbx_phone.AccessibleDescription = "required;length:^.{0,29}$:{0}1~30";
            this.tbx_phone.AccessibleName = "phone";
            this.tbx_phone.Location = new System.Drawing.Point(425, 41);
            this.tbx_phone.Name = "tbx_phone";
            this.tbx_phone.Size = new System.Drawing.Size(220, 23);
            this.tbx_phone.TabIndex = 81;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(357, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 80;
            this.label8.Text = "值班电话:";
            // 
            // tbx_manager
            // 
            this.tbx_manager.AccessibleDescription = "required;length:^.{0,7}$:{0}1~8";
            this.tbx_manager.AccessibleName = "manager";
            this.tbx_manager.Location = new System.Drawing.Point(87, 41);
            this.tbx_manager.Name = "tbx_manager";
            this.tbx_manager.Size = new System.Drawing.Size(220, 23);
            this.tbx_manager.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 78;
            this.label2.Text = "管理员:";
            // 
            // tbx_address
            // 
            this.tbx_address.AccessibleDescription = "required;length:^.{0,79}$:{0}1~80";
            this.tbx_address.AccessibleName = "address";
            this.tbx_address.Location = new System.Drawing.Point(425, 11);
            this.tbx_address.Name = "tbx_address";
            this.tbx_address.Size = new System.Drawing.Size(220, 23);
            this.tbx_address.TabIndex = 77;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(381, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 17);
            this.label12.TabIndex = 76;
            this.label12.Text = "地址:";
            // 
            // cbx_status
            // 
            this.cbx_status.AccessibleName = "status";
            this.cbx_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_status.FormattingEnabled = true;
            this.cbx_status.Location = new System.Drawing.Point(425, 71);
            this.cbx_status.Name = "cbx_status";
            this.cbx_status.Size = new System.Drawing.Size(220, 25);
            this.cbx_status.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(381, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 31;
            this.label11.Text = "状态:";
            // 
            // tbx_name
            // 
            this.tbx_name.AccessibleDescription = "required;length:^.{0,49}$:{0}1~50";
            this.tbx_name.AccessibleName = "name";
            this.tbx_name.Location = new System.Drawing.Point(87, 11);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(220, 23);
            this.tbx_name.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 14);
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
            this.tabPage_note.Size = new System.Drawing.Size(722, 445);
            this.tabPage_note.TabIndex = 3;
            this.tabPage_note.Text = "说明";
            this.tabPage_note.UseVisualStyleBackColor = true;
            // 
            // tbx_note
            // 
            this.tbx_note.AccessibleName = "note";
            this.tbx_note.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_note.Location = new System.Drawing.Point(3, 3);
            this.tbx_note.Multiline = true;
            this.tbx_note.Name = "tbx_note";
            this.tbx_note.Size = new System.Drawing.Size(716, 439);
            this.tbx_note.TabIndex = 13;
            // 
            // tabPage_mediaInfo
            // 
            this.tabPage_mediaInfo.Controls.Add(this.mediaControl1);
            this.tabPage_mediaInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPage_mediaInfo.Name = "tabPage_mediaInfo";
            this.tabPage_mediaInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_mediaInfo.Size = new System.Drawing.Size(722, 445);
            this.tabPage_mediaInfo.TabIndex = 1;
            this.tabPage_mediaInfo.Text = "多媒体文件";
            this.tabPage_mediaInfo.UseVisualStyleBackColor = true;
            // 
            // mediaControl1
            // 
            this.mediaControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaControl1.Location = new System.Drawing.Point(3, 3);
            this.mediaControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mediaControl1.Name = "mediaControl1";
            this.mediaControl1.Size = new System.Drawing.Size(716, 439);
            this.mediaControl1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(601, 502);
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
            this.btnOK.Location = new System.Drawing.Point(505, 502);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 540);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormWarehouse";
            this.Text = "防火物资储备库";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormWarehouse_FormClosed);
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
        private System.Windows.Forms.ComboBox cbx_status;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage_note;
        private System.Windows.Forms.TextBox tbx_note;
        private System.Windows.Forms.TabPage tabPage_mediaInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private Controls.MediaControl mediaControl1;
        private System.Windows.Forms.TextBox tbx_address;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbx_phone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbx_manager;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_build_year;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_director;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_management_unit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmb_type;
        private System.Windows.Forms.TextBox txt_mat_id;
        private System.Windows.Forms.TextBox txt_reserve_type;
        private Controls.NTextBox tbx_user_id;
        private Controls.NTextBox ntx_quantity;
        private System.Windows.Forms.Label label15;
        private Controls.NTextBox ntx_build_area;
        private Controls.NTextBox ntx_typeid;
    }
}