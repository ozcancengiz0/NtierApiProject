namespace Dto.Response.TourOrder
{
    public class TourOrderGetResponse
    {
        public long id { get; set; }
        public DomainModel.Entities.Tour tour { get; set; } = null!;
        public DomainModel.Entities.Agent agent { get; set; } = null!;
        public bool isActive { get; set; }
        public ICollection<DomainModel.Entities.Customer> customers { get; set; } = new List<DomainModel.Entities.Customer>();
    }
}
