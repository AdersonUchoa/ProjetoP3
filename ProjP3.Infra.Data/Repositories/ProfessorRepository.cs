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
    public class ProfessorRepository : Repository<Professor>, ProfessorIRepository
    {
        public ProfessorRepository(P3DbContext context) : base(context)
        {
        }

        public async Task<Professor?> GetProfessorByNomeAsync(string nome)
        {
            var professor = await _context.Professors.FirstOrDefaultAsync(p => p.TxNome.Contains(nome, StringComparison.OrdinalIgnoreCase));
            if (professor == null)
            {
                Console.WriteLine("Professor não encontrado.");
            }
            return professor;
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
    }
}
