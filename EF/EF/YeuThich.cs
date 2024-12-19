namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YeuThich")]
    public partial class YeuThich
    {
        [Key]
        public int MaYT { get; set; }

        public int? MaHH { get; set; }

        [StringLength(20)]
        public string MaKH { get; set; }

        public DateTime? NgayChon { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
