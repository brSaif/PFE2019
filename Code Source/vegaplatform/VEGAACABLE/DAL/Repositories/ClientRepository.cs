using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AnalysisServices;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.BL.Repositories;

namespace VEGAACABLE.DAL.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        
        public ClientRepository(DbContext context) : base(context)
        {
        }

        //public IQueryable SaiQueryable()
        //{
        //    return VegaContext.Supliers.Select(c => c.Adress);
        //}
        public IEnumerable<Client> AllClients()
        {
            var s = VegaContext.clients
                .OrderBy(c => c.Id)
                .ThenBy(c => c.FirstName)
                .ToList();
            return s;
        }

        public Client Find(int id)
        {
            return VegaContext.clients.Find(id);
        }

        public void InsertOrUpdate(Client client)
        {
            if (client.Id == default(int))
            {
                VegaContext.clients.Add(client);
            }
            else
            {
                VegaContext.Entry(client).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var client = VegaContext.clients.Find(id);
            VegaContext.clients.Remove(client);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
