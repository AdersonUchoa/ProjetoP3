using ProjP3.Domain.Models;
using ProjP3.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.InterfaceRepositories
{
    public interface IDisciplinaRepository : IRepository<Disciplina>
    {
        Task<List<DisciplinaQuantidadePorCurso>> GetQuantidadeDisciplinasPorCursoAsync();
        Task<List<Disciplina>> GetDisciplinasByAlunoAsync(int idAluno);
        Task<List<Disciplina>> GetDisciplinasByProfessorAsync(int idProfessor);
        Task<List<Disciplina>> GetDisciplinasByCursoAsync(int idCurso);
        Task<List<Disciplina>> GetDisciplinasByTipoAsync(int idTipoDisciplina);
        Task<TipoDisciplina?> GetTipoByDisciplinaAsync(int idDisciplina);
        Task<List<Disciplina>> GetDisciplinasByPeriodoAsync(int periodo);
        Task<List<Disciplina>> GetDisciplinasByCargaHorariaAsync(int cargaHoraria);
        Task<List<Disciplina>> GetDisciplinasBySiglaAsync(string sigla);
        Task<List<Disciplina>> GetDisciplinasByDescricaoAsync(string descricao);
        //Task<Disciplina> AdicionarAlunoADisciplinaAsync(int idDisciplina, int idAluno, int periodo);
        //Task<Disciplina> RemoverAlunoDaDisciplinaAsync(int idDisciplina, int idAluno, int periodo);
        //Task<Disciplina> AdicionarProfessorADisciplinaAsync(int idDisciplina, int idProfessor, int periodo);
        //Task<Disciplina> RemoverProfessorDaDisciplinaAsync(int idDisciplina, int idProfessor, int periodo);
        Task<bool> JaExisteCursaAsync(int idAluno, int idDisciplina, int periodo);
        Task<bool> JaExisteLecionaAsync(int idProfessor, int idDisciplina, int periodo);
        Task<Cursa?> GetCursaAsync(int idAluno, int idDisciplina, int periodo);
        void RemoverCursa(Cursa cursa);
        Task<Leciona?> GetLecionaAsync(int idProfessor, int idDisciplina, int periodo);
        void RemoverLeciona(Leciona leciona);
        Task<bool> ExistsByDescricaoAsync(string descricao);
    }
}
