namespace Dto.Request.Room
{
    public class RoomAddRequest
    {
        public string type { get; set; } = string.Empty;
        public double price { get; set; }
        public long hotelId { get; set; }
    }
}
