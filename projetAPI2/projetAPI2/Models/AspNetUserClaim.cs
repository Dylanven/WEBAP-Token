using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class AspNetUserClaim
{
    public int Id { get; set; }

    public int UserId { get; set; } = 0;

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
