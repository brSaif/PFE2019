using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.BL.Repositories;

namespace VEGAACABLE.DAL.Repositories
{
    public class ExpenceRepository : Repository<Expence>,IExpenceRepository
    {
        public ExpenceRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Expence> AllExpences()
        {
            var s = VegaContext.Expences
                .OrderBy(c => c.Id)
                .OrderBy(c => c.CreatedDate)
                .ToList();
            return s;
        }

        public Expence Find(int id)
        {
            return VegaContext.Expences.Find(id);
        }

        public void InsertOrUpdate(Expence expence)
        {
            if (expence.Id == default(int))
            {
                VegaContext.Expences.Add(expence);
            }
            else
            {
                VegaContext.Entry(expence).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var expence = VegaContext.Expences.Find(id);
            VegaContext.Expences.Remove(expence);
        }

        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
