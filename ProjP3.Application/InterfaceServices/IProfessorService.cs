using ProjP3.Application.Common;
using ProjP3.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.InterfaceServices
{
    public interface IProfessorService
    {
        Task<Result<bool>> DeleteAsync(ulong id);
        Task<Result<List<ProfessorDTO>>> GetAllAsync();
        Task<Result<ProfessorDTO>> GetByIdAsync(ulong id);
        Task<Result<ProfessorDTO>> AddAsync(ProfessorDTO professor);
        Task<Result<ProfessorDTO>> UpdateAsync(ProfessorDTO professor);
        Task<Result<ProfessorDTO?>> GetProfessorByNomeAsync(string nome);
        Task<Result<List<ProfessorDTO>>> GetProfessoresByTitulo(ulong idTitulo);
        Task<Result<TituloDTO>> GetTituloByProfessorAsync(ulong idProfessor);
        Task<Result<List<ProfessorDTO>>> GetProfessoresByDisciplinaAsync(ulong idDisciplina);
    }
}
