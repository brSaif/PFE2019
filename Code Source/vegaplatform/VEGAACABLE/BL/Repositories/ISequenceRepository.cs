using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface ISequenceRepository : IRepository<Sequence>
    {
        IEnumerable<Sequence> AllSequences();
        Sequence Find(int id);
        void InsertOrUpdate(Sequence sequence);
        void Delete(int id);
    }
}
