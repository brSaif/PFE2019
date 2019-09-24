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
    public class SupplierRepository : Repository<Suplier>, ISupplierRepository
    {
        public SupplierRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Suplier> AllSuppliers()
        {
            var s = VegaContext.Supliers.OrderBy(c => c.Id).ToList();
            return s;
        }

        public Suplier Find(int id)
        {
            return VegaContext.Supliers.Find(id);
        }

        public void InsertOrUpdate(Suplier suplier)
        {
            if (suplier.Id == default(int))
            {
                VegaContext.Supliers.Add(suplier);
            }
            else
            {
                VegaContext.Entry(suplier).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var suplier = VegaContext.Supliers.Find(id);
            VegaContext.Supliers.Remove(suplier);
        }

        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
