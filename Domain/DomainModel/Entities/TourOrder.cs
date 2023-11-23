using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DomainModel.Entities
{
    [Table("tourOrders")]
    public class TourOrder : EntityBase
    {
        public long TourId { get; set; }
        public Tour Tour { get; set; } = null!;
        [JsonIgnore]
        public ICollection<Customer> Customers { get; } = new List<Customer>();
        public long AgentId { get; set; }
        public Agent Agent { get; set; } = null!;
    }
}
