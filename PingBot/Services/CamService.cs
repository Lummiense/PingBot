using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PingBot.Contracts;
using PingBot.Contracts.Entities;

namespace PingBot.Services
{
    public class CamService:ICamService
    {
        //TODO: Add check for  incoming data
        private readonly IDbRepository _dbRepository;
        public CamService(IDbRepository repository)
        {
            _dbRepository = repository;
        }
        public CamEntity Get(uint Id)
        {
            var entity = _dbRepository.Get<CamEntity>().FirstOrDefault(x => x.Id == Id);
            return entity;
        }

        // public CamEntity GetByIp(string Ip)
        // {
        //     var entity = _dbRepository.Get<CamEntity>().FirstOrDefault(x => x.IP == Ip);
        //     return entity;
        // }

        public IEnumerable<CamEntity> GetAll()
        {
            return _dbRepository.GetAll<CamEntity>();
        }

        public async Task<uint> Add(CamEntity Cam)
        {
            var result = await _dbRepository.Add(Cam);
            await _dbRepository.SaveChangesAsync();
            return result;
        }

        public async Task AddRange(IEnumerable<CamEntity> Camers)
        {
            await _dbRepository.AddRange(Camers);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task<uint> Update(CamEntity Cam)
        {
            await _dbRepository.Update<CamEntity>(Cam);
            await _dbRepository.SaveChangesAsync();
            return Cam.Id;
        }

        public async Task UpdateRange(IEnumerable<CamEntity> Camers)
        {
            await _dbRepository.UpdateRange(Camers);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task Remove (CamEntity Cam)
        {
            await _dbRepository.Remove(Cam);
        }
        public async Task Delete(uint Id)
        {
            var entity = _dbRepository.Get<CamEntity>().FirstOrDefault(x => x.Id == Id);
            await _dbRepository.Remove(entity);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<CamEntity> Camers)
        {
            await _dbRepository.DeleteRange(Camers);
            await _dbRepository.SaveChangesAsync();
            }
    }
}