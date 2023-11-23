using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("managers")]
    public class Manager : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } =  string.Empty;
        public long AgentId { get; set; }
        public Agent Agent { get; set; } = null!;
    }
}
