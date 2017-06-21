﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;

namespace Detetive.Infrastructure.Repositories
{
    public class LocalRepository : ILocalRepository
    {
        private DetetiveContext _context;

        public LocalRepository(DetetiveContext context)
        {
            _context = context;
        }

        public Local Obter(int localID)
        {
            return _context.Locais.FirstOrDefault(x => x.ID == localID);
        }

        public IEnumerable<Local> Obter()
        {
            return _context.Locais.ToList();
        }
    }
}