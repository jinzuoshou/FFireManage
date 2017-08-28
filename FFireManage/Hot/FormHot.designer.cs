using System;

namespace FFireManage.Hot
{
    partial class FormHot
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.coordinatesInputControl1 = new FFireManage.Controls.CoordinatesInputControl();
            this.gbxFireHotInfo = new System.Windows.Forms.GroupBox();
            this.cbx_province = new System.Windows.Forms.ComboBox();
            this.cbx_city = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbx_county = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbx_pixels = new FFireManage.Controls.NTextBox();
            this.tbx_landType = new System.Windows.Forms.TextBox();
            this.tbx_note = new System.Windows.Forms.TextBox();
            this.cbx_type = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbx_opinion = new System.Windows.Forms.TextBox();
            this.tbx_cre_pers = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_reportTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_receiptTime = new System.Windows.Forms.DateTimePicker();
            this.cbx_continuous = new System.Windows.Forms.ComboBox();
            this.cbx_smoke = new System.Windows.Forms.ComboBox();
            this.tbx_duty = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbx_reporter = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_satellite = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_no = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.gbxFireHotInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.coordinatesInputControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 180);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输入经纬度可以精确地标绘热点位置，依次在以下的文本框中输入一个热点的经纬度。";
            // 
            // coordinatesInputControl1
            // 
            this.coordinatesInputControl1.Latitude = 0D;
            this.coordinatesInputControl1.Location = new System.Drawing.Point(16, 34);
            this.coordinatesInputControl1.Longitude = 0D;
            this.coordinatesInputControl1.MaximumSize = new System.Drawing.Size(300, 140);
            this.coordinatesInputControl1.MinimumSize = new System.Drawing.Size(300, 140);
            this.coordinatesInputControl1.Name = "coordinatesInputControl1";
            this.coordinatesInputControl1.Size = new System.Drawing.Size(300, 140);
            this.coordinatesInputControl1.TabIndex = 0;
            // 
            // gbxFireHotInfo
            // 
            this.gbxFireHotInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbxFireHotInfo.Controls.Add(this.cbx_province);
            this.gbxFireHotInfo.Controls.Add(this.cbx_city);
            this.gbxFireHotInfo.Controls.Add(this.label17);
            this.gbxFireHotInfo.Controls.Add(this.cbx_county);
            this.gbxFireHotInfo.Controls.Add(this.label13);
            this.gbxFireHotInfo.Controls.Add(this.tbx_pixels);
            this.gbxFireHotInfo.Controls.Add(this.tbx_landType);
            this.gbxFireHotInfo.Controls.Add(this.tbx_note);
            this.gbxFireHotInfo.Controls.Add(this.cbx_type);
            this.gbxFireHotInfo.Controls.Add(this.label15);
            this.gbxFireHotInfo.Controls.Add(this.label14);
            this.gbxFireHotInfo.Controls.Add(this.label16);
            this.gbxFireHotInfo.Controls.Add(this.tbx_opinion);
            this.gbxFireHotInfo.Controls.Add(this.tbx_cre_pers);
            this.gbxFireHotInfo.Controls.Add(this.label1);
            this.gbxFireHotInfo.Controls.Add(this.dateTimePicker_reportTime);
            this.gbxFireHotInfo.Controls.Add(this.dateTimePicker_receiptTime);
            this.gbxFireHotInfo.Controls.Add(this.cbx_continuous);
            this.gbxFireHotInfo.Controls.Add(this.cbx_smoke);
            this.gbxFireHotInfo.Controls.Add(this.tbx_duty);
            this.gbxFireHotInfo.Controls.Add(this.label18);
            this.gbxFireHotInfo.Controls.Add(this.label10);
            this.gbxFireHotInfo.Controls.Add(this.tbx_reporter);
            this.gbxFireHotInfo.Controls.Add(this.label11);
            this.gbxFireHotInfo.Controls.Add(this.label5);
            this.gbxFireHotInfo.Controls.Add(this.label6);
            this.gbxFireHotInfo.Controls.Add(this.label7);
            this.gbxFireHotInfo.Controls.Add(this.label8);
            this.gbxFireHotInfo.Controls.Add(this.label3);
            this.gbxFireHotInfo.Controls.Add(this.tbx_satellite);
            this.gbxFireHotInfo.Controls.Add(this.label4);
            this.gbxFireHotInfo.Controls.Add(this.label2);
            this.gbxFireHotInfo.Controls.Add(this.tbx_no);
            this.gbxFireHotInfo.Controls.Add(this.label9);
            this.gbxFireHotInfo.Location = new System.Drawing.Point(12, 201);
            this.gbxFireHotInfo.Name = "gbxFireHotInfo";
            this.gbxFireHotInfo.Size = new System.Drawing.Size(366, 333);
            this.gbxFireHotInfo.TabIndex = 2;
            this.gbxFireHotInfo.TabStop = false;
            this.gbxFireHotInfo.Text = "属性信息";
            // 
            // cbx_province
            // 
            this.cbx_province.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_province.FormattingEnabled = true;
            this.cbx_province.Location = new System.Drawing.Point(66, 153);
            this.cbx_province.Name = "cbx_province";
            this.cbx_province.Size = new System.Drawing.Size(100, 25);
            this.cbx_province.TabIndex = 95;
            this.cbx_province.SelectedIndexChanged += new System.EventHandler(this.cbx_province_SelectedIndexChanged);
            // 
            // cbx_city
            // 
            this.cbx_city.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_city.FormattingEnabled = true;
            this.cbx_city.Location = new System.Drawing.Point(242, 153);
            this.cbx_city.Name = "cbx_city";
            this.cbx_city.Size = new System.Drawing.Size(100, 25);
            this.cbx_city.TabIndex = 10;
            this.cbx_city.SelectedIndexChanged += new System.EventHandler(this.cbx_city_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(185, 156);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 17);
            this.label17.TabIndex = 94;
            this.label17.Text = "所 属 市";
            // 
            // cbx_county
            // 
            this.cbx_county.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_county.FormattingEnabled = true;
            this.cbx_county.Location = new System.Drawing.Point(66, 186);
            this.cbx_county.Name = "cbx_county";
            this.cbx_county.Size = new System.Drawing.Size(100, 25);
            this.cbx_county.TabIndex = 11;
            this.cbx_county.SelectedIndexChanged += new System.EventHandler(this.cbx_country_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 159);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 17);
            this.label13.TabIndex = 92;
            this.label13.Text = "所 属 省";
            // 
            // tbx_pixels
            // 
            this.tbx_pixels.Location = new System.Drawing.Point(242, 21);
            this.tbx_pixels.Name = "tbx_pixels";
            this.tbx_pixels.Size = new System.Drawing.Size(100, 23);
            this.tbx_pixels.TabIndex = 2;
            this.tbx_pixels.Text = "1";
            // 
            // tbx_landType
            // 
            this.tbx_landType.Location = new System.Drawing.Point(242, 90);
            this.tbx_landType.Name = "tbx_landType";
            this.tbx_landType.Size = new System.Drawing.Size(100, 23);
            this.tbx_landType.TabIndex = 8;
            this.tbx_landType.Text = "林地";
            // 
            // tbx_note
            // 
            this.tbx_note.Location = new System.Drawing.Point(66, 292);
            this.tbx_note.MaxLength = 50;
            this.tbx_note.Multiline = true;
            this.tbx_note.Name = "tbx_note";
            this.tbx_note.Size = new System.Drawing.Size(276, 21);
            this.tbx_note.TabIndex = 19;
            // 
            // cbx_type
            // 
            this.cbx_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_type.FormattingEnabled = true;
            this.cbx_type.Location = new System.Drawing.Point(242, 221);
            this.cbx_type.Name = "cbx_type";
            this.cbx_type.Size = new System.Drawing.Size(100, 25);
            this.cbx_type.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(182, 224);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 17);
            this.label15.TabIndex = 86;
            this.label15.Text = "热点类型";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 260);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 17);
            this.label14.TabIndex = 88;
            this.label14.Text = "处理意见";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(181, 260);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 17);
            this.label16.TabIndex = 85;
            this.label16.Text = "建 立 人";
            // 
            // tbx_opinion
            // 
            this.tbx_opinion.Location = new System.Drawing.Point(66, 257);
            this.tbx_opinion.MaxLength = 50;
            this.tbx_opinion.Name = "tbx_opinion";
            this.tbx_opinion.Size = new System.Drawing.Size(100, 23);
            this.tbx_opinion.TabIndex = 16;
            // 
            // tbx_cre_pers
            // 
            this.tbx_cre_pers.Location = new System.Drawing.Point(242, 257);
            this.tbx_cre_pers.Name = "tbx_cre_pers";
            this.tbx_cre_pers.Size = new System.Drawing.Size(100, 23);
            this.tbx_cre_pers.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "备    注";
            // 
            // dateTimePicker_reportTime
            // 
            this.dateTimePicker_reportTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_reportTime.Location = new System.Drawing.Point(242, 119);
            this.dateTimePicker_reportTime.Name = "dateTimePicker_reportTime";
            this.dateTimePicker_reportTime.Size = new System.Drawing.Size(100, 23);
            this.dateTimePicker_reportTime.TabIndex = 7;
            // 
            // dateTimePicker_receiptTime
            // 
            this.dateTimePicker_receiptTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_receiptTime.Location = new System.Drawing.Point(66, 118);
            this.dateTimePicker_receiptTime.Name = "dateTimePicker_receiptTime";
            this.dateTimePicker_receiptTime.Size = new System.Drawing.Size(100, 23);
            this.dateTimePicker_receiptTime.TabIndex = 5;
            // 
            // cbx_continuous
            // 
            this.cbx_continuous.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_continuous.FormattingEnabled = true;
            this.cbx_continuous.Location = new System.Drawing.Point(66, 88);
            this.cbx_continuous.Name = "cbx_continuous";
            this.cbx_continuous.Size = new System.Drawing.Size(100, 25);
            this.cbx_continuous.TabIndex = 6;
            // 
            // cbx_smoke
            // 
            this.cbx_smoke.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_smoke.FormattingEnabled = true;
            this.cbx_smoke.Location = new System.Drawing.Point(242, 55);
            this.cbx_smoke.Name = "cbx_smoke";
            this.cbx_smoke.Size = new System.Drawing.Size(100, 25);
            this.cbx_smoke.TabIndex = 4;
            // 
            // tbx_duty
            // 
            this.tbx_duty.Location = new System.Drawing.Point(242, 189);
            this.tbx_duty.MaxLength = 8;
            this.tbx_duty.Name = "tbx_duty";
            this.tbx_duty.Size = new System.Drawing.Size(100, 23);
            this.tbx_duty.TabIndex = 13;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(185, 192);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 17);
            this.label18.TabIndex = 24;
            this.label18.Text = "值 班 员";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "所属县局";
            // 
            // tbx_reporter
            // 
            this.tbx_reporter.Location = new System.Drawing.Point(66, 223);
            this.tbx_reporter.MaxLength = 8;
            this.tbx_reporter.Name = "tbx_reporter";
            this.tbx_reporter.Size = new System.Drawing.Size(100, 23);
            this.tbx_reporter.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 17);
            this.label11.TabIndex = 18;
            this.label11.Text = "报 告 人";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "地 类 别";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "上报时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "是否连续";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "接收时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "起 烟 否";
            // 
            // tbx_satellite
            // 
            this.tbx_satellite.Location = new System.Drawing.Point(66, 55);
            this.tbx_satellite.Name = "tbx_satellite";
            this.tbx_satellite.Size = new System.Drawing.Size(100, 23);
            this.tbx_satellite.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "接收卫星";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "像 素 数";
            // 
            // tbx_no
            // 
            this.tbx_no.Location = new System.Drawing.Point(66, 21);
            this.tbx_no.Name = "tbx_no";
            this.tbx_no.Size = new System.Drawing.Size(100, 23);
            this.tbx_no.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "编    号";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(279, 557);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(188, 557);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormHot
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(394, 597);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxFireHotInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormHot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "火灾热点";
            this.Load += new System.EventHandler(this.FormFireHot_Load);
            this.groupBox2.ResumeLayout(false);
            this.gbxFireHotInfo.ResumeLayout(false);
            this.gbxFireHotInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbxFireHotInfo;
        private System.Windows.Forms.TextBox tbx_landType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbx_opinion;
        private System.Windows.Forms.TextBox tbx_cre_pers;
        private System.Windows.Forms.TextBox tbx_note;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_reportTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_receiptTime;
        private System.Windows.Forms.ComboBox cbx_continuous;
        private System.Windows.Forms.ComboBox cbx_smoke;
        private System.Windows.Forms.TextBox tbx_duty;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbx_reporter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_satellite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_no;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private Controls.NTextBox tbx_pixels;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbx_type;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbx_county;
        private System.Windows.Forms.ComboBox cbx_city;
        private System.Windows.Forms.Label label17;
        private Controls.CoordinatesInputControl coordinatesInputControl1;
        private System.Windows.Forms.ComboBox cbx_province;
    }
}