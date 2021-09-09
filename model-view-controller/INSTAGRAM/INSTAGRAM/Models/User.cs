namespace INSTAGRAM.Models
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
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        [Required]
        [StringLength(150)]
        public string FullName { get; set; }
    }
}
