using ProjP3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.InterfaceRepositories
{
    public interface ITipoCursoRepository : IRepository<TipoCurso>
    {
        Task<TipoCurso?> GetTipoCursoByDescricaoAsync(string descricao);
    }
}
