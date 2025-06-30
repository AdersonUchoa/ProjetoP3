using ProjP3.Application.Common;
using ProjP3.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.InterfaceServices
{
    public interface CursoIService
    {
        Task<Result<List<CursoDTO>>> GetAllAsync();
        Task<Result<CursoDTO>> GetByIdAsync(ulong id);
        Task<Result<CursoDTO>> AddAsync(CursoDTO cursoDto);
        Task<Result<CursoDTO>> UpdateAsync(CursoDTO cursoDto);
        Task<Result<bool>> ExistsAsync(ulong id);
        Task<Result<bool>> DeleteAsync(ulong id);
        Task<Result<CursoDTO>> AdicionarDisciplinaAoCursoAsync(ulong idCurso, ulong idDisciplina);
        Task<Result<CursoDTO>> RemoverDisciplinaDoCursoAsync(ulong idCurso, ulong idDisciplina);
        Task<Result<List<CursoDTO>>> GetCursosByTipoAsync(ulong idTipoCurso);
        Task<Result<TipoCursoDTO>> GetTipoByCursoAsync(ulong idCurso);
        Task<Result<CursoDTO?>> GetCursoByDescricaoAsync(string descricao);
        Task<Result<List<CursoDTO>>> GetCursosByInstituicaoAsync(ulong idCurso);
    }
}
