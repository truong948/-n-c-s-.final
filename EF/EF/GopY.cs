namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GopY")]
    public partial class GopY
    {
        [Key]
        [StringLength(50)]
        public string MaGY { get; set; }

        public int MaCD { get; set; }

        [Required]
        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayGY { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string DienThoai { get; set; }

        public bool CanTraLoi { get; set; }

        [StringLength(50)]
        public string TraLoi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTL { get; set; }

        public virtual ChuDe ChuDe { get; set; }
    }
}
