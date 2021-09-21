using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context: DbContext
    {
        /* baglanti adresi tanimlicaz yani (connection string)
         * veri tabanına yansıtmak istedigimiz entitieleri tek tek yazıcaz
         * DATA access layer da crud işlemleri oldugu icin bu islemlere dahil olacak entitieler gerekiyor
         * hem üzerinde calisacagim entitieler hem de bu entitielerin crud operasyonlarına ait metodlara ihtiyacım olacagi icin
         * presantetion Layer: validasyon islemleri icin business ve digerleri
         * */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // baglanti stringini tanimlicaz
            optionsBuilder.UseSqlServer("server=DESKTOP-R1PSP5J;database=CoreBlogDb; integrated security=true;");

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }

    }
}

// 