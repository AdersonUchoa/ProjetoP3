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
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(P3DbContext context) : base(context)
        {
        }

        public async Task<Professor?> GetProfessoresByNomeAsync(string nome)
        {
            return await _context.Professors
                .Where(p => p.TxNome.Equals(nome.ToLower()))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Professor>> GetProfessoresByTituloAsync(ulong idTitulo)
        {
            return await _context.Professors
                .Where(p => p.IdTitulo == idTitulo)
                .ToListAsync();
        }

        public async Task<Titulo?> GetTituloByProfessorAsync(ulong idProfessor)
        {
            return await _context.Professors
            .Where(p => p.IdProfessor == idProfessor)
            .Select(p => p.IdTituloNavigation)
            .FirstOrDefaultAsync();
        }

        public async Task<List<Professor>> GetProfessoresByDisciplinaAsync(ulong idDisciplina)
        {
            return await _context.Lecionas
                .Where(l => l.IdDisciplina == idDisciplina)
                .Select(l => l.IdProfessorNavigation)
                .ToListAsync();
        }

        public async Task<bool> ExistsByNomeAsync(string nome)
        {
            return await _context.Professors.AnyAsync(p => p.TxNome.Equals(nome.ToLower()));
        }
    }
}
