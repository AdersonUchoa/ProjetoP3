using System;
using System.Collections.Generic;

namespace ProjP3.Domain.Models;

public partial class Curso
{
    public int IdCurso { get; set; }

    public int IdInstituicao { get; set; }

    public int IdTipoCurso { get; set; }

    public string TxDescricao { get; set; } = null!;

    public virtual ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

    public virtual Instituicao IdInstituicaoNavigation { get; set; } = null!;

    public virtual TipoCurso IdTipoCursoNavigation { get; set; } = null!;
}
