using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class FoodDistributionRequest
{
    public int RequestId { get; set; }

    public string? CharityName { get; set; }

    public string? ContactPerson { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? PickupAddress { get; set; }

    public string? FoodTypeNeeded { get; set; }

    public int? QuantityNeeded { get; set; }

    public DateOnly? PreferredDeliveryDate { get; set; }
}
