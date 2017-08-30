namespace FFireDataDocking
{
    partial class FormDataDocking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataDocking));
            this.btnAddFireCommand = new System.Windows.Forms.Button();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddFireCommand
            // 
            this.btnAddFireCommand.Location = new System.Drawing.Point(34, 29);
            this.btnAddFireCommand.Name = "btnAddFireCommand";
            this.btnAddFireCommand.Size = new System.Drawing.Size(140, 23);
            this.btnAddFireCommand.TabIndex = 2;
            this.btnAddFireCommand.Text = "森林防火指挥部";
            this.btnAddFireCommand.UseVisualStyleBackColor = true;
            this.btnAddFireCommand.Click += new System.EventHandler(this.btnAddFireCommand_Click);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(590, 276);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 3;
            // 
            // FormDataDocking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 522);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.btnAddFireCommand);
            this.Name = "FormDataDocking";
            this.Text = "上传数据";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddFireCommand;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
    }
}