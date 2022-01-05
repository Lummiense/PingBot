using System.Threading.Tasks;
using PingBot.Contracts.Entities;
using PingBot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace PingBot.Commands
{
    public class StartCommand:BaseCommand
    {
        private readonly ICamService _camService;
        private readonly TelegramBotClient _client;

        public StartCommand(ICamService camService, TelegramBot telegramBot)
        {
            _client = telegramBot.GetBot().Result;
            _camService = camService;
        }

        public override string Name => CommandNames.StartCommand;
        public override async Task ExecuteAsync(Update update)
        {
            var InlineKeyboard = new InlineKeyboardMarkup(
                new[]
                {
                   new InlineKeyboardButton
                    {
                        Text = "Отобразить камеру",
                        CallbackData=CommandNames.GetCamCommand
                        //CallBack не работает. Почему?
                    }
                }
            );
            var chat = update.Message?.Chat;
            await _client.SendTextMessageAsync(chat.Id, "Добро пожаловать в бот контроля камер", ParseMode.Markdown,
                replyMarkup: InlineKeyboard);

        }
    }
}