using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IColorRepository : IRepository<NColor>
    {
        IEnumerable<NColor> AllColors();
        NColor Find(int id);
        void InsertOrUpdate(NColor color);
        void Delete(int id);
    }
}
