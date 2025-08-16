using ProjP3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.InterfaceRepositories
{
    public interface IInstituicaoRepository : IRepository<Instituicao>
    {
        Task<List<Instituicao>> GetInstituicaoBySiglaAsync(string sigla);
        Task<List<Instituicao>> GetInstituicaoByDescricaoAsync(string descricao);
        Task<List<Instituicao>> GetInstituicoesByCursoAsync(int idCurso);
        //Task<bool> JaExisteCursoNaInstituicaoAsync(int idInstituicao, int idCurso);
        //Task<Curso?> GetCursoNaInstituicaoAsync(int idInstituicao, int idCurso);
        //void RemoverCursoNaInstituicao(Curso curso);
        Task<bool> ExistsByDescricaoAsync(string descricao);
    }
}
