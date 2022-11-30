using Beca.KeyboardShop.Entities;

namespace Beca.KeyboardShop.Models
{
    public class OrderForCreationDto
    {
        public double TotalPrice { get; set; }
        public int UserId { get; set; }
    }
}
