using System;
using System.Collections.Generic;

namespace ProjP3.Application.DTOs.Response;

public class TituloDTO
{
    public int IdTitulo { get; set; }

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<ProfessorDTO> Professors { get; set; } = new List<ProfessorDTO>();
}
