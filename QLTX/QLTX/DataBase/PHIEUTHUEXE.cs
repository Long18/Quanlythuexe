namespace QLTX.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Windows;
    using System.Windows.Forms;
    using MessageBox = System.Windows.MessageBox;

    [Table("PHIEUTHUEXE")]
    public partial class PHIEUTHUEXE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUTHUEXE()
        {
            CTPTHUEXE = new HashSet<CTPTHUEXE>();
        }

        [Key]
        public int SOPHIEUTHUEXE { get; set; }

        public DateTime? NGAYLAP { get; set; }

        public int? MAKH { get; set; }

        public int? MANV { get; set; }

        public int? MATK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPTHUEXE> CTPTHUEXE { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }


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




        public void them(int makh, int manv)
        {
            DataProvider context = new DataProvider();
            PHIEUTHUEXE ptx = new PHIEUTHUEXE();
            // ptx.SOPHIEUTHUEXE = int.Parse(txtsophieu.Text);
            ptx.MAKH = makh;
            ptx.MANV = manv;

            int s = manv;
            ptx.MATK = int.Parse(timmatk(s));

            //   ptx.NGAYLAP = DateTime.Now;
            string ngay = String.Format("{0:MM/dd/yyyy}", DateTime.Now);

            DataProvider conext = new DataProvider();
            PHIEUTHUEXE ptxDB = conext.PHIEUTHUEXEs.FirstOrDefault(p => p.SOPHIEUTHUEXE.ToString() == ptx.SOPHIEUTHUEXE.ToString());
            if (ptxDB == null)
            {
                context.Database.ExecuteSqlCommand("Insert into PHIEUTHUEXE( NGAYLAP, MAKH,MANV,MATK) Values('" + ngay + "'," + ptx.MAKH + "," + ptx.MANV + "," + ptx.MATK + ")");
                conext.SaveChanges();
            }
        }

        public void xoa(string maptx)
        {
            DataProvider context = new DataProvider();
            PHIEUTHUEXE ptxDB = context.PHIEUTHUEXEs.FirstOrDefault(p => p.SOPHIEUTHUEXE.ToString() == maptx);
            if (ptxDB == null)
                throw new Exception("khong tim thay");
            DialogResult dig = System.Windows.Forms.MessageBox.Show("Bạn có muốn xóa", "Canh bao", MessageBoxButtons.YesNo);
            if (dig == DialogResult.Yes)
            {
                context.PHIEUTHUEXEs.Remove(ptxDB);
                context.SaveChanges();

            }

        }

        public void sua(string maptx, int makh, int manv)
        {
            PHIEUTHUEXE ptx = new PHIEUTHUEXE();
            ptx.SOPHIEUTHUEXE = int.Parse(maptx);
            ptx.MAKH = makh;
            ptx.MANV = manv;
            ptx.NGAYLAP = DateTime.Now;
            int s = manv;
            ptx.MATK = int.Parse(timmatk(s));

            DataProvider conext = new DataProvider();
            PHIEUTHUEXE ptxDB = conext.PHIEUTHUEXEs.FirstOrDefault(p => p.SOPHIEUTHUEXE.ToString() == ptx.SOPHIEUTHUEXE.ToString());
            if (ptxDB != null)
            {
                ptxDB.SOPHIEUTHUEXE = ptx.SOPHIEUTHUEXE;
                ptxDB.MAKH = ptx.MAKH;
                ptxDB.MANV = ptx.MANV;
                ptxDB.NGAYLAP = ptx.NGAYLAP;
                ptxDB.MATK = ptx.MATK;
                conext.SaveChanges();
                MessageBox.Show("Sửa thành công.");
            }


        }
    }
}


