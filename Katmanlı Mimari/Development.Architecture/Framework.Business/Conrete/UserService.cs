using Framewokr.Entites;
using Framework.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Business.Conrete
{
    public class UserService : IUserService
    {
        IRepository repository;

        public UserService()
        {
            repository = new Repository();
        }


        public bool AddUser(User user)
        {
            return repository.Add<User>(user);
        }

    }
}
