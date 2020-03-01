namespace QLBH_NQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUANGCAO")]
    public partial class QUANGCAO
    {
        [Key]
        public int IDQC { get; set; }

        [StringLength(250)]
        public string TENQC { get; set; }

        [StringLength(200)]
        public string ANH { get; set; }

        [StringLength(200)]
        public string HREF { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYBATDAU { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYKETTHUC { get; set; }

        public int? THUTUQC { get; set; }

        public bool? TRANGTHAI { get; set; }
    }
}
