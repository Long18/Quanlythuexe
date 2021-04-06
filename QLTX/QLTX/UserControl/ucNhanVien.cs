using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLTX
{

    public partial class ucNhanVien : DevExpress.XtraEditors.XtraUserControl
    {
        QLTXDataSet da = new QLTXDataSet();
        public ucNhanVien()
        {
            InitializeComponent();
            nHANVIENTableAdapter.Fill(this.qLTXDataSet.NHANVIEN);
            tAIKHOANTableAdapter.Fill(qLTXDataSet.TAIKHOAN);
            gridControl1.RefreshDataSource();
            onSave();

            string[] genders = { "Nam", "Nữ" };
            string[] jobs = { "Nhân Viên", "Quản Lí" };
            foreach (string gender in genders)
            {
                cmbGioiTinh.Items.Add(gender);
            }

            foreach (string job in jobs)
            {
                cmbChucVu.Items.Add(job);
            }
        }
        public void onSave()
        {

            var dtChange = this.qLTXDataSet.NHANVIEN.GetChanges() as QLTXDataSet.NHANVIENDataTable;
            if (dtChange == null)
            {
                return;
            }
            else
            {
                try
                {
                    nHANVIENTableAdapter.Update(dtChange);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }


        }

        private void ucNhanVien_Load(object sender, EventArgs e)
        {
            nHANVIENTableAdapter.Fill(this.qLTXDataSet.NHANVIEN);
            tAIKHOANTableAdapter.Fill(qLTXDataSet.TAIKHOAN);
            
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            onSave();
            XtraMessageBox.Show("Lưu thành công!!", "Xác Nhận");
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
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
            }
        }
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }



        private void gridView1_CustomDrawRowIndicator_1(object sender, RowIndicatorCustomDrawEventArgs e)
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "CHUCVU")
            {
                var value = gridView1.GetRowCellValue(e.RowHandle, e.Column);
                var dt = da.NHANVIEN.FirstOrDefault(p => p.CHUCVU == (string)value);
                if (dt != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, "MATK", dt.MATK);
                }
            }
        }

        private void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Delete")
            {
                if (XtraMessageBox.Show("Có chắc bạn muốn xoá không?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
                {

                    gridView1.DeleteRow(gridView1.FocusedRowHandle);
                    nHANVIENTableAdapter.Update(qLTXDataSet);
                }
            }
            if (e.Button.Properties.Caption == "Refresh")
            {
                gridControl1.RefreshDataSource();
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            onSave();


            XtraMessageBox.Show("Thêm thành công.");

        }

    

        private void gridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            MessageBox.Show(this, e.ErrorText, "SDT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {

            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "SDT")
            {
                double phone = 0;
                if (!Double.TryParse(e.Value as String, out phone))
                {
                    e.Valid = false;
                    e.ErrorText = "Hãy nhập số điện thoại của bạn ( 9-13 số ).";
                }
            }
        }
    }
}
