using ProjP3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.InterfaceRepositories
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Task<List<Curso>> GetCursosByTipoAsync(int idTipoCurso);
        Task<TipoCurso?> GetTipoByCursoAsync(int idCurso);
        Task<Curso?> GetCursoByDescricaoAsync(string descricao);
        //Task<Curso> AdicionarDisciplinaAoCursoAsync(int idCurso, int idDisciplina);
        //Task<Curso> RemoverDisciplinaDoCursoAsync(int idCurso, int idDisciplina);
        Task<List<Curso>> GetCursosByInstituicaoAsync(int idCurso);
        Task<bool> ExistsByDescricaoAsync(string descricao);
        Task<bool> JaExisteDisciplinaNoCurso(int idDisciplina, int idCurso);
    }
}
