using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("vehicles")]
    public class Vehicle : EntityBase
    {
        public string ThumbnailImage { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string NumberPlate { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
