using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class FoodAvailable
{
    public int FoodId { get; set; }

    public int? RestaurantId { get; set; }

    public string? FoodName { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public DateTime? AvailableUntil { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Restaurant? Restaurant { get; set; }
}
