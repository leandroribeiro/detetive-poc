using Detetive.Domain.Entities;

namespace Detetive.Domain.Repositories
{
    public interface IArmaRepository
    {
        Arma Obter(int armaID);
    }
}