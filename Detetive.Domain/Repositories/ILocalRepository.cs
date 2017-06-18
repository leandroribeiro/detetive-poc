using Detetive.Domain.Entities;

namespace Detetive.Domain.Repositories
{
    public interface ILocalRepository
    {
        Local Obter(int localID);
    }
}