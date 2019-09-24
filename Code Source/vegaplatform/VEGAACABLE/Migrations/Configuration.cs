using System.Drawing.Design;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VEGAACABLE.DAL.VegaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VEGAACABLE.DAL.VegaContext context)
        {

        }
    }
}
