using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class Emoji
{
    public int IdEmojis { get; set; }

    public string EmoImg { get; set; } = null!;

    public string EmoShortCut { get; set; } = null!;
}
