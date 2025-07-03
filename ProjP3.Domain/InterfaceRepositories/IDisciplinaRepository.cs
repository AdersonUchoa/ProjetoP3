using ProjP3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.InterfaceRepositories
{
    public interface IDisciplinaRepository : IRepository<Disciplina>
    {
        Task<List<Disciplina>> GetDisciplinasByAlunoAsync(ulong idAluno);
        Task<List<Disciplina>> GetDisciplinasByProfessorAsync(ulong idProfessor);
        Task<List<Disciplina>> GetDisciplinasByCursoAsync(ulong idCurso);
        Task<List<Disciplina>> GetDisciplinasByTipoAsync(ulong idTipoDisciplina);
        Task<TipoDisciplina?> GetTipoByDisciplinaAsync(ulong idDisciplina);
        Task<List<Disciplina>> GetDisciplinasByPeriodoAsync(int periodo);
        Task<List<Disciplina>> GetDisciplinasByCargaHorariaAsync(int cargaHoraria);
        Task<List<Disciplina>> GetDisciplinasBySiglaAsync(string sigla);
        Task<List<Disciplina>> GetDisciplinasByDescricaoAsync(string descricao);
        //Task<Disciplina> AdicionarAlunoADisciplinaAsync(ulong idDisciplina, ulong idAluno, int periodo);
        //Task<Disciplina> RemoverAlunoDaDisciplinaAsync(ulong idDisciplina, ulong idAluno, int periodo);
        //Task<Disciplina> AdicionarProfessorADisciplinaAsync(ulong idDisciplina, ulong idProfessor, int periodo);
        //Task<Disciplina> RemoverProfessorDaDisciplinaAsync(ulong idDisciplina, ulong idProfessor, int periodo);
        Task<bool> JaExisteCursaAsync(ulong idAluno, ulong idDisciplina, int periodo);
        Task<bool> JaExisteLecionaAsync(ulong idProfessor, ulong idDisciplina, int periodo);
        Task<Cursa?> GetCursaAsync(ulong idAluno, ulong idDisciplina, int periodo);
        void RemoverCursa(Cursa cursa);
        Task<Leciona?> GetLecionaAsync(ulong idProfessor, ulong idDisciplina, int periodo);
        void RemoverLeciona(Leciona leciona);
        Task<bool> ExistsByDescricaoAsync(string descricao);
    }
}
