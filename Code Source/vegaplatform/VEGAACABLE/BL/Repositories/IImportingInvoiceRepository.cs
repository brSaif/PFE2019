using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IImportingInvoiceRepository : IRepository<ImportingInvoice>
    {
        IEnumerable<ImportingInvoice> AllImportingInvoices();
        ImportingInvoice Find(int id);
        void InsertOrUpdate(ImportingInvoice importingInvoice);
        void Delete(int id);
    }
}
