using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;

namespace Detetive.Domain
{
    public interface IUnitOfWork
    {

        void Commit();

        IRepository<Arma> ArmaRepository { get; }
        IRepository<Caso> CasoRepository { get; }
        IRepository<Local> LocalRepository { get; }
        IRepository<Suspeito> SuspeitoRepository { get; }
    }
}
