using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Detetive.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class LocalController : Controller
    {
        private readonly ILocalRepository _repository;

        public LocalController(ILocalRepository repository)
        {
            _repository = repository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Local> Get()
        {
            return _repository.Obter();
        }

    }
}
