using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class Forum
{
    public int IdForum { get; set; }

    public int ForVue { get; set; }

    public int IdEvent { get; set; }

    public virtual Event IdEventNavigation { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
