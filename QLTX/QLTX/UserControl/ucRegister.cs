using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLTX.DataBase;

namespace QLTX
{
    public partial class ucRegister : DevExpress.XtraEditors.XtraUserControl
    {
        TAIKHOAN tk = new TAIKHOAN();
        public frmMain parentForm { get; set; }

        public ucRegister()
        {
            InitializeComponent();
        }

      

        private void btnRegis_Click(object sender, EventArgs e)
        {
            if (tk.checkUserName(txtUserName.Text))
            {
                if (tk.checkPass(txtPassWord.Text, txtAgain.Text))
                {
                    tk.addAccount(txtUserName.Text, txtAgain.Text);

                    n_Status.ForeColor = Color.Green;
                    n_Status.Text = "Đăng kí thành công";
                    MessageBox.Show("Bạn hãy đăng nhập ");
                
                }
                else
                {
                    n_Status.ForeColor = Color.Red;
                    n_Status.Text = "Mật khẩu nhập lại không khớp";
                }
            }
            else
            {
                n_Status.ForeColor = Color.Red;
                n_Status.Text = "Tên tài khoản đã tồn tại";
            }
        }
    }
}
