using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace FFireManage.Controls
{
    public partial class IPTextBox : UserControl
    {
        private Color _backColor;
        private Color _borderColor = Color.FromArgb(0, 60, 0x74);

        private InputType _inputType;
        private Color _orgColor;
        private bool _showErrorFlag;
        private string _text = "";
        private HorizontalAlignment _textAlign = HorizontalAlignment.Center;

        private BorderStyle _borderStyle = BorderStyle.Fixed3D;

        public IPTextBox()
        {
            InitializeComponent();

            this.BackColor = SystemColors.Window;
            this._orgColor = this.BackColor;
        }

        private void IPTextBox_Validated(object sender, EventArgs e)
        {
            this.errorProvider.SetError(this, "");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.MaskIpAddr(this.textBox1, e);
        }


        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.MaskIpAddr(this.textBox2, e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.MaskIpAddr(this.textBox3, e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.MaskIpAddr(this.textBox4, e);
        }

        private void MaskIpAddr(System.Windows.Forms.TextBox textBox, KeyPressEventArgs e)
        {
            int length = textBox.Text.Length;
            this.errorProvider.SetError(this, "");
            if ((char.IsDigit(e.KeyChar) || (e.KeyChar == '.')) || (e.KeyChar == '\b'))
            {
                if (e.KeyChar == '\b')
                {
                    if (textBox.Name == "textBox1")
                    {
                        bool flag2 = textBox.Text == "";
                    }
                    if ((textBox.Name == "textBox2") && (textBox.Text == ""))
                    {
                        this.textBox1.Focus();
                        this.textBox1.SelectionStart = this.textBox1.Text.Length;
                    }
                    if ((textBox.Name == "textBox3") && (textBox.Text == ""))
                    {
                        this.textBox2.Focus();
                        this.textBox2.SelectionStart = this.textBox2.Text.Length;
                    }
                    if ((textBox.Name == "textBox4") && (textBox.Text == ""))
                    {
                        this.textBox3.Focus();
                        this.textBox3.SelectionStart = this.textBox3.Text.Length;
                    }
                    e.Handled = false;
                }
                else
                {
                    if ((length == 2) && (e.KeyChar != '.'))
                    {
                        int num2 = 0xe9;
                        if (this._inputType == InputType.Gateway)
                        {
                            num2 = 0xff;
                        }
                        string s = textBox.Text + e.KeyChar;
                        if (textBox.Name == "textBox1")
                        {
                            if (int.Parse(s) > num2)
                            {
                                textBox.Text = num2.ToString();
                                textBox.Focus();
                                if (this._showErrorFlag)
                                {
                                    this.errorProvider.SetError(this, "请指定一个介于 1 和 223 之间的数值。");
                                }
                                else
                                {
                                    MessageBox.Show(s + " 不是一个有效项目。请指定一个介于 1 和 223 之间的数值。", "出错", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                e.Handled = true;
                                return;
                            }
                            this.textBox2.Focus();
                            this.textBox2.SelectAll();
                        }
                        else if (textBox.Name == "textBox2")
                        {
                            if (int.Parse(s) > 0xff)
                            {
                                textBox.Text = "255";
                                textBox.Focus();
                                if (this._showErrorFlag)
                                {
                                    this.errorProvider.SetError(this, "请指定一个介于 1 和 255 之间的数值。");
                                }
                                else
                                {
                                    MessageBox.Show(s + " 不是一个有效项目。请指定一个介于 1 和 255 之间的数值。", "出错", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                e.Handled = true;
                                return;
                            }
                            this.textBox3.Focus();
                            this.textBox3.SelectAll();
                        }
                        else if (textBox.Name == "textBox3")
                        {
                            if (int.Parse(s) > 0xff)
                            {
                                textBox.Text = "255";
                                textBox.Focus();
                                if (this._showErrorFlag)
                                {
                                    this.errorProvider.SetError(this, "请指定一个介于 1 和 255 之间的数值。");
                                }
                                else
                                {
                                    MessageBox.Show(s + " 不是一个有效项目。请指定一个介于 1 和 255 之间的数值。", "出错", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                e.Handled = true;
                                return;
                            }
                            this.textBox4.Focus();
                            this.textBox4.SelectAll();
                        }
                        else if ((textBox.Name == "textBox4") && (int.Parse(s) > 0xff))
                        {
                            textBox.Text = "255";
                            textBox.Focus();
                            if (this._showErrorFlag)
                            {
                                this.errorProvider.SetError(this, "请指定一个介于 1 和 255 之间的数值。");
                            }
                            else
                            {
                                MessageBox.Show(s + " 不是一个有效项目。请指定一个介于 1 和 255 之间的数值。", "出错", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            e.Handled = true;
                            return;
                        }
                    }
                    if (e.KeyChar == '.')
                    {
                        if ((textBox.Name == "textBox1") && (textBox.Text != ""))
                        {
                            this.textBox2.Focus();
                            this.textBox2.SelectAll();
                        }
                        if ((textBox.Name == "textBox2") && (textBox.Text != ""))
                        {
                            this.textBox3.Focus();
                            this.textBox3.SelectAll();
                        }
                        if ((textBox.Name == "textBox3") && (textBox.Text != ""))
                        {
                            this.textBox4.Focus();
                            this.textBox4.SelectAll();
                        }
                        if (textBox.Name == "textBox4")
                        {
                            bool flag1 = textBox.Text != "";
                        }
                        e.Handled = true;
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }




        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string text = this.textBox1.Text;
            if (((this._inputType == InputType.IPAddress) && (text.Trim() != "")) && (text == "0"))
            {
                string str2 = "0 不是一个有效项目。请指定一个介于 1 和 223 之间的数值。";
                if (this._showErrorFlag)
                {
                    this.errorProvider.SetError(this, str2);
                }
                else
                {
                    MessageBox.Show(str2, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.textBox1.Text = "1";
            }
        }



        private bool VerifyForIP(System.Windows.Forms.TextBox box)
        {
            bool flag = true;
            int num = int.Parse(box.Text.Trim());
            return (((num >= 0) && (num <= 0xff)) && flag);
        }

        [DefaultValue(typeof(Color), "Window")]
        public override Color BackColor
        {
            get
            {
                return this._backColor;
            }
            set
            {
                this._backColor = value;
                base.BackColor = value;
                this.SetBackColor(this._backColor);
            }
        }

        [DefaultValue(typeof(Color), "0, 60, 116"), Description("获取或设置边框颜色")]
        public Color BorderColor
        {
            get
            {
                return this._borderColor;
            }
            set
            {
                this._borderColor = value;
                base.Invalidate();
            }
        }

        [Description("边框的样式"), DefaultValue(typeof(System.Windows.Forms.BorderStyle), "Fixed3D")]
        public new System.Windows.Forms.BorderStyle BorderStyle
        {
            get
            {
                return this._borderStyle;
            }
            set
            {
                this._borderStyle = value;
                base.Invalidate();
            }
        }

        [Browsable(false)]
        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
            }
        }

        [Description("选择输入的类型"), DefaultValue(typeof(InputType), "IPAddress")]
        public InputType InputType
        {
            get
            {
                return this._inputType;
            }
            set
            {
                this._inputType = value;
            }
        }

        [Browsable(false)]
        public bool IsValidate
        {
            get
            {
                return this.isValidateValue();
            }
        }

        [DefaultValue(false), Description("获取或设置是否显示出错标志")]
        public bool ShowErrorFlag
        {
            get
            {
                return this._showErrorFlag;
            }
            set
            {
                this._showErrorFlag = value;
            }
        }

        [Description("获取或设置文本的对齐方式"), DefaultValue(typeof(HorizontalAlignment), "Center")]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return this._textAlign;
            }
            set
            {
                this._textAlign = value;
                if (this._textAlign == HorizontalAlignment.Left)
                {
                    this.panel1.Dock = DockStyle.Left;
                }
                else if (this._textAlign == HorizontalAlignment.Right)
                {
                    this.panel1.Dock = DockStyle.Right;
                }
                else
                {
                    this.panel1.Dock = DockStyle.None;
                    this.SetCenter();
                }
                this.Refresh();
            }
        }

        [Description("IP 地址的值"), Browsable(true), DefaultValue("")]
        public string Value
        {
            get
            {
                if (((this.textBox1.Text == "") || (this.textBox2.Text == "")) || ((this.textBox3.Text == "") || (this.textBox4.Text == "")))
                {
                    this._text = "";
                    return this._text;
                }
                this._text = Convert.ToInt32(this.textBox1.Text).ToString() + "." + Convert.ToInt32(this.textBox2.Text).ToString() + "." + Convert.ToInt32(this.textBox3.Text).ToString() + "." + Convert.ToInt32(this.textBox4.Text).ToString();
                return this._text;
            }
            set
            {
                this._text = value;
                if ((this._text != null) && (this._text != ""))
                {
                    string[] nums = value.Split(new char[] { '.' });
                    if ((nums.Length < 4) && this._showErrorFlag)
                    {
                        this.errorProvider.SetError(this, "指定了一个无效的 IP 地址!");
                    }
                    this.SetTextBox(nums);
                }
                else
                {
                    this._text = "";
                    this.SetIPEmptyValue();
                }
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (!base.DesignMode)
            {
                if (base.Enabled)
                {
                    this.BackColor = this._orgColor;
                }
                else
                {
                    this._orgColor = this.BackColor;
                    this.BackColor = SystemColors.Control;
                }
            }
            base.OnEnabledChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (this.BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
            {
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1), this._borderColor, ButtonBorderStyle.Solid);
            }
            else if (VisualStyleRenderer.IsSupported && Application.RenderWithVisualStyles)
            {
                ControlPaint.DrawVisualStyleBorder(e.Graphics, new Rectangle(0, 0, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1));
            }
            else
            {
                ControlPaint.DrawBorder3D(e.Graphics, new Rectangle(0, 0, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1), Border3DStyle.Sunken);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            if (base.Width < 140)
            {
                base.Width = 140;
            }
            base.Height = 0x15;
            base.OnResize(e);
            this.SetCenter();
            base.Invalidate();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            if (this._showErrorFlag)
            {
                if (this.isValidateValue())
                {
                    this.errorProvider.SetError(this, "");
                }
                else
                {
                    this.errorProvider.SetError(this, "无效的 IP 地址。");
                }
            }
            base.OnValidating(e);
        }

        private void SetBackColor(Color color)
        {
            this.panel1.BackColor = color;
            this.textBox1.BackColor = color;
            this.label1.BackColor = color;
            this.textBox2.BackColor = color;
            this.label2.BackColor = color;
            this.textBox3.BackColor = color;
            this.label3.BackColor = color;
            this.textBox4.BackColor = color;
        }

        private void SetCenter()
        {
            int num = (((base.Width - this.panel1.Width) - base.Padding.Left) - base.Padding.Right) / 2;
            int num2 = 1;
            if (!VisualStyleRenderer.IsSupported || !Application.RenderWithVisualStyles)
            {
                num2 = 2;
            }
            if (num < num2)
            {
                num = num2;
            }
            this.panel1.Left = num;
            this.panel1.Top = num2;
        }

        private void SetIPEmptyValue()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
        }

        private void SetTextBox(string[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                string str = nums[i];
                if (IsNumeric(str))
                {
                    int num2 = int.Parse(str);
                    if (i == 0)
                    {
                        if (this._inputType == InputType.IPAddress)
                        {
                            if (((num2 < 1) && (num2 > 0xe9)) && this._showErrorFlag)
                            {
                                this.errorProvider.SetError(this, "无效的 IP 地址。");
                            }
                        }
                        else if (((num2 < 0) && (num2 > 0xff)) && this._showErrorFlag)
                        {
                            this.errorProvider.SetError(this, "无效的 IP 地址。");
                        }
                        this.textBox1.Text = num2.ToString();
                    }
                    if (i > 0)
                    {
                        if (((num2 < 0) && (num2 > 0xff)) && this._showErrorFlag)
                        {
                            this.errorProvider.SetError(this, "无效的 IP 地址。");
                        }
                        switch (i)
                        {
                            case 1:
                                this.textBox2.Text = num2.ToString();
                                break;

                            case 2:
                                this.textBox3.Text = num2.ToString();
                                break;

                            default:
                                this.textBox4.Text = num2.ToString();
                                break;
                        }
                    }
                }
            }
        }

        private static bool IsNumeric(string str)
        {
            foreach (char ch in str)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }

        private bool isValidateValue()
        {
            bool flag = true;
            if (((this.textBox1.Text.Trim() == "") || (this.textBox2.Text.Trim() == "")) || ((this.textBox3.Text.Trim() == "") || (this.textBox4.Text.Trim() == "")))
            {
                return false;
            }
            int num = int.Parse(this.textBox1.Text.Trim());
            if (this._inputType == InputType.IPAddress)
            {
                if ((num < 1) || (num > 0xe9))
                {
                    flag = false;
                }
            }
            else if ((num < 1) || (num > 0xe9))
            {
                flag = false;
            }
            if (flag)
            {
                flag = this.VerifyForIP(this.textBox2);
            }
            if (flag)
            {
                flag = this.VerifyForIP(this.textBox3);
            }
            if (flag)
            {
                flag = this.VerifyForIP(this.textBox4);
            }
            return flag;
        }
    }

    public enum InputType
    {
        IPAddress,
        Gateway
    }
}
