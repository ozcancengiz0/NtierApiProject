using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DomainModel.Entities
{
    [Table("hotels")]
    public class Hotel : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ThumbnailImage { get; set; } = string.Empty;
        public int Star { get; set; }
        [JsonIgnore]
        public ICollection<Room> Rooms { get; } = new List<Room>();
    }
}
