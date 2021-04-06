namespace QLTX.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Windows.Forms;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        public int MAHD { get; set; }

        public DateTime? NGAYLAPHD { get; set; }

        public DateTime? NGAYTRAXETT { get; set; }

        public int? TONGTIENTHUE { get; set; }

        public int? MANV { get; set; }

        public int? SOPHIEUTHUEXE { get; set; }

        public int? MAXE { get; set; }

        public int? MATK { get; set; }

        public virtual CTPTHUEXE CTPTHUEXE { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        static int sum = 0;

        public int tinhtongmoi(string a, DateTime ngaytratt)
        {
            int i = Convert.ToInt32(a);
            DataProvider connext = new DataProvider();
            CTPTHUEXE ctptx = connext.CTPTHUEXEs.FirstOrDefault(p => p.SOPHIEUTHUEXE == i);
            if (ctptx != null)
            {
                DateTime ngaymuon = ctptx.PHIEUTHUEXE.NGAYLAP.Value.Date;
                DateTime ngaytra = ngaytratt.Date;
                TimeSpan time = ngaytra - ngaymuon;
                int c = (time.Days * ctptx.XETHUE.GIAXE.Value) * ctptx.soluong.Value;
                return c;
            }
            return 0;
        }






        public string timmatk(int a)
        {

            DataProvider connext = new DataProvider();
            //PHIEUDENBU pdbDB = connext.PHIEUDENBUs.FirstOrDefault(p => p.SOPDB == a);
            NHANVIEN nv = connext.NHANVIENs.FirstOrDefault(p => p.MANV == a);
            if (nv != null)
            {
                return nv.MATK.ToString();
            }
            return null;
        }


        public string tim(int a)
        {
            DataProvider connext = new DataProvider();
            //PHIEUDENBU pdbDB = connext.PHIEUDENBUs.FirstOrDefault(p => p.SOPDB == a);
            CTPTHUEXE cttx = connext.CTPTHUEXEs.FirstOrDefault(p => p.SOPHIEUTHUEXE == a);
            if (cttx != null)
            {
                return cttx.MAXE.ToString();
            }
            return null;
        }

        public void them(int nhanvien, int phieuthuexe, int xe, int tongtien, DateTime ngaytra)
        {

            HOADON hd = new HOADON();


            hd.MANV = nhanvien;
            hd.SOPHIEUTHUEXE = phieuthuexe;

            int s1 = nhanvien;
            hd.MATK = int.Parse(timmatk(s1));

            hd.MAXE = xe;

            int s = phieuthuexe;

            //xe = hd.tim(s);
            //hd.MAXE = int.Parse(xe);

            hd.TONGTIENTHUE = tinhtongmoi(s.ToString(), ngaytra);
            string ngaytr = string.Format("{0:MM/dd/yyyy}", ngaytra);
            //  hd.NGAYTRAXETT = ngaytra;
            string ngay = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
            //  hd.NGAYLAP = DateTime.Now;

            DataProvider context = new DataProvider();
            HOADON hdDH = context.HOADONs.FirstOrDefault(p => p.MAHD.ToString() == hd.MAHD.ToString());
            if (hdDH == null)
            {
                try
                {


                    context.Database.ExecuteSqlCommand("Insert into HOADON(NGAYLAPHD,NGAYTRAXETT,TONGTIENTHUE,SOPHIEUTHUEXE,MAXE,MANV,MATK) Values('" + ngay + "','" + ngaytr + "','" + hd.TONGTIENTHUE + "','" + hd.SOPHIEUTHUEXE + "','" + hd.MAXE + "','" + hd.MANV + "'," + hd.MATK + ")");
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Số phiếu này không phù hợp với mã xe bạn đã nhập" +
                        "\n Hãy tạo phiếu trước khi lập hoá đơn");
                }
            }

        }



        public void xoa(string mahd)
        {
            DataProvider context = new DataProvider();
            HOADON hdDB = context.HOADONs.FirstOrDefault(p => p.MAHD.ToString() == mahd);
            if (hdDB == null)
                throw new Exception("Không tìm tìm thấy hoá đơn.");
            DialogResult dig = MessageBox.Show("Bạn có chắc chắn muốn xoá hoá đơn này", "Cảnh báo", MessageBoxButtons.YesNo);
            if (dig == DialogResult.Yes)
            {
                context.HOADONs.Remove(hdDB);
                context.SaveChanges();
            }
        }



        public void sua(string mahd, int nhanvien, int phieuthuexe, int xe, int tongtien, DateTime ngaytra)
        {

            DataProvider context = new DataProvider();
            HOADON hdDH = context.HOADONs.FirstOrDefault(p => p.MAHD.ToString() == mahd);
            if (hdDH != null)
            {
                hdDH.MAHD = int.Parse(mahd);
                hdDH.MANV = nhanvien;
                hdDH.SOPHIEUTHUEXE = phieuthuexe;
                hdDH.MAXE = xe;
                hdDH.TONGTIENTHUE = tongtien;
                hdDH.NGAYTRAXETT = ngaytra;
                context.SaveChanges();
                MessageBox.Show("Cập nhật thành công.");
            }

        }
    }
}
