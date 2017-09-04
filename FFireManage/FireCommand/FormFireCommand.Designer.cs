namespace FFireManage.FireCommand
{
    partial class FormFireCommand
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
            this.label12 = new System.Windows.Forms.Label();
            this.cbx_status = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbx_institutions = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbx_type = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbx_phone = new FFireManage.Controls.NTextBox();
            this.tbx_num_people = new FFireManage.Controls.NTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbx_commander_phone = new FFireManage.Controls.NTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_commander = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_dir_phone = new FFireManage.Controls.NTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_director = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_level = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_note = new System.Windows.Forms.TextBox();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_mediaInfo = new System.Windows.Forms.TabPage();
            this.mediaControl1 = new FFireManage.Controls.MediaControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbx_address = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage_location.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_baseInfo.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabPage_mediaInfo);
            this.tabControl1.Location = new System.Drawing.Point(3, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(633, 387);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_location
            // 
            this.tabPage_location.Controls.Add(this.groupBox1);
            this.tabPage_location.Controls.Add(this.pacControl11);
            this.tabPage_location.Location = new System.Drawing.Point(4, 26);
            this.tabPage_location.Name = "tabPage_location";
            this.tabPage_location.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_location.Size = new System.Drawing.Size(625, 357);
            this.tabPage_location.TabIndex = 2;
            this.tabPage_location.Text = "位置信息";
            this.tabPage_location.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.coordinatesInputControl1);
            this.groupBox1.Location = new System.Drawing.Point(47, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 165);
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
            this.pacControl11.Location = new System.Drawing.Point(47, 202);
            this.pacControl11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pacControl11.Name = "pacControl11";
            this.pacControl11.Size = new System.Drawing.Size(523, 38);
            this.pacControl11.TabIndex = 11;
            // 
            // tabPage_baseInfo
            // 
            this.tabPage_baseInfo.Controls.Add(this.tbx_address);
            this.tabPage_baseInfo.Controls.Add(this.label13);
            this.tabPage_baseInfo.Controls.Add(this.label12);
            this.tabPage_baseInfo.Controls.Add(this.cbx_status);
            this.tabPage_baseInfo.Controls.Add(this.label11);
            this.tabPage_baseInfo.Controls.Add(this.cbx_institutions);
            this.tabPage_baseInfo.Controls.Add(this.label10);
            this.tabPage_baseInfo.Controls.Add(this.cbx_type);
            this.tabPage_baseInfo.Controls.Add(this.label9);
            this.tabPage_baseInfo.Controls.Add(this.tbx_phone);
            this.tabPage_baseInfo.Controls.Add(this.tbx_num_people);
            this.tabPage_baseInfo.Controls.Add(this.label7);
            this.tabPage_baseInfo.Controls.Add(this.label8);
            this.tabPage_baseInfo.Controls.Add(this.tbx_commander_phone);
            this.tabPage_baseInfo.Controls.Add(this.label5);
            this.tabPage_baseInfo.Controls.Add(this.tbx_commander);
            this.tabPage_baseInfo.Controls.Add(this.label6);
            this.tabPage_baseInfo.Controls.Add(this.tbx_dir_phone);
            this.tabPage_baseInfo.Controls.Add(this.label4);
            this.tabPage_baseInfo.Controls.Add(this.tbx_director);
            this.tabPage_baseInfo.Controls.Add(this.label3);
            this.tabPage_baseInfo.Controls.Add(this.cbx_level);
            this.tabPage_baseInfo.Controls.Add(this.label2);
            this.tabPage_baseInfo.Controls.Add(this.tbx_note);
            this.tabPage_baseInfo.Controls.Add(this.tbx_name);
            this.tabPage_baseInfo.Controls.Add(this.label1);
            this.tabPage_baseInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPage_baseInfo.Name = "tabPage_baseInfo";
            this.tabPage_baseInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_baseInfo.Size = new System.Drawing.Size(625, 357);
            this.tabPage_baseInfo.TabIndex = 0;
            this.tabPage_baseInfo.Text = "基本信息";
            this.tabPage_baseInfo.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(44, 263);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 17);
            this.label12.TabIndex = 33;
            this.label12.Text = "说明:";
            // 
            // cbx_status
            // 
            this.cbx_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_status.FormattingEnabled = true;
            this.cbx_status.Location = new System.Drawing.Point(376, 218);
            this.cbx_status.Name = "cbx_status";
            this.cbx_status.Size = new System.Drawing.Size(185, 25);
            this.cbx_status.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(333, 221);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 31;
            this.label11.Text = "状态:";
            // 
            // cbx_institutions
            // 
            this.cbx_institutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_institutions.FormattingEnabled = true;
            this.cbx_institutions.Location = new System.Drawing.Point(376, 175);
            this.cbx_institutions.Name = "cbx_institutions";
            this.cbx_institutions.Size = new System.Drawing.Size(185, 25);
            this.cbx_institutions.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(309, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 29;
            this.label10.Text = "机构编制:";
            // 
            // cbx_type
            // 
            this.cbx_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_type.FormattingEnabled = true;
            this.cbx_type.Location = new System.Drawing.Point(87, 175);
            this.cbx_type.Name = "cbx_type";
            this.cbx_type.Size = new System.Drawing.Size(185, 25);
            this.cbx_type.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "类型:";
            // 
            // tbx_phone
            // 
            this.tbx_phone.Location = new System.Drawing.Point(87, 133);
            this.tbx_phone.Name = "tbx_phone";
            this.tbx_phone.Size = new System.Drawing.Size(185, 23);
            this.tbx_phone.TabIndex = 26;
            // 
            // tbx_num_people
            // 
            this.tbx_num_people.Location = new System.Drawing.Point(376, 134);
            this.tbx_num_people.Name = "tbx_num_people";
            this.tbx_num_people.Size = new System.Drawing.Size(185, 23);
            this.tbx_num_people.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "机构人数:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "值班电话:";
            // 
            // tbx_commander_phone
            // 
            this.tbx_commander_phone.Location = new System.Drawing.Point(376, 96);
            this.tbx_commander_phone.Name = "tbx_commander_phone";
            this.tbx_commander_phone.Size = new System.Drawing.Size(185, 23);
            this.tbx_commander_phone.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "指挥长电话:";
            // 
            // tbx_commander
            // 
            this.tbx_commander.Location = new System.Drawing.Point(87, 96);
            this.tbx_commander.Name = "tbx_commander";
            this.tbx_commander.Size = new System.Drawing.Size(185, 23);
            this.tbx_commander.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "指挥长:";
            // 
            // tbx_dir_phone
            // 
            this.tbx_dir_phone.Location = new System.Drawing.Point(376, 57);
            this.tbx_dir_phone.Name = "tbx_dir_phone";
            this.tbx_dir_phone.Size = new System.Drawing.Size(185, 23);
            this.tbx_dir_phone.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "主任电话:";
            // 
            // tbx_director
            // 
            this.tbx_director.Location = new System.Drawing.Point(87, 57);
            this.tbx_director.Name = "tbx_director";
            this.tbx_director.Size = new System.Drawing.Size(185, 23);
            this.tbx_director.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "办公室主任:";
            // 
            // cbx_level
            // 
            this.cbx_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_level.FormattingEnabled = true;
            this.cbx_level.Location = new System.Drawing.Point(87, 221);
            this.cbx_level.Name = "cbx_level";
            this.cbx_level.Size = new System.Drawing.Size(185, 25);
            this.cbx_level.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "级别:";
            // 
            // tbx_note
            // 
            this.tbx_note.Location = new System.Drawing.Point(85, 263);
            this.tbx_note.Multiline = true;
            this.tbx_note.Name = "tbx_note";
            this.tbx_note.Size = new System.Drawing.Size(474, 76);
            this.tbx_note.TabIndex = 12;
            // 
            // tbx_name
            // 
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
            // tabPage_mediaInfo
            // 
            this.tabPage_mediaInfo.Controls.Add(this.mediaControl1);
            this.tabPage_mediaInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPage_mediaInfo.Name = "tabPage_mediaInfo";
            this.tabPage_mediaInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_mediaInfo.Size = new System.Drawing.Size(625, 357);
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
            this.mediaControl1.Size = new System.Drawing.Size(619, 351);
            this.mediaControl1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(543, 405);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(447, 405);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbx_address
            // 
            this.tbx_address.Location = new System.Drawing.Point(374, 18);
            this.tbx_address.Name = "tbx_address";
            this.tbx_address.Size = new System.Drawing.Size(185, 23);
            this.tbx_address.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(333, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 17);
            this.label13.TabIndex = 34;
            this.label13.Text = "地址:";
            // 
            // FormFireCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 445);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormFireCommand";
            this.Text = "新增森林防火指挥部";
            this.Load += new System.EventHandler(this.FormFireCommand_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_location.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage_baseInfo.ResumeLayout(false);
            this.tabPage_baseInfo.PerformLayout();
            this.tabPage_mediaInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_baseInfo;
        private System.Windows.Forms.TabPage tabPage_mediaInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private Controls.NTextBox tbx_dir_phone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_director;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_level;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.Label label1;
        private Controls.NTextBox tbx_commander_phone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_commander;
        private System.Windows.Forms.Label label6;
        private Controls.NTextBox tbx_phone;
        private Controls.NTextBox tbx_num_people;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbx_institutions;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbx_type;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage_location;
        private Controls.CoordinatesInputControl coordinatesInputControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.PACControl1 pacControl11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbx_status;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbx_note;
        private Controls.MediaControl mediaControl1;
        private System.Windows.Forms.TextBox tbx_address;
        private System.Windows.Forms.Label label13;
    }
}