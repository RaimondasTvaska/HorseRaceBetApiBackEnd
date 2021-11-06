using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HorseRaceBetApi.Entities
{
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Runs { get; set; }
        public int Wins { get; set; }
        public string About { get; set; }
        [JsonIgnore]
        public List<Better> Betters { get; set; }
    }
}
