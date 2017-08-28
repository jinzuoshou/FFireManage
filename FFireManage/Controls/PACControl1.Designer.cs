namespace FFireManage.Controls
{
    partial class PACControl1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxProvince = new System.Windows.Forms.ComboBox();
            this.labelProvince = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.cbxCity = new System.Windows.Forms.ComboBox();
            this.cbxCounty = new System.Windows.Forms.ComboBox();
            this.lableCounty = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxProvince
            // 
            this.cbxProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProvince.FormattingEnabled = true;
            this.cbxProvince.Location = new System.Drawing.Point(34, 4);
            this.cbxProvince.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxProvince.Name = "cbxProvince";
            this.cbxProvince.Size = new System.Drawing.Size(120, 25);
            this.cbxProvince.TabIndex = 21;
            this.cbxProvince.SelectedIndexChanged += new System.EventHandler(this.cbxProvince_SelectedIndexChanged);
            // 
            // labelProvince
            // 
            this.labelProvince.AutoSize = true;
            this.labelProvince.Location = new System.Drawing.Point(3, 7);
            this.labelProvince.Name = "labelProvince";
            this.labelProvince.Size = new System.Drawing.Size(23, 17);
            this.labelProvince.TabIndex = 20;
            this.labelProvince.Text = "省:";
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(181, 7);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(23, 17);
            this.labelCity.TabIndex = 22;
            this.labelCity.Text = "市:";
            // 
            // cbxCity
            // 
            this.cbxCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCity.FormattingEnabled = true;
            this.cbxCity.Location = new System.Drawing.Point(212, 4);
            this.cbxCity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxCity.Name = "cbxCity";
            this.cbxCity.Size = new System.Drawing.Size(120, 25);
            this.cbxCity.TabIndex = 23;
            this.cbxCity.SelectedIndexChanged += new System.EventHandler(this.cbxCity_SelectedIndexChanged);
            // 
            // cbxCounty
            // 
            this.cbxCounty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCounty.FormattingEnabled = true;
            this.cbxCounty.Location = new System.Drawing.Point(388, 4);
            this.cbxCounty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxCounty.Name = "cbxCounty";
            this.cbxCounty.Size = new System.Drawing.Size(120, 25);
            this.cbxCounty.TabIndex = 25;
            this.cbxCounty.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lableCounty
            // 
            this.lableCounty.AutoSize = true;
            this.lableCounty.Location = new System.Drawing.Point(357, 7);
            this.lableCounty.Name = "lableCounty";
            this.lableCounty.Size = new System.Drawing.Size(23, 17);
            this.lableCounty.TabIndex = 24;
            this.lableCounty.Text = "县:";
            // 
            // PACControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxCounty);
            this.Controls.Add(this.lableCounty);
            this.Controls.Add(this.cbxCity);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.cbxProvince);
            this.Controls.Add(this.labelProvince);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PACControl1";
            this.Size = new System.Drawing.Size(552, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxProvince;
        private System.Windows.Forms.Label labelProvince;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.ComboBox cbxCity;
        private System.Windows.Forms.ComboBox cbxCounty;
        private System.Windows.Forms.Label lableCounty;
    }
}
