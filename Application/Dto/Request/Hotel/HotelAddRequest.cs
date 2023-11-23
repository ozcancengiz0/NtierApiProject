using DomainModel.Entities;

namespace Dto.Request.Hotel
{
    public class HotelAddRequest
    {
        public string name { get; set; } = string.Empty;
        public string adress { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string thumbnailImage { get; set; } = string.Empty;
        public int star { get; set; }
    }
}
