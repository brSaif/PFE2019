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
    public class FabricationOrderRepository : Repository<FabricationOrder>,IFabricationOrderRepository
    {
        public FabricationOrderRepository(DbContext context) : base(context)
        {
        }
        public IEnumerable<FabricationOrder> AllFabricationOrders()
        {
            var s = VegaContext.FabricationOrders
                .Include(c => c.Nomenclature)
                .OrderBy(c => c.Id)
                .ThenBy(c => c.Nomenclature.Designation)
                .ToList();
            return s;
        }

        public FabricationOrder Find(int id)
        {
            return VegaContext.FabricationOrders.Find(id);
        }

        public void InsertOrUpdate(FabricationOrder fabricationOrder)
        {
            if (fabricationOrder.Id == default(int))
            {
                VegaContext.FabricationOrders.Add(fabricationOrder);
            }
            else
            {
                VegaContext.Entry(fabricationOrder).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var fabricationOrder = VegaContext.FabricationOrders.Find(id);
            VegaContext.FabricationOrders.Remove(fabricationOrder);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
