using Detetive.Domain.Entities;
using System.Collections.Generic;

namespace Detetive.Domain.Repositories
{
    public interface ISuspeitoRepository
    {
        Suspeito Obter(int suspeitoID);
        IEnumerable<Suspeito> Obter();
        Suspeito ObterAleatorio();
    }
}