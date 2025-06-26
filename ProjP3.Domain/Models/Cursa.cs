using System;
using System.Collections.Generic;

namespace ProjP3.Domain.Models;

public partial class Cursa
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

    public virtual Aluno IdAlunoNavigation { get; set; } = null!;

    public virtual Disciplina IdDisciplinaNavigation { get; set; } = null!;
}
