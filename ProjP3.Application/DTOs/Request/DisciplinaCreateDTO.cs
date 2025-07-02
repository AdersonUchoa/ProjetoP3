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

        public ulong? IdCurso { get; set; }

        public ulong IdTipoDisciplina { get; set; }

        public string TxSigla { get; set; } = null!;

        public string TxDescricao { get; set; } = null!;

        public int InCargaHoraria { get; set; }

        public int InPeriodo { get; set; }
    }
}
