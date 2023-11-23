using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("agencies")]
    public class Agent : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;        
    }
}
