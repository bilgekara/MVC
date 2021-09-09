namespace stajDebut.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(500)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(250)]
        public string CompanyName { get; set; }

        [StringLength(250)]
        public string subject { get; set; }

        [StringLength(1000)]
        public string message { get; set; }
    }
}
