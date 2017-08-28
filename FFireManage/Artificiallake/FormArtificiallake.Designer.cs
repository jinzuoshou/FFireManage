namespace FFireManage.Artificiallake
{
    partial class FormArtificiallake
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
            this.tbx_phone = new FFireManage.Controls.NTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbx_manager = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbx_trafficCondition = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbx_managementUnit = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbx_storageCapacity = new FFireManage.Controls.NTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_maximumDepth = new FFireManage.Controls.NTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_isTakeWater = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_isCableway = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_volume = new FFireManage.Controls.NTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbx_storageArea = new FFireManage.Controls.NTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbx_status = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbx_shape = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_note = new System.Windows.Forms.TabPage();
            this.tbx_note = new System.Windows.Forms.TextBox();
            this.tabPage_mediaInfo = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.mediaControl1 = new FFireManage.Controls.MediaControl();
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
            this.tabControl1.Size = new System.Drawing.Size(636, 343);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage_location
            // 
            this.tabPage_location.Controls.Add(this.groupBox1);
            this.tabPage_location.Controls.Add(this.pacControl11);
            this.tabPage_location.Location = new System.Drawing.Point(4, 26);
            this.tabPage_location.Name = "tabPage_location";
            this.tabPage_location.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_location.Size = new System.Drawing.Size(628, 313);
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
            this.tabPage_baseInfo.Controls.Add(this.tbx_phone);
            this.tabPage_baseInfo.Controls.Add(this.label14);
            this.tabPage_baseInfo.Controls.Add(this.tbx_manager);
            this.tabPage_baseInfo.Controls.Add(this.label13);
            this.tabPage_baseInfo.Controls.Add(this.tbx_trafficCondition);
            this.tabPage_baseInfo.Controls.Add(this.label12);
            this.tabPage_baseInfo.Controls.Add(this.label10);
            this.tabPage_baseInfo.Controls.Add(this.cbx_managementUnit);
            this.tabPage_baseInfo.Controls.Add(this.label9);
            this.tabPage_baseInfo.Controls.Add(this.label8);
            this.tabPage_baseInfo.Controls.Add(this.tbx_storageCapacity);
            this.tabPage_baseInfo.Controls.Add(this.label6);
            this.tabPage_baseInfo.Controls.Add(this.tbx_maximumDepth);
            this.tabPage_baseInfo.Controls.Add(this.label7);
            this.tabPage_baseInfo.Controls.Add(this.label5);
            this.tabPage_baseInfo.Controls.Add(this.cbx_isTakeWater);
            this.tabPage_baseInfo.Controls.Add(this.label4);
            this.tabPage_baseInfo.Controls.Add(this.cbx_isCableway);
            this.tabPage_baseInfo.Controls.Add(this.label3);
            this.tabPage_baseInfo.Controls.Add(this.tbx_volume);
            this.tabPage_baseInfo.Controls.Add(this.label17);
            this.tabPage_baseInfo.Controls.Add(this.tbx_storageArea);
            this.tabPage_baseInfo.Controls.Add(this.label18);
            this.tabPage_baseInfo.Controls.Add(this.cbx_status);
            this.tabPage_baseInfo.Controls.Add(this.label11);
            this.tabPage_baseInfo.Controls.Add(this.cbx_shape);
            this.tabPage_baseInfo.Controls.Add(this.label2);
            this.tabPage_baseInfo.Controls.Add(this.tbx_name);
            this.tabPage_baseInfo.Controls.Add(this.label1);
            this.tabPage_baseInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPage_baseInfo.Name = "tabPage_baseInfo";
            this.tabPage_baseInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_baseInfo.Size = new System.Drawing.Size(628, 313);
            this.tabPage_baseInfo.TabIndex = 0;
            this.tabPage_baseInfo.Text = "基本信息";
            this.tabPage_baseInfo.UseVisualStyleBackColor = true;
            // 
            // tbx_phone
            // 
            this.tbx_phone.Location = new System.Drawing.Point(383, 128);
            this.tbx_phone.Name = "tbx_phone";
            this.tbx_phone.Size = new System.Drawing.Size(160, 23);
            this.tbx_phone.TabIndex = 89;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(306, 131);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 17);
            this.label14.TabIndex = 88;
            this.label14.Text = "管理员电话:";
            // 
            // tbx_manager
            // 
            this.tbx_manager.Location = new System.Drawing.Point(91, 128);
            this.tbx_manager.Name = "tbx_manager";
            this.tbx_manager.Size = new System.Drawing.Size(160, 23);
            this.tbx_manager.TabIndex = 87;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 17);
            this.label13.TabIndex = 86;
            this.label13.Text = "管理员:";
            // 
            // tbx_trafficCondition
            // 
            this.tbx_trafficCondition.Location = new System.Drawing.Point(383, 249);
            this.tbx_trafficCondition.Name = "tbx_trafficCondition";
            this.tbx_trafficCondition.Size = new System.Drawing.Size(160, 23);
            this.tbx_trafficCondition.TabIndex = 85;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(320, 252);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 17);
            this.label12.TabIndex = 84;
            this.label12.Text = "交通情况:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 252);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 83;
            this.label10.Text = "管理单位:";
            // 
            // cbx_managementUnit
            // 
            this.cbx_managementUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_managementUnit.FormattingEnabled = true;
            this.cbx_managementUnit.Location = new System.Drawing.Point(91, 249);
            this.cbx_managementUnit.Name = "cbx_managementUnit";
            this.cbx_managementUnit.Size = new System.Drawing.Size(160, 25);
            this.cbx_managementUnit.TabIndex = 82;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(549, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 17);
            this.label9.TabIndex = 81;
            this.label9.Text = "(米)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(255, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 80;
            this.label8.Text = "(立方米)";
            // 
            // tbx_storageCapacity
            // 
            this.tbx_storageCapacity.Location = new System.Drawing.Point(92, 207);
            this.tbx_storageCapacity.Name = "tbx_storageCapacity";
            this.tbx_storageCapacity.Size = new System.Drawing.Size(159, 23);
            this.tbx_storageCapacity.TabIndex = 79;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 78;
            this.label6.Text = "蓄水容量:";
            // 
            // tbx_maximumDepth
            // 
            this.tbx_maximumDepth.Location = new System.Drawing.Point(383, 207);
            this.tbx_maximumDepth.Name = "tbx_maximumDepth";
            this.tbx_maximumDepth.Size = new System.Drawing.Size(160, 23);
            this.tbx_maximumDepth.TabIndex = 77;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 76;
            this.label7.Text = "最大深度:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(549, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 75;
            this.label5.Text = "(平方米)";
            // 
            // cbx_isTakeWater
            // 
            this.cbx_isTakeWater.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_isTakeWater.FormattingEnabled = true;
            this.cbx_isTakeWater.Location = new System.Drawing.Point(383, 87);
            this.cbx_isTakeWater.Name = "cbx_isTakeWater";
            this.cbx_isTakeWater.Size = new System.Drawing.Size(160, 25);
            this.cbx_isTakeWater.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 73;
            this.label4.Text = "能否吊桶取水:";
            // 
            // cbx_isRope
            // 
            this.cbx_isCableway.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_isCableway.FormattingEnabled = true;
            this.cbx_isCableway.Location = new System.Drawing.Point(91, 87);
            this.cbx_isCableway.Name = "cbx_isRope";
            this.cbx_isCableway.Size = new System.Drawing.Size(160, 25);
            this.cbx_isCableway.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 71;
            this.label3.Text = "有无电线索道:";
            // 
            // tbx_volume
            // 
            this.tbx_volume.Location = new System.Drawing.Point(92, 167);
            this.tbx_volume.Name = "tbx_volume";
            this.tbx_volume.Size = new System.Drawing.Size(159, 23);
            this.tbx_volume.TabIndex = 52;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(39, 172);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 17);
            this.label17.TabIndex = 51;
            this.label17.Text = "容积量:";
            // 
            // tbx_storageArea
            // 
            this.tbx_storageArea.Location = new System.Drawing.Point(383, 167);
            this.tbx_storageArea.Name = "tbx_storageArea";
            this.tbx_storageArea.Size = new System.Drawing.Size(160, 23);
            this.tbx_storageArea.TabIndex = 48;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(320, 172);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 17);
            this.label18.TabIndex = 47;
            this.label18.Text = "蓄水面积:";
            // 
            // cbx_status
            // 
            this.cbx_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_status.FormattingEnabled = true;
            this.cbx_status.Location = new System.Drawing.Point(383, 50);
            this.cbx_status.Name = "cbx_status";
            this.cbx_status.Size = new System.Drawing.Size(160, 25);
            this.cbx_status.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(342, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 31;
            this.label11.Text = "状态:";
            // 
            // cbx_shape
            // 
            this.cbx_shape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_shape.FormattingEnabled = true;
            this.cbx_shape.Location = new System.Drawing.Point(91, 50);
            this.cbx_shape.Name = "cbx_shape";
            this.cbx_shape.Size = new System.Drawing.Size(160, 25);
            this.cbx_shape.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "形状:";
            // 
            // tbx_name
            // 
            this.tbx_name.Location = new System.Drawing.Point(91, 18);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(452, 23);
            this.tbx_name.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 21);
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
            this.tabPage_note.Size = new System.Drawing.Size(628, 313);
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
            this.tbx_note.Size = new System.Drawing.Size(622, 307);
            this.tbx_note.TabIndex = 13;
            // 
            // tabPage_mediaInfo
            // 
            this.tabPage_mediaInfo.Controls.Add(this.mediaControl1);
            this.tabPage_mediaInfo.Location = new System.Drawing.Point(4, 26);
            this.tabPage_mediaInfo.Name = "tabPage_mediaInfo";
            this.tabPage_mediaInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_mediaInfo.Size = new System.Drawing.Size(628, 313);
            this.tabPage_mediaInfo.TabIndex = 1;
            this.tabPage_mediaInfo.Text = "多媒体文件";
            this.tabPage_mediaInfo.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(517, 372);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(421, 372);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // mediaControl1
            // 
            this.mediaControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaControl1.Location = new System.Drawing.Point(3, 3);
            this.mediaControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mediaControl1.Name = "mediaControl1";
            this.mediaControl1.Size = new System.Drawing.Size(622, 307);
            this.mediaControl1.TabIndex = 0;
            // 
            // FormArtificiallake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 425);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormArtificiallake";
            this.Text = "新增航空灭火蓄水池";
            this.Load += new System.EventHandler(this.FormArtificiallake_Load);
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
        private System.Windows.Forms.ComboBox cbx_isTakeWater;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_isCableway;
        private System.Windows.Forms.Label label3;
        private Controls.NTextBox tbx_volume;
        private System.Windows.Forms.Label label17;
        private Controls.NTextBox tbx_storageArea;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbx_status;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbx_shape;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage_note;
        private System.Windows.Forms.TextBox tbx_note;
        private System.Windows.Forms.TabPage tabPage_mediaInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label5;
        private Controls.NTextBox tbx_storageCapacity;
        private System.Windows.Forms.Label label6;
        private Controls.NTextBox tbx_maximumDepth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbx_managementUnit;
        private System.Windows.Forms.TextBox tbx_trafficCondition;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbx_manager;
        private System.Windows.Forms.Label label13;
        private Controls.NTextBox tbx_phone;
        private System.Windows.Forms.Label label14;
        private Controls.MediaControl mediaControl1;
    }
}