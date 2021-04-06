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
using QLTX.DataBase;
using QLTX.UserControl;

namespace QLTX
{
    public partial class ucThanhToan : DevExpress.XtraEditors.XtraUserControl
    {
        CTPTHUEXE ct = new CTPTHUEXE();
        public frmMain parentForm { get; set; }
        public ucThanhToan()
        {
            InitializeComponent();
            onSaveTHUEXE();
            onSaveCTTHUEXE();
            gridControl1.RefreshDataSource();


            pHIEUTHUEXETableAdapter.Fill(qLTXDataSet.PHIEUTHUEXE);
            cTPTHUEXETableAdapter.Fill(qLTXDataSet.CTPTHUEXE);
            kHACHHANGTableAdapter.Fill(qLTXDataSet.KHACHHANG);
            tAIKHOANTableAdapter.Fill(qLTXDataSet.TAIKHOAN);
            nHANVIENTableAdapter.Fill(qLTXDataSet.NHANVIEN);
            xETHUETableAdapter.Fill(qLTXDataSet.XETHUE);
        }

        #region  //Lưu dữ liệu
        public void onSaveTHUEXE()
        {

            var dtChange = this.qLTXDataSet.PHIEUTHUEXE.GetChanges() as QLTXDataSet.PHIEUTHUEXEDataTable;
            if (dtChange == null) return;
            try
            {
                pHIEUTHUEXETableAdapter.Update(dtChange);
                XtraMessageBox.Show("Cập nhật thành công");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        public void onSaveCTTHUEXE()
        {

            var dtChange = this.qLTXDataSet.CTPTHUEXE.GetChanges() as QLTXDataSet.CTPTHUEXEDataTable;
            if (dtChange == null) return;
            try
            {
                cTPTHUEXETableAdapter.Update(dtChange);
                XtraMessageBox.Show("Cập nhật thành công");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        #endregion

       




        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            onSaveTHUEXE();
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            onSaveCTTHUEXE();

           
        }

        private void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Delete")
            {
                if (XtraMessageBox.Show("Có chắc bạn muốn xoá không?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
                {
                    gridView1.DeleteSelectedRows();
                    onSaveTHUEXE();
                    onSaveCTTHUEXE();
                }
            }
            if (e.Button.Properties.Caption == "Refresh")
            {
                onSaveCTTHUEXE();
                onSaveTHUEXE();
                gridControl1.RefreshDataSource();
            }
            if (e.Button.Properties.Caption == "Phiếu Thuê Xe")
            {
                gridControl1.DataSource = null;
                gridControl1.DataSource = qLTXDataSet.PHIEUTHUEXE;
                gridControl1.MainView = gridView1;
            }
            if (e.Button.Properties.Caption == "Chi Tiết Phiếu Thuê Xe")
            {
                ucCTPhieuThuXe ctp = new ucCTPhieuThuXe();
                controlUserControl.showControl( ctp, parentForm.panelForm);
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

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView2); })); //Tăng kích thước nếu Text vượt quá
            }
        }

        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        private void ucThanhToan_Load(object sender, EventArgs e)
        {
            pHIEUTHUEXETableAdapter.Fill(qLTXDataSet.PHIEUTHUEXE);
            cTPTHUEXETableAdapter.Fill(qLTXDataSet.CTPTHUEXE);
            kHACHHANGTableAdapter.Fill(qLTXDataSet.KHACHHANG);
            tAIKHOANTableAdapter.Fill(qLTXDataSet.TAIKHOAN);
            nHANVIENTableAdapter.Fill(qLTXDataSet.NHANVIEN);
            xETHUETableAdapter.Fill(qLTXDataSet.XETHUE);
        }

        
    }
}
