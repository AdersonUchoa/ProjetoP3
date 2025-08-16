using System;
using System.Collections.Generic;

namespace ProjP3.Domain.Models;

public partial class Aluno
{
    public int IdAluno { get; set; }

    public string TxNome { get; set; } = null!;

    public string TxSexo { get; set; } = null!;

    public DateOnly DtNascimento { get; set; }

    public virtual ICollection<Cursa> Cursas { get; set; } = new List<Cursa>();
}
