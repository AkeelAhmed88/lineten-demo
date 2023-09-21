using System.ComponentModel.DataAnnotations;

namespace LineTen.Api.Requests
{
    public class CustomerRequest
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [MaxLength(50)]
        public string? Phone { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }
    }
}
