using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detetive.Infrastructure
{
    public class MigrationsContextFactory : IDbContextFactory<DetetiveContext>
    {
        public DetetiveContext Create()
        {
            return new DetetiveContext("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Detetive;Integrated Security=SSPI;");
        }
    }
}
