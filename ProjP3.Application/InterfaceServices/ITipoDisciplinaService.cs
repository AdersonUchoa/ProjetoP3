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
    public interface ITipoDisciplinaService
    {
        Task<Result<List<TipoDisciplinaDTO>>> GetAllAsync();
        Task<Result<TipoDisciplinaDTO>> GetByIdAsync(int id);
        Task<Result<TipoDisciplinaDTO>> AddAsync(TipoDisciplinaCreateDTO tipoDisciplinaDto);
        Task<Result<TipoDisciplinaDTO>> UpdateAsync(TipoDisciplinaUpdateDTO tipoDisciplinaDto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<TipoDisciplinaDTO>> GetTipoDisciplinaByDescricaoAsync(string descricao);
    }
}
