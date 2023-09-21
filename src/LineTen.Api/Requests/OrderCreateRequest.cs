using System.ComponentModel.DataAnnotations;

namespace LineTen.Api.Requests
{
    public class OrderCreateRequest
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int CustomerId { get; set; }
    }
}
