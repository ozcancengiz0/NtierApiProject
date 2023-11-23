namespace Dto.Request.HotelOrder
{
    public class HotelOrderUpdateRequest
    {
        public long id { get; set; }
        public int night { get; set; }
        public double total { get; set; }
        public long hotelId { get; set; }
        public long agentId { get; set; }
        public long roomId { get; set; }
    }
}
