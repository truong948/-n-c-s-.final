namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoiDap")]
    public partial class HoiDap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHD { get; set; }

        [Required]
        [StringLength(50)]
        public string CauHoi { get; set; }

        [Required]
        [StringLength(50)]
        public string TraLoi { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDua { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNV { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
