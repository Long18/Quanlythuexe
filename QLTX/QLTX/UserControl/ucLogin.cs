using DevExpress.XtraEditors;
using QLTX.DataBase;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLTX
{
    public partial class ucLogin : XtraUserControl
    {
        TAIKHOAN tk = new TAIKHOAN();
        public frmMain parentForm { get; set; }


        public ucLogin()
        {
            InitializeComponent();
        }

        #region // // Hàm tự động tắt MessageBox
        public class AutoClosingMessageBox
        {
            System.Threading.Timer timeoutTimer;
            string caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                this.caption = caption;
                timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", caption);
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        #endregion


        private void btnLogin_Click(object sender, EventArgs e)
        {


            if (tk.Login(txtUserName.Text, txtPassWord.Text))
            {

                frmMain.chuadangnhap = false;
                n_Status.ForeColor = Color.Green;
                n_Status.Text = "Đăng nhập thành công, giờ đây bạn có thể sử dụng!!";
                AutoClosingMessageBox.Show(" Đăng Nhập thành công!! \nXin chào: " + txtUserName.Text, "Thông báo", 2000);
                {
                    ucVehicle vh = new ucVehicle();
                    controlUserControl.showControl(vh, parentForm.panelForm);
                }
            }
            else
            {
                n_Status.ForeColor = Color.Red;
                n_Status.Text = "Tên tài khoản hoặc mật khẩu không đúng. Vui lòng nhập lại";
            }

        }

        private void btnRegis_Click(object sender, EventArgs e)
        {
            this.parentForm.panelForm.Controls.Clear();
            this.parentForm.panelForm.Controls.Add(new ucRegister());
        }

        private void txtPassWord_OnValueChanged(object sender, EventArgs e)
        {
            txtPassWord.isPassword = true;
        }

        private void ucLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();

        }

        private void ckbHienThi_OnChange(object sender, EventArgs e)
        {
            if (ckbHienThi.Checked != false)
            {
                txtPassWord.isPassword = false;
            }
            else
            {
                txtPassWord.isPassword = true;
            }
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }
    }
}
