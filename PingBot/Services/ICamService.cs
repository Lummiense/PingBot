using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch.Operations;
using PingBot.Contracts.Entities;

namespace PingBot.Services
{
    public interface ICamService
    {
        Task<CamEntity> GetCam(uint camID);
    }
}