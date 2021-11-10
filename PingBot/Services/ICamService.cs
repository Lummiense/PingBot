using System.Collections.Generic;
using System.Threading.Tasks;
using PingBot.Contracts.Entities;

namespace PingBot.Services
{
    public interface ICamService
    {
        CamEntity Get(uint Id);
        CamEntity GetByIp(string Ip);
        IEnumerable<CamEntity> GetAll();
        Task<uint> Add(CamEntity Cam);
        Task AddRange(IEnumerable<CamEntity> Camers);
        Task<uint> Update(CamEntity Cam);
        Task UpdateRange(IEnumerable<CamEntity> Camers);
        Task Delete(uint Id);
        Task Remove(CamEntity Cam);
        Task DeleteRange(IEnumerable<CamEntity> Camers);
    }
}