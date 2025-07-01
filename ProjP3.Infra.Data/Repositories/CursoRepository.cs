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
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(P3DbContext context) : base(context)
        {
        }

        public async Task<List<Curso>> GetCursosByTipoAsync(ulong idTipoCurso)
        {
            return await _context.Cursos
                .Where(c => c.IdTipoCurso == idTipoCurso)
                .ToListAsync();
        }

        public async Task<List<Curso>> GetCursosByInstituicaoAsync(ulong idInstituicao)
        {
            return await _context.Cursos
                .Where(c => c.IdInstituicao == idInstituicao)
                .ToListAsync();
        }

        public async Task<TipoCurso?> GetTipoByCursoAsync(ulong idCurso)
        {
            return await _context.Cursos
                .Where(c => c.IdCurso == idCurso)
                .Select(c => c.IdTipoCursoNavigation)
                .FirstOrDefaultAsync();
        }

        public async Task<Curso?> GetCursoByDescricaoAsync(string descricao)
        {
            return await _context.Cursos
                .FirstOrDefaultAsync(c => c.TxDescricao.Contains(descricao, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Curso> AdicionarDisciplinaAoCursoAsync(ulong idCurso, ulong idDisciplina)
        {
            var curso = await _context.Cursos.FindAsync(idCurso);

            if (curso == null)
            {
                throw new Exception("Curso não encontrado.");
            }

            var disciplina = await _context.Disciplinas.FindAsync(idDisciplina);

            if (disciplina == null)
            {
                throw new Exception("Disciplina não encontrada.");
            }

            curso.Disciplinas.Add(disciplina);
            
            return curso;
        }

        public async Task<Curso> RemoverDisciplinaDoCursoAsync(ulong idCurso, ulong idDisciplina)
        {
            var curso = await _context.Cursos.FindAsync(idCurso);

            if (curso == null)
            {
                throw new Exception("Curso não encontrado.");
            }

            var disciplina = await _context.Disciplinas.FindAsync(idDisciplina);

            if (disciplina == null || !curso.Disciplinas.Contains(disciplina))
            {
                throw new Exception("Disciplina não encontrada.");
            }

            curso.Disciplinas.Remove(disciplina);

            return curso;
        }
    }
}

