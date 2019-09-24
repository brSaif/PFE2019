using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<NomenclatureSequance> NomenclatureSequances { get; set; }
        public ICollection<RawMaterial> RawMaterials { get; set; }
    }
}
