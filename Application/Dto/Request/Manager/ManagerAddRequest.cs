namespace Dto.Request.Manager
{
    public class ManagerAddRequest
    {
        public string name { get; set; } = string.Empty;
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public bool isActive { get; set; } = false;
        public long agentId { get; set; }
    }
}
