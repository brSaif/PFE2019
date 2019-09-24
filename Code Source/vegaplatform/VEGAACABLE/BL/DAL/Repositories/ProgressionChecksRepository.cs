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
    public class ProgressionChecksRepository : Repository<ProgressionCheck>,IProgressionChecksRepository
    {
        public ProgressionChecksRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<ProgressionCheck> AllProgressionChecks(int id)
        {
            var s = VegaContext.ProgressionChecks
                .Include(c => c.Sequence)
                .Where(c => c.OFID == id)
                .OrderBy(c => c.ID)
                .ThenBy(c => c.Sequence.Name)
                .ToList();
            return s;
        }

        public ProgressionCheck Find(int id)
        {
            return VegaContext.ProgressionChecks.Find(id);
        }

        public void InsertOrUpdate(ProgressionCheck progressionCheck)
        {
            if (progressionCheck.ID == default(int))
            {
                VegaContext.ProgressionChecks.Add(progressionCheck);
            }
            else
            {
                VegaContext.Entry(progressionCheck).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var progressionCheck = VegaContext.ProgressionChecks.Find(id);
            VegaContext.ProgressionChecks.Remove(progressionCheck);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
