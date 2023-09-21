namespace LineTen.Api.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }

        public ProductResponse ProductId { get; set; } = new ProductResponse();

        public CustomerResponse Customer { get; set; } = new CustomerResponse();

        public string Status { get; set; } = "Created";

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
