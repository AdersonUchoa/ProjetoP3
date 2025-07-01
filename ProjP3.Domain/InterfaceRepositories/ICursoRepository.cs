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
        Task<List<Curso>> GetCursosByTipoAsync(ulong idTipoCurso);
        Task<TipoCurso?> GetTipoByCursoAsync(ulong idCurso);
        Task<Curso?> GetCursoByDescricaoAsync(string descricao);
        Task<Curso> AdicionarDisciplinaAoCursoAsync(ulong idCurso, ulong idDisciplina);
        Task<Curso> RemoverDisciplinaDoCursoAsync(ulong idCurso, ulong idDisciplina);
        Task<List<Curso>> GetCursosByInstituicaoAsync(ulong idCurso);
    }
}
