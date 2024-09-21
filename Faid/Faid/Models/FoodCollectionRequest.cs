using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class FoodCollectionRequest
{
    public int RequestId { get; set; }

    public int? UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? PickupAddress { get; set; }

    public string? FoodType { get; set; }

    public DateOnly? PreferredPickupDate { get; set; }

    public TimeOnly? PreferredPickupTime { get; set; }

    public virtual User? User { get; set; }
}
