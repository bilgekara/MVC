namespace stajDebut.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VeritabaniBaglantisi : DbContext
    {
        public VeritabaniBaglantisi()
            : base("name=VeritabaniBaglantisi")
        {
        }

        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
