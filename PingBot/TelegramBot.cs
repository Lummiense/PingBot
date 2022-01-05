using System.Threading.Tasks;
using Telegram.Bot;
using Microsoft.Extensions.Configuration;

namespace PingBot
{
    public class TelegramBot
    {
        private readonly IConfiguration _configuration;
        private TelegramBotClient _client;

        public TelegramBot(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TelegramBotClient> GetBot()
        {
            if (_client!=null)
            {
                return _client;
            }

            _client = new TelegramBotClient(_configuration["Token"]);
            var hook = $"{_configuration["Url"]}api/message/update";
            await _client.SetWebhookAsync(hook);
            return _client;

        }
    }
}