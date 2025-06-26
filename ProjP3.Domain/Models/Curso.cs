using System;
using System.Collections.Generic;

namespace ProjP3.Domain.Models;

public partial class Curso
{
    public ulong IdCurso { get; set; }

    public ulong IdInstituicao { get; set; }

    public ulong IdTipoCurso { get; set; }

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

    public virtual Instituicao IdInstituicaoNavigation { get; set; } = null!;

    public virtual TipoCurso IdTipoCursoNavigation { get; set; } = null!;
}
