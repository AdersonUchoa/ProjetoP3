using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs;

public partial class TipoCursoDTO
{
    public ulong IdTipoCurso { get; set; }

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<CursoDTO> Cursos { get; set; } = new List<CursoDTO>();
}
