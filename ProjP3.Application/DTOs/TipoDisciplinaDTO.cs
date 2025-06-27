using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs;

public partial class TipoDisciplinaDTO
{
    public ulong IdTipoDisciplina { get; set; }

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<DisciplinaDTO> Disciplinas { get; set; } = new List<DisciplinaDTO>();
}
