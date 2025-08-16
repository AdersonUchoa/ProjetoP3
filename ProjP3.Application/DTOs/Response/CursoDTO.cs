using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs.Response;

public class CursoDTO
{
    public int IdCurso { get; set; }

    public int IdInstituicao { get; set; }

    public int IdTipoCurso { get; set; }

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<DisciplinaDTO> Disciplinas { get; set; } = new List<DisciplinaDTO>();

    public virtual InstituicaoDTO IdInstituicaoNavigation { get; set; } = null!;

    public virtual TipoCursoDTO IdTipoCursoNavigation { get; set; } = null!;
}
