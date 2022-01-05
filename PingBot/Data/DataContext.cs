using Microsoft.EntityFrameworkCore;
using PingBot.Contracts.Entities;

namespace PingBot.Data
{
    public class DataContext:DbContext
    {
        public DbSet<CamEntity> Camers { get; set; }
        // public DbSet<CamTypeEntity> CamTypes { get; set; }
        public DbSet<ContractEntity> Contract { get; set; }
       
        
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
    }
}