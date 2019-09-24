using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IFabricationOrderRepository : IRepository<FabricationOrder>
    {
        IEnumerable<FabricationOrder> AllFabricationOrders();
        FabricationOrder Find(int id);
        void InsertOrUpdate(FabricationOrder fabricationOrder);
        void Delete(int id);
    }
}
