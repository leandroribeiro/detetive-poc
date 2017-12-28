using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;
using System.Data.Entity.SqlServer;

namespace Detetive.Infrastructure.Repositories
{
    public class ArmaRepository : Repository<Arma>, IArmaRepository
    {
        public ArmaRepository(DbContext context) : base(context)
        {
        }
    }
}
