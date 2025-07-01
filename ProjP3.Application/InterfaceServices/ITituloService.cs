using ProjP3.Application.Common;
using ProjP3.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.InterfaceServices
{
    public interface ITituloService
    {
        Task<Result<List<TituloDTO>>> GetAllAsync();
        Task<Result<TituloDTO>> GetByIdAsync(ulong id);
        Task<Result<TituloDTO>> AddAsync(TituloDTO tituloDto);
        Task<Result<TituloDTO>> UpdateAsync(TituloDTO tituloDto);
        Task<Result<bool>> DeleteAsync(ulong id);
        Task<Result<List<TituloDTO>>> GetTituloByDescricaoAsync(string descricao);

    }
}
