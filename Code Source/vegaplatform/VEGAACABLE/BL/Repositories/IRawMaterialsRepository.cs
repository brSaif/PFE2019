using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IRawMaterialsRepository : IRepository<RawMaterial>
    {
        IEnumerable<RawMaterial> AllRawMaterials();
        RawMaterial Find(int id);
        void InsertOrUpdate(RawMaterial rawMaterial);
        void Delete(int id);
    }
}
