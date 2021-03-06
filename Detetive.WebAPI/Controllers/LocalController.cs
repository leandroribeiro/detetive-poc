﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Detetive.Domain;
using Detetive.Domain.Entities;
using Detetive.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Detetive.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class LocalController : Controller
    {
        private readonly IUnitOfWork _uow;

        public LocalController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Local> Get()
        {
            return _uow.LocalRepository.Get();
        }

    }
}
