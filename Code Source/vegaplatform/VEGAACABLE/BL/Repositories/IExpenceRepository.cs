using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IExpenceRepository : IRepository<Expence>
    {
        IEnumerable<Expence> AllExpences();
        Expence Find(int id);
        void Delete(int id);
        void InsertOrUpdate(Expence expence);
    }
}
