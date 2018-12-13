using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWebApi.Entities;
using GameWebApi.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public MarketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/yapimci
        [HttpGet]
        public ActionResult<IEnumerable<Market>> GetAll()
        {
            return _unitOfWork.MarketRepository.getAll().ToList();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Market market)
        {
            if (market != null)
            {
                if (_unitOfWork.MarketRepository.Insert(market) >= 0)
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