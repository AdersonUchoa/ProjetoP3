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
    public interface IDisciplinaService
    {
        Task<List<DisciplinaDataDTO>> GetQuantidadeDisciplinasPorCursoAsync();
        Task<Result<List<DisciplinaDTO>>> GetAllAsync();
        Task<Result<DisciplinaDTO>> GetByIdAsync(int id);
        Task<Result<DisciplinaDTO>> AddAsync(DisciplinaCreateDTO disciplinaDTO);
        Task<Result<DisciplinaDTO>> UpdateAsync(DisciplinaUpdateDTO disciplinaDTO);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasByAlunoAsync(int idAluno);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasByTipoAsync(int idTipoDisciplina);
        Task<Result<TipoDisciplinaDTO>> GetTipoByDisciplinaAsync(int idDisciplina);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasByPeriodoAsync(int periodo);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasByCargaHorariaAsync(int cargaHoraria);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasBySiglaAsync(string sigla);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasByDescricaoAsync(string descricao);
        Task<Result<DisciplinaDTO>> AdicionarAlunoADisciplinaAsync(int idDisciplina, int idAluno, int periodo);
        Task<Result<DisciplinaDTO>> RemoverAlunoDaDisciplinaAsync(int idDisciplina, int idAluno, int periodo);
        Task<Result<DisciplinaDTO>> AdicionarProfessorADisciplinaAsync(int idDisciplina, int idProfessor, int periodo);
        Task<Result<DisciplinaDTO>> RemoverProfessorDaDisciplinaAsync(int idDisciplina, int idProfessor, int periodo);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasByProfessorAsync(int idProfessor);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasByCursoAsync(int idCurso);
    }
}
