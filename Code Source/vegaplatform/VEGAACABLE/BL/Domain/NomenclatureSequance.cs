using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class NomenclatureSequance
    {
        public int ID { get; set; }
        public int NomenclatureID { get; set; }
        public int SequenceId { get; set; }
        public int ComponentId { get; set; }
        public float Mass { get; set; }
        public Sequence Sequence { get; set; }
        public Component Component { get; set; }
        public Nomenclature Nomenclature { get; set; }
    }
}
