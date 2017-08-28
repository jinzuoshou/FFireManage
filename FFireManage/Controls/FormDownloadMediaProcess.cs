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
    public partial class FormDownloadMediaProcess : Form
    {
        public FormDownloadMediaProcess()
        {
            InitializeComponent();
        }

        public void UpdateMediaDownloadProgress(object filePath, object userData)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (filePath == null)
                    return;

                this.progressBar1.Value = Convert.ToInt32(userData);
                this.lbl_processState.Text = string.Format("当前下载进度：{0}%", this.progressBar1.Value);
            }));
           
        }
    }
}
