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
    public class OzellikController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public OzellikController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/ozellik
        [HttpGet]
        public ActionResult<IEnumerable<Ozellik>> GetAll()
        {
            return _unitOfWork.OzellikRepository.getAll().ToList();
        }

        // POST api/ozellik
        [HttpPost]
        public IActionResult Post([FromBody] Ozellik ozellik)
        {
            if (ozellik != null)
            {
                if (_unitOfWork.OzellikRepository.Insert(ozellik) >= 0)
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