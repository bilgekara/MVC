using Framework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DataAccess.Repositories
{
    public interface IRepository
    {
        bool Add<TEntity>(TEntity entity) where TEntity : class;
    }
}
