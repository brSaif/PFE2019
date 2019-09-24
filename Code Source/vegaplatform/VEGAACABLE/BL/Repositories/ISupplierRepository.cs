using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface ISupplierRepository : IRepository<Suplier>
    {
        IEnumerable<Suplier> AllSuppliers();
        Suplier Find(int id);
        void InsertOrUpdate(Suplier suplier);
        void Delete(int id);

    }
}
