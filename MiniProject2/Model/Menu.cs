using System.ComponentModel.DataAnnotations;

namespace MiniProject2.Model
{
    public class Menu
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Range(0.01, 100000)]
        public decimal Price { get; set; }

        [Required]
        [RegularExpression("Food|Beverage|Dessert")]
        public string Category { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; } = 0;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsAvailable { get; set; } = true;
    }
}
