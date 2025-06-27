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
    public class CursoRepository : Repository<Curso>, CursoIRepository
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

        public async Task<Curso?> GetCursoByDescricaoAsync(string descricao)
        {
            return await _context.Cursos
                .FirstOrDefaultAsync(c => c.TxDescricao.Contains(descricao, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<List<TipoCurso>> GetAllTiposCursoAsync()
        {
            return await _context.Cursos
                .Select(c => c.IdTipoCursoNavigation)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<Disciplina>> GetDisciplinasByCursoAsync(ulong idCurso)
        {
            return await _context.Disciplinas
                .Where(disciplina => disciplina.IdCurso == idCurso)
                .ToListAsync();
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

        public async Task<List<Instituicao>> GetInstituicoesByCursoAsync(ulong idCurso)
        {
            return await _context.Instituicaos
                .Where(i => i.Cursos.Any(c => c.IdCurso == idCurso))
                .ToListAsync();
        }
    }
}

