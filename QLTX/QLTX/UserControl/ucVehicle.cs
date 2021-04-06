using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using QLTX.DataBase;

namespace QLTX
{
    public partial class ucVehicle : XtraUserControl
    {
        public ucVehicle()
        {
            InitializeComponent();
            loaixeTableAdapter1.Fill(qLTXDataSet.LOAIXE);
            onSave();



            string[] types = { "Tay ga", "Tay côn", "Xe số", "Xe hơi", "Xe đạp", "Xe tải" };
            foreach (string type in types)
            {
                cmbKieuXe.Items.Add(type);
            }


        }
       

        public void onSave()
        {

            var dtChange = this.qLTXDataSet.XETHUE.GetChanges() as QLTXDataSet.XETHUEDataTable;
            if (dtChange == null) return;
            try
            {
                xETHUETableAdapter.Update(dtChange);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void ucVehicle_Load(object sender, EventArgs e)
        {
            xETHUETableAdapter.Fill(qLTXDataSet.XETHUE);

        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            txtVehicleName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HINHANH").ToString();

            if (txtVehicleName.Text == "")
            {
                pictureBox1.Image = ResourceImageHelper.CreateImageFromResources("DevExpress.XtraEditors.Images.loading.gif", typeof(BackgroundImageLoader).Assembly);

                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GIAXE").ToString() != "")
                {
                    pictureBox1.Image = null;
                }
            }
            else
            {
                pictureBox1.Image = new Bitmap(txtVehicleName.Text);
            }
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png; *.jpeg;)|*.jpg; *.png; *.jpeg; ";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string linkFileName;
                //txtVehicleName.Text = open.FileName;
                pictureBox1.Image = new Bitmap(open.FileName);
                linkFileName = open.FileName;
                gridView1.SetFocusedRowCellValue(colHINHANH, linkFileName);
            }
        }

        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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

        private void gridControl_Load(object sender, EventArgs e)
        {
            xETHUETableAdapter.Fill(qLTXDataSet.XETHUE);
        }

        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "GIAXE")
            {
                double price = 0;
                if (!Double.TryParse(e.Value as String, out price))
                {
                    e.Valid = false;
                    e.ErrorText = "Chỉ nhập số tiền vào đây.";
                }
            }

            if (view.FocusedColumn.FieldName == "BIENSOXE")
            {
                double num = 0;
                if (!Double.TryParse(e.Value as String, out num))
                {
                    e.Valid = false;
                    e.ErrorText = "Chỉ nhập số biển số xe.";
                }
            }

           



        }

       

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            onSave();
            XtraMessageBox.Show("Lưu Thành Công!");

            
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
                onSave();
                gridControl.DataSource = null;
                gridControl.DataSource = qLTXDataSet.XETHUE;
                xETHUETableAdapter.Fill(qLTXDataSet.XETHUE);
            }
            if (e.Button.Properties.Caption == "Add")
            {
                gridView1.AddNewRow();
            }
        }
    }
}
