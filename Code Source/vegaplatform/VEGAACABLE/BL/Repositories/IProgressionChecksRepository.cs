using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IProgressionChecksRepository : IRepository<ProgressionCheck>
    {
        IEnumerable<ProgressionCheck> AllProgressionChecks(int id);
        ProgressionCheck Find(int id);
        void InsertOrUpdate(ProgressionCheck progressionCheck);
        void Delete(int id);
    }
}
