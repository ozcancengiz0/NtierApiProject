namespace Dto.Response.Manager
{
    public class ManagerGetResponse
    {
        public long id { get; set; }
        public string name { get; set; } = string.Empty;
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public bool isActive { get; set; }
        public DomainModel.Entities.Agent agent { get; set; } = null!;
    }
}
