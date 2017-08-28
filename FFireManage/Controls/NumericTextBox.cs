using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FFireManage.Controls
{
    public partial class NumericTextBox : TextBox
    {
        private const int WM_CHAR = 0x0102;
        private const int WM_PASTE = 0x0302;

        private int _DecimalNumber = 0;
        /// <summary>
        /// 小数位数
        /// </summary>
        public int DecimalNumber
        {
            get { return _DecimalNumber; }
            set { _DecimalNumber = value; }
        }

        public NumericTextBox()
        {
            InitializeComponent();
            this.Text = "0";
        }

        protected override void WndProc(ref   Message m)
        {
            switch (m.Msg)
            {
                case WM_CHAR:
                    bool isSign = ((int)m.WParam == 45);
                    bool isNum = ((int)m.WParam >= 48) && ((int)m.WParam <= 57);
                    bool isBack = (int)m.WParam == (int)Keys.Back;
                    bool isDelete = (int)m.WParam == (int)Keys.Delete;//实际上这是一个 "."键 
                    bool isCtr = ((int)m.WParam == 24) || ((int)m.WParam == 22) || ((int)m.WParam == 26) || ((int)m.WParam == 3);
                    bool isEnter = ((int)m.WParam == 13);

                    if (isNum || isBack || isCtr)
                    {
                        string tValue = this.Text.Trim();
                        if (isNum && this.Text.Trim() == "0")
                            this.Text = "";
                        base.WndProc(ref   m);
                        if (isBack && this.Text.Trim() == "")
                            this.Text = "0";
                        if (isNum && this.Text.IndexOf(".") >= 0 && this.Text.Substring(this.Text.IndexOf(".") + 1).Length > DecimalNumber)
                        {
                            this.Text = tValue;
                        }
                    }
                    if (isSign)
                    {
                        if (((this.SelectionStart != 0)))
                        {
                            break;
                        }
                        base.WndProc(ref   m);
                        break;
                    }
                    if (isDelete)
                    {
                        if (DecimalNumber == 0)
                            break;

                        if (this.Text.IndexOf(".") < 0)
                        {
                            base.WndProc(ref   m);
                        }
                    }
                    if ((int)m.WParam == 1)
                    {
                        this.SelectAll();
                    }
                    break;
                case WM_PASTE:
                    IDataObject iData = Clipboard.GetDataObject();//取剪贴板对象 

                    if (iData.GetDataPresent(DataFormats.Text))   //判断是否是Text 
                    {
                        string str = (string)iData.GetData(DataFormats.Text);//取数据 

                        if (IsNumeric(str))
                        {
                            string tValue = this.Text.Trim();
                            if (!(this.Text.IndexOf(".") >= 0 && str.IndexOf(".") >= 0))
                            {
                                base.WndProc(ref   m);
                            }
                            if ((DecimalNumber == 0 && this.Text.IndexOf(".") >= 0)
                                || (this.Text.Substring(this.Text.IndexOf(".") + 1).Length > DecimalNumber))
                            {
                                this.Text = tValue;
                            }

                            break;
                        }
                    }
                    m.Result = (IntPtr)0;//不可以粘贴 
                    break;
                default:
                    base.WndProc(ref   m);
                    break;
            }
        }
        ///   <summary> 
        ///   是否数字类型 
        ///   </summary> 
        ///   <param   name= "str "> </param> 
        ///   <returns> </returns> 
        private bool IsNumeric(string str)
        {
            try
            {
                double db = Convert.ToDouble(str);
                return true;
            }
            catch
            {
                return false;
            }
        } 
    }
}
