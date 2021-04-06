using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace QLTX.Report
{
    public partial class frmReportDanhSachHoaDon : DevExpress.XtraEditors.XtraForm
    {
        public static string datas = @"WILLIAM\WILLIAM";
        public static string datan = "QLTX";

        SqlConnection con = new SqlConnection(@"Data Source=" + datas + ";Initial Catalog=" + datan + ";Integrated Security=True");
        public frmReportDanhSachHoaDon()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            string tungay = string.Format("{0:MM/dd/yyyy}", dtptungay.Value);
            string denngay = string.Format("{0:MM/dd/yyyy}", dtpdenngay.Value);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from b where NGAYLAPHD BETWEEN  '" + tungay + "' and '" + denngay + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            
            rptDSHoaDon rp = new rptDSHoaDon();
            rp.xrlngay.Text = string.Format("TP.HCM, ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            //  rp.xrlsohd.Text = txtprhoadon.Text;
            rp.DataSource = dt;
            rp.ShowPreviewDialog();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}