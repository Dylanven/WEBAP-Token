using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class Country
{
    public int IdCountry { get; set; }

    public string CouName { get; set; } = null!;

    public string CouCode { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
