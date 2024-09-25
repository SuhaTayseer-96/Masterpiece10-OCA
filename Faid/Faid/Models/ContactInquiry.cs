using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class ContactInquiry
{
    public int InquiryId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string MessageContent { get; set; } = null!;

    public DateTime? SubmissionDate { get; set; }
}
