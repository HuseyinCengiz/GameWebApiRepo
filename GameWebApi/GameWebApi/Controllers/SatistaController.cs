using GameWebApi.Contracts.Requests;
using GameWebApi.Contracts.Responses;
using GameWebApi.Entities;
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

        // POST api/satista
        [HttpPost]
        public IActionResult Post([FromBody] Satista satista)
        {
            if (satista != null)
            {
                if (_unitOfWork.SatistaRepository.Insert(satista) >= 0)
                {
                    try
                    {
                        _unitOfWork.Commit();
                    }
                    catch (Exception)
                    {

                        return StatusCode(500);
                    }
                    return Ok();
                }
            }

            return BadRequest();
        }

    }




}
