namespace QLBH_NQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BINHLUAN")]
    public partial class BINHLUAN
    {
        [Key]
        public int MABL { get; set; }

        public int? MAKH { get; set; }

        public int? MAHOA { get; set; }

        [StringLength(50)]
        public string HOTENKH { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYGIO { get; set; }

        [StringLength(1000)]
        public string NOIDUNGBL { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
