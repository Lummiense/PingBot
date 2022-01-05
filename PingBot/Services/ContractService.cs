using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PingBot.Contracts.Entities;
using PingBot.Data;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace PingBot.Services
{
    public class ContractService:IContractService
    {
        private readonly DataContext _context;

        public ContractService(DataContext context)
        {
            _context = context;
        }

        
        public async Task<ContractEntity> GetСontract(uint contractID)
        {
            return await _context.Contract.FirstOrDefaultAsync(x => x.Id == contractID);
        }
    }
}