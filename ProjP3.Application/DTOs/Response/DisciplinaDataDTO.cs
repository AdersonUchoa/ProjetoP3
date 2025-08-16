using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjP3.Application.DTOs.Response
{
    public class DisciplinaDataDTO
    {
        [JsonPropertyName("curso")]
        public string Curso { get; set; } = null!;

        [JsonPropertyName("quantidade_disciplinas")]
        public int QuantidadeDisciplinas { get; set; }
    }
}
