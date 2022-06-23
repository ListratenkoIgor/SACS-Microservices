using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SheduleService.Data.Models
{
    public class UpdateInfo
    {
        [JsonProperty("id")]
        public int Id;
        [JsonProperty("lastUpdate")]
        public DateTime LastUpdate;
    }
}
