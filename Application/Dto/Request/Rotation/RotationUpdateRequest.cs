namespace Dto.Request.Rotation
{
    public class RotationUpdateRequest
    {
        public long id { get; set; }
        public string location { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public DateTime date { get; set; }
        public long tourId { get; set; }
    }
}
