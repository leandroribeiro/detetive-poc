using Detetive.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Detetive.Domain.Entities;

namespace Detetive.Infrastructure.Repositories
{
    public class CasoRepository : Repository<Caso>, ICasoRepository
    {
        public CasoRepository(DbContext context) : base(context)
        {
        }
    }
}
