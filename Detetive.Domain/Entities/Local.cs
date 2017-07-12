using System.Collections.Generic;

namespace Detetive.Domain.Entities
{
    public class Local
    {
        public string Nome { get; set; }
        public int ID { get; set; }
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