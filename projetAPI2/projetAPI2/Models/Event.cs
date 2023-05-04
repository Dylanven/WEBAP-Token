using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class Event
{
    public int IdEvent { get; set; }

    public string EvePublic { get; set; } = null!;

    public string EveTitle { get; set; } = null!;

    public string EveDescription { get; set; } = null!;

    public DateTime EveStartDate { get; set; }

    public DateTime EveEndDate { get; set; }

    public short? EveMaxParticipant { get; set; }

    public int IdStatesEvent { get; set; }

    public int IdCountry { get; set; }

    public virtual ICollection<Forum> Forums { get; set; } = new List<Forum>();

    public virtual Country IdCountryNavigation { get; set; } = null!;

    public virtual StatesEvent IdStatesEventNavigation { get; set; } = null!;

    public virtual ICollection<Invitation>? Invitations { get; set; } = new List<Invitation>();

    public virtual ICollection<Category> IdCategories { get; set; } = new List<Category>();
}
