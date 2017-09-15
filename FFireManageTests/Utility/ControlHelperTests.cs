using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFireManage.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Pex.Framework.Generated;
using System.Globalization;
using System.Drawing;

namespace FFireManage.Utility.Tests
{
    [TestClass()]
    public class ControlHelperTests
    {
        [TestMethod()]
        public void SetValueTest()
        {
            bool b;
            ListBox listBox;
            Control control;
            NumericUpDown numericUpDown;
            // 测试用例1
            b = ControlHelper.SetValue((Control)null, (object)null);
            // 测试用例2
            object s0 = new object();
            b = ControlHelper.SetValue((Control)null, s0);
            // 测试用例3
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                listBox = new ListBox();
                listBox.BorderStyle = BorderStyle.None;
                listBox.ColumnWidth = 0;
                listBox.UseCustomTabOffsets = false;
                listBox.DrawMode = DrawMode.Normal;
                listBox.HorizontalExtent = 0;
                listBox.HorizontalScrollbar = false;
                listBox.IntegralHeight = false;
                listBox.ItemHeight = 1;
                listBox.MultiColumn = false;
                listBox.ScrollAlwaysVisible = false;
                listBox.SelectedIndex = -1;
                listBox.SelectionMode = SelectionMode.None;
                listBox.Sorted = false;
                listBox.Text = (string)null;
                listBox.TopIndex = 0;
                listBox.UseTabStops = false;
                listBox.Padding = default(Padding);
                ((ListControl)listBox).DataSource = (object)null;
                ((ListControl)listBox).FormatInfo = (IFormatProvider)null;
                ((ListControl)listBox).FormattingEnabled = false;
                ((ListControl)listBox).ValueMember = (string)null;
                ((Control)listBox).Dock = DockStyle.None;
                ((Control)listBox).Site = (ISite)null;
                ((Control)listBox).TabIndex = 0;
                disposables.Add((IDisposable)listBox);
                b = ControlHelper.SetValue((Control)listBox, s0);
                disposables.Dispose();
            }
            // 测试用例4
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                listBox = new ListBox();
                listBox.BorderStyle = BorderStyle.None;
                listBox.ColumnWidth = 0;
                listBox.UseCustomTabOffsets = false;
                listBox.DrawMode = DrawMode.Normal;
                listBox.HorizontalExtent = 0;
                listBox.HorizontalScrollbar = false;
                listBox.IntegralHeight = false;
                listBox.ItemHeight = 1;
                listBox.MultiColumn = false;
                listBox.ScrollAlwaysVisible = false;
                listBox.SelectedIndex = -1;
                listBox.SelectionMode = SelectionMode.None;
                listBox.Sorted = false;
                listBox.Text = (string)null;
                listBox.TopIndex = 0;
                listBox.UseTabStops = false;
                listBox.Padding = default(Padding);
                ((ListControl)listBox).DataSource = (object)null;
                ((ListControl)listBox).FormatInfo = (IFormatProvider)null;
                ((ListControl)listBox).FormattingEnabled = false;
                ((ListControl)listBox).ValueMember = (string)null;
                ((Control)listBox).Dock = DockStyle.Top;
                ((Control)listBox).Site = (ISite)null;
                ((Control)listBox).TabIndex = 0;
                disposables.Add((IDisposable)listBox);
                b = ControlHelper.SetValue((Control)listBox, s0);
                disposables.Dispose();
            }
            // 测试用例5
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {               
                listBox = new ListBox();
                listBox.BorderStyle = BorderStyle.None;
                listBox.ColumnWidth = 0;
                listBox.UseCustomTabOffsets = false;
                listBox.DrawMode = DrawMode.Normal;
                listBox.HorizontalExtent = 0;
                listBox.HorizontalScrollbar = false;
                listBox.IntegralHeight = false;
                listBox.ItemHeight = 1;
                listBox.MultiColumn = false;
                listBox.ScrollAlwaysVisible = false;
                listBox.SelectedIndex = -1;
                listBox.SelectionMode = SelectionMode.None;
                listBox.Sorted = false;
                listBox.Text = (string)null;
                listBox.TopIndex = 0;
                listBox.UseTabStops = false;
                listBox.Padding = default(Padding);
                ((ListControl)listBox).DataSource = (object)null;
                ((ListControl)listBox).FormatInfo = (IFormatProvider)null;
                ((ListControl)listBox).FormattingEnabled = true;
                ((ListControl)listBox).ValueMember = (string)null;
                ((Control)listBox).Dock = DockStyle.None;
                ((Control)listBox).Site = (ISite)null;
                ((Control)listBox).TabIndex = 0;
                disposables.Add((IDisposable)listBox);
                b = ControlHelper.SetValue((Control)listBox, s0);
                disposables.Dispose();
            }
            // 测试用例6
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                listBox = new ListBox();
                listBox.BorderStyle = BorderStyle.None;
                listBox.ColumnWidth = 0;
                listBox.UseCustomTabOffsets = false;
                listBox.DrawMode = DrawMode.Normal;
                listBox.HorizontalExtent = 0;
                listBox.HorizontalScrollbar = false;
                listBox.IntegralHeight = false;
                listBox.ItemHeight = 1;
                listBox.MultiColumn = false;
                listBox.ScrollAlwaysVisible = false;
                listBox.SelectedIndex = -1;
                listBox.SelectionMode = SelectionMode.One;
                listBox.Sorted = false;
                listBox.Text = (string)null;
                listBox.TopIndex = 0;
                listBox.UseTabStops = false;
                listBox.Padding = default(Padding);
                ((ListControl)listBox).DataSource = (object)null;
                ((ListControl)listBox).FormatInfo = (IFormatProvider)null;
                ((ListControl)listBox).FormattingEnabled = false;
                ((ListControl)listBox).ValueMember = (string)null;
                ((Control)listBox).Dock = DockStyle.None;
                ((Control)listBox).Site = (ISite)null;
                ((Control)listBox).TabIndex = 0;
                disposables.Add((IDisposable)listBox);
                b = ControlHelper.SetValue((Control)listBox, s0);
                disposables.Dispose();
            }
            // 测试用例7
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                listBox = new ListBox();
                listBox.BorderStyle = BorderStyle.None;
                listBox.ColumnWidth = 0;
                listBox.UseCustomTabOffsets = false;
                listBox.DrawMode = DrawMode.Normal;
                listBox.HorizontalExtent = 0;
                listBox.HorizontalScrollbar = false;
                listBox.IntegralHeight = false;
                listBox.ItemHeight = 1;
                listBox.MultiColumn = false;
                listBox.ScrollAlwaysVisible = false;
                listBox.SelectedIndex = -1;
                listBox.SelectionMode = SelectionMode.One;
                listBox.Sorted = false;
                listBox.Text = (string)null;
                listBox.TopIndex = 0;
                listBox.UseTabStops = false;
                listBox.Padding = default(Padding);
                ((ListControl)listBox).DataSource = (object)null;
                ((ListControl)listBox).FormatInfo = NumberFormatInfo.CurrentInfo;
                ((ListControl)listBox).FormattingEnabled = false;
                ((ListControl)listBox).ValueMember = (string)null;
                ((Control)listBox).Dock = DockStyle.None;
                ((Control)listBox).Site = (ISite)null;
                ((Control)listBox).TabIndex = 0;
                disposables.Add((IDisposable)listBox);
                b = ControlHelper.SetValue((Control)listBox, s0);
                disposables.Dispose();
            }
            // 测试用例8
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                listBox = new ListBox();
                listBox.BorderStyle = BorderStyle.None;
                listBox.ColumnWidth = 0;
                listBox.UseCustomTabOffsets = false;
                listBox.DrawMode = DrawMode.Normal;
                listBox.HorizontalExtent = 0;
                listBox.HorizontalScrollbar = false;
                listBox.IntegralHeight = false;
                listBox.ItemHeight = 1;
                listBox.MultiColumn = false;
                listBox.ScrollAlwaysVisible = false;
                listBox.SelectedIndex = -1;
                listBox.SelectionMode = SelectionMode.None;
                listBox.Sorted = false;
                listBox.Text = "\0";
                listBox.TopIndex = 0;
                listBox.UseTabStops = false;
                listBox.Padding = default(Padding);
                ((ListControl)listBox).DataSource = (object)null;
                ((ListControl)listBox).FormatInfo = (IFormatProvider)null;
                ((ListControl)listBox).FormattingEnabled = false;
                ((ListControl)listBox).ValueMember = (string)null;
                ((Control)listBox).Dock = DockStyle.None;
                ((Control)listBox).Site = (ISite)null;
                ((Control)listBox).TabIndex = 0;
                disposables.Add((IDisposable)listBox);
                b = ControlHelper.SetValue((Control)listBox, s0);
                disposables.Dispose();
            }
            // 测试用例9
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                object[] os = new object[0];
                listBox = new ListBox();
                listBox.BorderStyle = BorderStyle.None;
                listBox.ColumnWidth = 0;
                listBox.UseCustomTabOffsets = false;
                listBox.DrawMode = DrawMode.Normal;
                listBox.HorizontalExtent = 0;
                listBox.HorizontalScrollbar = false;
                listBox.IntegralHeight = false;
                listBox.ItemHeight = 1;
                listBox.MultiColumn = false;
                listBox.ScrollAlwaysVisible = false;
                listBox.SelectedIndex = -1;
                listBox.SelectionMode = SelectionMode.None;
                listBox.Sorted = false;
                listBox.Text = (string)null;
                listBox.TopIndex = 0;
                listBox.UseTabStops = false;
                listBox.Padding = default(Padding);
                ((ListControl)listBox).DataSource = (object)os;
                ((ListControl)listBox).FormatInfo = (IFormatProvider)null;
                ((ListControl)listBox).FormattingEnabled = false;
                ((ListControl)listBox).ValueMember = (string)null;
                ((Control)listBox).Dock = DockStyle.None;
                ((Control)listBox).Site = (ISite)null;
                ((Control)listBox).TabIndex = 0;
                disposables.Add((IDisposable)listBox);
                b = ControlHelper.SetValue((Control)listBox, s0);
                disposables.Dispose();
            }
            // 测试用例10
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                listBox = new ListBox();
                listBox.BorderStyle = BorderStyle.None;
                listBox.ColumnWidth = 0;
                listBox.UseCustomTabOffsets = false;
                listBox.DrawMode = DrawMode.Normal;
                listBox.HorizontalExtent = 0;
                listBox.HorizontalScrollbar = true;
                listBox.IntegralHeight = false;
                listBox.ItemHeight = 1;
                listBox.MultiColumn = false;
                listBox.ScrollAlwaysVisible = false;
                listBox.SelectedIndex = -1;
                listBox.SelectionMode = SelectionMode.One;
                listBox.Sorted = false;
                listBox.Text = (string)null;
                listBox.TopIndex = 0;
                listBox.UseTabStops = false;
                listBox.Padding = default(Padding);
                ((ListControl)listBox).DataSource = (object)null;
                ((ListControl)listBox).FormatInfo = (IFormatProvider)null;
                ((ListControl)listBox).FormattingEnabled = false;
                ((ListControl)listBox).ValueMember = (string)null;
                ((Control)listBox).Dock = DockStyle.None;
                ((Control)listBox).Site = (ISite)null;
                ((Control)listBox).TabIndex = 0;
                disposables.Add((IDisposable)listBox);
                b = ControlHelper.SetValue((Control)listBox, s0);
                disposables.Dispose();
            }
            // 测试用例11
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                control = new Control();
                control.AllowDrop = false;
                control.Dock = DockStyle.None;
                control.Site = (ISite)null;
                control.TabIndex = 0;
                disposables.Add((IDisposable)control);
                b = ControlHelper.SetValue(control, s0);
                disposables.Dispose();
            }
            // 测试用例12
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {             
                control = new Control();
                control.AllowDrop = true;
                control.Dock = DockStyle.None;
                control.Site = (ISite)null;
                control.TabIndex = 0;
                disposables.Add((IDisposable)control);
                b = ControlHelper.SetValue(control, s0);
                disposables.Dispose();
            }
            // 测试用例13
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                numericUpDown = new NumericUpDown();
                ((ISupportInitialize)numericUpDown).BeginInit();
                numericUpDown.DecimalPlaces = 0;
                numericUpDown.Hexadecimal = false;
                numericUpDown.Padding = default(Padding);
                numericUpDown.Text = (string)null;
                numericUpDown.ThousandsSeparator = false;
                ((UpDownBase)numericUpDown).AutoScrollMargin = default(Size);
                ((UpDownBase)numericUpDown).BorderStyle = BorderStyle.None;
                ((UpDownBase)numericUpDown).UpDownAlign = LeftRightAlignment.Left;
                ((ContainerControl)numericUpDown).AutoScaleMode = AutoScaleMode.None;
                ((ContainerControl)numericUpDown).AutoValidate = AutoValidate.Disable;
                ((ContainerControl)numericUpDown).ActiveControl = (Control)null;
                ((ScrollableControl)numericUpDown).AutoScrollPosition = default(Point);
                ((Control)numericUpDown).Site = (ISite)null;
                ((Control)numericUpDown).TabIndex = 0;
                numericUpDown.DownButton();
                ((ISupportInitialize)numericUpDown).EndInit();
                disposables.Add((IDisposable)numericUpDown);
                b = ControlHelper.SetValue((Control)numericUpDown, s0);
                disposables.Dispose();
            }
            // 测试用例14
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                numericUpDown = new NumericUpDown();
                ((ISupportInitialize)numericUpDown).BeginInit();
                numericUpDown.DecimalPlaces = 0;
                numericUpDown.Hexadecimal = false;
                numericUpDown.Padding = default(Padding);
                numericUpDown.Text = (string)null;
                numericUpDown.ThousandsSeparator = false;
                ((UpDownBase)numericUpDown).AutoScrollMargin = default(Size);
                ((UpDownBase)numericUpDown).BorderStyle = BorderStyle.None;
                ((UpDownBase)numericUpDown).UpDownAlign = LeftRightAlignment.Left;
                ((ContainerControl)numericUpDown).AutoScaleMode = AutoScaleMode.None;
                ((ContainerControl)numericUpDown).AutoValidate = AutoValidate.Disable;
                ((ContainerControl)numericUpDown).ActiveControl = (Control)null;
                ((ScrollableControl)numericUpDown).AutoScrollPosition = default(Point);
                ((Control)numericUpDown).Site = (ISite)null;
                ((Control)numericUpDown).TabIndex = 0;
                numericUpDown.DownButton();
                ((ISupportInitialize)numericUpDown).EndInit();
                disposables.Add((IDisposable)numericUpDown);
                object box = (object)(default(decimal));
                b = ControlHelper.SetValue((Control)numericUpDown, box);
                disposables.Dispose();
            }
            // 测试用例15
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                numericUpDown = new NumericUpDown();
                ((ISupportInitialize)numericUpDown).BeginInit();
                numericUpDown.DecimalPlaces = 0;
                numericUpDown.Hexadecimal = false;
                numericUpDown.Padding = default(Padding);
                numericUpDown.Text = (string)null;
                numericUpDown.ThousandsSeparator = false;
                ((UpDownBase)numericUpDown).AutoScrollMargin = default(Size);
                ((UpDownBase)numericUpDown).BorderStyle = BorderStyle.None;
                ((UpDownBase)numericUpDown).UpDownAlign = LeftRightAlignment.Left;
                ((ContainerControl)numericUpDown).AutoScaleMode = AutoScaleMode.None;
                ((ContainerControl)numericUpDown).AutoValidate = AutoValidate.Disable;
                ((ContainerControl)numericUpDown).ActiveControl = (Control)null;
                ((ScrollableControl)numericUpDown).AutoScrollPosition = default(Point);
                ((Control)numericUpDown).Site = (ISite)null;
                ((Control)numericUpDown).TabIndex = 0;
                numericUpDown.DownButton();
                ((ISupportInitialize)numericUpDown).EndInit();
                disposables.Add((IDisposable)numericUpDown);
                object box = (object)(default(decimal));
                PexSafeHelpers.AssignBoxedValue<decimal>
                    (box, -76819052936496198642298613574e-19M);
                b = ControlHelper.SetValue((Control)numericUpDown, box);
                disposables.Dispose();
            }
            // 测试用例16
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                numericUpDown = new NumericUpDown();
                ((ISupportInitialize)numericUpDown).BeginInit();
                numericUpDown.DecimalPlaces = 0;
                numericUpDown.Hexadecimal = false;
                numericUpDown.Padding = default(Padding);
                numericUpDown.Text = "0";
                numericUpDown.ThousandsSeparator = false;
                ((UpDownBase)numericUpDown).AutoScrollMargin = default(Size);
                ((UpDownBase)numericUpDown).BorderStyle = BorderStyle.None;
                ((UpDownBase)numericUpDown).UpDownAlign = LeftRightAlignment.Left;
                ((ContainerControl)numericUpDown).AutoScaleMode = AutoScaleMode.None;
                ((ContainerControl)numericUpDown).AutoValidate = AutoValidate.Disable;
                ((ContainerControl)numericUpDown).ActiveControl = (Control)null;
                ((ScrollableControl)numericUpDown).AutoScrollPosition = default(Point);
                ((Control)numericUpDown).Site = (ISite)null;
                ((Control)numericUpDown).TabIndex = 0;
                numericUpDown.DownButton();
                ((ISupportInitialize)numericUpDown).EndInit();
                disposables.Add((IDisposable)numericUpDown);
                b = ControlHelper.SetValue((Control)numericUpDown, s0);
                disposables.Dispose();
            }
            // 测试用例17
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                numericUpDown = new NumericUpDown();
                ((ISupportInitialize)numericUpDown).BeginInit();
                numericUpDown.DecimalPlaces = 0;
                numericUpDown.Hexadecimal = true;
                numericUpDown.Padding = default(Padding);
                numericUpDown.Text = "0";
                numericUpDown.ThousandsSeparator = false;
                ((UpDownBase)numericUpDown).AutoScrollMargin = default(Size);
                ((UpDownBase)numericUpDown).BorderStyle = BorderStyle.None;
                ((UpDownBase)numericUpDown).UpDownAlign = LeftRightAlignment.Left;
                ((ContainerControl)numericUpDown).AutoScaleMode = AutoScaleMode.None;
                ((ContainerControl)numericUpDown).AutoValidate = AutoValidate.Disable;
                ((ContainerControl)numericUpDown).ActiveControl = (Control)null;
                ((ScrollableControl)numericUpDown).AutoScrollPosition = default(Point);
                ((Control)numericUpDown).Site = (ISite)null;
                ((Control)numericUpDown).TabIndex = 0;
                numericUpDown.DownButton();
                ((ISupportInitialize)numericUpDown).EndInit();
                disposables.Add((IDisposable)numericUpDown);
                b = ControlHelper.SetValue((Control)numericUpDown, s0);
                disposables.Dispose();
            }
            // 测试用例18
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {             
                numericUpDown = new NumericUpDown();
                ((ISupportInitialize)numericUpDown).BeginInit();
                numericUpDown.DecimalPlaces = 0;
                numericUpDown.Hexadecimal = false;
                numericUpDown.Padding = default(Padding);
                numericUpDown.Text = (string)null;
                numericUpDown.ThousandsSeparator = false;
                ((UpDownBase)numericUpDown).AutoScrollMargin = default(Size);
                ((UpDownBase)numericUpDown).BorderStyle = BorderStyle.None;
                ((UpDownBase)numericUpDown).UpDownAlign = LeftRightAlignment.Left;
                ((ContainerControl)numericUpDown).AutoScaleMode = AutoScaleMode.None;
                ((ContainerControl)numericUpDown).AutoValidate = AutoValidate.Disable;
                ((ContainerControl)numericUpDown).ActiveControl = (Control)null;
                ((ScrollableControl)numericUpDown).AutoScrollPosition = default(Point);
                ((Control)numericUpDown).Site = (ISite)null;
                ((Control)numericUpDown).TabIndex = 0;
                numericUpDown.DownButton();
                ((ISupportInitialize)numericUpDown).EndInit();
                disposables.Add((IDisposable)numericUpDown);
                object box = (object)(default(decimal));
                PexSafeHelpers.AssignBoxedValue<decimal>(box, decimal.MaxValue);
                b = ControlHelper.SetValue((Control)numericUpDown, box);
                disposables.Dispose();
            }
            // 测试用例19
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {               
                numericUpDown = new NumericUpDown();
                ((ISupportInitialize)numericUpDown).BeginInit();
                numericUpDown.DecimalPlaces = 0;
                numericUpDown.Hexadecimal = false;
                numericUpDown.Padding = default(Padding);
                numericUpDown.Text = (string)null;
                numericUpDown.ThousandsSeparator = false;
                ((UpDownBase)numericUpDown).AutoScrollMargin = default(Size);
                ((UpDownBase)numericUpDown).BorderStyle = BorderStyle.Fixed3D;
                ((UpDownBase)numericUpDown).UpDownAlign = LeftRightAlignment.Left;
                ((ContainerControl)numericUpDown).AutoScaleMode = AutoScaleMode.Font;
                ((ContainerControl)numericUpDown).AutoValidate = AutoValidate.Disable;
                ((ContainerControl)numericUpDown).ActiveControl = (Control)null;
                ((ScrollableControl)numericUpDown).AutoScrollPosition = default(Point);
                ((Control)numericUpDown).Site = (ISite)null;
                ((Control)numericUpDown).TabIndex = 0;
                numericUpDown.DownButton();
                ((ISupportInitialize)numericUpDown).EndInit();
                disposables.Add((IDisposable)numericUpDown);
                b = ControlHelper.SetValue((Control)numericUpDown, s0);
                disposables.Dispose();
            }
            // 测试用例20
            using (PexDisposableContext disposables = PexDisposableContext.Create())
            {
                numericUpDown = new NumericUpDown();
                ((ISupportInitialize)numericUpDown).BeginInit();
                numericUpDown.DecimalPlaces = 0;
                numericUpDown.Hexadecimal = false;
                numericUpDown.Padding = default(Padding);
                numericUpDown.Text = (string)null;
                numericUpDown.ThousandsSeparator = false;
                ((UpDownBase)numericUpDown).AutoScrollMargin = default(Size);
                ((UpDownBase)numericUpDown).BorderStyle = BorderStyle.None;
                ((UpDownBase)numericUpDown).UpDownAlign = LeftRightAlignment.Left;
                ((ContainerControl)numericUpDown).AutoScaleMode = AutoScaleMode.None;
                ((ContainerControl)numericUpDown).AutoValidate = AutoValidate.Disable;
                ((ContainerControl)numericUpDown).ActiveControl = (Control)null;
                ((ScrollableControl)numericUpDown).AutoScrollPosition = default(Point);
                ((Control)numericUpDown).Site = (ISite)null;
                ((Control)numericUpDown).TabIndex = 0;
                numericUpDown.DownButton();
                ((ISupportInitialize)numericUpDown).EndInit();
                disposables.Add((IDisposable)numericUpDown);
                object box = (object)(default(decimal));
                PexSafeHelpers.AssignBoxedValue<decimal>(box, 1e-1M);
                b = ControlHelper.SetValue((Control)numericUpDown, box);
                disposables.Dispose();
            }
        }
    }
}