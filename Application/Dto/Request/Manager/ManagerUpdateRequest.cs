using DomainModel.Entities;

namespace Dto.Request.Manager
{
    public class ManagerUpdateRequest
    {
        public long id { get; set; }
        public string name { get; set; } = string.Empty;
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public long agentId { get; set; }
    }
}
