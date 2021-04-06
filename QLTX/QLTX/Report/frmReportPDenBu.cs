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
    public partial class frmReportPDenBu : DevExpress.XtraEditors.XtraForm
    {
        public static string datas = @"WILLIAM\WILLIAM";
        public static string datan = "QLTX";

        SqlConnection con = new SqlConnection(@"Data Source=" + datas + ";Initial Catalog=" + datan + ";Integrated Security=True");
        public frmReportPDenBu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtprdenbu.Text.Trim() != "")
            {
                

                con.Open();
                SqlCommand cmd = new SqlCommand("select * from a where SOPDB =" + txtprdenbu.Text, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                rptPhieuDenBu rp = new rptPhieuDenBu();
                rp.xrlsopdb.Text = txtprdenbu.Text;
                rp.xrlngay.Text = string.Format("TP.HCM, ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

                rp.DataSource = dt;
                rp.ShowPreviewDialog();
                this.Close();

                XtraMessageBox.Show("Hãy nhập số phiếu hoá đơn muốn in");
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