using Detetive.Domain.Entities;
using System.Collections.Generic;

namespace Detetive.Domain.Repositories
{
    public interface IArmaRepository
    {
        Arma Obter(int armaID);
        IEnumerable<Arma> Obter();
    }
}