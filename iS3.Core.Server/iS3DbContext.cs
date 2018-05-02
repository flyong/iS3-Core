using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using iS3.Core.Server;
using System.Data.Entity.Core.EntityClient;

namespace iS3.Core.Server
{
    public class iS3DbContext : DbContext
    {
        public iS3DbContext() : base("name=MyStrConn")
        {

        }
        //public iS3DbContext(string db, string path)
        //   : base(ConnectString(db, path))
        //{
        //}
        public virtual iS3DbContext GetInstance()
        {
            return new iS3DbContext();
        }
        private static string ConnectString(string db, string path)

        {
            //SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
            //{
            //    DataSource = DBUtil.ip,
            //    InitialCatalog = db,
            //    UserID = DBUtil.user,
            //    Password = DBUtil.password,
            //};

            //Build an Entity Framework connection string
            EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder()
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = "Server = 127.0.0.1;Database = iS3Test;User ID = sa;Password = 123456;Integrated Security=True"
            };
            return entityString.ConnectionString;
        }

    }
}
