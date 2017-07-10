namespace Detetive.Domain.Entities
{
    public class Caso
    {
        public int ID { get; set; }
        public Suspeito Suspeito { get; set; }
        public Local Local { get; set; }
        public Arma Arma { get; set; }
        public Testemunha Testemunha { get; set; }

        public Caso(Suspeito suspeito, Local local, Arma arma, Testemunha testemunha)
        {
            this.Suspeito = suspeito;
            this.Local = local;
            this.Arma = arma;

            AtribuirTestemunha(testemunha);
            
        }

        public void AtribuirTestemunha(Testemunha testemunha)
        {
            this.Testemunha = testemunha;
            this.Testemunha.Caso = this;
        }
    }
}