using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IGroupPermissionRepository : IRepository<UGroupPermission>
    {
        IEnumerable<UGroupPermission> AllGroupPermissions();
        IEnumerable<UGroupPermission> Find(int id);
        void InsertOrUpdate(UGroupPermission groupPermission);
        void Delete(int id);
    }
}
