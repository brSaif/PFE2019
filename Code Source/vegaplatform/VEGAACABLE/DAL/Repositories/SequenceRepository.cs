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
    public class SequenceRepository : Repository<Sequence>,ISequenceRepository
    {
        public SequenceRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Sequence> AllSequences()
        {
            var s = VegaContext.Sequences
                .OrderBy(c => c.Id)
                //.OrderBy(c => c.Name)
                .ToList();
            return s;
        }

        public Sequence Find(int id)
        {
            return VegaContext.Sequences.Find(id);
        }

        public void InsertOrUpdate(Sequence sequence)
        {
            if (sequence.Id == default(int))
            {
                VegaContext.Sequences.Add(sequence);
            }
            else
            {
                VegaContext.Entry(sequence).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var sequence = VegaContext.Sequences.Find(id);
            VegaContext.Sequences.Remove(sequence);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
