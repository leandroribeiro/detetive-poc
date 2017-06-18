namespace Detetive.Domain.Entities
{
    public class Teoria
    {
        public Suspeito Suspeito;
        public Local Local;
        public Arma Arma;

        public Teoria(Suspeito suspeito, Local local, Arma arma)
        {
            this.Suspeito = suspeito;
            this.Local = local;
            this.Arma = arma;
        }

        public const int TEORIA_CORRETA = 0;
        public const int TEORIA_SUSPEITO_ERRADO = 1;
        public const int TEORIA_LOCAL_ERRADO = 2;
        public const int TEORIA_ARMA_ERRADO = 3;
    }
}