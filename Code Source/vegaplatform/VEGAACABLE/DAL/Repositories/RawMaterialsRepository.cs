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
    public class RawMaterialsRepository : Repository<RawMaterial>,IRawMaterialsRepository
    {
        public RawMaterialsRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<RawMaterial> AllRawMaterials()
        {
            var s = VegaContext.RawMaterials
                .Include(c => c.Composant)
                .Include(c => c.User)
                .OrderBy(c => c.ID)
                .ThenBy(c => c.RefNbr)
                .ToList();
            return s;
        }

        public RawMaterial Find(int id)
        {
            return VegaContext.RawMaterials.Find(id);
        }

        public void InsertOrUpdate(RawMaterial rawMaterial)
        {
            if (rawMaterial.ID == default(int))
            {
                VegaContext.RawMaterials.Add(rawMaterial);
            }
            else
            {
                VegaContext.Entry(rawMaterial).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var rawMaterial = VegaContext.RawMaterials.Find(id);
            VegaContext.RawMaterials.Remove(rawMaterial);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
