using Detetive.Domain.Entities;

namespace Detetive.Domain.Repositories
{
    public interface ISuspeitoRepository
    {
        Suspeito Obter(int suspeitoID);
    }
}