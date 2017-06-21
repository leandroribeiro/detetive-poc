using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;

namespace Detetive.Infrastructure.Repositories
{
    public class SuspeitoRepository : ISuspeitoRepository
    {
        private DetetiveContext _context;

        public SuspeitoRepository(DetetiveContext context)
        {
            _context = context;
        }

        public Suspeito Obter(int suspeitoID)
        {
            return _context.Suspeitos.FirstOrDefault(x => x.ID == suspeitoID);
        }

        public IEnumerable<Suspeito> Obter()
        {
            return _context.Suspeitos.ToList();
        }

    }
}
