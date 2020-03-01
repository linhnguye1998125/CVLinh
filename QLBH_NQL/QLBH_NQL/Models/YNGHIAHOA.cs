namespace QLBH_NQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YNGHIAHOA")]
    public partial class YNGHIAHOA
    {
        [Key]
        public int IDYN { get; set; }

        [StringLength(200)]
        public string TIEUDE { get; set; }

        [StringLength(100)]
        public string ANH { get; set; }

        [StringLength(250)]
        public string MOTA { get; set; }

        [StringLength(2000)]
        public string NOIDUNG { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYDANG { get; set; }
    }
}
