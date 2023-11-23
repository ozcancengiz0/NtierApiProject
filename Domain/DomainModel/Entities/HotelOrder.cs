using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("hotelOrders")]
    public class HotelOrder : EntityBase
    {
        public int Night { get; set; }
        public double Total { get; set; }
        public long RoomId { get; set; }
        public Room Room { get; set; } = null!;
        public long HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;
        public long AgentId { get; set; }
        public Agent Agent { get; set; } = null!;
    }
}
