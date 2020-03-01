namespace QLBH_NQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHMUCCON")]
    public partial class DANHMUCCON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DANHMUCCON()
        {
            HOAs = new HashSet<HOA>();
        }

        [Key]
        [StringLength(5)]
        public string MADMH { get; set; }

        public int? ID { get; set; }

        [StringLength(50)]
        public string TENDMCON { get; set; }

        [StringLength(5)]
        public string MADM { get; set; }

        public bool? HIDEN { get; set; }

        public virtual DANHMUCHOA DANHMUCHOA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOA> HOAs { get; set; }
    }
}
