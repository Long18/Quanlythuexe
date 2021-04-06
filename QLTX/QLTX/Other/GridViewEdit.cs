using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace QLTX
{
    public class GridViewEdit
    {

        GridView grid;// dùng cái này để hứng khi mình ném cái gridview vào
        public GridViewEdit(GridView grid)//hàm dựng
        {
            this.grid = grid;
            cells = new List();
            grid.CellValueChanged += gridView_CellValueChanged; //gắn event bắt cái thay đổi dữ liệu cho grid
            grid.RowCellStyle += gridView1_RowCellStyle; //cái này dùng để thay đổi giá trị backgroud của ô
        }


        #region "Thay đôi màu sắc khi chỉnh sửa giá trị ô"
        List cells;//lưu các ô được thay đổi dữ liệu

        public GridView Grid //k bt phải nói gì
        {
            get
            {
                return grid;
            }

            set
            {
                grid = value;
            }
        }

        public void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string key = e.Column.FieldName + ";" + e.RowHandle.ToString();//cặp khóa lưu thông tin của ô gồm fieldname và rowhandle khi ô đó đc update value
            //if (!cells.Contains(key))
                //cells.Add(key); //thêm khóa vào 
        }

        public void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            string key = e.Column.FieldName + ";" + e.RowHandle.ToString();//bắt lấy cái ô đang thực hiện update
            //if (cells.Contains(key))//nếu ô này có sửa data thì nó sẽ nằm trong cái biến mình lưu ở trên
                e.Appearance.ForeColor = Color.Red; //sửa nền ô
            //else
                //e.Appearance.BackColor = Color.White; //đưa màu nền về mặc định hoặc khỏi dùng cái này cũng được, tùy mục đích
        }
        #endregion

    }
}
