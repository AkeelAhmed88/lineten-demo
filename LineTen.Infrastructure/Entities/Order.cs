namespace LineTen.Infrastructure.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual Product? Product { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
