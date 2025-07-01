using ProjP3.Application.Common;
using ProjP3.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.InterfaceServices
{
    public interface ITipoDisciplinaService
    {
        Task<Result<List<TipoDisciplinaDTO>>> GetAllAsync();
        Task<Result<TipoDisciplinaDTO>> GetByIdAsync(ulong id);
        Task<Result<TipoDisciplinaDTO>> AddAsync(TipoDisciplinaDTO tipoDisciplinaDto);
        Task<Result<TipoDisciplinaDTO>> UpdateAsync(TipoDisciplinaDTO tipoDisciplinaDto);
        Task<Result<bool>> DeleteAsync(ulong id);
        Task<Result<TipoDisciplinaDTO>> GetTipoDisciplinaByDescricaoAsync(string descricao);
    }
}
