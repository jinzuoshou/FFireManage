using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Runtime.InteropServices;

namespace FFireManage.Controls
{
    [Designer(typeof(NTextBox.NTextBoxDesigner))]
    public class NTextBox : TextBox
    {
        #region Static Fields

        [DllImport("user32.dll")]
        private static extern bool MessageBeep(uint uType);

        #endregion

        #region Method Overrides

        protected override bool ProcessKeyEventArgs(ref Message m)
        {
            int keyValue = m.WParam.ToInt32();
            // (keyValue > 47 && keyValue <58) ?Numbers 0 ?9
            // keyValue == 46 - Decimal point
            // (keyValue > 34 && keyValue <41) ?Home, End, and Arrow Keys
            // keyValue == 8 ?Backspace Key
            if ((keyValue > 47 && keyValue < 58) || keyValue == 46 || (keyValue > 34 && keyValue < 41) || keyValue == 8 || keyValue == 45)
            {
                return base.ProcessKeyPreview(ref m);
            }
            else
            {
                // Delete Key
                if (m.Msg == 256 && keyValue == 46)
                {
                    return base.ProcessKeyPreview(ref m);
                }
                // Windows message id used to limit 1 beep per keystroke
                if (m.Msg == 258)
                {
                    MessageBeep(0);
                }
                return true;
            }
        }

        #endregion

        #region Internal Classes

        /// <summary>
        /// NumbersOnlyTextBoxDesigner class
        /// </summary>
        internal class NTextBoxDesigner : ControlDesigner
        {
            #region Method Overrides

            //protected override void PostFilterProperties(System.Collections.IDictionary properties)
            //{
            //    properties.Remove("Text");
            //}

            #endregion
        }

        #endregion
    }
}
