namespace QLBH_NQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ADMIN()
        {
            TINTUCs = new HashSet<TINTUC>();
        }

        [Key]
        public int MAAD { get; set; }

        [StringLength(50)]
        public string TENAD { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYSINH { get; set; }

        public int? GIOITINH { get; set; }

        [StringLength(100)]
        public string DIACHI { get; set; }

        [StringLength(15)]
        public string DIENTHOAI { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(30)]
        public string TENDN { get; set; }

        [StringLength(30)]
        public string MATKHAU { get; set; }

        public int? QUYENADMIN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TINTUC> TINTUCs { get; set; }
    }
}
