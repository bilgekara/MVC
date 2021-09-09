namespace Repository.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RepositoryContext : DbContext
    {
        public RepositoryContext()
            : base("name=RepositoryContext")
        {
        }

        public virtual DbSet<Ogrenci> Ogrencis { get; set; }
        public virtual DbSet<Ogretman> Ogretmen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
