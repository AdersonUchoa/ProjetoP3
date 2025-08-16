using Microsoft.EntityFrameworkCore;
using ProjP3.Domain.InterfaceRepositories;
using ProjP3.Domain.Models;
using ProjP3.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Infra.Data.Repositories
{
    public class TipoDisciplinaRepository : Repository<TipoDisciplina>, ITipoDisciplinaRepository
    {
        public TipoDisciplinaRepository(P3DbContext context) : base(context)
        {
        }

        public async Task<TipoDisciplina?> GetTipoDisciplinaByDescricaoAsync(string descricao)
        {
            return await _context.TipoDisciplinas
                .FirstOrDefaultAsync(td => td.TxDescricao.Contains(descricao.ToLower()));
        }

        public async Task<bool> ExistsByDescricaoAsync(string descricao)
        {
            return await _context.TipoDisciplinas
                .AnyAsync(td => td.TxDescricao.Equals(descricao.ToLower()));
        }
    }
}
