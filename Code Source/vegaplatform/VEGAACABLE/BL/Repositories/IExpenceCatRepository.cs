using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IExpenceCatRepository : IRepository<ExpenceCat>
    {
        IEnumerable<ExpenceCat> AllExpenceCats();
        ExpenceCat Find(int id);
        void InsertOrUpdate(ExpenceCat expenceCat);
        void Delete(int id);
    }
}
