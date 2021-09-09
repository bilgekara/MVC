namespace Repository.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ogretman
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string Departman { get; set; }

        public int Age { get; set; }
    }
}
