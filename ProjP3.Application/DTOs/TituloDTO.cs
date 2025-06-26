using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs;

public partial class TituloDTO
{
    public ulong IdTitulo { get; set; }

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();
}
