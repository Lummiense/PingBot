using System;

namespace PingBot.Contracts.Entities
{
    public class IEntity
    {
        public uint Id { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}