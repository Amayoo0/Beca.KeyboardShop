using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Beca.KeyboardShop.Entities
{
    public class Keyboard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public string? Description { get; set; }

        public bool Discounter { get; set; } = false;

        public int? OfferInSeconds { get; set; }


        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }


        public Keyboard(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
