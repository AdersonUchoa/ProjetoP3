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
    public interface IAlunoService
    {
        Task<Result<List<AlunoDTO>>> GetAllAsync();
        Task<Result<AlunoDTO>> GetByIdAsync(int id);
        Task<Result<AlunoDTO>> AddAsync(AlunoCreateDTO alunoDto);
        Task<Result<AlunoDTO>> UpdateAsync(AlunoUpdateDTO alunoDto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<AlunoDTO>> GetAlunoByNomeAsync(string nome);
        Task<Result<List<AlunoDTO>>> GetAlunosByDisciplinaAsync(int idDisciplina);
    }
}
