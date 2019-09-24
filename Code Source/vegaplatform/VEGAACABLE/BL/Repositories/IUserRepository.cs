using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> AllUsers();
        User Find(int id);
        void InsertOrUpdate(User user);
        void Delete(int id);
    }
}