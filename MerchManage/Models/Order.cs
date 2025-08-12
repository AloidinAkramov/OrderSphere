using System.ComponentModel.DataAnnotations;

namespace MerchManage.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; } // bu Orderga qaysi Model ulanganini bildirib turishi uchun 
        public ICollection<OrderDetail> orderDetails { get; set; } //ICollection o'rniga List ishlatsam ham bo'ladi
    }
}