namespace QLTX.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XETHUE")]
    public partial class XETHUE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XETHUE()
        {
            CTPTHUEXE = new HashSet<CTPTHUEXE>();
        }

        [Key]
        public int MAXE { get; set; }

        public int? MALX { get; set; }

        [StringLength(30)]
        public string TENXE { get; set; }

        [StringLength(30)]
        public string KIEUXE { get; set; }

        [StringLength(10)]
        public string BIENSOXE { get; set; }

        public int? GIAXE { get; set; }

        public string HINHANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPTHUEXE> CTPTHUEXE { get; set; }

        public virtual LOAIXE LOAIXE { get; set; }
    }
}
