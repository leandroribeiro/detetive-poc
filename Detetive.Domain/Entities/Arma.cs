namespace Detetive.Domain.Entities
{
    public class Arma
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public Arma()
        {

        }

        public Arma(string nome)
        {
            Nome = nome;
        }
    }
}