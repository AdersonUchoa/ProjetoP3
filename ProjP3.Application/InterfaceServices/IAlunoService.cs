using ProjP3.Application.Common;
using ProjP3.Application.DTOs;
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
        Task<Result<AlunoDTO>> GetByIdAsync(ulong id);
        Task<Result<AlunoDTO>> AddAsync(AlunoDTO alunoDto);
        Task<Result<AlunoDTO>> UpdateAsync(AlunoDTO alunoDto);
        Task<Result<bool>> DeleteAsync(ulong id);
        Task<Result<AlunoDTO>> GetAlunoByNomeAsync(string nome);
        Task<Result<List<AlunoDTO>>> GetAlunosByDisciplinaAsync(ulong idDisciplina);
    }
}
