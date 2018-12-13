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
    public class ItemController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public ItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/item
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetAll()
        {
            return _unitOfWork.ItemRepository.getAll().ToList();
        }
        // GET api/item/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            return _unitOfWork.ItemRepository.getById(id);
        }

        // POST api/item
        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            if (item != null)
            {
                if (_unitOfWork.ItemRepository.Insert(item) >= 0)
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