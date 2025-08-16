using ProjP3.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.DTOs.Request
{
    public class DisciplinaCreateDTO
    {

        public int? IdCurso { get; set; }

        public int IdTipoDisciplina { get; set; }

        public string TxSigla { get; set; } = null!;

        public string TxDescricao { get; set; } = null!;

        public int InCargaHoraria { get; set; }

        public int InPeriodo { get; set; }
    }
}
