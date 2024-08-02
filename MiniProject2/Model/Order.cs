using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MiniProject2.Model
{
    public class Order
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalPrice { get; set; }

        [Required]
        [RegularExpression("Processed|Delivered|Canceled")]
        public string OrderStatus { get; set; } = "Processed";

        [StringLength(500)]
        public string Note { get; set; }

        public List<int> OrderedMenuIds { get; set; } = new List<int>();

        public List<Menu> OrderedMenus { get; set; } = new List<Menu>();

        public void CalculateTotalOrder()
        {
            TotalPrice = 0;
            foreach (var menu in OrderedMenus)
            {
                TotalPrice += menu.Price;
            }
        }
    }
}