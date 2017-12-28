using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Detetive.Domain;
using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;
using Detetive.Infrastructure.Migrations;
using Detetive.Infrastructure.Repositories;

namespace Detetive.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DetetiveContext _context;

        private Repository<Arma> _armaRepository;
        private Repository<Caso> _casoRepository;
        private Repository<Local> _localRepository;
        private Repository<Suspeito> _suspeitoRepository;

        public UnitOfWork(DetetiveContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();

        }

        public IRepository<Arma> ArmaRepository => _armaRepository ?? (_armaRepository = new ArmaRepository(_context));

        public IRepository<Caso> CasoRepository => _casoRepository ?? (_casoRepository = new CasoRepository(_context));

        public IRepository<Local> LocalRepository =>
            _localRepository ?? (_localRepository = new LocalRepository(_context));

        public IRepository<Suspeito> SuspeitoRepository =>
            _suspeitoRepository ?? (_suspeitoRepository = new SuspeitoRepository(_context));


        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
