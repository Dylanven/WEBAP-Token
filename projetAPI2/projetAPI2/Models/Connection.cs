using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class Connection
{
    public int IdConnection { get; set; }

    public DateTime ConDate { get; set; }

    public string ConToken { get; set; } = null!;

    public int IdUser { get; set; }

    public virtual UserAccount IdUserNavigation { get; set; } = null!;
}
