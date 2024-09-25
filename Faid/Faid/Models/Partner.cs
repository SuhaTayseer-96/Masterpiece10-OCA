using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class Partner
{
    public int PartnerId { get; set; }

    public string? PartnerName { get; set; }

    public string? PartnerType { get; set; }

    public string? ContactInfo { get; set; }

    public string? Image { get; set; }
}
