using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class Restaurant
{
    public int RestaurantId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? FoodType { get; set; }

    public string? ContactInfo { get; set; }

    public string? Image { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? OwnerName { get; set; }

    public string? PhoneNo { get; set; }

    public virtual ICollection<FoodAvailable> FoodAvailables { get; set; } = new List<FoodAvailable>();
}
