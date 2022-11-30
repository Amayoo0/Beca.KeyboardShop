using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Beca.KeyboardShop.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public ICollection<Keyboard> Keyboards { get; set; } = new List<Keyboard>();

        public Category(string name) 
        {
            Name = name;
        }

    }
}
