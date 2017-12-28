using System;

namespace Detetive.Domain.Entities
{
    public class Caso
    {
        protected Caso()
        {
            
        }

        public Caso(int suspeitoId, int armaId, int localId) : this(new Suspeito { ID = suspeitoId }, new Local() { ID = localId }, new Arma() { ID = armaId })
        {

        }

        public Caso(Suspeito suspeito, Local local, Arma arma) : this(suspeito, local, arma, new Testemunha())
        {

        }

        public Caso(Suspeito suspeito, Local local, Arma arma, Testemunha testemunha)
        {
            this.DataAbertura = DateTime.Now;

            this.Suspeito = suspeito;
            this.SuspeitoID = suspeito.ID;

            this.Local = local;
            this.LocalID = local.ID;

            this.Arma = arma;
            this.ArmaID = arma.ID;

            AtribuirTestemunha(testemunha);

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


        public void AtribuirTestemunha(Testemunha testemunha)
        {
            this.Testemunha = testemunha;
            this.Testemunha.Caso = this;
        }
    }
}