using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DomainModel.Entities
{
    [Table("tours")]
    public class Tour : EntityBase
    {
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        [JsonIgnore]
        public ICollection<Rotation> Rotations { get; } = new List<Rotation>();
    }
}
