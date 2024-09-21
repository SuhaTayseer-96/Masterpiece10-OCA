using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public int? FoodId { get; set; }

    public int? Quantity { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime? OrderDate { get; set; }

    public virtual FoodAvailable? Food { get; set; }

    public virtual User? User { get; set; }
}
