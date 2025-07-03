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
    public interface IProfessorService
    {
        Task<Result<List<ProfessorDTO>>> GetAllAsync();
        Task<Result<ProfessorDTO>> GetByIdAsync(ulong id);
        Task<Result<ProfessorDTO>> AddAsync(ProfessorCreateDTO professor);
        Task<Result<ProfessorDTO>> UpdateAsync(ProfessorUpdateDTO professor);
        Task<Result<bool>> DeleteAsync(ulong id);
        Task<Result<ProfessorDTO>> GetProfessoresByNomeAsync(string nome);
        Task<Result<List<ProfessorDTO>>> GetProfessoresByTitulo(ulong idTitulo);
        Task<Result<TituloDTO>> GetTituloByProfessorAsync(ulong idProfessor);
        Task<Result<List<ProfessorDTO>>> GetProfessoresByDisciplinaAsync(ulong idDisciplina);
    }
}
