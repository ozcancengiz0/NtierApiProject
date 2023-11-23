using System.Text.Json.Serialization;

namespace Dto.Request.Tour
{
    public class TourAddRequest
    {
        public string type { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public DateTime startingDate { get; set; }
        public DateTime endingDate { get; set; }
    }
}
