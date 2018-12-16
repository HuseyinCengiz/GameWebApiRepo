using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWebApi.Entities;
using GameWebApi.Infrastructure;
using GameWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public KullaniciController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // POST api/kullanici
        [HttpPost("login")]
        public ActionResult<int> Login([FromBody] Kullanici entity)
        {
            try
            {
                if (entity != null)
                {
                    return ((KullaniciRepository)_unitOfWork.KullaniciRepository).IsLogin(entity);
                }
                else
                {
                    return Forbid();
                }

            }
            catch (Exception)
            {
                return -1;
            }
        }

        // GET api/kullanici/{kullaniciId}
        [HttpGet("{kullaniciId}")]
        public ActionResult<string> GetUserName(int kullaniciId)
        {
            return ((KullaniciRepository)_unitOfWork.KullaniciRepository).getUserName(kullaniciId);
        }
    }
}