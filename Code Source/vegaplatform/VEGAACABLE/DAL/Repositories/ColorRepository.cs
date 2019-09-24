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
    public class ColorRepository : Repository<NColor>,IColorRepository
    {
        public ColorRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<NColor> AllColors()
        {
            var s = VegaContext.NColors
                .OrderBy(c => c.Id)
                .ThenBy(c => c.Name)
                .ToList();
            return s;
        }

        public NColor Find(int id)
        {
            return VegaContext.NColors.Find(id);
        }

        public void InsertOrUpdate(NColor color)
        {
            if (color.Id == default(int))
            {
                VegaContext.NColors.Add(color);
            }
            else
            {
                VegaContext.Entry(color).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var color = VegaContext.NColors.Find(id);
            VegaContext.NColors.Remove(color);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
