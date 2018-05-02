using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Server;

namespace iS3.Geology.Server
{
    public class GeologyDbContext : iS3DbContext
    {
        //public GeologyDbContext(): base("DB_iS3", "Models.Project.DB_iS3")
        //{

        //}
        public GeologyDbContext() : base()
        {

        }
        public DbSet<Borehole> Borehole { get; set; }
        public DbSet<BoreholeGeology> BoreholeGeology { get; set; }
        public override iS3DbContext GetInstance()
        {
            return new GeologyDbContext();
        }
    }
}
