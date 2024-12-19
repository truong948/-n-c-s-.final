namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietHDs = new HashSet<ChiTietHD>();
        }

        [Key]
        public int MaHD { get; set; }

        [Required]
        [StringLength(20)]
        public string MaKH { get; set; }

        public DateTime NgayDat { get; set; }

        public DateTime? NgayCan { get; set; }

        public DateTime? NgayGiao { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(60)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(50)]
        public string CachThanhToan { get; set; }

        [Required]
        [StringLength(50)]
        public string CachVanChuyen { get; set; }

        public double PhiVanChuyen { get; set; }

        public int MaTrangThai { get; set; }

        [StringLength(50)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHD> ChiTietHDs { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual TrangThai TrangThai { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
