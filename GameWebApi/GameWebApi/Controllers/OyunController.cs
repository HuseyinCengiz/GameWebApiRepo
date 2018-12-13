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
    public class OyunController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public OyunController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/item
        [HttpGet]
        public ActionResult<IEnumerable<Oyun>> GetAll()
        {
            return _unitOfWork.OyunRepository.getAll().ToList();
        }
        // GET api/item/{id}
        [HttpGet("{id}")]
        public ActionResult<Oyun> Get(int id)
        {
            return _unitOfWork.OyunRepository.getById(id);
        }

        // POST api/item
        [HttpPost]
        public IActionResult Post([FromBody] Oyun oyun)
        {
            if (oyun != null)
            {
                if (_unitOfWork.OyunRepository.Insert(oyun) >= 0)
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

        // PUT api/item/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/item/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}