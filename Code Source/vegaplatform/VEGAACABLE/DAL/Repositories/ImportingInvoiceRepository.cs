using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.BL.Repositories;

namespace VEGAACABLE.DAL.Repositories
{
    public class ImportingInvoiceRepository : Repository<ImportingInvoice>,IImportingInvoiceRepository
    {
        public ImportingInvoiceRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<ImportingInvoice> AllImportingInvoices()
        {
            var s = VegaContext.ImportingInvoices
                .Include(c => c.RawMaterial)
                .Include(c => c.Suplier)
                .Include(c => c.User)
                .OrderBy(c => c.Id)
                .ThenBy(c => c.CreatedDate)
                .ToList();
            return s;
        }

        public ImportingInvoice Find(int id)
        {
            return VegaContext.ImportingInvoices.Find(id);
        }

        public void InsertOrUpdate(ImportingInvoice importingInvoice)
        {
            if (importingInvoice.Id == default(int))
            {
                VegaContext.ImportingInvoices.Add(importingInvoice);
            }
            else
            {
                VegaContext.Entry(importingInvoice).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var importingInvoice = VegaContext.ImportingInvoices.Find(id);
            VegaContext.ImportingInvoices.Remove(importingInvoice);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
