using ProjP3.Application.Common;
using ProjP3.Application.DTOs.Request;
using ProjP3.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.InterfaceServices
{
    public interface IInstituicaoService
    {
        Task<Result<List<InstituicaoDTO>>> GetAllAsync();
        Task<Result<InstituicaoDTO>> GetByIdAsync(ulong id);
        Task<Result<InstituicaoDTO>> AddAsync(InstituicaoCreateDTO instituicao);
        Task<Result<InstituicaoDTO>> UpdateAsync(InstituicaoUpdateDTO instituicao);
        Task<Result<bool>> DeleteAsync(ulong id);
        Task<Result<List<InstituicaoDTO>>> GetInstituicaoBySiglaAsync(string sigla);
        Task<Result<List<InstituicaoDTO>>> GetInstituicaoByDescricaoAsync(string descricao);
        Task<Result<List<InstituicaoDTO>>> GetInstituicoesByCursoAsync(ulong idCurso);
        //Task<Result<InstituicaoDTO>> AdicionarCursoAInstituicaoAsync(ulong idInstituicao, ulong idCurso);
        //Task<Result<InstituicaoDTO>> RemoverCursoDeInstituicaoAsync(ulong idInstituicao, ulong idCurso);
    }
}
