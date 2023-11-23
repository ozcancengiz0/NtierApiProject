namespace Dto.Response.Room
{
    public class RoomGetResponse
    {
        public long id { get; set; }
        public string type { get; set; } = string.Empty;
        public double price { get; set; }
        public bool isActive { get; set; }
    }
}
