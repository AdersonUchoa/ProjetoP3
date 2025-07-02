using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.DTOs.Request
{
    public class ProfessorUpdateDTO
    {
        public ulong IdTitulo { get; set; }

        public string TxNome { get; set; } = null!;

        public string TxEstadoCivil { get; set; } = null!;

        public string TxTelefone { get; set; } = null!;
    }
}
