using System.ComponentModel.DataAnnotations;

namespace Beca.KeyboardShop.Models
{
    public class CategoryDto
    {
        /// <summary>
        /// Category ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
