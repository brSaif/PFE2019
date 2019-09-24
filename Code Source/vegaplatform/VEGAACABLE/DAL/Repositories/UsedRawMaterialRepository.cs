using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.BL.Repositories;

namespace VEGAACABLE.DAL.Repositories
{
    public class UsedRawMaterialRepository : Repository<UsedRawMaterial>,IUsedRawMaterialRepository
    {
        public UsedRawMaterialRepository(VegaContext context) : base(context)
        {

        }

        public IEnumerable<UsedRawMaterial> AllUsedRawMaterials(int id)
        {
            var s = VegaContext.UsedRawMaterials
                .Include(c => c.RawMaterial)
                .Where(c => c.FabOrdID == id)
                 .OrderBy(c => c.Id)
                 .ThenBy(c => c.Weight).ToList();
            return s;
        }

        public UsedRawMaterial Find(int id)
        {
            return VegaContext.UsedRawMaterials.Find(id);
        }

        public void InsertOrUpdate(UsedRawMaterial usedRM)
        {
            if (usedRM.Id == default(int))
            {
                VegaContext.UsedRawMaterials.Add(usedRM);
            }
            else
            {
                VegaContext.Entry(usedRM).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var c = VegaContext.UsedRawMaterials.Find(id);
            VegaContext.UsedRawMaterials.Remove(c);
        }

        public VegaContext VegaContext
        {
            get { return Context as VegaContext;}
        }
    }
}
