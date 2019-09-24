using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IUsedRawMaterialRepository : IRepository<UsedRawMaterial>
    {
        IEnumerable<UsedRawMaterial> AllUsedRawMaterials(int id);
        UsedRawMaterial Find(int id);
        void InsertOrUpdate(UsedRawMaterial usedRM);
        void Delete(int id);
    }
}
