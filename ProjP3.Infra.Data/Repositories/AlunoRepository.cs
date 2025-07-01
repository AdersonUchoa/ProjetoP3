using ProjP3.Domain.InterfaceRepositories;
using ProjP3.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjP3.Infra.Data.Context;

namespace ProjP3.Infra.Data.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(P3DbContext context) : base(context)
        {
        }

        public async Task<Aluno?> GetAlunoByNomeAsync(string nome)
        {
            var aluno = await _context.Alunos
                .FirstOrDefaultAsync(a => a.TxNome.Contains(nome, StringComparison.OrdinalIgnoreCase));

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
            }

            return aluno;
        }

        public async Task<List<Aluno>> GetAlunosByDisciplinaAsync(ulong idDisciplina)
        {
            return await _context.Cursas
                .Where(c => c.IdDisciplina == idDisciplina)
                .Select(c => c.IdAlunoNavigation)
                .ToListAsync();
        }
    }
}

