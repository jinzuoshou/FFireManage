using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFireManage.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using Microsoft.Pex.Framework.Generated;

namespace FFireManage.Controls.Tests
{
    [TestClass()]
    public class CoordinatesInputControl1Tests
    {
        [TestMethod()]
        [PexGeneratedBy(typeof(CoordinatesInputControl1Tests))]       
        public void UpdateValueTest()
        {
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                CoordinatesInputControl1 coordinatesInputControl1;
                coordinatesInputControl1 = new CoordinatesInputControl1();
                coordinatesInputControl1.Longitude = 0;
                coordinatesInputControl1.Latitude = 0;
                ((UserControl)coordinatesInputControl1).AutoValidate = AutoValidate.Disable;
                ((UserControl)coordinatesInputControl1).BorderStyle = BorderStyle.None;
                ((ContainerControl)coordinatesInputControl1).ActiveControl = (Control)null;
                ((ScrollableControl)coordinatesInputControl1).AutoScrollPosition = default(Point);
                ((Control)coordinatesInputControl1).Site = (ISite)null;
                ((Control)coordinatesInputControl1).TabIndex = 0;
                disposables.Add((IDisposable)coordinatesInputControl1);
                coordinatesInputControl1.UpdateValue();
                disposables.Dispose();
            }
        }
    }
}