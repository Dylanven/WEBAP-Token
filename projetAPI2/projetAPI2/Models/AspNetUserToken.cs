using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class AspNetUserToken
{
    public int UserId { get; set; } = 0;

    public string LoginProvider { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Value { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
