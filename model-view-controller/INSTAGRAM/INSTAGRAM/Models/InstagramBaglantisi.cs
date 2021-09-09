namespace INSTAGRAM.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InstagramBaglantisi : DbContext
    {
        public InstagramBaglantisi()
            : base("name=InstagramBaglantisi")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();
        }
    }
}
