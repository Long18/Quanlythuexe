using System;
using System.Linq;
using System.Windows.Forms;

namespace QLTX
{
    class controlUserControl
    {
        public static void showControl(System.Windows.Forms.Control control, System.Windows.Forms.Control Content)
        {
            Content.Controls.Clear();

            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();

            Content.Controls.Add(control);

        }
    }
}
