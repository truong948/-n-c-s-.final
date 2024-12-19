namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            HangHoas = new HashSet<HangHoa>();
        }

        [Key]
        [StringLength(50)]
        public string MaNCC { get; set; }

        [Required]
        [StringLength(50)]
        public string TenCongTy { get; set; }

        [Required]
        [StringLength(50)]
        public string Logo { get; set; }

        [StringLength(50)]
        public string NguoiLienLac { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string DienThoai { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
