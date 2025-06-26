using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs;
public partial class InstituicaoDTO
{
    public ulong IdInstituicao { get; set; }

    public string TxSigla { get; set; } = null!;

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
