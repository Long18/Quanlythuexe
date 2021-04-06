namespace QLTX.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            PHIEUTHUEXE = new HashSet<PHIEUTHUEXE>();
        }

        [Key]
        public int MAKH { get; set; }

        [StringLength(25)]
        public string TENKH { get; set; }

        [StringLength(15)]
        public string CMND { get; set; }

        [StringLength(15)]
        public string BANGLAI { get; set; }

        public string DIACHI { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHUEXE> PHIEUTHUEXE { get; set; }
    }
}
