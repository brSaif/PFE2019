using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class FabricationOrder
    {
        public int Id { get; set; }
        public int NomenclatureId { get; set; }
        public float Length { get; set; }
        public stat Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartingDate { get; set; }
        public ICollection<SellingInvoice> SellingInvoices { get; set; }
        public Nomenclature Nomenclature { get; set; }
        public ICollection<ProgressionCheck> ProgressionChecks { get; set; }
        public ICollection<UsedRawMaterial> UsedRawMaterials { get; set; }
        public enum stat
        {
            Pending = 0,
            Started = 1
        }
    }
}
