using System;
using PingBot.Contracts.Entities;

namespace PingBot.Contracts
{
    public class BaseEntity:IEntity
    {
        public uint Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}