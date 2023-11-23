using DomainModel.Entities;

namespace Dto.Response.Rotation
{
    public class RotationGetResponse
    {
        public long id { get; set; }
        public string location { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public DateTime date { get; set; }
        public bool isActive { get; set; }
    }
}
