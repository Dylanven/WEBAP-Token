using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class Invitation
{
    public int IdInvitation { get; set; }

    public string InvCode { get; set; } = null!;

    public int IdUser { get; set; }

    public int? InvIdUser { get; set; }

    public int IdEvent { get; set; }

    public virtual Event IdEventNavigation { get; set; } = null!;

    public virtual UserAccount IdUserNavigation { get; set; } = null!;

    public virtual UserAccount? InvIdUserNavigation { get; set; }
}
