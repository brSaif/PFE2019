using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.BL.Repositories;

namespace VEGAACABLE.DAL.Repositories
{
    public class PermissionRepository: Repository<UPermission> , IPermissionRepository
    {
        public PermissionRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<UPermission> AllPermissions()
        {
            return VegaContext.UPermissions;
        }

        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
