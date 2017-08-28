using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage.Controls
{
    public class MediaRemarkEventManageClass
    {
        public event EventHandler OnImageRemark;

        public static string image_sremark;

        public void SendImageRemark(object send, EventArgs e)
        {
            if (OnImageRemark != null)
            {
                OnImageRemark(this, null);
            }
        }
    }
}
