using Framework.Core.Entities;
using Framework.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DataAccess.Repositories
{
    public class Repository : IRepository
    {
        /*Ekleme - Güncelleme -Silme- Birtanesini Getirme -Hepsini Getirme
         
         */
        DataContext _context;

        public Repository()
        {
            _context = new DataContext();
        }


        public bool Add<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);

            int result = _context.SaveChanges();

            return result > 0;
        }

    }
}
