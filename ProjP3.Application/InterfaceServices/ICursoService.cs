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
        Task<Result<CursoDTO>> GetByIdAsync(int id);
        Task<Result<CursoDTO>> AddAsync(CursoCreateDTO cursoDto);
        Task<Result<CursoDTO>> UpdateAsync(CursoUpdateDTO cursoDto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<CursoDTO>> AdicionarDisciplinaAoCursoAsync(int idCurso, int idDisciplina);
        Task<Result<bool>> RemoverDisciplinaDoCursoAsync(int idCurso, int idDisciplina);
        Task<Result<List<CursoDTO>>> GetCursosByTipoAsync(int idTipoCurso);
        Task<Result<TipoCursoDTO>> GetTipoByCursoAsync(int idCurso);
        Task<Result<CursoDTO?>> GetCursoByDescricaoAsync(string descricao);
        Task<Result<List<CursoDTO>>> GetCursosByInstituicaoAsync(int idCurso);
    }
}
