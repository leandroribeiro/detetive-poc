using System.Collections.Generic;

namespace Detetive.Domain.Entities
{
    public class Local : Entity<int>
    {
        public string Nome { get; set; }

        public ICollection<Caso> Casos { get; set; }

        public Local()
        {
        }

        public Local(string nome)
        {
            Nome = nome;
        }

    }

}