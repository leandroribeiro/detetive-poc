using System;
using System.Collections.Generic;
using System.Linq;

namespace Detetive.Domain.Entities
{
    public class Testemunha
    {
        public Caso Caso { get; set; }

        public int Interrogar(Teoria teoria)
        {
            var respostas = new List<int>();

            if (teoria.Suspeito.GetHashCode() != Caso.Suspeito.GetHashCode())
                respostas.Add(Teoria.TEORIA_SUSPEITO_ERRADO);

            if (teoria.Local.GetHashCode() != Caso.Local.GetHashCode())
                respostas.Add(Teoria.TEORIA_LOCAL_ERRADO);

            if (teoria.Arma.GetHashCode() != Caso.Arma.GetHashCode())
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