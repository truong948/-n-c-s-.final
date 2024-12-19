namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHD")]
    public partial class ChiTietHD
    {
        [Key]
        public int MaCT { get; set; }

        public int MaHD { get; set; }

        public int MaHH { get; set; }

        public double DonGia { get; set; }

        public int SoLuong { get; set; }

        public double GiamGia { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual HangHoa HangHoa { get; set; }
    }
}
