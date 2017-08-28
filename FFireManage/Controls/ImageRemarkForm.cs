using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FFireManage.Controls
{
    public partial class ImageRemarkForm : Form
    {
        MediaRemarkEventManageClass ImageRemarkEventManageClass = new MediaRemarkEventManageClass();

        public ImageRemarkForm()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (this.textBox_Value.Text.Trim() != "")
            {
                string value = textBox_Value.Text;

                if (value.Length >50)
                {
                    MessageBox.Show(this, "媒体描述请确认在50字以内", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                MediaRemarkEventManageClass.image_sremark = this.textBox_Value.Text.Trim();

                ImageRemarkEventManageClass.SendImageRemark(this, null);

                this.DialogResult = DialogResult.OK;
            }            
        }

        private void button_CanCel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
