using System;

namespace PingBot.Contracts.Entities
{
    public class CamTypeEntity:IEntity
    {
        public uint Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CamType { get; set; }
    }
}