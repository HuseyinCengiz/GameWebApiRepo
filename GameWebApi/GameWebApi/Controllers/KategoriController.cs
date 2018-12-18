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
    public class KategoriController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public KategoriController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/kategori
        [HttpGet]
        public ActionResult<IEnumerable<Kategori>> GetAll()
        {
            return _unitOfWork.KategoriRepository.getAll().ToList();
        }
        [HttpPost]
        public IActionResult Post([FromBody] Kategori kategori)
        {
            if (kategori != null)
            {
                if (_unitOfWork.KategoriRepository.Insert(kategori) >= 0)
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