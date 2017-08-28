namespace FFireManage.License
{
    partial class FormUpdateAppLicense
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
            this.pacControl1 = new FFireManage.Controls.PACControl();
            this.tbxImei = new FFireManage.Controls.NTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbxKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pacControl1
            // 
            this.pacControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pacControl1.LocalPac = null;
            this.pacControl1.Location = new System.Drawing.Point(40, 17);
            this.pacControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pacControl1.Name = "pacControl1";
            this.pacControl1.Size = new System.Drawing.Size(244, 136);
            this.pacControl1.TabIndex = 1;
            // 
            // tbxImei
            // 
            this.tbxImei.Location = new System.Drawing.Point(87, 197);
            this.tbxImei.MaxLength = 15;
            this.tbxImei.Name = "tbxImei";
            this.tbxImei.Size = new System.Drawing.Size(177, 23);
            this.tbxImei.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "设备序列号:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(189, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(87, 250);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "更新(&U)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbxKey
            // 
            this.tbxKey.Location = new System.Drawing.Point(87, 154);
            this.tbxKey.Name = "tbxKey";
            this.tbxKey.ReadOnly = true;
            this.tbxKey.Size = new System.Drawing.Size(177, 23);
            this.tbxKey.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "授权码:";
            // 
            // FormUpdateAppLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 317);
            this.Controls.Add(this.tbxKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxImei);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pacControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUpdateAppLicense";
            this.Text = "更新许可";
            this.Load += new System.EventHandler(this.FormUpdateAppLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.PACControl pacControl1;
        private Controls.NTextBox tbxImei;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbxKey;
        private System.Windows.Forms.Label label1;
    }
}