using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class UsedRawMaterial
    {
        public int Id { get; set; }
        public int FabOrdID { get; set; }
        public int RawMaterialID { get; set; }
        public float Weight { get; set; }
        public FabricationOrder FabricationOrder { get; set; }
        public RawMaterial RawMaterial { get; set; }
    }
}
