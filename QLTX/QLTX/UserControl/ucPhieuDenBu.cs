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
using DevExpress.XtraGrid.Views.Grid;

namespace QLTX.UserControl
{
    public partial class ucPhieuDenBu : DevExpress.XtraEditors.XtraUserControl
    {
        public frmMain parentForm { get; set; }
        public ucPhieuDenBu()
        {
            InitializeComponent();

            pHIEUDENBUTableAdapter.Fill(qLTXDataSet.PHIEUDENBU);
            pHIEUTHUEXETableAdapter.Fill(qLTXDataSet.PHIEUTHUEXE);
            xETHUETableAdapter.Fill(qLTXDataSet.XETHUE);
            nHANVIENTableAdapter.Fill(qLTXDataSet.NHANVIEN);
            tAIKHOANTableAdapter.Fill(qLTXDataSet.TAIKHOAN);
            onSave();
        }
        public void onSave()
        {

            var dtChange = this.qLTXDataSet.PHIEUDENBU.GetChanges() as QLTXDataSet.PHIEUDENBUDataTable;
            if (dtChange == null) return;
            try
            {
                pHIEUDENBUTableAdapter.Update(dtChange);
                MessageBox.Show("Cập nhật thành công!!");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void UIButton_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            try
            {

            if (e.Button.Properties.Caption == "Add")
            {
                gridView1.AddNewRow();
                onSave();

            }
            if (e.Button.Properties.Caption == "Delete")
            {
                if (XtraMessageBox.Show("Có chắc bạn muốn xoá không?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
                {
                    gridView1.DeleteSelectedRows();
                    onSave();
                    

                }
            }
            if (e.Button.Properties.Caption == "Refresh")
            {
                onSave();
                gridControl1.DataSource = null;
                gridControl1.DataSource = qLTXDataSet.PHIEUDENBU;
            }
            if (e.Button.Properties.Caption == "Print")
            {
                frmReportPDenBu db = new frmReportPDenBu();
                db.ShowDialog();
                db.Close();
            }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Hãy nhập đầy đủ thông tin");
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
            {
                if (e.RowHandle < 0)
                {
                    e.Info.ImageIndex = 0;
                    e.Info.DisplayText = string.Empty;
                }
                else
                {
                    e.Info.ImageIndex = -1; //Không hiển thị hình
                    e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                }
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); })); //Tăng kích thước nếu Text vượt quá
            }
        }

        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            onSave();
            XtraMessageBox.Show("Thêm thành công.");
        }

        private void ucPhieuDenBu_Load(object sender, EventArgs e)
        {
            pHIEUDENBUTableAdapter.Fill(qLTXDataSet.PHIEUDENBU);
            pHIEUTHUEXETableAdapter.Fill(qLTXDataSet.PHIEUTHUEXE);
            xETHUETableAdapter.Fill(qLTXDataSet.XETHUE);
            nHANVIENTableAdapter.Fill(qLTXDataSet.NHANVIEN);
            tAIKHOANTableAdapter.Fill(qLTXDataSet.TAIKHOAN);
        }
    }
}
