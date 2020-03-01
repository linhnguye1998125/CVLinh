namespace QLBH_NQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONDATHANG")]
    public partial class DONDATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONDATHANG()
        {
            CTDATHANGs = new HashSet<CTDATHANG>();
        }

        [Key]
        public int MADH { get; set; }

        public int? MAKH { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYDATHANG { get; set; }

        public decimal? TRIGIA { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYGIAOHANG { get; set; }

        [StringLength(50)]
        public string TENNGUOINHAN { get; set; }

        [StringLength(15)]
        public string DIENTHOAI { get; set; }

        [StringLength(200)]
        public string DIACHI { get; set; }

        [StringLength(100)]
        public string HTTHANHTOAN { get; set; }

        [StringLength(100)]
        public string HTGIAOHANG { get; set; }

        public bool? TRANGTHAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDATHANG> CTDATHANGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
