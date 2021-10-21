using System;
using System.Collections.Generic;

namespace PingBot.Contracts.Entities
{
    public class ContractEntity:BaseEntity
    {
        public uint Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ContractTitle { get; set; }
        public List<CamEntity> Cams { get; set; }
    }
}