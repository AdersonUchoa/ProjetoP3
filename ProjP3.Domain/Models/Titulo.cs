using System;
using System.Collections.Generic;

namespace ProjP3.Domain.Models;

public partial class Titulo
{
    public int IdTitulo { get; set; }

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();
}
