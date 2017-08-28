
namespace FFireManage.Monitor
{
    partial class FormMonitor
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.tbxLatitude = new FFireManage.Controls.NTextBox();
            this.tbxLongitude = new FFireManage.Controls.NTextBox();
            this.tbxPhone = new System.Windows.Forms.TextBox();
            this.tbxManager = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxElevation = new FFireManage.Controls.NTextBox();
            this.tbxHeight = new FFireManage.Controls.NTextBox();
            this.tbx_v_offset = new FFireManage.Controls.NTextBox();
            this.tbx_h_offset = new FFireManage.Controls.NTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pacControl1 = new FFireManage.Controls.PACControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbxChannel1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxPassword1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxUser1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbxPort1 = new FFireManage.Controls.NTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxIp1 = new FFireManage.Controls.IPTextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cbxChannel2 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxPassword2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbxUser2 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbxPort2 = new FFireManage.Controls.NTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tbxIp2 = new FFireManage.Controls.IPTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbx_deviceid = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(69, 317);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(165, 317);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbxAddress
            // 
            this.tbxAddress.Location = new System.Drawing.Point(75, 158);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(180, 23);
            this.tbxAddress.TabIndex = 14;
            this.tbxAddress.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // tbxLatitude
            // 
            this.tbxLatitude.Location = new System.Drawing.Point(75, 129);
            this.tbxLatitude.Name = "tbxLatitude";
            this.tbxLatitude.Size = new System.Drawing.Size(180, 23);
            this.tbxLatitude.TabIndex = 13;
            this.tbxLatitude.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // tbxLongitude
            // 
            this.tbxLongitude.Location = new System.Drawing.Point(75, 100);
            this.tbxLongitude.Name = "tbxLongitude";
            this.tbxLongitude.Size = new System.Drawing.Size(180, 23);
            this.tbxLongitude.TabIndex = 12;
            this.tbxLongitude.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // tbxPhone
            // 
            this.tbxPhone.Location = new System.Drawing.Point(75, 71);
            this.tbxPhone.Name = "tbxPhone";
            this.tbxPhone.Size = new System.Drawing.Size(180, 23);
            this.tbxPhone.TabIndex = 11;
            this.tbxPhone.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // tbxManager
            // 
            this.tbxManager.Location = new System.Drawing.Point(75, 43);
            this.tbxManager.Name = "tbxManager";
            this.tbxManager.Size = new System.Drawing.Size(180, 23);
            this.tbxManager.TabIndex = 10;
            this.tbxManager.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(75, 15);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(180, 23);
            this.tbxName.TabIndex = 5;
            this.tbxName.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 17);
            this.label12.TabIndex = 5;
            this.label12.Text = "位置纬度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "位置经度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "管理员电话";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "管理员";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "地址";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称";
            // 
            // tbxElevation
            // 
            this.tbxElevation.Location = new System.Drawing.Point(89, 101);
            this.tbxElevation.Name = "tbxElevation";
            this.tbxElevation.Size = new System.Drawing.Size(180, 23);
            this.tbxElevation.TabIndex = 4;
            this.tbxElevation.Text = "0";
            this.tbxElevation.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // tbxHeight
            // 
            this.tbxHeight.Location = new System.Drawing.Point(89, 72);
            this.tbxHeight.Name = "tbxHeight";
            this.tbxHeight.Size = new System.Drawing.Size(180, 23);
            this.tbxHeight.TabIndex = 3;
            this.tbxHeight.Text = "50";
            this.tbxHeight.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // tbx_v_offset
            // 
            this.tbx_v_offset.Location = new System.Drawing.Point(89, 43);
            this.tbx_v_offset.Name = "tbx_v_offset";
            this.tbx_v_offset.Size = new System.Drawing.Size(180, 23);
            this.tbx_v_offset.TabIndex = 2;
            this.tbx_v_offset.Text = "0.0";
            this.tbx_v_offset.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // tbx_h_offset
            // 
            this.tbx_h_offset.Location = new System.Drawing.Point(89, 15);
            this.tbx_h_offset.Name = "tbx_h_offset";
            this.tbx_h_offset.Size = new System.Drawing.Size(180, 23);
            this.tbx_h_offset.TabIndex = 1;
            this.tbx_h_offset.Text = "0.0";
            this.tbx_h_offset.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "海拔高度";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "云台高度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "俯仰角纠正值";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "水平角纠正值";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(9, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(291, 284);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbxAddress);
            this.tabPage1.Controls.Add(this.tbxName);
            this.tabPage1.Controls.Add(this.tbxLatitude);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbxLongitude);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbxPhone);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbxManager);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(283, 254);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pacControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(283, 254);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "行政区域";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pacControl1
            // 
            this.pacControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pacControl1.LocalPac = null;
            this.pacControl1.Location = new System.Drawing.Point(17, 13);
            this.pacControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pacControl1.Name = "pacControl1";
            this.pacControl1.Size = new System.Drawing.Size(263, 136);
            this.pacControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbx_deviceid);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.tbxElevation);
            this.tabPage3.Controls.Add(this.tbxHeight);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.tbx_v_offset);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.tbx_h_offset);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(283, 254);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "数字云台配置信息";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.checkBox1);
            this.tabPage4.Controls.Add(this.cbxChannel1);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.tbxPassword1);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.tbxUser1);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.tbxPort1);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.tbxIp1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(283, 258);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "可见光";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(69, 204);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 21);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "近红外设置";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cbxChannel1
            // 
            this.cbxChannel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChannel1.FormattingEnabled = true;
            this.cbxChannel1.Location = new System.Drawing.Point(69, 72);
            this.cbxChannel1.Name = "cbxChannel1";
            this.cbxChannel1.Size = new System.Drawing.Size(140, 25);
            this.cbxChannel1.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "分辨率";
            // 
            // tbxPassword1
            // 
            this.tbxPassword1.Location = new System.Drawing.Point(69, 133);
            this.tbxPassword1.Name = "tbxPassword1";
            this.tbxPassword1.Size = new System.Drawing.Size(140, 23);
            this.tbxPassword1.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(32, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 17);
            this.label15.TabIndex = 17;
            this.label15.Text = "密码";
            // 
            // tbxUser1
            // 
            this.tbxUser1.Location = new System.Drawing.Point(69, 104);
            this.tbxUser1.Name = "tbxUser1";
            this.tbxUser1.Size = new System.Drawing.Size(140, 23);
            this.tbxUser1.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 17);
            this.label14.TabIndex = 15;
            this.label14.Text = "用户名";
            // 
            // tbxPort1
            // 
            this.tbxPort1.Location = new System.Drawing.Point(69, 43);
            this.tbxPort1.Name = "tbxPort1";
            this.tbxPort1.Size = new System.Drawing.Size(140, 23);
            this.tbxPort1.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 17);
            this.label13.TabIndex = 13;
            this.label13.Text = "端口";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "IP地址";
            // 
            // tbxIp1
            // 
            this.tbxIp1.Location = new System.Drawing.Point(69, 15);
            this.tbxIp1.Name = "tbxIp1";
            this.tbxIp1.Padding = new System.Windows.Forms.Padding(1);
            this.tbxIp1.Size = new System.Drawing.Size(140, 21);
            this.tbxIp1.TabIndex = 9;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.cbxChannel2);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.tbxPassword2);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.tbxUser2);
            this.tabPage5.Controls.Add(this.label18);
            this.tabPage5.Controls.Add(this.tbxPort2);
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Controls.Add(this.label20);
            this.tabPage5.Controls.Add(this.tbxIp2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(283, 258);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "近红外";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // cbxChannel2
            // 
            this.cbxChannel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChannel2.FormattingEnabled = true;
            this.cbxChannel2.Location = new System.Drawing.Point(69, 72);
            this.cbxChannel2.Name = "cbxChannel2";
            this.cbxChannel2.Size = new System.Drawing.Size(140, 25);
            this.cbxChannel2.TabIndex = 30;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 75);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 17);
            this.label16.TabIndex = 29;
            this.label16.Text = "分辨率";
            // 
            // tbxPassword2
            // 
            this.tbxPassword2.Location = new System.Drawing.Point(69, 133);
            this.tbxPassword2.Name = "tbxPassword2";
            this.tbxPassword2.Size = new System.Drawing.Size(140, 23);
            this.tbxPassword2.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(32, 136);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 17);
            this.label17.TabIndex = 27;
            this.label17.Text = "密码";
            // 
            // tbxUser2
            // 
            this.tbxUser2.Location = new System.Drawing.Point(69, 104);
            this.tbxUser2.Name = "tbxUser2";
            this.tbxUser2.Size = new System.Drawing.Size(140, 23);
            this.tbxUser2.TabIndex = 26;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 107);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 17);
            this.label18.TabIndex = 25;
            this.label18.Text = "用户名";
            // 
            // tbxPort2
            // 
            this.tbxPort2.Location = new System.Drawing.Point(69, 43);
            this.tbxPort2.Name = "tbxPort2";
            this.tbxPort2.Size = new System.Drawing.Size(140, 23);
            this.tbxPort2.TabIndex = 24;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(32, 46);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 17);
            this.label19.TabIndex = 23;
            this.label19.Text = "端口";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(21, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 17);
            this.label20.TabIndex = 21;
            this.label20.Text = "IP地址";
            // 
            // tbxIp2
            // 
            this.tbxIp2.Location = new System.Drawing.Point(69, 15);
            this.tbxIp2.Name = "tbxIp2";
            this.tbxIp2.Padding = new System.Windows.Forms.Padding(1);
            this.tbxIp2.Size = new System.Drawing.Size(140, 21);
            this.tbxIp2.TabIndex = 22;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(30, 140);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 17);
            this.label21.TabIndex = 13;
            this.label21.Text = "设备编号";
            // 
            // tbx_deviceid
            // 
            this.tbx_deviceid.Location = new System.Drawing.Point(89, 137);
            this.tbx_deviceid.Name = "tbx_deviceid";
            this.tbx_deviceid.Size = new System.Drawing.Size(180, 23);
            this.tbx_deviceid.TabIndex = 5;
            // 
            // FormMonitor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(309, 356);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMonitor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "林火远程视频监控维护";
            this.Load += new System.EventHandler(this.FormMonitoring_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxAddress;
        private Controls.NTextBox tbxLatitude;
        private Controls.NTextBox tbxLongitude;
        private System.Windows.Forms.TextBox tbxPhone;
        private System.Windows.Forms.TextBox tbxManager;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private Controls.NTextBox tbxElevation;
        private Controls.NTextBox tbxHeight;
        private Controls.NTextBox tbx_v_offset;
        private Controls.NTextBox tbx_h_offset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label7;
        private Controls.IPTextBox tbxIp1;
        private System.Windows.Forms.TextBox tbxPassword1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbxUser1;
        private System.Windows.Forms.Label label14;
        private Controls.NTextBox tbxPort1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxChannel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxChannel2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbxPassword2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbxUser2;
        private System.Windows.Forms.Label label18;
        private Controls.NTextBox tbxPort2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private Controls.IPTextBox tbxIp2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private Controls.PACControl pacControl1;
        private System.Windows.Forms.TextBox tbx_deviceid;
        private System.Windows.Forms.Label label21;
    }
}