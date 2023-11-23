namespace Dto.Response.Customer
{
    public class TransferGetResponse
    {
        public long id { get; set; }
        public string startingPosition { get; set; } = string.Empty;
        public string endPosition { get; set; } = string.Empty;
        public DateTime startingDate { get; set; }
        public bool hostess { get; set; }
        public bool isActive { get; set; }
        public DomainModel.Entities.Agent agent { get; set; } = null!;
        public DomainModel.Entities.Vehicle vehicle { get; set; } = null!;
    }
}
