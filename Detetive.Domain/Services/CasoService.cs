using Detetive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Detetive.Domain.Services
{
    public class CasoService : ICasoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CasoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Caso IniciarNovo()
        {
            var suspeito = _unitOfWork.SuspeitoRepository.GetRandom();
            var local = _unitOfWork.LocalRepository.GetRandom();
            var arma = _unitOfWork.ArmaRepository.GetRandom();
            var testemunha = new Testemunha();

            var caso = new Caso(suspeito, local, arma, testemunha);

            _unitOfWork.CasoRepository.Insert(caso);
            _unitOfWork.Commit();


            return caso;
        }

        public int InterrogarTestemunha(int casoID, int armaID, int localID, int suspeitoID)
        {
            var suspeito = _unitOfWork.SuspeitoRepository.GetByID(suspeitoID);
            var local = _unitOfWork.LocalRepository.GetByID(localID);
            var arma = _unitOfWork.ArmaRepository.GetByID(armaID);

            var teoria = new Teoria(suspeito, local, arma);

            return InterrogarTestemunha(casoID, teoria);
        }

        public int InterrogarTestemunha(int casoID, Teoria teoria)
        {
            var caso = _unitOfWork.CasoRepository.GetByID(casoID);

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
