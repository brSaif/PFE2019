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
    public class NomenclatureRepository : Repository<Nomenclature> , INomenclatureRepository
    {
        public NomenclatureRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Nomenclature> AllNomenclatures()
        {
            var s = VegaContext.Nomenclatures
                .Include(c => c.Color)
                .OrderBy(c => c.Id);
            return s;
        }

        public Nomenclature Find(int id)
        {
            return VegaContext.Nomenclatures.Find(id);
        }

        public void InsertOrUpdate(Nomenclature nomenclature)
        {
            if (nomenclature.Id == default(int))
            {
                VegaContext.Nomenclatures.Add(nomenclature);
            }
            else
            {
                VegaContext.Entry(nomenclature).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var nomenclature = VegaContext.Nomenclatures.Find(id);
            VegaContext.Nomenclatures.Remove(nomenclature);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
