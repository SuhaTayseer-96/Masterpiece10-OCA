using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class PartnershipRequest
{
    public int RequestId { get; set; }

    public string? OrganizationType { get; set; }

    public string? OrganizationName { get; set; }

    public string? ContactPerson { get; set; }

    public string? Email { get; set; }

    public string? PartnershipGoals { get; set; }

    public string? ContactPhoneNumber { get; set; }
}
