using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe.UI.WindowsForm
{
    static class UIThreadBoundControlExtensions
    {
        public static void SetText(this Control control, string text)
        {
            Invoke(control, () => control.Text = text);
        }

        public static void SetText(this ToolStripItem control, string text)
        {
            Invoke(control.Owner, () => control.Text = text);
        }

        private static void Invoke(Control control, Action action)
        {
            if (control != null)
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(new MethodInvoker(action));
                }
                else
                {
                    action();
                }
            }
        }
    }
}
