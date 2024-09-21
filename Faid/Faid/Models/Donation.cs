using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class Donation
{
    public int DonationId { get; set; }

    public int? UserId { get; set; }

    public string? DonationType { get; set; }

    public string? DonationDetails { get; set; }

    public decimal? DonationAmount { get; set; }

    public DateTime? DonationDate { get; set; }

    public virtual User? User { get; set; }
}
