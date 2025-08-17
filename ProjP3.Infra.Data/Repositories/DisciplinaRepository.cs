using Microsoft.EntityFrameworkCore;
using ProjP3.Domain.InterfaceRepositories;
using ProjP3.Domain.Models;
using ProjP3.Domain.ReadModels;
using ProjP3.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Infra.Data.Repositories
{
    public class DisciplinaRepository : Repository<Disciplina>, IDisciplinaRepository
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;

        public DisciplinaRepository(P3DbContext context, IAlunoRepository alunoIRepository, IProfessorRepository professorIRepository) : base(context)
        {
            _alunoRepository = alunoIRepository;
            _professorRepository = professorIRepository;
        }

        public async Task<List<DisciplinaQuantidadePorCurso>> GetQuantidadeDisciplinasPorCursoAsync()
        {
            var resultado = await _context.Disciplinas
                .Include(d => d.IdCursoNavigation)
                .GroupBy(d => d.IdCursoNavigation.TxDescricao)
                .Select(g => new DisciplinaQuantidadePorCurso
                {
                    Curso = g.Key,
                    QuantidadeDisciplinas = g.Count()
                })
                .OrderByDescending(x => x.QuantidadeDisciplinas)
                .ToListAsync();

            return resultado;
        }

        public async Task<List<Disciplina>> GetDisciplinasByAlunoAsync(int idAluno)
        {
            return await _context.Disciplinas
                .Where(disciplina => disciplina.Cursas.Any(cursa => cursa.IdAluno == idAluno))
                .ToListAsync();
        }

        public async Task<List<Disciplina>> GetDisciplinasByTipoAsync(int idTipoDisciplina)
        {
            return await _context.Disciplinas
                .Where(d => d.IdTipoDisciplina == idTipoDisciplina)
                .ToListAsync();
        }

        public async Task<List<Disciplina>> GetDisciplinasByCursoAsync(int idCurso)
        {
            return await _context.Disciplinas
                .Where(disciplina => disciplina.IdCurso == idCurso)
                .ToListAsync();
        }

        public async Task<TipoDisciplina?> GetTipoByDisciplinaAsync(int idDisciplina)
        {
            return await _context.Disciplinas
                .Where(d => d.IdDisciplina == idDisciplina)
                .Select(d => d.IdTipoDisciplinaNavigation)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Disciplina>> GetDisciplinasByPeriodoAsync(int periodo)
        {
            return await _context.Disciplinas
                .Where(d => d.InPeriodo == periodo)
                .ToListAsync();
        }

        public async Task<List<Disciplina>> GetDisciplinasByCargaHorariaAsync(int cargaHoraria)
        {
            return await _context.Disciplinas
                .Where(d => d.InCargaHoraria == cargaHoraria)
                .ToListAsync();
        }

        public async Task<List<Disciplina>> GetDisciplinasBySiglaAsync(string sigla)
        {
            return await _context.Disciplinas
                .Where(d => d.TxSigla.Contains(sigla.ToLower()))
                .ToListAsync();
        }

        public async Task<List<Disciplina>> GetDisciplinasByDescricaoAsync(string descricao)
        {
            return await _context.Disciplinas
                .Where(d => d.TxDescricao.Contains(descricao.ToLower()))
                .ToListAsync();
        }

        //public async Task<Disciplina> AdicionarAlunoADisciplinaAsync(int idDisciplina, int idAluno, int periodo)
        //{
        //    var jaMatriculadoNoPeriodo = await _context.Cursas
        //           .AnyAsync(c => c.IdDisciplina == idDisciplina &&
        //           c.IdAluno == idAluno &&
        //           c.InSemestre == periodo);

        //    if (jaMatriculadoNoPeriodo)
        //    {
        //        throw new InvalidOperationException($"O aluno já está matriculado nesta disciplina no período {periodo}.");
        //    }

        //    var disciplina = await _context.Disciplinas.FindAsync(idDisciplina);
        //    if (disciplina == null)
        //    {
        //        throw new KeyNotFoundException("Disciplina não encontrada.");
        //    }

        //    var alunoExiste = await _alunoRepository.ExistsAsync(idAluno);
        //    if (!alunoExiste)
        //    {
        //        throw new KeyNotFoundException("Aluno não encontrado.");
        //    }

        //    var cursa = new Cursa
        //    {
        //        IdDisciplina = idDisciplina,
        //        IdAluno = idAluno,
        //        InSemestre = periodo
        //    };

        //    _context.Cursas.Add(cursa);

        //    return disciplina;
        //}

        //public async Task<Disciplina> RemoverAlunoDaDisciplinaAsync(int idDisciplina, int idAluno, int periodo)
        //{
        //    var cursa = await _context.Cursas
        //        .Include(c => c.IdDisciplinaNavigation)
        //        .FirstOrDefaultAsync(c => c.IdDisciplina == idDisciplina &&
        //                                  c.IdAluno == idAluno &&
        //                                  c.InSemestre == periodo);

        //    if (cursa == null)
        //    {
        //        throw new KeyNotFoundException($"Matrícula para o aluno na disciplina no período {periodo} não encontrada.");
        //    }

        //    _context.Cursas.Remove(cursa);

        //    return cursa.IdDisciplinaNavigation ?? throw new Exception("Não foi possível carregar a disciplina associada.");
        //}

        //public async Task<Disciplina> AdicionarProfessorADisciplinaAsync(int idDisciplina, int idProfessor, int periodo)
        //{

        //    var jaExiste = await _context.Lecionas
        //        .AnyAsync(l => l.IdDisciplina == idDisciplina &&
        //                       l.IdProfessor == idProfessor &&
        //                       l.InPeriodo == periodo);

        //    if (jaExiste)
        //    {
        //        throw new InvalidOperationException($"O professor já está alocado para esta disciplina no período {periodo}.");
        //    }

        //    var disciplina = await _context.Disciplinas.FindAsync(idDisciplina);
        //    if (disciplina == null)
        //    {
        //        throw new KeyNotFoundException("Disciplina não encontrada.");
        //    }

        //    var professorExiste = await _professorRepository.ExistsAsync(idProfessor);
        //    if (!professorExiste)
        //    {
        //        throw new KeyNotFoundException("Professor não encontrado.");
        //    }

        //    var leciona = new Leciona
        //    {
        //        IdDisciplina = idDisciplina,
        //        IdProfessor = idProfessor,
        //        InPeriodo = periodo
        //    };

        //    _context.Lecionas.Add(leciona);

        //    return disciplina;
        //}

        //public async Task<Disciplina> RemoverProfessorDaDisciplinaAsync(int idDisciplina, int idProfessor, int periodo)
        //{
        //    var leciona = await _context.Lecionas
        //        .FirstOrDefaultAsync(l => l.IdDisciplina == idDisciplina &&
        //                                  l.IdProfessor == idProfessor &&
        //                                  l.InPeriodo == periodo);

        //    if (leciona == null)
        //    {
        //        throw new KeyNotFoundException($"O professor não está alocado para esta disciplina no período {periodo}.");
        //    }

        //    _context.Lecionas.Remove(leciona);

        //    return leciona.IdDisciplinaNavigation ?? throw new Exception("Não foi possível carregar a disciplina associada.");
        //}

        public async Task<List<Disciplina>> GetDisciplinasByProfessorAsync(int idProfessor)
        {
            return await _context.Disciplinas
                .Where(disciplina => disciplina.Lecionas.Any(le => le.IdProfessor == idProfessor))
                .ToListAsync();
        }

        public async Task<bool> JaExisteCursaAsync(int idAluno, int idDisciplina, int periodo)
        {
            return await _context.Cursas
                .AnyAsync(c => c.IdAluno == idAluno &&
                               c.IdDisciplina == idDisciplina &&
                               c.InSemestre == periodo);
        }

        public async Task<bool> JaExisteLecionaAsync(int idProfessor, int idDisciplina, int periodo)
        {
            return await _context.Lecionas
                .AnyAsync(l => l.IdProfessor == idProfessor &&
                               l.IdDisciplina == idDisciplina &&
                               l.InPeriodo == periodo);
        }

        public async Task<Cursa?> GetCursaAsync(int idAluno, int idDisciplina, int periodo)
        {
            return await _context.Cursas
                .FirstOrDefaultAsync(c => c.IdAluno == idAluno &&
                                          c.IdDisciplina == idDisciplina &&
                                          c.InSemestre == periodo);
        }

        public void RemoverCursa(Cursa cursa)
        {
            _context.Cursas.Remove(cursa);
        }

        public async Task<Leciona?> GetLecionaAsync(int idProfessor, int idDisciplina, int periodo)
        {
            return await _context.Lecionas
                .FirstOrDefaultAsync(c => c.IdProfessor == idProfessor &&
                                          c.IdDisciplina == idDisciplina &&
                                          c.InPeriodo == periodo);
        }

        public void RemoverLeciona(Leciona leciona)
        {
            _context.Lecionas.Remove(leciona);
        }

        public async Task<bool> ExistsByDescricaoAsync(string descricao)
        {
            return await _context.Disciplinas
                .AnyAsync(d => d.TxDescricao.Equals(descricao.ToLower()));
        }
    }
}

