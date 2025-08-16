using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.ReadModels
{
    public class DisciplinaQuantidadePorCurso
    {
        public string Curso { get; set; } = null!;
        public int QuantidadeDisciplinas { get; set; }
    }
}
