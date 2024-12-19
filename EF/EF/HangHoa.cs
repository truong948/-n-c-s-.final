namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HangHoa")]
    public partial class HangHoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HangHoa()
        {
            BanBes = new HashSet<BanBe>();
            ChiTietHDs = new HashSet<ChiTietHD>();
            YeuThiches = new HashSet<YeuThich>();
        }

        [Key]
        public int MaHH { get; set; }

        [Required]
        [StringLength(50)]
        public string TenHH { get; set; }

        [StringLength(50)]
        public string TenAlias { get; set; }

        public int MaLoai { get; set; }

        [StringLength(50)]
        public string MoTaDonVi { get; set; }

        public double? DonGia { get; set; }

        [StringLength(50)]
        public string Hinh { get; set; }

        public DateTime NgaySX { get; set; }

        public double GiamGia { get; set; }

        public int SoLanXem { get; set; }

        public string MoTa { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BanBe> BanBes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHD> ChiTietHDs { get; set; }

        public virtual Loai Loai { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YeuThich> YeuThiches { get; set; }
    }
}
