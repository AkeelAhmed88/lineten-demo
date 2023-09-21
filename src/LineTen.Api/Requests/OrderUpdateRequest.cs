using System.ComponentModel.DataAnnotations;

namespace LineTen.Api.Requests
{
    public class OrderUpdateRequest : BaseOrderRequest
    {
        [Required]
        public string Status { get; set; } = "Created";
    }
}
