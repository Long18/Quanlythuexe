using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QLTX
{
    public partial class frmReportHoaDon : DevExpress.XtraEditors.XtraForm
    {
        public static string datas = @"WILLIAM\WILLIAM";
        public static string datan = "QLTX";

        SqlConnection con = new SqlConnection(@"Data Source=" + datas + ";Initial Catalog=" + datan + ";Integrated Security=True");
        public frmReportHoaDon()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtprhoadon.Text.Trim() != "")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select * from b where MAHD =" + txtprhoadon.Text, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                rptHoaDon rp = new rptHoaDon();
                rp.xrlngay.Text = string.Format("TP.HCM, ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
                rp.xrlsohd.Text = txtprhoadon.Text;
                rp.DataSource = dt;
                rp.ShowPreviewDialog();
                this.Close();

            }
            else
            {
                XtraMessageBox.Show("Hãy nhập số hoá đơn muốn in.");
            }

        }

    

    private void simpleButton1_Click(object sender, EventArgs e)
    {
        this.Hide();
    }
}
}