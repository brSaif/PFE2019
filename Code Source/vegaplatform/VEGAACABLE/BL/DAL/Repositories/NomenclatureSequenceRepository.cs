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
    public class NomenclatureSequenceRepository : Repository<NomenclatureSequance>,INomenclatureSequenceRepository
    {
        public NomenclatureSequenceRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<NomenclatureSequance> AllNomenclatureSequances(int id)
        {
            var NomclSeq = VegaContext.NomenclatureSequances
                .Include(c => c.Component)
                .Include(c => c.Sequence)
                .Where(c => c.NomenclatureID == id).ToList();
            return NomclSeq;
        }

        public void InsertOrUpdate(NomenclatureSequance ns)
        {
            if (ns.ID == default(int))
            {
                VegaContext.NomenclatureSequances.Add(ns);
            }
            else
            {
                VegaContext.Entry(ns).State = EntityState.Modified;
            }
        }

        public NomenclatureSequance Find(int id)
        {
            return VegaContext.NomenclatureSequances.Find(id);
        }

        public void Delete(int id)
        {
            var c = VegaContext.NomenclatureSequances.Find(id);
            VegaContext.NomenclatureSequances.Remove(c);
        }

        public VegaContext VegaContext
        {
            get { return Context as VegaContext;}
        }
    }
}
