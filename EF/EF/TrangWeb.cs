namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrangWeb")]
    public partial class TrangWeb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrangWeb()
        {
            PhanQuyens = new HashSet<PhanQuyen>();
        }

        [Key]
        public int MaTrang { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTrang { get; set; }

        [Required]
        [StringLength(250)]
        public string URL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyen> PhanQuyens { get; set; }
    }
}
