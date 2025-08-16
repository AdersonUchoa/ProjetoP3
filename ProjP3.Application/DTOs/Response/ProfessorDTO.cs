using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs.Response;

public class ProfessorDTO
{
    public int IdProfessor { get; set; }

    public int IdTitulo { get; set; }

    public string TxNome { get; set; } = null!;

    public string TxSexo { get; set; } = null!;

    public string TxEstadoCivil { get; set; } = null!;

    public DateOnly DtNascimento { get; set; }

    public string TxTelefone { get; set; } = null!;

    public virtual TituloDTO IdTituloNavigation { get; set; } = null!;

    public virtual ICollection<DisciplinaDTO> IdDisciplinas { get; set; } = new List<DisciplinaDTO>();
}
