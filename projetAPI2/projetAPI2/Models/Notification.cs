using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class Notification
{
    public int IdNotification { get; set; }

    public string NotTitle { get; set; } = null!;

    public string NotMessage { get; set; } = null!;
}
