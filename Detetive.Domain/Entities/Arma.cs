using System.Collections.Generic;

namespace Detetive.Domain.Entities
{
    public class Arma : Entity<int>
    {

        public string Nome { get; set; }
        public ICollection<Caso> Casos { get; set; }

        public Arma()
        {
        }

        public Arma(string nome)
        {
            Nome = nome;
        }

    }
}