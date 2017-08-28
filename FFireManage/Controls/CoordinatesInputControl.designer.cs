namespace FFireManage.Controls
{
    partial class CoordinatesInputControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.rbtDegree = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxLongitudeDegree1 = new Controls.NTextBox();
            this.panDegreeMinutes = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbxLatitudeMinutes2 = new Controls.NTextBox();
            this.tbxLatitudeDegree2 = new Controls.NTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbxLongitudeMinutes2 = new Controls.NTextBox();
            this.tbxLongitudeDegree2 = new Controls.NTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbtDegreeMinutesSeconds = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbxLatitudeDegree1 = new Controls.NTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtDegreeMinutes = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxLatitudeSeconds3 = new Controls.NTextBox();
            this.tbxLatitudeMinutes3 = new Controls.NTextBox();
            this.tbxLatitudeDegree3 = new Controls.NTextBox();
            this.panDegreeMinutesSeconds = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxLongitudeSeconds3 = new Controls.NTextBox();
            this.tbxLongitudeMinutes3 = new Controls.NTextBox();
            this.tbxLongitudeDegree3 = new Controls.NTextBox();
            this.panDegree = new System.Windows.Forms.Panel();
            this.groupBox4.SuspendLayout();
            this.panDegreeMinutes.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panDegreeMinutesSeconds.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panDegree.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "分";
            // 
            // rbtDegree
            // 
            this.rbtDegree.AutoSize = true;
            this.rbtDegree.Location = new System.Drawing.Point(30, 6);
            this.rbtDegree.Name = "rbtDegree";
            this.rbtDegree.Size = new System.Drawing.Size(37, 17);
            this.rbtDegree.TabIndex = 10;
            this.rbtDegree.Text = "度";
            this.rbtDegree.UseVisualStyleBackColor = true;
            this.rbtDegree.CheckedChanged += new System.EventHandler(this.rbtDegree_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "秒";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.tbxLongitudeDegree1);
            this.groupBox4.Location = new System.Drawing.Point(19, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(241, 51);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "经度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(174, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "度";
            // 
            // tbxLongitudeDegree1
            // 
            this.tbxLongitudeDegree1.Location = new System.Drawing.Point(49, 19);
            this.tbxLongitudeDegree1.MaxLength = 10;
            this.tbxLongitudeDegree1.Name = "tbxLongitudeDegree1";
            this.tbxLongitudeDegree1.Size = new System.Drawing.Size(120, 20);
            this.tbxLongitudeDegree1.TabIndex = 0;
            this.tbxLongitudeDegree1.Text = "0.00";
            // 
            // panDegreeMinutes
            // 
            this.panDegreeMinutes.Controls.Add(this.groupBox5);
            this.panDegreeMinutes.Controls.Add(this.groupBox6);
            this.panDegreeMinutes.Location = new System.Drawing.Point(11, 23);
            this.panDegreeMinutes.Name = "panDegreeMinutes";
            this.panDegreeMinutes.Size = new System.Drawing.Size(279, 111);
            this.panDegreeMinutes.TabIndex = 15;
            this.panDegreeMinutes.VisibleChanged += new System.EventHandler(this.panDegreeMinutes_VisibleChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.tbxLatitudeMinutes2);
            this.groupBox5.Controls.Add(this.tbxLatitudeDegree2);
            this.groupBox5.Location = new System.Drawing.Point(19, 56);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(241, 51);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "纬度";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(201, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "分";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(96, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "度";
            // 
            // tbxLatitudeMinutes2
            // 
            this.tbxLatitudeMinutes2.Location = new System.Drawing.Point(127, 19);
            this.tbxLatitudeMinutes2.MaxLength = 8;
            this.tbxLatitudeMinutes2.Name = "tbxLatitudeMinutes2";
            this.tbxLatitudeMinutes2.Size = new System.Drawing.Size(70, 20);
            this.tbxLatitudeMinutes2.TabIndex = 7;
            this.tbxLatitudeMinutes2.Text = "0.0";
            // 
            // tbxLatitudeDegree2
            // 
            this.tbxLatitudeDegree2.Location = new System.Drawing.Point(23, 19);
            this.tbxLatitudeDegree2.MaxLength = 2;
            this.tbxLatitudeDegree2.Name = "tbxLatitudeDegree2";
            this.tbxLatitudeDegree2.Size = new System.Drawing.Size(70, 20);
            this.tbxLatitudeDegree2.TabIndex = 6;
            this.tbxLatitudeDegree2.Text = "0";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.tbxLongitudeMinutes2);
            this.groupBox6.Controls.Add(this.tbxLongitudeDegree2);
            this.groupBox6.Location = new System.Drawing.Point(19, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(241, 51);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "经度";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(201, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "分";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(97, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "度";
            // 
            // tbxLongitudeMinutes2
            // 
            this.tbxLongitudeMinutes2.Location = new System.Drawing.Point(127, 19);
            this.tbxLongitudeMinutes2.MaxLength = 8;
            this.tbxLongitudeMinutes2.Name = "tbxLongitudeMinutes2";
            this.tbxLongitudeMinutes2.Size = new System.Drawing.Size(70, 20);
            this.tbxLongitudeMinutes2.TabIndex = 1;
            this.tbxLongitudeMinutes2.Text = "0.0";
            // 
            // tbxLongitudeDegree2
            // 
            this.tbxLongitudeDegree2.Location = new System.Drawing.Point(23, 19);
            this.tbxLongitudeDegree2.MaxLength = 3;
            this.tbxLongitudeDegree2.Name = "tbxLongitudeDegree2";
            this.tbxLongitudeDegree2.Size = new System.Drawing.Size(70, 20);
            this.tbxLongitudeDegree2.TabIndex = 0;
            this.tbxLongitudeDegree2.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(174, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "度";
            // 
            // rbtDegreeMinutesSeconds
            // 
            this.rbtDegreeMinutesSeconds.AutoSize = true;
            this.rbtDegreeMinutesSeconds.Checked = true;
            this.rbtDegreeMinutesSeconds.Location = new System.Drawing.Point(200, 6);
            this.rbtDegreeMinutesSeconds.Name = "rbtDegreeMinutesSeconds";
            this.rbtDegreeMinutesSeconds.Size = new System.Drawing.Size(67, 17);
            this.rbtDegreeMinutesSeconds.TabIndex = 12;
            this.rbtDegreeMinutesSeconds.TabStop = true;
            this.rbtDegreeMinutesSeconds.Text = "度 分 秒";
            this.rbtDegreeMinutesSeconds.UseVisualStyleBackColor = true;
            this.rbtDegreeMinutesSeconds.CheckedChanged += new System.EventHandler(this.rbtDegreeMinutesSeconds_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbxLatitudeDegree1);
            this.groupBox3.Location = new System.Drawing.Point(19, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(241, 51);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "纬度";
            // 
            // tbxLatitudeDegree1
            // 
            this.tbxLatitudeDegree1.Location = new System.Drawing.Point(49, 19);
            this.tbxLatitudeDegree1.MaxLength = 10;
            this.tbxLatitudeDegree1.Name = "tbxLatitudeDegree1";
            this.tbxLatitudeDegree1.Size = new System.Drawing.Size(120, 20);
            this.tbxLatitudeDegree1.TabIndex = 6;
            this.tbxLatitudeDegree1.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "分";
            // 
            // rbtDegreeMinutes
            // 
            this.rbtDegreeMinutes.AutoSize = true;
            this.rbtDegreeMinutes.Location = new System.Drawing.Point(119, 6);
            this.rbtDegreeMinutes.Name = "rbtDegreeMinutes";
            this.rbtDegreeMinutes.Size = new System.Drawing.Size(52, 17);
            this.rbtDegreeMinutes.TabIndex = 11;
            this.rbtDegreeMinutes.Text = "度 分";
            this.rbtDegreeMinutes.UseVisualStyleBackColor = true;
            this.rbtDegreeMinutes.CheckedChanged += new System.EventHandler(this.rbtDegreeMinutes_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbxLatitudeSeconds3);
            this.groupBox2.Controls.Add(this.tbxLatitudeMinutes3);
            this.groupBox2.Controls.Add(this.tbxLatitudeDegree3);
            this.groupBox2.Location = new System.Drawing.Point(19, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 51);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "纬度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "秒";
            // 
            // tbxLatitudeSeconds3
            // 
            this.tbxLatitudeSeconds3.Location = new System.Drawing.Point(159, 19);
            this.tbxLatitudeSeconds3.MaxLength = 6;
            this.tbxLatitudeSeconds3.Name = "tbxLatitudeSeconds3";
            this.tbxLatitudeSeconds3.Size = new System.Drawing.Size(50, 20);
            this.tbxLatitudeSeconds3.TabIndex = 8;
            this.tbxLatitudeSeconds3.Text = "0.0";
            // 
            // tbxLatitudeMinutes3
            // 
            this.tbxLatitudeMinutes3.Location = new System.Drawing.Point(86, 19);
            this.tbxLatitudeMinutes3.MaxLength = 2;
            this.tbxLatitudeMinutes3.Name = "tbxLatitudeMinutes3";
            this.tbxLatitudeMinutes3.Size = new System.Drawing.Size(50, 20);
            this.tbxLatitudeMinutes3.TabIndex = 7;
            this.tbxLatitudeMinutes3.Text = "0";
            // 
            // tbxLatitudeDegree3
            // 
            this.tbxLatitudeDegree3.Location = new System.Drawing.Point(13, 19);
            this.tbxLatitudeDegree3.MaxLength = 2;
            this.tbxLatitudeDegree3.Name = "tbxLatitudeDegree3";
            this.tbxLatitudeDegree3.Size = new System.Drawing.Size(50, 20);
            this.tbxLatitudeDegree3.TabIndex = 6;
            this.tbxLatitudeDegree3.Text = "0";
            // 
            // panDegreeMinutesSeconds
            // 
            this.panDegreeMinutesSeconds.Controls.Add(this.groupBox2);
            this.panDegreeMinutesSeconds.Controls.Add(this.groupBox1);
            this.panDegreeMinutesSeconds.Location = new System.Drawing.Point(11, 23);
            this.panDegreeMinutesSeconds.Name = "panDegreeMinutesSeconds";
            this.panDegreeMinutesSeconds.Size = new System.Drawing.Size(279, 111);
            this.panDegreeMinutesSeconds.TabIndex = 13;
            this.panDegreeMinutesSeconds.VisibleChanged += new System.EventHandler(this.panDegreeMinutesSeconds_VisibleChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbxLongitudeSeconds3);
            this.groupBox1.Controls.Add(this.tbxLongitudeMinutes3);
            this.groupBox1.Controls.Add(this.tbxLongitudeDegree3);
            this.groupBox1.Location = new System.Drawing.Point(19, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "经度";
            // 
            // tbxLongitudeSeconds3
            // 
            this.tbxLongitudeSeconds3.Location = new System.Drawing.Point(159, 19);
            this.tbxLongitudeSeconds3.MaxLength = 6;
            this.tbxLongitudeSeconds3.Name = "tbxLongitudeSeconds3";
            this.tbxLongitudeSeconds3.Size = new System.Drawing.Size(50, 20);
            this.tbxLongitudeSeconds3.TabIndex = 2;
            this.tbxLongitudeSeconds3.Text = "0.0";
            // 
            // tbxLongitudeMinutes3
            // 
            this.tbxLongitudeMinutes3.Location = new System.Drawing.Point(86, 19);
            this.tbxLongitudeMinutes3.MaxLength = 2;
            this.tbxLongitudeMinutes3.Name = "tbxLongitudeMinutes3";
            this.tbxLongitudeMinutes3.Size = new System.Drawing.Size(50, 20);
            this.tbxLongitudeMinutes3.TabIndex = 1;
            this.tbxLongitudeMinutes3.Text = "0";
            // 
            // tbxLongitudeDegree3
            // 
            this.tbxLongitudeDegree3.Location = new System.Drawing.Point(13, 19);
            this.tbxLongitudeDegree3.MaxLength = 3;
            this.tbxLongitudeDegree3.Name = "tbxLongitudeDegree3";
            this.tbxLongitudeDegree3.Size = new System.Drawing.Size(50, 20);
            this.tbxLongitudeDegree3.TabIndex = 0;
            this.tbxLongitudeDegree3.Text = "0";
            // 
            // panDegree
            // 
            this.panDegree.Controls.Add(this.groupBox3);
            this.panDegree.Controls.Add(this.groupBox4);
            this.panDegree.Location = new System.Drawing.Point(11, 23);
            this.panDegree.Name = "panDegree";
            this.panDegree.Size = new System.Drawing.Size(279, 111);
            this.panDegree.TabIndex = 14;
            this.panDegree.VisibleChanged += new System.EventHandler(this.panDegree_VisibleChanged);
            // 
            // CoordinatesInputControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.rbtDegree);
            this.Controls.Add(this.rbtDegreeMinutesSeconds);
            this.Controls.Add(this.rbtDegreeMinutes);
            this.Controls.Add(this.panDegree);
            this.Controls.Add(this.panDegreeMinutes);
            this.Controls.Add(this.panDegreeMinutesSeconds);
            this.MaximumSize = new System.Drawing.Size(300, 140);
            this.MinimumSize = new System.Drawing.Size(300, 140);
            this.Name = "CoordinatesInputControl";
            this.Size = new System.Drawing.Size(300, 140);
            this.Load += new System.EventHandler(this.CoordinatesInputControl_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panDegreeMinutes.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panDegreeMinutesSeconds.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panDegree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtDegree;
        private System.Windows.Forms.Label label2;
        private NTextBox tbxLongitudeDegree1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private NTextBox tbxLongitudeSeconds3;
        private System.Windows.Forms.Panel panDegreeMinutes;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private NTextBox tbxLatitudeMinutes2;
        private NTextBox tbxLatitudeDegree2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private NTextBox tbxLongitudeMinutes2;
        private NTextBox tbxLongitudeDegree2;
        private NTextBox tbxLongitudeMinutes3;
        private NTextBox tbxLatitudeDegree1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbtDegreeMinutesSeconds;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtDegreeMinutes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private NTextBox tbxLatitudeSeconds3;
        private NTextBox tbxLatitudeMinutes3;
        private NTextBox tbxLatitudeDegree3;
        private System.Windows.Forms.Panel panDegreeMinutesSeconds;
        private System.Windows.Forms.GroupBox groupBox1;
        private NTextBox tbxLongitudeDegree3;
        private System.Windows.Forms.Panel panDegree;

    }
}
