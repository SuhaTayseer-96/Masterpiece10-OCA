using System;
using System.Collections.Generic;

namespace Faid.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateTime? DateJoined { get; set; }

    public string? Password { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public string? UserName { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<ContactU> ContactUs { get; set; } = new List<ContactU>();

    public virtual ICollection<FoodCollectionRequest> FoodCollectionRequests { get; set; } = new List<FoodCollectionRequest>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
