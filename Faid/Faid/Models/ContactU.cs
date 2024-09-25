using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class ContactU
{
    public int ContactId { get; set; }

    public int? UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime? SubmittedOn { get; set; }

    public virtual User? User { get; set; }
}
