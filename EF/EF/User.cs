namespace EF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string FullName { get; set; }

        [Required]
        [StringLength(20)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Image { get; set; }

        public bool Status { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
