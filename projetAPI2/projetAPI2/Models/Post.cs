using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class Post
{
    public int IdPost { get; set; }

    public string PosTitle { get; set; } = null!;

    public string PosMessage { get; set; } = null!;

    public DateTime PosDate { get; set; }

    public int MulitAnswer { get; set; }

    public int IdForum { get; set; }

    public virtual Forum IdForumNavigation { get; set; } = null!;
}
