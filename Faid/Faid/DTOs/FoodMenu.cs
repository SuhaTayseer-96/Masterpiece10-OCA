using Faid.Models;

namespace Faid.DTOs
{
    public class FoodMenu
    {
        public int? RestaurantId { get; set; }

        public string? FoodName { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public DateTime? AvailableUntil { get; set; }

        public string? Image { get; set; }


    }
}



