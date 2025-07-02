using ProjP3.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.DTOs.Request
{
    public class CursoCreateDTO
    {
        public ulong IdInstituicao { get; set; }

        public ulong IdTipoCurso { get; set; }

        public string TxDescricao { get; set; } = null!;
    }
}
