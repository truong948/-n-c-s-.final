namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            BanBes = new HashSet<BanBe>();
            HoaDons = new HashSet<HoaDon>();
            YeuThiches = new HashSet<YeuThich>();
        }

        [Key]
        [StringLength(20)]
        public string MaKH { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        public bool GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        [StringLength(60)]
        public string DiaChi { get; set; }

        [StringLength(24)]
        public string DienThoai { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Hinh { get; set; }

        public bool HieuLuc { get; set; }

        public int VaiTro { get; set; }

        [StringLength(50)]
        public string RandomKey { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BanBe> BanBes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YeuThich> YeuThiches { get; set; }
    }
}
