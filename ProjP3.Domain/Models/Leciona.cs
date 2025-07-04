﻿using System;
using System.Collections.Generic;

namespace ProjP3.Domain.Models;

public partial class Leciona
{
    public ulong IdProfessor { get; set; }

    public ulong IdDisciplina { get; set; }

    public int InPeriodo { get; set; }

    public virtual Disciplina IdDisciplinaNavigation { get; set; } = null!;

    public virtual Professor IdProfessorNavigation { get; set; } = null!;
}
