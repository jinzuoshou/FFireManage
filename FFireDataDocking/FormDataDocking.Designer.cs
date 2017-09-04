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
            this.btnAddFireHBrigade = new System.Windows.Forms.Button();
            this.btnDeleteFireCommands = new System.Windows.Forms.Button();
            this.btnDeleteFireHBrigade = new System.Windows.Forms.Button();
            this.btnAddFirePBrigade = new System.Windows.Forms.Button();
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
            // btnAddFireHBrigade
            // 
            this.btnAddFireHBrigade.Location = new System.Drawing.Point(203, 29);
            this.btnAddFireHBrigade.Name = "btnAddFireHBrigade";
            this.btnAddFireHBrigade.Size = new System.Drawing.Size(140, 23);
            this.btnAddFireHBrigade.TabIndex = 4;
            this.btnAddFireHBrigade.Text = "半专业森林防火消防队";
            this.btnAddFireHBrigade.UseVisualStyleBackColor = true;
            this.btnAddFireHBrigade.Click += new System.EventHandler(this.btnAddFireHBrigade_Click);
            // 
            // btnDeleteFireCommands
            // 
            this.btnDeleteFireCommands.Location = new System.Drawing.Point(34, 462);
            this.btnDeleteFireCommands.Name = "btnDeleteFireCommands";
            this.btnDeleteFireCommands.Size = new System.Drawing.Size(140, 23);
            this.btnDeleteFireCommands.TabIndex = 5;
            this.btnDeleteFireCommands.Text = "删除所有森林防火指挥部";
            this.btnDeleteFireCommands.UseVisualStyleBackColor = true;
            this.btnDeleteFireCommands.Click += new System.EventHandler(this.btnDeleteFireCommands_Click);
            // 
            // btnDeleteFireHBrigade
            // 
            this.btnDeleteFireHBrigade.Location = new System.Drawing.Point(206, 462);
            this.btnDeleteFireHBrigade.Name = "btnDeleteFireHBrigade";
            this.btnDeleteFireHBrigade.Size = new System.Drawing.Size(140, 23);
            this.btnDeleteFireHBrigade.TabIndex = 6;
            this.btnDeleteFireHBrigade.Text = "删除所有半专业森林消防队";
            this.btnDeleteFireHBrigade.UseVisualStyleBackColor = true;
            this.btnDeleteFireHBrigade.Click += new System.EventHandler(this.btnDeleteFireHBrigade_Click);
            // 
            // btnAddFirePBrigade
            // 
            this.btnAddFirePBrigade.Location = new System.Drawing.Point(368, 29);
            this.btnAddFirePBrigade.Name = "btnAddFirePBrigade";
            this.btnAddFirePBrigade.Size = new System.Drawing.Size(140, 23);
            this.btnAddFirePBrigade.TabIndex = 7;
            this.btnAddFirePBrigade.Text = "专业森林防火消防队";
            this.btnAddFirePBrigade.UseVisualStyleBackColor = true;
            this.btnAddFirePBrigade.Click += new System.EventHandler(this.btnAddFirePBrigade_Click);
            // 
            // FormDataDocking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 522);
            this.Controls.Add(this.btnAddFirePBrigade);
            this.Controls.Add(this.btnDeleteFireHBrigade);
            this.Controls.Add(this.btnDeleteFireCommands);
            this.Controls.Add(this.btnAddFireHBrigade);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.btnAddFireCommand);
            this.Name = "FormDataDocking";
            this.Text = "上传数据";
            this.Load += new System.EventHandler(this.FormDataDocking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddFireCommand;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Button btnAddFireHBrigade;
        private System.Windows.Forms.Button btnDeleteFireCommands;
        private System.Windows.Forms.Button btnDeleteFireHBrigade;
        private System.Windows.Forms.Button btnAddFirePBrigade;
    }
}