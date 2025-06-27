using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs;

public partial class LecionaDTO
{
    public ulong IdProfessor { get; set; }

    public ulong IdDisciplina { get; set; }

    public int InPeriodo { get; set; }

    public virtual DisciplinaDTO IdDisciplinaNavigation { get; set; } = null!;

    public virtual ProfessorDTO IdProfessorNavigation { get; set; } = null!;
}
