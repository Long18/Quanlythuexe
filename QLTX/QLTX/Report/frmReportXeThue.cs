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
using QLTX.Report;
using DevExpress.XtraReports.UI;

namespace QLTX
{
    public partial class frmReportXeThue : DevExpress.XtraEditors.XtraForm
    {
        public static string datas = @"WILLIAM\WILLIAM";
        public static string datan = "QLTX";

        SqlConnection con = new SqlConnection(@"Data Source=" + datas + ";Initial Catalog=" + datan + ";Integrated Security=True");
        public frmReportXeThue()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from c where SOPHIEUTHUEXE =" + txtphieuthuexe.Text, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            try
            {
            rptXeThue rp = new rptXeThue();
            rp.xrlngay.Text = string.Format("TP.HCM, ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            rp.xrlphieuso.Text = txtphieuthuexe.Text;
            rp.DataSource = dt;
            rp.ShowPreviewDialog();
            this.Close();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Hãy nhập số phiếu hoá đơn muốn in");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}