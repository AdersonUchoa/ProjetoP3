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
    public class TipoCursoRepository : Repository<TipoCurso>, ITipoCursoRepository
    {
        public TipoCursoRepository(P3DbContext context) : base(context)
        {
        }

        public async Task<List<TipoCurso>> GetTiposCursoByDescricaoAsync(string descricao)
        {
            return await _context.TipoCursos
                .Where(tc => tc.TxDescricao.Contains(descricao, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }
    }
}
