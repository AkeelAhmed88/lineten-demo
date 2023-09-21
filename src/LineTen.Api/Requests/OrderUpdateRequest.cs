using System.ComponentModel.DataAnnotations;

namespace LineTen.Api.Requests
{
    public class OrderUpdateRequest
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string Status { get; set; } = "Created";
    }
}
