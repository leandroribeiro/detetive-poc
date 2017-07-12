using System;

namespace Detetive.Domain.Entities
{
    public class Caso
    {
        public Caso()
        {

        }

        public int ID { get; set; }
        public DateTime DataAbertura { get; set; }

        public virtual Suspeito Suspeito { get; set; }
        public int SuspeitoID { get; set; }

        public virtual Local Local { get; set; }
        public int LocalID { get; set; }

        public virtual Arma Arma { get; set; }
        public int ArmaID { get; set; }

        public Testemunha Testemunha { get; set; }
        

        public Caso(Suspeito suspeito, Local local, Arma arma, Testemunha testemunha)
        {
            this.DataAbertura = DateTime.Now;

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