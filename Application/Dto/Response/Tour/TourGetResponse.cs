

namespace Dto.Response.Tour
{
    public class TourGetResponse
    {
        public long id { get; set; }
        public string type { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public DateTime startingDate { get; set; }
        public DateTime endingDate { get; set; }
        public bool isActive { get; set; }
        public ICollection<DomainModel.Entities.Rotation> Rotations { get; set; }=new List<DomainModel.Entities.Rotation>();
    }
}
