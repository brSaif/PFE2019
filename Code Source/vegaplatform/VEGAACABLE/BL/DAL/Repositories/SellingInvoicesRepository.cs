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
   public class SellingInvoicesRepository : Repository<SellingInvoice>,ISellingInvoicesRepository
    {
        public SellingInvoicesRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<SellingInvoice> AllSellingInvoices()
        {
            var s = VegaContext.SellingInvoices
                .Include(c => c.FabricationOrder.Nomenclature)
                .Include(c => c.Client)
                .Include(c => c.User)
                .OrderBy(c => c.Id)
                .ThenBy(c => c.CreatedDate)
                .ToList();
            return s;
        }

        public SellingInvoice Find(int id)
        {
            return VegaContext.SellingInvoices.Find(id);
        }

        public void InsertOrUpdate(SellingInvoice sellingInvoice)
        {
            if (sellingInvoice.Id == default(int))
            {
                VegaContext.SellingInvoices.Add(sellingInvoice);
            }
            else
            {
                VegaContext.Entry(sellingInvoice).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var sellingInvoice = VegaContext.SellingInvoices.Find(id);
            VegaContext.SellingInvoices.Remove(sellingInvoice);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
