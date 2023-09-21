using System.ComponentModel.DataAnnotations;

namespace LineTen.Api.Requests
{
    public class BaseOrderRequest
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int CustomerId { get; set; }
    }
}
