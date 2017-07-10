using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detetive.Domain.Services
{
    public class CasoService : ICasoService
    {
        private readonly ICasoRepository _casoRepository;
        private readonly ISuspeitoRepository _suspeitoRepository;
        private readonly IArmaRepository _armaRepository;
        private readonly ILocalRepository _localRepository;

        public CasoService(ICasoRepository casoRepository, ISuspeitoRepository suspeitoRepository, IArmaRepository armaRepository, ILocalRepository localRepository)
        {
            this._casoRepository = casoRepository;
            this._suspeitoRepository = suspeitoRepository;
            this._armaRepository = armaRepository;
            this._localRepository = localRepository;
        }

        public Caso IniciarNovo()
        {
            var suspeito = _suspeitoRepository.ObterAleatorio();
            var local = _localRepository.ObterAleatorio();
            var arma = _armaRepository.ObterAleatorio();
            var testemunha = new Testemunha();

            var caso = new Caso(suspeito, local, arma, testemunha);

            _casoRepository.Inserir(caso);
            

            return caso;
        }

        public int InterrogarTestemunha(int casoID, int armaID, int localID, int suspeitoID)
        {
            var suspeito = _suspeitoRepository.Obter(suspeitoID);
            var local = _localRepository.Obter(localID);
            var arma = _armaRepository.Obter(armaID);

            var teoria = new Teoria(suspeito, local, arma);

            return InterrogarTestemunha(casoID, teoria);
        }

        public int InterrogarTestemunha(int casoID, Teoria teoria)
        {
            var caso = _casoRepository.Obter(casoID);

            return InterrogarTestemunha(caso, teoria);
        }

        public int InterrogarTestemunha(Caso caso, Teoria teoria)
        {
            var respostas = new List<int>();

            if (teoria.Suspeito.GetHashCode() != caso.Suspeito.GetHashCode())
                respostas.Add(Teoria.TEORIA_SUSPEITO_ERRADO);

            if (teoria.Local.GetHashCode() != caso.Local.GetHashCode())
                respostas.Add(Teoria.TEORIA_LOCAL_ERRADO);

            if (teoria.Arma.GetHashCode() != caso.Arma.GetHashCode())
                respostas.Add(Teoria.TEORIA_ARMA_ERRADO);

            if (respostas.Count == 0)
            {
                return Teoria.TEORIA_CORRETA;
            }
            else if (respostas.Count == 1)
            {
                return respostas.Single();
            }
            else if (respostas.Count > 1)
            {
                return respostas.OrderBy(x => Guid.NewGuid()).First();
            }

            return -1;
        }
    }
}
