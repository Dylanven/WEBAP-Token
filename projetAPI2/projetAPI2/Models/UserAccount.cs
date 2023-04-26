using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class UserAccount
{
    public int IdUser { get; set; }

    public string UseEmail { get; set; } = null!;

    public string UseFirstName { get; set; } = null!;

    public string UseLastName { get; set; } = null!;

    public string UsePassword { get; set; } = null!;

    public DateTime UseBirthDate { get; set; }

    public string? UsePhone { get; set; }

    public string? UseAvatar { get; set; }

    public byte[] UseIsActive { get; set; } = null!;

    public int IdRole { get; set; }

    public int IdCountry { get; set; }

    public virtual ICollection<Connection> Connections { get; set; } = new List<Connection>();

    public virtual ICollection<Invitation> InvitationIdUserNavigations { get; set; } = new List<Invitation>();

    public virtual ICollection<Invitation> InvitationInvIdUserNavigations { get; set; } = new List<Invitation>();
}
