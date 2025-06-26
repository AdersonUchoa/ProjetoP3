using ProjP3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.InterfaceRepositories
{
    internal interface DisciplinaIRepository : IRepository
    {
        Task<List<Disciplina>> GetDisciplinasByTipoAsync(ulong idTipoDisciplina);
        Task<List<Disciplina>> GetDisciplinasByPeriodoAsync(int periodo);
        Task<List<Disciplina>> GetDisciplinasByCargaHorariaAsync(int cargaHoraria);
        Task<List<Disciplina>> GetDisciplinasBySiglaAsync(string sigla);
        Task<List<Disciplina>> GetDisciplinasByDescricaoAsync(string descricao);
        Task<List<TipoDisciplina>> GetAllTiposDisciplinaAsync();
        Task<List<Aluno>> GetAlunosByDisciplinaAsync(ulong idDisciplina);
        Task<Disciplina> AdicionarAlunoADisciplinaAsync(ulong idDisciplina, ulong idAluno);
        Task<Disciplina> RemoverAlunoDaDisciplinaAsync(ulong idDisciplina, ulong idAluno);
        Task<List<Professor>> GetProfessoresByDisciplinaAsync(ulong idDisciplina);
        Task<Disciplina> AdicionarProfessorADisciplinaAsync(ulong idDisciplina, ulong idProfessor);
        Task<Disciplina> RemoverProfessorDaDisciplinaAsync(ulong idDisciplina, ulong idProfessor);
    }
}
