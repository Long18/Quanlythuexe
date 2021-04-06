namespace QLTX.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Windows.Forms;

    [Table("CTPTHUEXE")]
    public partial class CTPTHUEXE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CTPTHUEXE()
        {
            PHIEUDENBU = new HashSet<PHIEUDENBU>();
            HOADON = new HashSet<HOADON>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOPHIEUTHUEXE { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAXE { get; set; }

        public DateTime? NGAYTRAXEDK { get; set; }

        public int? TONGTIENTHUEXE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDENBU> PHIEUDENBU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADON { get; set; }

        public int? soluong { get; set; }

        public virtual PHIEUTHUEXE PHIEUTHUEXE { get; set; }

        public virtual XETHUE XETHUE { get; set; }


        public int tinhtongnho(string a, DateTime ngaytra2, int maxe, int solong)
        {
            DataProvider connext = new DataProvider();
            PHIEUTHUEXE ctptx = connext.PHIEUTHUEXEs.FirstOrDefault(p => p.SOPHIEUTHUEXE.ToString() == a.ToString());
            XETHUE xt = connext.XETHUEs.FirstOrDefault(p => p.MAXE == maxe);
            if (ctptx != null)
            {
                DateTime ngaymuon = ctptx.NGAYLAP.Value.Date;
                DateTime ngaytra = ngaytra2;//ctptx.NGAYTRAXEDK.Value.Date;
                TimeSpan time = ngaytra - ngaymuon;
                int c = (time.Days * xt.GIAXE.Value) * solong;
                return c;
            }
            return 0;
        }




        public void them(int sophieuthue, int maxe, string ngay, int tongtien, int soluong)
        {
            CTPTHUEXE cttx = new CTPTHUEXE();
            DataProvider context = new DataProvider();

            cttx.SOPHIEUTHUEXE = sophieuthue;
            cttx.MAXE = maxe;
            cttx.TONGTIENTHUEXE = tongtien;
            cttx.soluong = soluong;

            CTPTHUEXE ptxDB = context.CTPTHUEXEs.FirstOrDefault(p => p.SOPHIEUTHUEXE.ToString() == cttx.SOPHIEUTHUEXE.ToString() && p.MAXE.ToString() == cttx.MAXE.ToString());
            if (ptxDB == null)
            {
                //context.CTPTHUEXEs.Add(cttx);
                context.Database.ExecuteSqlCommand("Insert into CTPTHUEXE(SOPHIEUTHUEXE,MAXE,NGAYTRAXEDK,soluong,TONGTIENTHUEXE) Values(" + cttx.SOPHIEUTHUEXE + ", " + cttx.MAXE + ", '" + ngay + "', '" + cttx.soluong + "','" + cttx.TONGTIENTHUEXE + "')");

                context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Phiếu này đã có");
            }

        }


        // thue ham tu bang vao nen ko sua dc


        public void xoa(int sophieu, int maxe)
        {
            DataProvider context = new DataProvider();
            CTPTHUEXE ctPtxDB = context.CTPTHUEXEs.FirstOrDefault(p => p.SOPHIEUTHUEXE == sophieu);
            if (ctPtxDB == null)
                throw new Exception("khong tim thay");
            DialogResult dig = MessageBox.Show("Bạn có muốn xóa", "Canh bao", MessageBoxButtons.YesNo);
            if (dig == DialogResult.Yes)
            {
                context.CTPTHUEXEs.Remove(ctPtxDB);
                context.SaveChanges();
            }
        }




        public void sua(int sophieuthue, int maxe, DateTime ngay, int tong, int soluong)
        {
            CTPTHUEXE cttx = new CTPTHUEXE();
            DataProvider context = new DataProvider();



            CTPTHUEXE ptxDB = context.CTPTHUEXEs.FirstOrDefault(p => p.SOPHIEUTHUEXE.ToString() == sophieuthue.ToString());
            if (ptxDB != null)
            {
                ptxDB.SOPHIEUTHUEXE = sophieuthue;
                ptxDB.MAXE = maxe;
                ptxDB.NGAYTRAXEDK = ngay;
                ptxDB.TONGTIENTHUEXE = tong;
                ptxDB.soluong = soluong;

                context.SaveChanges();
            }
        }




    }
}
