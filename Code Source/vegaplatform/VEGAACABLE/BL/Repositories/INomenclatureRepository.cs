using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface INomenclatureRepository : IRepository<Nomenclature>
    {
        IEnumerable<Nomenclature> AllNomenclatures();
        Nomenclature Find(int id);
        void InsertOrUpdate(Nomenclature nomenclature);
        void Delete(int id);
    }
}
