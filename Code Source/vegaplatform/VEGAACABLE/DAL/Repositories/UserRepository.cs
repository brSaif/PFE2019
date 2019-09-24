using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.BL.Repositories;

namespace VEGAACABLE.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(VegaContext context) : base(context)
        {
        }

        public IEnumerable<User> AllUsers()
        {
            var s = VegaContext.Users
                .OrderBy(c => c.Id)
                .ThenBy(c => c.FullName)
                .ToList();
            return s;
        }

        public User Find(int id)
        {
            return VegaContext.Users.Find(id);
        }

        public void InsertOrUpdate(User user)
        {
            if (user.Id == default(int))
            {
                VegaContext.Users.Add(user);
            }
            else
            {
                VegaContext.Entry(user).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var user = VegaContext.Users.Find(id);
            VegaContext.Users.Remove(user);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }

    }
}
