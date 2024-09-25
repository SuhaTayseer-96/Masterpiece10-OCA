using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class NewsPost
{
    public int PostId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime? PublishedDate { get; set; }

    public string? Image { get; set; }
}
