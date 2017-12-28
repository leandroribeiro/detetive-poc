using Detetive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detetive.WebAPI.Models
{
    public class CasoResponseModel
    {
        public int Id { get; set; }
        public string DataAbertura { get; set; }

        public CasoResponseModel(Caso model)
        {
            Create(model);
        }

        private void Create(Caso model)
        {
            this.Id = model.Id;
            this.DataAbertura = model.DataAbertura.ToString("dd/MM/yyyy");
        }
    }
}
