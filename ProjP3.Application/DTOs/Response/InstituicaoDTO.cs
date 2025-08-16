using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs.Response;
public class InstituicaoDTO
{
    public int IdInstituicao { get; set; }

    public string TxSigla { get; set; } = null!;

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<CursoDTO> Cursos { get; set; } = new List<CursoDTO>();
}
