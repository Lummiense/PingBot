using System;
using System.Threading.Tasks;
using PingBot.Data;
using PingBot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace PingBot.Commands
{
    public class GetCamCommand:BaseCommand
    {
        private readonly DataContext _context;
        private readonly ICamService _camService;
        private readonly TelegramBotClient _client;

        public GetCamCommand(DataContext context, ICamService camService, TelegramBot telegramBot)
        {
            _context = context;
            _camService = camService;
            _client = telegramBot.GetBot().Result;
        }
        public override string Name => CommandNames.GetCamCommand;
        public override async Task ExecuteAsync(Update update)
        {
            //TODO: В эту команду уже должен прилетать ID нужной камеры. Вероятно нужно добавить промежуточную команду на ввод ID
            _client.SendTextMessageAsync(update.Message.Chat.Id, "Введите ID камеры", ParseMode.Markdown);
            var id = update.Message.Text.ToString();
            var cam=await _camService.GetCam(Convert.ToUInt32(id));
            string message = cam.Id + cam.IP + cam.InstallationAddress + cam.ViewDescription + cam.ViewPhoto +
                             cam.InstallationPlacePhoto;
            await _client.SendTextMessageAsync(update.Id, message, ParseMode.Markdown);
        }
    }
}