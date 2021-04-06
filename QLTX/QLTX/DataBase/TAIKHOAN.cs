namespace QLTX.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Windows;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            NHANVIEN = new HashSet<NHANVIEN>();
        }

        [Key]
        public int MATK { get; set; }

        [StringLength(30)]
        public string TENTAIKHOAN { get; set; }

        [StringLength(30)]
        public string MATKHAU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN> NHANVIEN { get; set; }

        public bool checkPass(string mk1, string mk2)
        {
            if (mk1.Equals(mk2))
            {
                return true;
            }
            return false;
        }


        public bool checkUserName(string Tk)
        {
            TAIKHOAN tk = new TAIKHOAN();
            DataProvider context = new DataProvider();

            tk.TENTAIKHOAN = Tk;
            TAIKHOAN tkDH = context.TAIKHOANs.FirstOrDefault(p => p.TENTAIKHOAN == tk.TENTAIKHOAN);
            if (tkDH == null)
            {
                return true;
            }
            return false;

        }


        //+++ ham dang nhap

        public bool Login(string tk, string mk)
        {
            TAIKHOAN TK = new TAIKHOAN();
            DataProvider context = new DataProvider();
            //TK.TENTAIKHOAN = tk

            TAIKHOAN DN = context.TAIKHOANs.FirstOrDefault(p => p.TENTAIKHOAN == tk && p.MATKHAU == mk);
            if (DN != null)
            {

                return true;
            }
            return false;
        }



        //+++ ham chuc nang
        public void addAccount(string tk, string mk)
        {
            TAIKHOAN TK = new TAIKHOAN();
            DataProvider contextDB = new DataProvider();

            TK.TENTAIKHOAN = tk;
            TK.MATKHAU = mk;

            TAIKHOAN tkDH = contextDB.TAIKHOANs.FirstOrDefault(p => p.MATK.ToString() == TK.MATK.ToString());
            if (tkDH == null)
            {
                contextDB.Database.ExecuteSqlCommand("Insert into TAIKHOAN( TENTAIKHOAN,MATKHAU) Values('" + TK.TENTAIKHOAN + "','" + TK.MATKHAU + "')");
                contextDB.SaveChanges();
            }

        }
    }
}
