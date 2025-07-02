using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.DTOs.Request
{
    public class AlunoCreateDTO
    {
        public string TxNome { get; set; } = null!;

        public string TxSexo { get; set; } = null!;

        public DateOnly DtNascimento { get; set; }
    }
}
