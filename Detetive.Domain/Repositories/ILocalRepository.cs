using Detetive.Domain.Entities;
using System.Collections.Generic;

namespace Detetive.Domain.Repositories
{
    public interface ILocalRepository
    {
        Local Obter(int localID);
        IEnumerable<Local> Obter();
        Local ObterAleatorio();
    }
}