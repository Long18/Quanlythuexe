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
using QLTX.DataBase;
using System.Threading;

namespace QLTX.UserControl
{
    public partial class ucCTPhieuThuXe : XtraUserControl
    {
        CTPTHUEXE ct = new CTPTHUEXE();
        public frmMain parentForm { get; set; }
        public ucCTPhieuThuXe()
        {
            InitializeComponent();
        }

        private void BindGrid(List<CTPTHUEXE> listCtthuexe)
        {
            dtgdanhsach.Rows.Clear();
            foreach (var item in listCtthuexe)
            {
                int index = dtgdanhsach.Rows.Add();
                dtgdanhsach.Rows[index].Cells[0].Value = item.SOPHIEUTHUEXE;
                dtgdanhsach.Rows[index].Cells[1].Value = item.XETHUE.TENXE;
                dtgdanhsach.Rows[index].Cells[2].Value = item.NGAYTRAXEDK;
                dtgdanhsach.Rows[index].Cells[3].Value = item.soluong;
                dtgdanhsach.Rows[index].Cells[4].Value = item.TONGTIENTHUEXE;
            }
        }


        private void Combobox(List<PHIEUTHUEXE> listphieuthuexe, List<XETHUE> listxethue)
        {
            this.cbxsphieu.DataSource = listphieuthuexe;
            this.cbxsphieu.DisplayMember = "SOPHIEUTHUEXE";
            this.cbxsphieu.ValueMember = "SOPHIEUTHUEXE";

            this.cbxxemuon.DataSource = listxethue;
            this.cbxxemuon.DisplayMember = "TENXE";
            this.cbxxemuon.ValueMember = "MAXE";
        }




        private void LoadData()
        {
            DataProvider context = new DataProvider();
            List<CTPTHUEXE> listCtThuexe = context.CTPTHUEXEs.ToList();
            List<PHIEUTHUEXE> listphieuthue = context.PHIEUTHUEXEs.ToList();
            List<XETHUE> listxethue = context.XETHUEs.ToList();
            Combobox(listphieuthue, listxethue);
            BindGrid(listCtThuexe);
        }

        private void ucCTPhieuThuXe_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {

            try
            {

                if (e.Button.Properties.Caption == "New")
                {
                    string ngay = String.Format("{0:MM/dd/yyyy}", dtvngaytra.Value);
                    ct.them(int.Parse(cbxsphieu.SelectedValue.ToString()), int.Parse(cbxxemuon.SelectedValue.ToString()), ngay, int.Parse(txttongtien.Text), int.Parse(txtsoluong.Text));
                    LoadData();
                }
                if (e.Button.Properties.Caption == "Tổng")
                {
                    txttongtien.Text = ct.tinhtongnho(cbxsphieu.SelectedValue.ToString(), dtvngaytra.Value, int.Parse(cbxxemuon.SelectedValue.ToString()), int.Parse(txtsoluong.Text)).ToString();
                }
                if (e.Button.Properties.Caption == "Delete")
                {
                    ct.xoa(int.Parse(cbxsphieu.SelectedValue.ToString()), int.Parse(cbxxemuon.SelectedValue.ToString()));
                    LoadData();
                }
                if (e.Button.Properties.Caption == "Edit")
                {
                    ct.sua(int.Parse(cbxsphieu.SelectedValue.ToString()), int.Parse(cbxxemuon.SelectedValue.ToString()), dtvngaytra.Value, int.Parse(txttongtien.Text), int.Parse(txtsoluong.Text));
                    LoadData();
                }
                if (e.Button.Properties.Caption == "Print")
                {
                    frmReportXeThue xt = new frmReportXeThue();
                    xt.ShowDialog();
                    xt.Close();
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Hãy nhập đầy đủ thông tin.");
            }
        }

        private void dtvngaytra_ValueChanged(object sender, EventArgs e)
        {
            /*Thread.Sleep(2);
            txttongtien.Text = ct.tinhtongnho(cbxsphieu.SelectedValue.ToString(),
            dtvngaytra.Value, int.Parse(cbxxemuon.SelectedValue.ToString()), int.Parse(txtsoluong.Text)).ToString();*/
        }

        private void dtgdanhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int h;
                h = e.RowIndex;

                string chitietphieu = dtgdanhsach.Rows[h].Cells[0].Value.ToString();
            
                DataProvider context = new DataProvider();
                CTPTHUEXE ctphieuthue = context.CTPTHUEXEs.FirstOrDefault(p => p.SOPHIEUTHUEXE.ToString() == chitietphieu  );
                if (ctphieuthue != null)
                {
                    cbxsphieu.Text = ctphieuthue.SOPHIEUTHUEXE.ToString();
                    cbxxemuon.Text = ctphieuthue.XETHUE.TENXE.ToString();
                    dtvngaytra.Text = ctphieuthue.NGAYTRAXEDK.ToString();
                    txtsoluong.Text = ctphieuthue.soluong.ToString();
                    txttongtien.Text = ctphieuthue.TONGTIENTHUEXE.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hãy chọn dòng đầu tiên-- \nNơi có dấu mũi tên màu đen.");
            }
        }

        
    }
}
