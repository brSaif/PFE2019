using System.Collections.Generic;

namespace VEGAACABLE.BL.Domain
{
    public class Sequence
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<NomenclatureSequance> NomenclatureSequances { get; set; }
        public ICollection<ProgressionCheck> ProgressionChecks { get; set; }
    }
}
