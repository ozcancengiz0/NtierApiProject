using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("customers")]
    public class Customer : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public long TourOrderId { get; set; }
    }
}
