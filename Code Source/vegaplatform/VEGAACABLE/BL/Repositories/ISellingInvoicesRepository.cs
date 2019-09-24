using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface ISellingInvoicesRepository : IRepository<SellingInvoice>
    {
        IEnumerable<SellingInvoice> AllSellingInvoices();
        SellingInvoice Find(int id);
        void InsertOrUpdate(SellingInvoice sellingInvoice);
        void Delete(int id);
    }
}
