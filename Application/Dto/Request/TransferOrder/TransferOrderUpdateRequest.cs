using FluentValidation;

namespace Dto.Request.Customer
{
    public class TransferOrderUpdateRequest
    {
        public long id { get; set; }
        public string startingPosition { get; set; } = string.Empty;
        public string endPosition { get; set; } = string.Empty;
        public DateTime startingDate { get; set; }
        public bool hostess { get; set; }
        public long agentId { get; set; }
        public long vehicleId { get; set; }
    }
}
