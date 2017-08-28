namespace FFireManage.Controls
{
    partial class ImageRemarkForm
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
            this.textBox_Value = new System.Windows.Forms.TextBox();
            this.button_CanCel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Value
            // 
            this.textBox_Value.Location = new System.Drawing.Point(13, 13);
            this.textBox_Value.Multiline = true;
            this.textBox_Value.Name = "textBox_Value";
            this.textBox_Value.Size = new System.Drawing.Size(368, 124);
            this.textBox_Value.TabIndex = 0;
            // 
            // button_CanCel
            // 
            this.button_CanCel.Location = new System.Drawing.Point(306, 143);
            this.button_CanCel.Name = "button_CanCel";
            this.button_CanCel.Size = new System.Drawing.Size(75, 23);
            this.button_CanCel.TabIndex = 1;
            this.button_CanCel.Text = "取消(&C)";
            this.button_CanCel.UseVisualStyleBackColor = true;
            this.button_CanCel.Click += new System.EventHandler(this.button_CanCel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(225, 143);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "确定(&O)";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // ImageRemarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 174);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_CanCel);
            this.Controls.Add(this.textBox_Value);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageRemarkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "描述";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Value;
        private System.Windows.Forms.Button button_CanCel;
        private System.Windows.Forms.Button button_OK;
    }
}