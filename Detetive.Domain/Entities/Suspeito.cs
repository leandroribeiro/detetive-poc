using System.Globalization;

namespace Detetive.Domain.Entities
{
    public class Suspeito
    {
        private const string CULTURE = "pt-BR";

        public string Nome { get; set; }

        public Suspeito()
        {

        }

        public Suspeito(string nome)
        {
            var textInfo = new CultureInfo(CULTURE, false).TextInfo;
            Nome = textInfo.ToTitleCase(nome.Trim());
        }

        public int ID { get; set; }
    }
}