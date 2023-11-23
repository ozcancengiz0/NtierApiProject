using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("transferOrders")]
    public class TransferOrder : EntityBase
    {
        public string StartingPosition { get; set; } = string.Empty;
        public string EndPosition { get; set; } = string.Empty;
        public DateTime StartingDate { get; set; }
        public bool Hostess { get; set; }
        public long AgentId { get; set; }
        public Agent Agent { get; set; } = null!;
        public long VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
    }
}
