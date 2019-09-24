using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IGroupsRepository : IRepository<UGroup>
    {
        IEnumerable<UGroup> AllGroups();
        UGroup Find(int id);
        void InsertOrUpdate(UGroup uGroup);
        void Delete(int id);
    }
}
