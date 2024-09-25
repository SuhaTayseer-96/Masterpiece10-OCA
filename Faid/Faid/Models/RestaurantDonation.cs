using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class RestaurantDonation
{
    public int DonationId { get; set; }

    public string RestaurantName { get; set; } = null!;

    public string FoodDonated { get; set; } = null!;

    public string PickupDetails { get; set; } = null!;

    public string ContactDetails { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}
