namespace Beca.KeyboardShop.Models
{
    public class KeyboardDto
    {
        /// <summary>
        /// Identifier of Keyboard
        /// </summary>
        public int Id { get; set; }

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

        public int CategoryId { get; set; }

        public bool Discounter { get; set; }

        public int? OfferInSeconds { get; set; }

        public int? Selected { get; set; }
    }
}
