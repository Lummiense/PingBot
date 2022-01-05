using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PingBot.Contracts.Entities;
using PingBot.Services;

namespace PingBot.Controllers
{
    [Route("Cams")]
    [ApiController]
    public class CamController : Controller
    {
        private readonly ICamService _camService;

        public CamController(ICamService camService)
        {
            _camService = camService;
        }

        [HttpGet("{id}")]
        public ActionResult<CamEntity> Get(uint id)
        {
            var cam = _camService.GetCam(id);

            if (cam == null)
            {
                return BadRequest("Cam  was not found");
            }

            return Ok(cam);
        }

     
    }
}