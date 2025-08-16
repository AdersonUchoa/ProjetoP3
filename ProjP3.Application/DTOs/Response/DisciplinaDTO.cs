using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs.Response;

public class DisciplinaDTO
{
    public int IdDisciplina { get; set; }

    public int? IdCurso { get; set; }

    public int IdTipoDisciplina { get; set; }

    public string TxSigla { get; set; } = null!;

    public string TxDescricao { get; set; } = null!;

    public int InCargaHoraria { get; set; }

    public int InPeriodo { get; set; }

    public virtual ICollection<CursaDTO> Cursas { get; set; } = new List<CursaDTO>();

    public virtual CursoDTO? IdCursoNavigation { get; set; }

    public virtual TipoDisciplinaDTO IdTipoDisciplinaNavigation { get; set; } = null!;

    public virtual ICollection<ProfessorDTO> IdProfessors { get; set; } = new List<ProfessorDTO>();
}
