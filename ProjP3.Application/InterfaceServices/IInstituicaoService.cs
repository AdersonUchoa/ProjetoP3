using ProjP3.Application.Common;
using ProjP3.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.InterfaceServices
{
    public interface IInstituicaoService
    {
        Task<Result<bool>> DeleteAsync(ulong id);
        Task<Result<bool>> ExistsAsync(ulong id);
        Task<Result<List<InstituicaoDTO>>> GetAllAsync();
        Task<Result<InstituicaoDTO>> GetByIdAsync(ulong id);
        Task<Result<InstituicaoDTO>> AddAsync(InstituicaoDTO instituicao);
        Task<Result<InstituicaoDTO>> UpdateAsync(InstituicaoDTO instituicao);
        Task<Result<List<InstituicaoDTO>>> GetInstituicaoBySiglaAsync(string sigla);
        Task<Result<List<InstituicaoDTO>>> GetInstituicaoByDescricaoAsync(string descricao);
        Task<Result<List<InstituicaoDTO>>> GetInstituicoesByCursoAsync(ulong idCurso);
        Task<Result<InstituicaoDTO>> AdicionarCursoAInstituicaoAsync(ulong idInstituicao, ulong idCurso);
        Task<Result<InstituicaoDTO>> RemoverCursoDeInstituicaoAsync(ulong idInstituicao, ulong idCurso);
    }
}
