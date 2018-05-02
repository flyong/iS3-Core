using iS3.Core.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Geology.Server
{
    public class BoreholeGeologyRepositoryForServer : RepositoryForServer<BoreholeGeology>, IBoreholeGeologyRepository
    {
        public BoreholeGeologyRepositoryForServer(iS3DbContext dbContext) : base(dbContext)
        {

        }
    }
}
