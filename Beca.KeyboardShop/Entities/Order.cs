using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Beca.KeyboardShop.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [ForeignKey("UserId")]
        public User? user { get; set; }
        public int UserId { get; set; }
    }
}
