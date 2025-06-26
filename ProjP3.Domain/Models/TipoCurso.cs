using System;
using System.Collections.Generic;

namespace ProjP3.Domain.Models;

public partial class TipoCurso
{
    public ulong IdTipoCurso { get; set; }

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
