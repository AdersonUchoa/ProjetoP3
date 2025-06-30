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
    public class TituloRepository : Repository<Titulo>, ITituloRepository
    {
        public TituloRepository(P3DbContext context) : base(context)
        {
        }

        public async Task<List<Titulo>> GetTitulosByDescricaoAsync(string descricao)
        {
            return await _context.Titulos
                .Where(t => t.TxDescricao.Contains(descricao, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }
    }
}
