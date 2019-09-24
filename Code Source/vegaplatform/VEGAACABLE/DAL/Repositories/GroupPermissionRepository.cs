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
    public class GroupPermissionRepository : Repository<UGroupPermission>,IGroupPermissionRepository
    {
        public GroupPermissionRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<UGroupPermission> AllGroupPermissions()
        {
            var s = VegaContext.UGroupPermissions
                .OrderBy(c => c.Id)
                .ToList();
            return s;
        }

        public IEnumerable<UGroupPermission> Find(int id)
        {
            var g = VegaContext.UGroups.Find(id);
            var p = VegaContext.UGroupPermissions.Where(c => c.GroupId == g.Id);
            return p;
        }

        public void InsertOrUpdate(UGroupPermission permission)
        {
            if (permission.Id == default(int))
            {
                VegaContext.UGroupPermissions.Add(permission);
            }
            else
            {
                VegaContext.Entry(permission).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var p = VegaContext.UGroupPermissions.Find(id);
            VegaContext.UGroupPermissions.Remove(p);
        }

        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
