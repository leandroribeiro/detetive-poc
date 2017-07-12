using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;
using Detetive.Domain.Services;
using Detetive.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detetive.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CasoController : Controller
    {
        private ICasoService _service { get; set; }

        public CasoController(ICasoService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("novo")]
        public IActionResult Novo()
        {
            var caso =_service.IniciarNovo();
            var casoResponse = new CasoResponseModel(caso);

            return Ok(casoResponse);

            //return this.Created(string.Format("/Books/GetById/{0}", newBook.Id), Mapper.Map<BookResponseModel>(newBook));
            //return CreatedAtRoute("GetCaso", new { id = item.Id }, item);

        }

        [HttpPost]
        [Route("interrogar")]
        public IActionResult InterrogarTestemunha(int casoID, int armaID, int localID, int suspeitoID)
        {
            var resposta = _service.InterrogarTestemunha(casoID, armaID, localID, suspeitoID);

            return Ok(resposta);
        }

    }
}
