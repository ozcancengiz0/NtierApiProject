namespace Dto.Request.Hotel
{
    public class HotelUpdateRequest
    {
        public long id { get; set; }
        public string name { get; set; } = string.Empty;
        public string adress { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string thumbnailImage { get; set; } = string.Empty;
        public int star { get; set; }
    }
}
