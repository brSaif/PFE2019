using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IPermissionRepository : IRepository<UPermission>
    {
        IEnumerable<UPermission> AllPermissions();
    }
}
