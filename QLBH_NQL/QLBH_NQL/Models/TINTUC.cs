namespace QLBH_NQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TINTUC")]
    public partial class TINTUC
    {
        [Key]
        public int MATT { get; set; }

        public int MAAD { get; set; }

        [StringLength(200)]
        public string TIEUDE { get; set; }

        [StringLength(2000)]
        public string NOIDUNG { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGAYDANG { get; set; }

        public int? LUOTXEM { get; set; }

        public virtual ADMIN ADMIN { get; set; }
    }
}
