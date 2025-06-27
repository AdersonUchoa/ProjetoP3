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

        public async Task<List<Disciplina>> GetDisciplinasByProfessorAsync(ulong idProfessor)
        {
            return await _context.Disciplinas
                .Where(disciplina => disciplina.Lecionas.Any(le => le.IdProfessor == idProfessor))
                .ToListAsync();
        }

        public async Task<List<Professor>> GetProfessoresByTitulo(ulong idTitulo)
        {
            return await _context.Professors
                .Where(p => p.IdTitulo == idTitulo)
                .ToListAsync();
        }
    }
}
