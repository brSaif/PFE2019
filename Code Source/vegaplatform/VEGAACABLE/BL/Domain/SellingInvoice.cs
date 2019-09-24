using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class SellingInvoice
    {
        public int Id { get; set; }
        public int FabOrdId { get; set; }
        public int ClientId { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public PaymentMethod PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
        public FabricationOrder FabricationOrder { get; set; }
        //public enum Ptype
        //{
        //    Held =0,
        //    Term = 1,
        //    Cash = 2,
        //    Bank = 3
        //}
        //public enum Pstate
        //{
            
        //}
    }
}
