using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Data
{
    public class Inventoryitems
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ItemName { get; set; } = string.Empty;

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Category { get; set; } = string.Empty;
    }
}
