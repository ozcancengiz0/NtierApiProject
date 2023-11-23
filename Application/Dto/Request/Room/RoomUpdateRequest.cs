namespace Dto.Request.Room
{
    public class RoomUpdateRequest
    {
        public long id { get; set; }
        public string type { get; set; } = string.Empty;
        public double price { get; set; }
        public long hotelId { get; set; }
    }
}
