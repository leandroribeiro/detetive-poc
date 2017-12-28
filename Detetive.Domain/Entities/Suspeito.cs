using System.Collections.Generic;
using System.Globalization;

namespace Detetive.Domain.Entities
{
    public class Suspeito : Entity<int>
    {
        private const string CULTURE = "pt-BR";

        public string Nome { get; set; }

        public Suspeito()
        {
        }

        public Suspeito(string nome)
        {
            var textInfo = new CultureInfo(CULTURE, false).TextInfo;
            Nome = textInfo.ToTitleCase(nome.ToLower().Trim());
        }

        public ICollection<Caso> Casos { get; set; }
    }
}