using Detetive.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Detetive.Domain.Entities;

namespace Detetive.Infrastructure.Repositories
{
    public class CasoRepository : ICasoRepository
    {
        private DetetiveContext _context;

        public CasoRepository(DetetiveContext context)
        {
            _context = context;
        }

        public void Inserir(Caso caso)
        {
            _context.Casos.Add(caso);
        }

        public Caso Obter(int casoID)
        {
            return _context.Casos.FirstOrDefault(x => x.ID == casoID);
        }
    }
}
