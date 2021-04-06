using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using QLTX.DataBase;
using QLTX.UserControl;
using QLTX.Report;
using System.Threading;

namespace QLTX
{
    public partial class ucBill : DevExpress.XtraEditors.XtraUserControl
    {
        HOADON hd = new HOADON();
        ucPhieuDenBu denbu = new ucPhieuDenBu();

        public ucBill()
        {
            InitializeComponent();

        }

        private void BindGrid(List<HOADON> listhoadon)
        {
            dtgdanhsach.Rows.Clear();
            foreach (var item in listhoadon)
            {
                int index = dtgdanhsach.Rows.Add();
                dtgdanhsach.Rows[index].Cells[0].Value = item.MAHD;
                dtgdanhsach.Rows[index].Cells[1].Value = item.NHANVIEN.TENNV;
                dtgdanhsach.Rows[index].Cells[2].Value = item.SOPHIEUTHUEXE;
                dtgdanhsach.Rows[index].Cells[3].Value = item.CTPTHUEXE.XETHUE.TENXE;
                dtgdanhsach.Rows[index].Cells[4].Value = item.TONGTIENTHUE;
                dtgdanhsach.Rows[index].Cells[5].Value = item.NGAYTRAXETT;
                dtgdanhsach.Rows[index].Cells[6].Value = item.NGAYLAPHD;
            }
        }

        private void Combobox(List<NHANVIEN> listNhanVien, List<PHIEUTHUEXE> listPhieuThueXe, List<XETHUE> listxethue)
        {
            this.cbonhanvien.DataSource = listNhanVien;
            this.cbonhanvien.DisplayMember = "TENNV";
            this.cbonhanvien.ValueMember = "MANV";

            this.cbophieuthuexe.DataSource = listPhieuThueXe;
            this.cbophieuthuexe.DisplayMember = "SOPHIEUTHUEXE";
            this.cbophieuthuexe.ValueMember = "SOPHIEUTHUEXE";

            this.cboxe.DataSource = listxethue;
            this.cboxe.DisplayMember = "TENXE";
            this.cboxe.ValueMember = "MAXE";

        }

        private void LoadData()
        {
            DataProvider context = new DataProvider();
            List<HOADON> listHOADON = context.HOADONs.ToList();

            List<NHANVIEN> listnhanvien = context.NHANVIENs.ToList();
            List<PHIEUTHUEXE> listphieuthuexe = context.PHIEUTHUEXEs.ToList();
            List<XETHUE> listthuexe = context.XETHUEs.ToList();

            Combobox(listnhanvien, listphieuthuexe, listthuexe);
            BindGrid(listHOADON);
        }
        void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "New")
            {
                hd.them(int.Parse(cbonhanvien.SelectedValue.ToString()), int.Parse(cbophieuthuexe.SelectedValue.ToString()), int.Parse(cboxe.SelectedValue.ToString()), int.Parse(txttongtien.Text), dtpngaytratt.Value);
                LoadData();
            }
            if (e.Button.Properties.Caption == "Delete")
            {
                hd.xoa(txtsophieu.Text);
                LoadData();
            }
            if (e.Button.Properties.Caption == "Edit")
            {
                hd.sua(txtsophieu.Text, int.Parse(cbonhanvien.SelectedValue.ToString()), int.Parse(cbophieuthuexe.SelectedValue.ToString()), int.Parse(cboxe.SelectedValue.ToString()), int.Parse(txttongtien.Text), dtpngaytratt.Value);
                LoadData();
            }
            if (e.Button.Properties.Caption == "Phiếu Đền Bù")
            {
                controlUserControl.showControl(denbu, parentForm.panelForm);
            }
            if (e.Button.Properties.Caption == "Print")
            {
                frmReportHoaDon hd = new frmReportHoaDon();
                hd.ShowDialog();
                hd.Close();
            }
            if (e.Button.Properties.Caption == "Báo Cáo Hoá Đơn Theo Ngày")
            {
                frmReportDanhSachHoaDon dshd = new frmReportDanhSachHoaDon();
                dshd.ShowDialog();
                dshd.Close();
            }
        }

        public frmMain parentForm { get; set; }

        private void ucBill_Load(object sender, EventArgs e)
        {
            LoadData();
        }



        private void dtgdanhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int h;
            h = e.RowIndex;
            string hoadon = dtgdanhsach.Rows[h].Cells[0].Value.ToString();
            DataProvider context = new DataProvider();
            HOADON hdDB = context.HOADONs.FirstOrDefault(p => p.MAHD.ToString() == hoadon);
            if (hdDB != null)
            {
                txtsophieu.Text = hdDB.MAHD.ToString();
                cbonhanvien.SelectedItem = int.Parse(hdDB.MANV.ToString()) - 1;
                cbophieuthuexe.SelectedItem = int.Parse(hdDB.SOPHIEUTHUEXE.ToString()) - 1;
                cboxe.Text = hdDB.CTPTHUEXE.XETHUE.TENXE;
                //txtxe.Text = hdDB.MAXE.ToString();
                txttongtien.Text = hdDB.TONGTIENTHUE.ToString();
                dtpngaytratt.Text = hdDB.NGAYTRAXETT.ToString();
            }
            
        }

        private void dtpngaytratt_ValueChanged(object sender, EventArgs e)
        {
            Thread.Sleep(2);
            txttongtien.Text = hd.tinhtongmoi(cbophieuthuexe.SelectedValue.ToString(), dtpngaytratt.Value).ToString();
        }
    }
}
