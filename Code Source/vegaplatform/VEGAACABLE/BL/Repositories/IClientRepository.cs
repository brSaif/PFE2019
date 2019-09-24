using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
         IEnumerable<Client> AllClients();
         Client Find(int id);
         void Delete(int id);
         void InsertOrUpdate(Client client);
    }
}
