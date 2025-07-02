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
        Task<Result<List<DisciplinaDTO>>> GetAllAsync();
        Task<Result<DisciplinaDTO>> GetByIdAsync(ulong id);
        Task<Result<DisciplinaDTO>> AddAsync(DisciplinaCreateDTO disciplinaDTO);
        Task<Result<DisciplinaDTO>> UpdateAsync(DisciplinaUpdateDTO disciplinaDTO);
        Task<Result<bool>> DeleteAsync(ulong id);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasByAlunoAsync(ulong idAluno);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasByTipoAsync(ulong idTipoDisciplina);
        Task<Result<TipoDisciplinaDTO>> GetTipoByDisciplinaAsync(ulong idDisciplina);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasByPeriodoAsync(int periodo);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasByCargaHorariaAsync(int cargaHoraria);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasBySiglaAsync(string sigla);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasByDescricaoAsync(string descricao);
        Task<Result<DisciplinaDTO>> AdicionarAlunoADisciplinaAsync(ulong idDisciplina, ulong idAluno, int periodo);
        Task<Result<DisciplinaDTO>> RemoverAlunoDaDisciplinaAsync(ulong idDisciplina, ulong idAluno, int periodo);
        Task<Result<DisciplinaDTO>> AdicionarProfessorADisciplinaAsync(ulong idDisciplina, ulong idProfessor, int periodo);
        Task<Result<DisciplinaDTO>> RemoverProfessorDaDisciplinaAsync(ulong idDisciplina, ulong idProfessor, int periodo);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasByProfessorAsync(ulong idProfessor);
        Task<Result<List<DisciplinaDTO>>> GetDisciplinasByCursoAsync(ulong idCurso);
    }
}
