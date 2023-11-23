using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("rooms")]
    public class Room : EntityBase
    {
        public string Type { get; set; } = string.Empty;
        public double Price { get; set; }
        public long HotelId { get; set; }
    }
}
