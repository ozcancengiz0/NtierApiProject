using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("rotations")]
    public class Rotation : EntityBase
    {
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public long TourId { get; set; }
    }
}
