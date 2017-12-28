using System;
using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;

namespace Detetive.Domain
{
    public interface IUnitOfWork : IDisposable
    {

        void Commit();

        IRepository<Arma> ArmaRepository { get; }
        IRepository<Caso> CasoRepository { get; }
        IRepository<Local> LocalRepository { get; }
        IRepository<Suspeito> SuspeitoRepository { get; }
    }
}
