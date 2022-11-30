namespace Beca.KeyboardShop.Models
{
    public class CartKeyboardDto
    {
        public int Id { get; set; }
        public int KeyboardId { get; set; }
        public int NumItems { get; set; }

        public int OrderId { get; set; }
    }
}
