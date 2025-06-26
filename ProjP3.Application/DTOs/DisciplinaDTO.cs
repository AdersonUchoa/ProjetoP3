using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs;

public partial class DisciplinaDTO
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

    public virtual TipoDisciplinaDTO IdTipoDisciplinaNavigation { get; set; } = null!;

    public virtual ICollection<ProfessorDTO> IdProfessors { get; set; } = new List<ProfessorDTO>();
}
