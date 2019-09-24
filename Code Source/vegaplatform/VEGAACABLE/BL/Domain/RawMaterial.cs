using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class RawMaterial
    {
        public int ID { get; set; }
        public int ComposantID { get; set; }
        public string RefNbr { get; set; }
        public float Mass { get; set; }
        public string Lot { get; set; }
        public DateTime ImpDate { get; set; }
        public DateTime UpDate { get; set; }
        public int UserId { get; set; }
        public RMStatus Status { get; set; }
        public Component Composant { get; set; }
        public User User { get; set; }
        public ICollection<UsedRawMaterial> UsedRawMaterials { get; set; }
        public ICollection<ImportingInvoice> ImportingInvoices { get; set; }
        public enum RMStatus
        {
            Available = 0,
            Reserved = 1,
            OutOfStock = 2
        }
    }
}
