namespace QLBH_NQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHMUCHOA")]
    public partial class DANHMUCHOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DANHMUCHOA()
        {
            DANHMUCCONs = new HashSet<DANHMUCCON>();
        }

        public int ID { get; set; }

        [StringLength(5)]
        public string MADM { get; set; }

        [StringLength(30)]
        public string TENDM { get; set; }

        [StringLength(50)]
        public string HREF { get; set; }

        public bool? HIDEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHMUCCON> DANHMUCCONs { get; set; }
    }
}
