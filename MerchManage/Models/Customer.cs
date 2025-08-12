using System.ComponentModel.DataAnnotations;

namespace MerchManage.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredOn { get; set; }

        // Bu navigatorim 
        public ICollection<Order> Orders { get; set; } // Qaysi modelga ulanmoqchi bo'lsam shuni ko'rsataman
    }
}