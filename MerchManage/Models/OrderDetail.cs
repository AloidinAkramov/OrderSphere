namespace MerchManage.Models
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Order Order { get; set; } // Bu qaysi model menga ulanganligi
        public Product Product { get; set; }// Bu qaysi model menga ulanganligi
    }
}