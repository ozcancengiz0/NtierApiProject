namespace Dto.Response.Customer
{
    public class CustomerGetResponse
    {
        public long id { get; set; }
        public string name { get; set; } = string.Empty;
        public string nationality { get; set; } = string.Empty;
        public string passportNumber { get; set; } = string.Empty;
        public DateTime dateOfBirth { get; set; }
        public bool isActive { get; set; }
        public long tourOrderId { get; set; }
    }
}
