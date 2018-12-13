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
    public class YapimciController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public YapimciController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/yapimci
        [HttpGet]
        public ActionResult<IEnumerable<Yapimci>> GetAll()
        {
            return _unitOfWork.YapimciRepository.getAll().ToList();
        }
        // GET api/yapimci/{id}
        [HttpGet("{id}")]
        public ActionResult<Yapimci> Get(int id)
        {
            return _unitOfWork.YapimciRepository.getById(id);
        }

        // POST api/yapimci
        [HttpPost]
        public IActionResult Post([FromBody] Yapimci yapimci)
        {
            if (yapimci != null)
            {
                if (_unitOfWork.YapimciRepository.Insert(yapimci) >= 0)
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