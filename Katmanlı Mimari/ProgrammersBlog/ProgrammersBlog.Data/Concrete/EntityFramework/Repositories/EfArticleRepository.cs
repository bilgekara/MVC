using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repositories
{
    // entity framework yapısı üzerine kurulmuş bir repository,
    // daha buyuk projelerde enittiy framework kullanılmayabilir docker,ado.net vb kullanılabilir

    public class EfArticleRepository : EfEntityRepositoryBase<Article>, IArticleRepository
    {
        // constructor icinde bir db context vermeliyiz
        public EfArticleRepository(DbContext context) : base(context)
        {
        }

        //public IList<Article> GetArticleByCategory(int categoryId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
