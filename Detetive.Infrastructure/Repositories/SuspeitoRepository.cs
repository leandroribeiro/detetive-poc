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
    public class SuspeitoRepository : Repository<Suspeito>, ISuspeitoRepository
    {
        public SuspeitoRepository(DbContext context) : base(context)
        {
        }
    }
}
