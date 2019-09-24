using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class Suplier
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public Cat Category { get; set; }
        public string Adress { get; set; }
        public virtual ICollection<ImportingInvoice> ImportingInvoices { get; set; }

        public enum Cat
        {
             Copper ,
            Plastic  
        }
    }
}
