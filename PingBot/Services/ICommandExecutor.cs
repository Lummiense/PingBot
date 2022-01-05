using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace PingBot.Services
{
    public interface ICommandExecutor
    {
        Task Execute(Update update);
    }
}