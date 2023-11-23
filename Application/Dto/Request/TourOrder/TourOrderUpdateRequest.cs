namespace Dto.Request.TourOrder
{
    public class TourOrderUpdateRequest
    {
        public long id { get; set; }
        public long tourId { get; set; }
        public long agentId { get; set; }
    }
}
