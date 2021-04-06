using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using QLTX.DataBase;
using QLTX.UserControl;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;

namespace QLTX
{
    public partial class frmMain : Form
    {
        DataProvider context = new DataProvider();
        TAIKHOAN tk = new TAIKHOAN();

        public static string soban = string.Empty;
        public static string tenkhach = string.Empty;
        public static bool chuadangnhap = true;

        //private UCThanhToan tt = null;
        private ucRegister reg = null;
        public ucLogin login = null;
        private ucVehicle vehicle = null;
        private ucThanhToan tt = null;
        public ucCustomer custom = null;
        public ucNhanVien nv = null;
        public ucBill bill = null;
        public ucPhieuDenBu denbu = null;
        public ucBackGround bg = null;
        public ucCTPhieuThuXe ctp = null;
        public frmMain()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(frmMain_KeyDown);

            nv = new ucNhanVien();
            custom = new ucCustomer();
            reg = new ucRegister();
            login = new ucLogin();
            vehicle = new ucVehicle();
            tt = new ucThanhToan();
            bill = new ucBill();
            denbu = new ucPhieuDenBu();
            this.login.parentForm = this;
            this.reg.parentForm = this;
            this.bill.parentForm = this;
            this.denbu.parentForm = this;
            this.tt.parentForm = this;



            this.panelForm.Controls.Clear();

            this.panel1.Controls.Add(this.labelYear);
            this.labelYear.Location = new System.Drawing.Point(12, 423);
            this.panel1.Controls.Add(this.labelTime);
            this.labelTime.Location = new System.Drawing.Point(13, 465);

            this.panel1.Controls.Clear();


            this.panel1.Controls.Add(this.btnHoaDon);
            this.btnHoaDon.Dock = DockStyle.Top;
            this.panel1.Controls.Add(this.btnLogin);
            this.btnLogin.Dock = DockStyle.Top;
            this.panel1.Controls.Add(this.btnVehicle);
            this.btnVehicle.Dock = DockStyle.Top;
            this.panel1.Controls.Add(this.btnThanhToan);
            this.btnThanhToan.Dock = DockStyle.Top;
            this.panel1.Controls.Add(this.btnNhanVien);
            this.btnNhanVien.Dock = DockStyle.Top;
            this.panel1.Controls.Add(this.btnCustomer);
            this.btnCustomer.Dock = DockStyle.Top;
            this.btnLogin.Dock = DockStyle.Top;
            this.panel1.Controls.Add(this.btnLogin);




            this.panelForm.Controls.Add(new ucBackGround());


        }



        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void runWaitForm()
        {

            SplashScreenManager.ShowForm(this, typeof(frmWaitting), true, true, false);
            for (int i = 1; i <= 100; i++)
            {
                SplashScreenManager.Default.SetWaitFormDescription(i.ToString() + "%");
                Thread.Sleep(25);
            }
            SplashScreenManager.CloseForm(false);


        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (chuadangnhap == false) { XtraMessageBox.Show("Bạn Đã đăng nhập rồi! \nBạn có thể đăng xuất!"); return; }
            controlUserControl.showControl(login, panelForm);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            controlUserControl.showControl(reg, panelForm);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {

        }



        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (chuadangnhap) { XtraMessageBox.Show("Đăng Nhập Để Tính Tiền"); return; }
            controlUserControl.showControl(tt, panelForm);
        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            if (chuadangnhap) { XtraMessageBox.Show("Đăng Nhập Để Chọn Xe"); return; }

            controlUserControl.showControl(vehicle, panelForm);

        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            controlUserControl.showControl(login, panelForm);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (chuadangnhap) { XtraMessageBox.Show("Bạn Chưa Đăng Nhập Nên Không Thể Đăng Xuất"); return; }
            XtraMessageBox.Show("Bạn đã đăng xuất!!");
            ucBackGround bg = new ucBackGround();
            controlUserControl.showControl(bg, panelForm);
            chuadangnhap = true;

        }


        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (chuadangnhap) { XtraMessageBox.Show("Đăng Nhập Để Kiểm Tra Khách Hàng"); return; }

           
            controlUserControl.showControl(custom, panelForm);
        }

        private void btnNhanVien_Click_1(object sender, EventArgs e)
        {
            if (chuadangnhap) { XtraMessageBox.Show("Đăng Nhập Để Quản Lí Nhân Viên"); return; }

            controlUserControl.showControl(nv, panelForm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
            labelYear.Text = DateTime.Now.ToString(" dddd - dd.MM.yyy");
            if (chuadangnhap == false)
            {
                this.panel1.Controls.Add(this.btnThoat);
                this.btnThoat.Dock = DockStyle.Top;
            }
            else this.panel1.Controls.Remove(btnThoat);

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.panel1.Controls.Add(this.labelYear);
            this.labelYear.Location = new System.Drawing.Point(12, 423);
            this.panel1.Controls.Add(this.labelTime);
            this.labelTime.Location = new System.Drawing.Point(13, 465);
            runWaitForm();
        }



        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            if (chuadangnhap) { XtraMessageBox.Show("Đăng Nhập Để Vào Hoá Đơn"); return; }

            
            controlUserControl.showControl(bill, panelForm);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                goodbyeScreen a = new goodbyeScreen();
                this.Hide();
                a.ShowDialog();
            }
            

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this,@"D:\QLTX\QLTX\Other\helpFile.chm");
            this.CenterToScreen();
        }

        private void frmMain_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Help.ShowHelp(this, @"D:\QLTX\QLTX\Other\helpFile.chm");
            this.CenterToScreen();
        }

        void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Help.ShowHelp(this, @"D:\QLTX\QLTX\Other\helpFile.chm");
                this.CenterToScreen();
                e.Handled = true;
            }
        }

       
    }

}

