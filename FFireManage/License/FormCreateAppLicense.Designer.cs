namespace FFireManage
{
    partial class FormCreateAppLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pacControl1 = new FFireManage.Controls.PACControl();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDeviceType = new System.Windows.Forms.ComboBox();
            this.tbxNumber = new FFireManage.Controls.NTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "许可数:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(83, 238);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(164, 238);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "取消(&C)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pacControl1
            // 
            this.pacControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pacControl1.LocalPac = null;
            this.pacControl1.Location = new System.Drawing.Point(26, 8);
            this.pacControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pacControl1.Name = "pacControl1";
            this.pacControl1.Size = new System.Drawing.Size(244, 136);
            this.pacControl1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "设备类型:";
            // 
            // cbxDeviceType
            // 
            this.cbxDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDeviceType.FormattingEnabled = true;
            this.cbxDeviceType.Location = new System.Drawing.Point(73, 186);
            this.cbxDeviceType.Name = "cbxDeviceType";
            this.cbxDeviceType.Size = new System.Drawing.Size(177, 25);
            this.cbxDeviceType.TabIndex = 3;
            // 
            // tbxNumber
            // 
            this.tbxNumber.Location = new System.Drawing.Point(73, 148);
            this.tbxNumber.Name = "tbxNumber";
            this.tbxNumber.Size = new System.Drawing.Size(177, 23);
            this.tbxNumber.TabIndex = 6;
            this.tbxNumber.Text = "10";
            // 
            // FormCreateAppLicense
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(269, 292);
            this.Controls.Add(this.tbxNumber);
            this.Controls.Add(this.cbxDeviceType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pacControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCreateAppLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加许可";
            this.Load += new System.EventHandler(this.FormCreateAppLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button2;
        private Controls.PACControl pacControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxDeviceType;
        private Controls.NTextBox tbxNumber;
    }
}