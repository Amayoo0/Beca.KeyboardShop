using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beca.KeyboardShop.Entities
{
    public class Cart_Keyboards
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
            
        public int ProductId { get; set; }

        public int Num { get; set; }

        public int CartId { get; set; }

    }
}
