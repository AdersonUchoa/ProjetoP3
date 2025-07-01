using ProjP3.Application.Common;
using ProjP3.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.InterfaceServices
{
    public interface ITipoCursoService
    {
        Task<Result<List<TipoCursoDTO>>> GetAllAsync();
        Task<Result<TipoCursoDTO>> GetByIdAsync(ulong id);
        Task<Result<TipoCursoDTO>> AddAsync(TipoCursoDTO tipoCursoDto);
        Task<Result<TipoCursoDTO>> UpdateAsync(TipoCursoDTO tipoCursoDto);
        Task<Result<bool>> DeleteAsync(ulong id);
        Task<Result<List<TipoCursoDTO>>> GetTipoCursoByDescricaoAsync(string descricao);
    }
}
