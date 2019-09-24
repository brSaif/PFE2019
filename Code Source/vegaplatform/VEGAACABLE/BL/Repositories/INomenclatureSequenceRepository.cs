using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface INomenclatureSequenceRepository : IRepository<NomenclatureSequance>
    {
        IEnumerable<NomenclatureSequance> AllNomenclatureSequances(int id);
        void InsertOrUpdate(NomenclatureSequance ns);
        void Delete(int id);
        NomenclatureSequance Find(int id);
    }
}
