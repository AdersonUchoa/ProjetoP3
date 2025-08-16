using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs.Response;

public class AlunoDTO
{
    public int IdAluno { get; set; }

    public string TxNome { get; set; } = null!;

    public string TxSexo { get; set; } = null!;

    public DateOnly DtNascimento { get; set; }

    public virtual ICollection<CursaDTO> Cursas { get; set; } = new List<CursaDTO>();
}
