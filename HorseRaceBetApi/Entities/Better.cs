using System.Text.Json.Serialization;

namespace HorseRaceBetApi.Entities
{
    public class Better
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Bet { get; set; }
        public int HorseId { get; set; }
        [JsonIgnore]
        public Horse Horse { get; set; }
    }
}
