namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanCong")]
    public partial class PhanCong
    {
        [Key]
        public int MaPC { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(7)]
        public string MaPB { get; set; }

        public DateTime? NgayPC { get; set; }

        public bool? HieuLuc { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual PhongBan PhongBan { get; set; }
    }
}
