using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class FoodDonation
{
    public int DonationId { get; set; }

    public string FoodType { get; set; } = null!;

    public string PickupArrangements { get; set; } = null!;

    public string ContactInfo { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}
