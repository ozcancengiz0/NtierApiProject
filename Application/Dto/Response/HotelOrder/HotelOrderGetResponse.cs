namespace Dto.Response.HotelOrder
{
    public class HotelOrderGetResponse
    {
        public long id { get; set; }
        public int night { get; set; }
        public double total { get; set; }
        public bool isActive { get; set; }
        public DomainModel.Entities.Room room { get; set; } = null!;
        public DomainModel.Entities.Hotel hotel { get; set; } = null!;
        public DomainModel.Entities.Agent agent { get; set; } = null!;

    }
}
