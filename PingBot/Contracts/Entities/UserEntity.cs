using System;
using System.Text.Json.Serialization;

namespace PingBot.Contracts.Entities
{
    public class UserEntity:IEntity
    {
        [JsonIgnore]
        public uint Id { get; set; }
        [JsonIgnore]
        public DateTime UpdateDate { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; }
        public long ChatId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}