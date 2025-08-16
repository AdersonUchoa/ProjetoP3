using System;
using System.Collections.Generic;

namespace ProjP3.Domain.Models;

public partial class Instituicao
{
    public int IdInstituicao { get; set; }

    public string TxSigla { get; set; } = null!;

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
