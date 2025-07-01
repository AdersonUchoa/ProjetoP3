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
        Task<Instituicao> AdicionarCursoAInstituicaoAsync (ulong idInstituicao, ulong idCurso);
        Task<Instituicao> RemoverCursoDeInstituicaoAsync(ulong idInstituicao, ulong idCurso);
        Task<List<Instituicao>> GetInstituicoesByCursoAsync(ulong idCurso);
    }
}
