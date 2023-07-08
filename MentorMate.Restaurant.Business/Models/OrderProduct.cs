namespace MentorMate.Restaurant.Business.Models
{
    public class OrderProduct
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
