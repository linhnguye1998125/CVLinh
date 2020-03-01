namespace QLBH_NQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOA")]
    public partial class HOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOA()
        {
            CTDATHANGs = new HashSet<CTDATHANG>();
        }

        [Key]
        public int MAHOA { get; set; }

        [StringLength(30)]
        public string TENHOA { get; set; }

        [StringLength(30)]
        public string XUATSU { get; set; }

        public decimal? DONGIA { get; set; }

        [StringLength(500)]
        public string MOTA { get; set; }

        [StringLength(100)]
        public string ANHHOA { get; set; }

        [Required]
        [StringLength(5)]
        public string MADMH { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYCAPNHAT { get; set; }

        public int? TONGSOLUONG { get; set; }

        public int? SOLANXEM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDATHANG> CTDATHANGs { get; set; }

        public virtual DANHMUCCON DANHMUCCON { get; set; }
    }
}
