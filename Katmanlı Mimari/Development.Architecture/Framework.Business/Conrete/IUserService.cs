using Framewokr.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Business.Conrete
{
    public interface IUserService
    {
        bool AddUser(User user);
    }
}
