namespace Dto.Request.Vehicle
{
    public class VehicleAddRequest
    {
        public string thumbnailImage { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string numberPlate { get; set; } = string.Empty;
        public double price { get; set; }
    }
}
