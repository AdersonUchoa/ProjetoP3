using System;
using System.Collections.Generic;

namespace ProjP3.Domain.Models;

public partial class TipoDisciplina
{
    public int IdTipoDisciplina { get; set; }
    
    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
}
