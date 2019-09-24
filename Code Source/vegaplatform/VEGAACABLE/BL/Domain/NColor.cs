using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class NColor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Nomenclature> Nomenclatures { get; set; }
    }
}
