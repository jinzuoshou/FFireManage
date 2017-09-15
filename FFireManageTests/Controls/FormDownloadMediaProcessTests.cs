using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFireManage.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Pex.Framework.Generated;
using FFireManage.Controls.Tests;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace FFireManage.Controls.Tests
{
    [TestClass()]
    public class FormDownloadMediaProcessTest
    {
        [TestMethod()]
        [PexGeneratedBy(typeof(FormDownloadMediaProcessTest))]
        public void UpdateMediaDownloadProgressTest()
        {
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                FormDownloadMediaProcess formDownloadMediaProcess;
                formDownloadMediaProcess = new FormDownloadMediaProcess();
                ((Form)formDownloadMediaProcess).AutoValidate = AutoValidate.Disable;
                ((Form)formDownloadMediaProcess).DialogResult = DialogResult.None;
                ((Form)formDownloadMediaProcess).Icon = (Icon)null;
                ((Form)formDownloadMediaProcess).Owner = (Form)null;
                ((Form)formDownloadMediaProcess).RightToLeftLayout = false;
                ((Form)formDownloadMediaProcess).TabIndex = 0;
                ((ContainerControl)formDownloadMediaProcess).ActiveControl = (Control)null;
                ((ScrollableControl)formDownloadMediaProcess).AutoScrollPosition =
                  default(Point);
                ((Control)formDownloadMediaProcess).Site = (ISite)null;
                disposables.Add((IDisposable)formDownloadMediaProcess);                
                formDownloadMediaProcess.UpdateMediaDownloadProgress((object)null, (object)null);
                disposables.Dispose();
            }
        }
    }
}