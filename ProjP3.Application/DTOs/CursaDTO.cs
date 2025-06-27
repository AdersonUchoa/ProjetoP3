using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs;

public partial class CursaDTO
{
    public ulong IdAluno { get; set; }

    public ulong IdDisciplina { get; set; }

    public int InAno { get; set; }

    public int InSemestre { get; set; }

    public int InFaltas { get; set; }

    public decimal? NmNota1 { get; set; }

    public decimal? NmNota2 { get; set; }

    public decimal? NmNota3 { get; set; }

    public bool BlAprovado { get; set; }

    public virtual AlunoDTO IdAlunoNavigation { get; set; } = null!;

    public virtual DisciplinaDTO IdDisciplinaNavigation { get; set; } = null!;
}
