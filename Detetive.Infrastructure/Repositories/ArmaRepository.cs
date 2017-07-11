using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;
using System.Data.Entity.SqlServer;

namespace Detetive.Infrastructure.Repositories
{
    public class ArmaRepository : IArmaRepository
    {
        private DetetiveContext _context;

        public ArmaRepository(DetetiveContext context)
        {
            this._context = context;
        }
        public Arma Obter(int armaID)
        {
            return _context.Armas.FirstOrDefault(x => x.ID == armaID);
        }

        public IEnumerable<Arma> Obter()
        {
            return _context.Armas.ToList();
        }

        public Arma ObterAleatorio()
        {
            return _context.Armas.OrderBy(o => Guid.NewGuid()).First();
        }
    }
}
