using System;

namespace PingBot.Contracts.Entities
{
    public interface IEntity
    {
        public uint Id { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}