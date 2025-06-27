using System;
using System.Collections.Generic;

namespace ProjP3.Domain.Models;

public partial class Disciplina
{
    public ulong IdDisciplina { get; set; }

    public ulong? IdCurso { get; set; }

    public ulong IdTipoDisciplina { get; set; }

    public string TxSigla { get; set; } = null!;

    public string TxDescricao { get; set; } = null!;

    public int InCargaHoraria { get; set; }

    public int InPeriodo { get; set; }

    public virtual ICollection<Cursa> Cursas { get; set; } = new List<Cursa>();

    public virtual Curso? IdCursoNavigation { get; set; }

    public virtual TipoDisciplina IdTipoDisciplinaNavigation { get; set; } = null!;

    public virtual ICollection<Leciona> Lecionas { get; set; } = new List<Leciona>();
}
