using Beca.KeyboardShop.Entities;

namespace Beca.KeyboardShop.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public int UserId { get; set; }

    }
}
