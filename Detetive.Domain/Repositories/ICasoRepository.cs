using Detetive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detetive.Domain.Repositories
{
    public interface ICasoRepository
    {
        Caso Obter(int casoID);
        void Inserir(Caso caso);
    }
}
