using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.EntityFrameworkCore;
using PingBot.Contracts;
using PingBot.Contracts.Entities;
using PingBot.Data;

namespace PingBot.Services
{
    public class CamService : ICamService
    {
        private readonly DataContext _context;

        public CamService(DataContext context)
        {
            _context = context;
        }
        public async Task<CamEntity> GetCam(uint camID)
        {
            return await _context.Camers.FirstOrDefaultAsync(x =>x.Id==camID);
        }
    }
}