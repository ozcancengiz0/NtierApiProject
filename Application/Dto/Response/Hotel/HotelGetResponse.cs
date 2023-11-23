namespace Dto.Response.Hotel
{
    public class HotelGetResponse
    {
        public long id { get; set; }
        public string name { get; set; } = string.Empty;
        public string adress { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string thumbnailImage { get; set; } = string.Empty;
        public int star { get; set; }
        public bool isActive { get; set; }
        public ICollection<DomainModel.Entities.Room> Rooms { get; } = new List<DomainModel.Entities.Room>();
    }
}
