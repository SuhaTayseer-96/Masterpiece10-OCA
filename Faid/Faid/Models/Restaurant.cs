using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class Restaurant
{
    public int RestaurantId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public TimeOnly? OpenTime { get; set; }

    public TimeOnly? CloseTime { get; set; }

    public string? FoodType { get; set; }

    public string? ContactInfo { get; set; }

    public virtual ICollection<FoodAvailable> FoodAvailables { get; set; } = new List<FoodAvailable>();
}
