using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IComponentRepository : IRepository<Component>
    {
        IEnumerable<Component> AllComponents();
        Component Find(int id);
        void InsertOrUpdate(Component component);
        void Delete(int id);
    }
}
