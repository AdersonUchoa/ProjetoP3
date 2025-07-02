using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.DTOs.Request
{
    public class InstituicaoUpdateDTO
    {
        public string TxSigla { get; set; } = null!;

        public string TxDescricao { get; set; } = null!;
    }
}
