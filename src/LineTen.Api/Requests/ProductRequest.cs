using System.ComponentModel.DataAnnotations;

namespace LineTen.Api.Requests
{
    public class ProductRequest
    {
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(50)]
        public string? Description { get; set; }

        [MaxLength(250)]
        public string? Sku { get; set; }
    }
}
