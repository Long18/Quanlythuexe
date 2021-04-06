namespace QLTX.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUDENBU")]
    public partial class PHIEUDENBU
    {
        [Key]
        public int SOPDB { get; set; }

        public DateTime? NGAYLAPPDB { get; set; }

        [StringLength(50)]
        public string LYDODENBU { get; set; }

        [StringLength(30)]
        public string HINHTHUCDENBU { get; set; }

        public int? SOPHIEUTHUEXE { get; set; }

        public int? MAXE { get; set; }

        public int? MANV { get; set; }

        public int? GIADENBU { get; set; }

        public int? MATK { get; set; }

        public virtual CTPTHUEXE CTPTHUEXE { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
