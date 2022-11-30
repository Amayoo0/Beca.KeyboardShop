namespace Beca.KeyboardShop.Models
{
    public class KeyboardForCreationDto
    {
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Actual product Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Short product Description
        /// </summary>
        public string? Description { get; set; }
    }
}
