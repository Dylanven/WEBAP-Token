using System;
using System.Collections.Generic;

namespace projetAPI2.Models;

public partial class Question
{
    public int IdQuestion { get; set; }

    public string QueMessage { get; set; } = null!;

    public int IdSurvey { get; set; }

    public virtual Survey IdSurveyNavigation { get; set; } = null!;
}
