using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class ImportingInvoice
    {
        public int Id { get; set; }
        public int SuplierId { get; set; }
        public int RawMaterialId { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public PaymentMethod PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public RawMaterial RawMaterial { get; set; }
        public Suplier Suplier { get; set; }
        public User User { get; set; }
        public enum Ptype
        {
            Held = 0,
            Term = 1,
            Cash = 2,
            Bank = 3
        }
        public enum Pstate
        {
            Unpaid = 0,
            Paid = 1
        }
    }
}
