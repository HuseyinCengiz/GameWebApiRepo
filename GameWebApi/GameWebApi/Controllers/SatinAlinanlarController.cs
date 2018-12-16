using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWebApi.Contracts.Responses;
using GameWebApi.Entities;
using GameWebApi.Infrastructure;
using GameWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatinAlinanlarController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public SatinAlinanlarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/satinalinanlar/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<SatinAlinanResponse>> GetAll(int id)
        {
            return ((SatinAlinanlarRepository)_unitOfWork.SatinAlinanlarRepository).getAllItemByUserId(id).ToList();
        }

        // POST api/satinalinanlar
        [HttpPost]
        public IActionResult Post([FromBody] SatinAlinanlar entity)
        {
            if (entity != null)
            {
                if (_unitOfWork.SatinAlinanlarRepository.Insert(entity) >= 0)
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