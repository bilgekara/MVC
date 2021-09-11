using Framewokr.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DataAccess.Concrete//bina
{
    public class DataContext : DbContext
    {
        public DataContext(string connectionString = null) :
            base(@"data source=DESKTOP-P7QAI0G\SQLEXPRESS;initial catalog=AlzheimerMerkezi;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {

        }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<UserDetail> UserDetail { get; set; }
    }
}
