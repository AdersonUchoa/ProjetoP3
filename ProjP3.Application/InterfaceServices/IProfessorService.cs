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
        Task<Result<ProfessorDTO>> GetByIdAsync(int id);
        Task<Result<ProfessorDTO>> AddAsync(ProfessorCreateDTO professor);
        Task<Result<ProfessorDTO>> UpdateAsync(ProfessorUpdateDTO professor);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<ProfessorDTO>> GetProfessoresByNomeAsync(string nome);
        Task<Result<List<ProfessorDTO>>> GetProfessoresByTitulo(int idTitulo);
        Task<Result<TituloDTO>> GetTituloByProfessorAsync(int idProfessor);
        Task<Result<List<ProfessorDTO>>> GetProfessoresByDisciplinaAsync(int idDisciplina);
    }
}
