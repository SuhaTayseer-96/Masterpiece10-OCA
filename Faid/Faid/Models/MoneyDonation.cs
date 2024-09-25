using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class MoneyDonation
{
    public int DonationId { get; set; }

    public decimal DonationAmount { get; set; }

    public string DonationFrequency { get; set; } = null!;

    public string FundUsage { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}
