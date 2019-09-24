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
    public class ExpenceCatRepository : Repository<ExpenceCat>,IExpenceCatRepository
    {
        public ExpenceCatRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<ExpenceCat> AllExpenceCats()
        {
            var s = VegaContext.ExpenceCats
                .OrderBy(c => c.Id)
                .ThenBy(c => c.Name)
                .ToList();
            return s;
        }

        public ExpenceCat Find(int id)
        {
            return VegaContext.ExpenceCats.Find(id);
        }

        public void InsertOrUpdate(ExpenceCat expenceCat)
        {
            if (expenceCat.Id == default(int))
            {
                VegaContext.ExpenceCats.Add(expenceCat);
            }
            else
            {
                VegaContext.Entry(expenceCat).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var expCategory = VegaContext.ExpenceCats.Find(id);
            VegaContext.ExpenceCats.Remove(expCategory);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
