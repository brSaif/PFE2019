
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class User
    {
        public byte[] ProfileImage { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
        public int GroupId { get; set; } 
        public virtual UGroup Group { get; set; }
        public virtual ICollection<Expence> Expences { get; set; }
        public ICollection<RawMaterial> RawMaterials { get; set; }
        public virtual ICollection<ImportingInvoice> ImportingInvoices { get; set; }
        public virtual ICollection<SellingInvoice> SellingInvoices { get; set; }
    }
}
