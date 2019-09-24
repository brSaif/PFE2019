using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class Nomenclature
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public string NormRef { get; set; }
        public string Condition { get; set; }
        public int ColorId { get; set; }
        public NColor Color{ get; set; }
        public ICollection<NomenclatureSequance> NomenclatureSequances { get; set; }
        public ICollection<FabricationOrder> FabricationOrders { get; set; }
    }
}
