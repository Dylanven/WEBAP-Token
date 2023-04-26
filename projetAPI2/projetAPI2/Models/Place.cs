using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class Place
{
    public int IdPlace { get; set; }

    public string PlaAddress { get; set; } = null!;

    public int IdCountry { get; set; }

    public virtual Country IdCountryNavigation { get; set; } = null!;
}
