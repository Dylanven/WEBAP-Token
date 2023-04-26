using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class Category
{
    public int IdCategory { get; set; }

    public string CatName { get; set; } = null!;

    public virtual ICollection<Event> IdEvents { get; set; } = new List<Event>();
}
