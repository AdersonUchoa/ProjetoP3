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
        Task<List<Instituicao>> GetInstituicoesByCursoAsync(ulong idCurso);
        //Task<bool> JaExisteCursoNaInstituicaoAsync(ulong idInstituicao, ulong idCurso);
        //Task<Curso?> GetCursoNaInstituicaoAsync(ulong idInstituicao, ulong idCurso);
        //void RemoverCursoNaInstituicao(Curso curso);
        Task<bool> ExistsByDescricaoAsync(string descricao);
    }
}
