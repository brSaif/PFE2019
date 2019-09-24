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
    public class ComponentRepository : Repository<Component>,IComponentRepository
    {
        public ComponentRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Component> AllComponents()
        {
            var s = VegaContext.Components
                .OrderBy(c => c.Id)
                .ToList();
            return s;
        }

        public Component Find(int id)
        {
            return VegaContext.Components.Find(id);
        }

        public void InsertOrUpdate(Component component)
        {
            if (component.Id == default(int))
            {
                VegaContext.Components.Add(component);
            }
            else
            {
                VegaContext.Entry(component).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var component = VegaContext.Components.Find(id);
            VegaContext.Components.Remove(component);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
