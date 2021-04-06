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
using QLTX.UserControl;
using DevExpress.XtraBars.Docking2010;
using System.Web.UI.WebControls;
using DevExpress.XtraGrid.Views.Grid;
using GridView = DevExpress.XtraGrid.Views.Grid.GridView;

namespace QLTX
{
    public partial class ucHoaDon : XtraUserControl
    {
        public frmMain parentForm { get; set; }
        public ucHoaDon()
        {
            InitializeComponent();

            hOADONTableAdapter.Fill(qLTXDataSet.HOADON);
            nhanvienTableAdapter1.Fill(qLTXDataSet.NHANVIEN);
            kHACHHANGTableAdapter.Fill(qLTXDataSet.KHACHHANG);
            pHIEUTHUEXETableAdapter.Fill(qLTXDataSet.PHIEUTHUEXE);
            tAIKHOANTableAdapter.Fill(qLTXDataSet.TAIKHOAN);
            xETHUETableAdapter.Fill(qLTXDataSet.XETHUE);
        }

        public void onSave()
        {

            var dtChange = this.qLTXDataSet.HOADON.GetChanges() as QLTXDataSet.HOADONDataTable;
            if (dtChange == null) return;
            try
            {
                hOADONTableAdapter.Update(dtChange);
                MessageBox.Show("Cập nhật thành công!!");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            onSave();
        }

        private void ucHoaDon_Load(object sender, EventArgs e)
        {
        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            if (XtraMessageBox.Show("Có chắc bạn muốn xoá không?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {
                gridView1.DeleteSelectedRows();
                onSave();
            }
        }

        private void windowsUIButtonPanel_ButtonClick(object sender, ButtonEventArgs e)
        {
            
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
                gridControl1.DataSource = qLTXDataSet.HOADON;
            }
            if (e.Button.Properties.Caption == "Phiếu Đền Bù")
            {
                ucPhieuDenBu denbu = new ucPhieuDenBu();
                controlUserControl.showControl(denbu, parentForm.panelForm);
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
    }
}
