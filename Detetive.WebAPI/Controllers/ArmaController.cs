using System.Collections.Generic;
using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;
using Detetive.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Detetive.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ArmaController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public ArmaController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Arma> Get()
        {
            return _unitOfWork.ArmaRepository.Get();
        }

    }

}