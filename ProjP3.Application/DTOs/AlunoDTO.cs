using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs;

public partial class AlunoDTO
{
    public ulong IdAluno { get; set; }

    public string TxNome { get; set; } = null!;

    public string TxSexo { get; set; } = null!;

    public DateOnly DtNascimento { get; set; }

    public virtual ICollection<Cursa> Cursas { get; set; } = new List<Cursa>();
}
