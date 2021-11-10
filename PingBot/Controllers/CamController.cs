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
            var cam = _camService.Get(id);

            if (cam == null)
            {
                return BadRequest("Cam  was not found");
            }

            return Ok(cam);
        }
        
        [HttpGet("{ip}")]
        public ActionResult<CamEntity> GetByIp(uint ip)
        {
            var cam = _camService.Get(ip);

            if (cam == null)
            {
                return BadRequest("Cam  was not found");
            }

            return Ok(cam);
        }  
        [HttpGet]
        public ActionResult<CamEntity> GetAll()
        {
            var cams = _camService.GetAll();

            if (cams == null)
            {
                return BadRequest("Cams list is empty");
            }

            return Ok(cams);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CamEntity cam)
        {
            if (cam == null)
            {
                return BadRequest("Cam is null");
            }
            
            await _camService.Add(cam);
            
            return Ok("Cam added");
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> AddRange(IEnumerable<CamEntity> Camers)
        {
            if (Camers == null)
            {
                return BadRequest("List of cams is empty");
            }
            
            await _camService.AddRange(Camers);
            
            return Ok("Cams added");
        }
        [HttpPut]
        public async Task<IActionResult> Update(CamEntity cam)
        {
            if (cam == null)
            {
                return BadRequest("Cam is null");
            }
            
            await _camService.Update(cam);

            return Ok("Cam updated");
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(CamEntity cam)
        {
            if (cam == null)
            {
                return BadRequest("Cam is null");
            }
            
            await _camService.Remove(cam);

            return Ok("Cam deleted");
        }

    }
}