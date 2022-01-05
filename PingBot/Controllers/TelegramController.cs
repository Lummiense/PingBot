using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PingBot.Contracts.Entities;
using PingBot.Data;
using PingBot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace PingBot.Controllers
{
    [Route("api/message/update")]
    [ApiController]
    public class TelegramController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        public TelegramController(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody]object update)
        {
         
            var upd = JsonConvert.DeserializeObject<Update>(update.ToString());

            if (upd?.Message?.Chat == null && upd?.CallbackQuery == null)
            {
                return Ok();
            }

            try
            {
                await _commandExecutor.Execute(upd);
            }
            catch (Exception e)
            {
                return Ok();
            }
            
            return Ok();
        }
        
    }
    

}