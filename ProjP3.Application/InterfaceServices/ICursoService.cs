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
    public interface ICursoService
    {
        Task<Result<List<CursoDTO>>> GetAllAsync();
        Task<Result<CursoDTO>> GetByIdAsync(ulong id);
        Task<Result<CursoDTO>> AddAsync(CursoCreateDTO cursoDto);
        Task<Result<CursoDTO>> UpdateAsync(CursoUpdateDTO cursoDto);
        Task<Result<bool>> DeleteAsync(ulong id);
        Task<Result<CursoDTO>> AdicionarDisciplinaAoCursoAsync(ulong idCurso, ulong idDisciplina);
        Task<Result<CursoDTO>> RemoverDisciplinaDoCursoAsync(ulong idCurso, ulong idDisciplina);
        Task<Result<List<CursoDTO>>> GetCursosByTipoAsync(ulong idTipoCurso);
        Task<Result<TipoCursoDTO>> GetTipoByCursoAsync(ulong idCurso);
        Task<Result<CursoDTO?>> GetCursoByDescricaoAsync(string descricao);
        Task<Result<List<CursoDTO>>> GetCursosByInstituicaoAsync(ulong idCurso);
    }
}
