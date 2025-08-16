using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs.Response;

public class TipoCursoDTO
{
    public int IdTipoCurso { get; set; }

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<CursoDTO> Cursos { get; set; } = new List<CursoDTO>();
}
