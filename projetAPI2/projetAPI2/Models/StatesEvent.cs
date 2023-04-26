using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class StatesEvent
{
    public int IdStatesEvent { get; set; }

    public string StaEvName { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
