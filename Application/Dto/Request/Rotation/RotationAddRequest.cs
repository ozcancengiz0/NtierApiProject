namespace Dto.Request.Rotation
{
    public class RotationAddRequest
    {
        public string location { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public DateTime date { get; set; }
        public long tourId { get; set; }
    }
}
