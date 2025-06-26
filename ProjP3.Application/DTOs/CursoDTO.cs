using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs;

public partial class CursoDTO
{
    public ulong IdCurso { get; set; }

    public ulong IdInstituicao { get; set; }

    public ulong IdTipoCurso { get; set; }

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<DisciplinaDTO> Disciplinas { get; set; } = new List<DisciplinaDTO>();

    public virtual InstituicaoDTO IdInstituicaoNavigation { get; set; } = null!;

    public virtual TipoCursoDTO IdTipoCursoNavigation { get; set; } = null!;
}
