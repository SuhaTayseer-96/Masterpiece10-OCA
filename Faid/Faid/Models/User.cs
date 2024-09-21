using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public string? UserType { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateTime? DateJoined { get; set; }

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual ICollection<FoodCollectionRequest> FoodCollectionRequests { get; set; } = new List<FoodCollectionRequest>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
