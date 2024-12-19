namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanQuyen")]
    public partial class PhanQuyen
    {
        [Key]
        public int MaPQ { get; set; }

        [StringLength(7)]
        public string MaPB { get; set; }

        public int? MaTrang { get; set; }

        public bool Them { get; set; }

        public bool Sua { get; set; }

        public bool Xoa { get; set; }

        public bool Xem { get; set; }

        public virtual PhongBan PhongBan { get; set; }

        public virtual TrangWeb TrangWeb { get; set; }
    }
}
