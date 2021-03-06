using System;


namespace PingBot.Contracts.Entities
{
    
    public class CamEntity:IEntity
    {
        public long ChatId { get; set; }
        public uint Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public string InstallationAddress { get; set; }
        public string ViewDescription { get; set; }
        public string Coordinates { get; set; }
        public string InstallationPlacePhoto { get; set; }
        public string ViewPhoto { get; set; }
        public string IP { get; set; }
        public ContractEntity Contract { get; set; }
    }
}