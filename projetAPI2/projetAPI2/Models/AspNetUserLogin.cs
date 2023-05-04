using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class AspNetUserLogin
{
    public string LoginProvider { get; set; } = null!;

    public string ProviderKey { get; set; } = null!;

    public string? ProviderDisplayName { get; set; }

    public int UserId { get; set; } = 0;

    public virtual AspNetUser User { get; set; } = null!;
}
