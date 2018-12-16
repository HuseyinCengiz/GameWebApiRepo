using GameWebApi.Contracts.Responses;
using GameWebApi.Infrastructure;
using GameWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatistaController:ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public SatistaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET api/satislar
        [HttpGet]
        public ActionResult<IEnumerable<Satislar>> GetAll()
        {
            return ((SatistaRepository)_unitOfWork.SatistaRepository).getAlll().ToList();
        }

    }




}
