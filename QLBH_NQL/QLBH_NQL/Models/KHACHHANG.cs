namespace QLBH_NQL.Models
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
            BINHLUANs = new HashSet<BINHLUAN>();
            DONDATHANGs = new HashSet<DONDATHANG>();
        }

        [Key]
        public int MAKH { get; set; }

        [StringLength(50)]
        public string TENKH { get; set; }

        [StringLength(200)]
        public string DIACHI { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYSINH { get; set; }

        public int? GIOITINH { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [StringLength(25)]
        public string TENDN { get; set; }

        [StringLength(25)]
        public string MATKHAU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BINHLUAN> BINHLUANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONDATHANG> DONDATHANGs { get; set; }
    }
}
