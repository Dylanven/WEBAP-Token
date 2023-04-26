using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class Survey
{
    public int IdSurvey { get; set; }

    public string SurTitle { get; set; } = null!;

    public string SurMessage { get; set; } = null!;

    public byte[] SurMultipleAnswer { get; set; } = null!;

    public int IdEvent { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
