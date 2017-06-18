namespace Detetive.Domain.Entities
{
    public class Caso
    {
        public Suspeito Suspeito;
        public Local Local;
        public Arma Arma;

        public Caso(Suspeito suspeito, Local local, Arma arma)
        {
            this.Suspeito = suspeito;
            this.Local = local;
            this.Arma = arma;
        }

        public Testemunha Testemunha { get; set; }

        public void AtribuirTestemunha(Testemunha testemunha)
        {
            this.Testemunha = testemunha;
            this.Testemunha.Caso = this;
        }
    }
}