namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BanBe")]
    public partial class BanBe
    {
        [Key]
        public int MaBB { get; set; }

        [StringLength(20)]
        public string MaKH { get; set; }

        public int MaHH { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public DateTime NgayGui { get; set; }

        public string GhiChu { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual HangHoa HangHoa { get; set; }
    }
}
