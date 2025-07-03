using ProjP3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.InterfaceRepositories
{
    public interface ITipoDisciplinaRepository : IRepository<TipoDisciplina>
    {
        Task<TipoDisciplina?> GetTipoDisciplinaByDescricaoAsync(string descricao);
        Task<bool> ExistsByDescricaoAsync(string descricao);
    }
}
