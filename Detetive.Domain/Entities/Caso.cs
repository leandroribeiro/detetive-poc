using System;

namespace Detetive.Domain.Entities
{
    public class Caso : Entity<int>
    {
        protected Caso()
        {
            
        }

        public Caso(int suspeitoId, int armaId, int localId) : this(new Suspeito { Id = suspeitoId }, new Local() { Id = localId }, new Arma() { Id = armaId })
        {

        }

        public Caso(Suspeito suspeito, Local local, Arma arma) : this(suspeito, local, arma, new Testemunha())
        {

        }

        public Caso(Suspeito suspeito, Local local, Arma arma, Testemunha testemunha)
        {
            this.DataAbertura = DateTime.Now;

            this.Suspeito = suspeito;
            this.SuspeitoId = suspeito.Id;

            this.Local = local;
            this.LocalId = local.Id;

            this.Arma = arma;
            this.ArmaId = arma.Id;

            AtribuirTestemunha(testemunha);

        }

        public DateTime DataAbertura { get; set; }

        public virtual Suspeito Suspeito { get; set; }
        public int SuspeitoId { get; set; }

        public virtual Local Local { get; set; }
        public int LocalId { get; set; }

        public virtual Arma Arma { get; set; }
        public int ArmaId { get; set; }

        public Testemunha Testemunha { get; set; }


        public void AtribuirTestemunha(Testemunha testemunha)
        {
            this.Testemunha = testemunha;
            this.Testemunha.Caso = this;
        }
    }
}