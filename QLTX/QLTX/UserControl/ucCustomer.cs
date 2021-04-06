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
using QLTX.QLTXDataSetTableAdapters;

namespace QLTX
{
    public partial class ucCustomer : DevExpress.XtraEditors.XtraUserControl
    {
        public ucCustomer()
        {
            InitializeComponent();
            gridControl1.RefreshDataSource();
            string[] locals = { "An Giang ", "Bà Rịa - Vũng Tàu", "Bắc Giang",
                "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương",
                "Bình Phước", "Bình Thuận", "Cà Mau", "Cao Bằng", "Đắk Lắk", "Đắk Nông",
                "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang","Hà Nam",
                "Hà Tĩnh","Hải Dương","Hậu Giang","Hòa Bình","Hưng Yên","Khánh Hòa",
                "Kiên Giang","Kon Tum","Lai Châu","Lâm Đồng","Lạng Sơn","Lào Cai",
                "Long An","Nam Định","Nghệ An","Ninh Bình","Ninh Thuận","Phú Thọ",
                "Quảng Bình","Quảng Nam","Quảng Ngãi","Quảng Ninh","Quảng Trị","Sóc Trăng",
                "Sơn La","Tây Ninh","Thái Bình","Thái Nguyên","Thanh Hóa","Thừa Thiên Huế",
                "Tiền Giang","Trà Vinh","Tuyên Quang","Vĩnh Long","Vĩnh Phúc","Yên Bái","Phú Yên",
                "Cần Thơ","Đà Nẵng","Hải Phòng","Hà Nội","TP HCM", };

            foreach (string local in locals)
            {
                cmbDiaChi.Items.Add(local);
            }
        }
        public void onSave()
        {

            var dtChange = this.qLTXDataSet.KHACHHANG.GetChanges() as QLTXDataSet.KHACHHANGDataTable;
            if (dtChange == null) return;
            try
            {
                kHACHHANGTableAdapter.Update(dtChange);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void ucCustomer_Load(object sender, EventArgs e)
        {
            this.kHACHHANGTableAdapter.Fill(this.qLTXDataSet.KHACHHANG);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Có chắc bạn muốn xoá không?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {
                gridView1.DeleteSelectedRows();
                onSave();
            }
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
                Int32 _Width = Convert.ToInt32(_Size.Width) +20;
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

        private void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
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
                
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            onSave();
            XtraMessageBox.Show("Thêm thành công.");
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
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

            if (view.FocusedColumn.FieldName == "BANGLAI")
            {
                double banglai = 0;
                if (!Double.TryParse(e.Value as String, out banglai))
                {
                    e.Valid = false;
                    e.ErrorText = "Hãy nhập số bằng lái của bạn ( 12 số ).";
                }
            }

            if (view.FocusedColumn.FieldName == "CMND")
            {
                double cmnd = 0;
                if (!Double.TryParse(e.Value as String, out cmnd))
                {
                    e.Valid = false;
                    e.ErrorText = "Hãy nhập số chứng minh nhân dân của bạn ( 12 số ).";
                }
            }
        }
    }
}
