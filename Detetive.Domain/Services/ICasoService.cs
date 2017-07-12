using Detetive.Domain.Entities;

namespace Detetive.Domain.Services
{
    public interface ICasoService
    {
        Caso IniciarNovo();

        int InterrogarTestemunha(Caso caso, Teoria teoria);
        int InterrogarTestemunha(int casoID, int armaID, int localID, int suspeitoID);
        int InterrogarTestemunha(int casoID, Teoria teoria);
    }
}