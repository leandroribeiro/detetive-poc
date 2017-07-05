using System.Collections.Generic;
using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Detetive.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ArmaController
    {
        private IArmaRepository _repository {get; set;}

        public ArmaController(IArmaRepository repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Arma> Get()
        {
            return _repository.Obter();
        }
    }
}