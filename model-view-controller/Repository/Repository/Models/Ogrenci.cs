namespace Repository.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ogrenci")]
    public partial class Ogrenci
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string FullName { get; set; }

        public int Age { get; set; }

        public bool Gender { get; set; }
    }
}
