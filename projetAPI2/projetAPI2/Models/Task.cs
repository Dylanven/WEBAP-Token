using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class Task
{
    public int IdTask { get; set; }

    public string TasTitle { get; set; } = null!;

    public string TasDescription { get; set; } = null!;

    public DateTime TasStartDate { get; set; }

    public DateTime TasEndDate { get; set; }

    public int IdStatesTask { get; set; }

    public int IdEvent { get; set; }
}
