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
    public interface ITituloService
    {
        Task<Result<List<TituloDTO>>> GetAllAsync();
        Task<Result<TituloDTO>> GetByIdAsync(ulong id);
        Task<Result<TituloDTO>> AddAsync(TituloCreateDTO tituloDto);
        Task<Result<TituloDTO>> UpdateAsync(TituloUpdateDTO tituloDto);
        Task<Result<bool>> DeleteAsync(ulong id);
        Task<Result<List<TituloDTO>>> GetTituloByDescricaoAsync(string descricao);

    }
}
