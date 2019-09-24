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
    public class GroupsRepository : Repository<UGroup>,IGroupsRepository
    {
        public GroupsRepository(DbContext context) : base(context)
        {
        }
        public IEnumerable<UGroup> AllGroups()
        {
            var s = VegaContext.UGroups
                .OrderBy(c => c.Id)
                .OrderBy(c => c.Name);
            return s;
        }

        public UGroup Find(int id)
        {
            return VegaContext.UGroups.Find(id);
        }

        public void InsertOrUpdate(UGroup uGroup)
        {
            if (uGroup.Id == default(int))
            {
                VegaContext.UGroups.Add(uGroup);
            }
            else
            {
                VegaContext.Entry(uGroup).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var uGroup = VegaContext.UGroups.Find(id);
            VegaContext.UGroups.Remove(uGroup);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
