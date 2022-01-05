using System.Threading.Tasks;
using PingBot.Contracts.Entities;
using Telegram.Bot.Types;

namespace PingBot.Services
{
    public interface IContractService
    {
         Task<ContractEntity> GetСontract(uint contractID);
    }
}