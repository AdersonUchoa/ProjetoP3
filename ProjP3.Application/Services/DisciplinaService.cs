using AutoMapper;
using ProjP3.Application.Common;
using ProjP3.Application.DTOs;
using ProjP3.Application.InterfaceServices;
using ProjP3.Domain.InterfaceRepositories;
using ProjP3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICursoRepository _cursoRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly ITipoDisciplinaRepository _tipoDisciplinaRepository

        public DisciplinaService(IDisciplinaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<DisciplinaDTO>>> GetAllAsync()
        {
            var disciplinas = await _repository.GetAllAsync();
            var disciplinaDtos = _mapper.Map<List<DisciplinaDTO>>(disciplinas);
            return Result<List<DisciplinaDTO>>.Success(disciplinaDtos);
        }

        public async Task<Result<DisciplinaDTO>> GetByIdAsync(ulong id)
        {
            var disciplina = await _repository.GetByIdAsync(id);
            if (disciplina == null)
            {
                return Result<DisciplinaDTO>.Failure("Disciplina não encontrada com este ID.");
            }
            var disciplinaDto = _mapper.Map<DisciplinaDTO>(disciplina);
            return Result<DisciplinaDTO>.Success(disciplinaDto);
        }

        public async Task<Result<DisciplinaDTO>> AddAsync(DisciplinaDTO disciplinaDto)
        {
            var disciplinaExiste = await _repository.ExistsAsync(disciplinaDto.IdDisciplina);
            if (disciplinaExiste)
            {
                return Result<DisciplinaDTO>.Failure("Disciplina já existe com este ID.");
            }
            var disciplina = _mapper.Map<Domain.Models.Disciplina>(disciplinaDto);
            var addedDisciplina = await _repository.AddAsync(disciplina);
            await _repository.SaveAllAsync();
            return Result<DisciplinaDTO>.Success(_mapper.Map<DisciplinaDTO>(addedDisciplina));
        }

        public async Task<Result<DisciplinaDTO>> UpdateAsync(DisciplinaDTO disciplinaDto)
        {
            var disciplinaOriginal = await _repository.GetByIdAsync(disciplinaDto.IdDisciplina);
            if (disciplinaOriginal == null)
            {
                return Result<DisciplinaDTO>.Failure("Disciplina não encontrada com este ID.");
            }
            _mapper.Map(disciplinaDto, disciplinaOriginal);
            var updatedDisciplina = await _repository.UpdateAsync(disciplinaOriginal);
            await _repository.SaveAllAsync();
            return Result<DisciplinaDTO>.Success(_mapper.Map<DisciplinaDTO>(updatedDisciplina));
        }

        public async Task<Result<bool>> DeleteAsync(ulong id)
        {
            var disciplinaExiste = await _repository.ExistsAsync(id);
            if (!disciplinaExiste)
            {
                return Result<bool>.Failure("Disciplina não encontrada com este ID.");
            }
            var deleted = await _repository.DeleteAsync(id);
            await _repository.SaveAllAsync();
            return Result<bool>.Success(deleted);
        }

        public async Task<Result<List<DisciplinaDTO>>> GetDisciplinasByAlunoAsync(ulong idAluno)
        {
            var alunoExiste = await _alunoRepository.ExistsAsync(idAluno);
            if (!alunoExiste)
            {
                return Result<List<DisciplinaDTO>>.Failure("Aluno não encontrado com este ID.");
            }
            var disciplinas = await _repository.GetDisciplinasByAlunoAsync(idAluno);
            var disciplinaDtos = _mapper.Map<List<DisciplinaDTO>>(disciplinas);
            return Result<List<DisciplinaDTO>>.Success(disciplinaDtos);
        }

        public async Task<Result<List<DisciplinaDTO>>> GetDisciplinasByTipoAsync(ulong idTipoDisciplina)
        {
            var tipoDisciplinaExiste = await _tipoDisciplinaRepository.ExistsAsync(idTipoDisciplina);
            if (!tipoDisciplinaExiste)
            {
                return Result<List<DisciplinaDTO>>.Failure("Tipo de disciplina não encontrado com este ID.");
            }
            var disciplinas = await _repository.GetDisciplinasByTipoAsync(idTipoDisciplina);
            var disciplinaDtos = _mapper.Map<List<DisciplinaDTO>>(disciplinas);
            return Result<List<DisciplinaDTO>>.Success(disciplinaDtos);
        }

        public async Task<Result<TipoDisciplinaDTO>> GetTipoByDisciplinaAsync(ulong idDisciplina)
        {
            var tipoDisciplina = await _repository.GetTipoByDisciplinaAsync(idDisciplina);
            if (tipoDisciplina == null)
            {
                return Result<TipoDisciplinaDTO>.Failure("Disciplina não encontrada ou não possui um tipo associado.");
            }
            var tipoDisciplinaDto = _mapper.Map<TipoDisciplinaDTO>(tipoDisciplina);
            return Result<TipoDisciplinaDTO>.Success(tipoDisciplinaDto);
        }

        public async Task<Result<List<DisciplinaDTO>>> GetDisciplinasByPeriodoAsync(int periodo)
        {
            var disciplinas = await _repository.GetDisciplinasByPeriodoAsync(periodo);
            var disciplinaDtos = _mapper.Map<List<DisciplinaDTO>>(disciplinas);
            return Result<List<DisciplinaDTO>>.Success(disciplinaDtos);
        }

        public async Task<Result<List<DisciplinaDTO>>> GetDisciplinasByCargaHorariaAsync(int cargaHoraria)
        {
            var disciplinas = await _repository.GetDisciplinasByCargaHorariaAsync(cargaHoraria);
            var disciplinaDtos = _mapper.Map<List<DisciplinaDTO>>(disciplinas);
            return Result<List<DisciplinaDTO>>.Success(disciplinaDtos);
        }

        public async Task<Result<List<DisciplinaDTO>>> GetDisciplinasBySiglaAsync(string sigla)
        {
            var disciplinas = await _repository.GetDisciplinasBySiglaAsync(sigla);
            var disciplinaDtos = _mapper.Map<List<DisciplinaDTO>>(disciplinas);
            return Result<List<DisciplinaDTO>>.Success(disciplinaDtos);
        }

        public async Task<Result<List<DisciplinaDTO>>> GetDisciplinasByDescricaoAsync(string descricao)
        {
            var disciplinas = await _repository.GetDisciplinasByDescricaoAsync(descricao);
            var disciplinaDtos = _mapper.Map<List<DisciplinaDTO>>(disciplinas);
            return Result<List<DisciplinaDTO>>.Success(disciplinaDtos);
        }

        public async Task<Result<DisciplinaDTO>> AdicionarAlunoADisciplinaAsync(ulong idDisciplina, ulong idAluno, int periodo)
        {
            var disciplina = await _repository.GetByIdAsync(idDisciplina);
            if (disciplina == null)
            {
                return Result<DisciplinaDTO>.Failure("Disciplina não encontrada.");
            }

            var alunoExiste = await _alunoRepository.ExistsAsync(idAluno);
            if (!alunoExiste)
            {
                return Result<DisciplinaDTO>.Failure("Aluno não encontrado com este ID.");
            }

            var jaMatriculadoNoPeriodo = await _repository.JaExisteCursaAsync(idAluno, idDisciplina, periodo);
            if (jaMatriculadoNoPeriodo)
            {
                return Result<DisciplinaDTO>.Failure($"O aluno já está matriculado nesta disciplina no período {periodo}.");
            }

            var novaMatricula = new Cursa { IdAluno = idAluno, IdDisciplina = idDisciplina, InSemestre = periodo };
            disciplina.Cursas.Add(novaMatricula);

            await _repository.SaveAllAsync();

            var disciplinaDto = _mapper.Map<DisciplinaDTO>(disciplina);
            return Result<DisciplinaDTO>.Success(disciplinaDto);
        }

        public async Task<Result<DisciplinaDTO>> RemoverAlunoDaDisciplinaAsync(ulong idDisciplina, ulong idAluno, int periodo)
        {
            var matriculaParaRemover = await _repository.GetCursaAsync(idAluno, idDisciplina, periodo);

            if (matriculaParaRemover == null)
            {
                return Result<DisciplinaDTO>.Failure($"Matrícula para o aluno na disciplina no período {periodo} não encontrada.");
            }

            _repository.RemoverCursa(matriculaParaRemover);

            var sucesso = await _repository.SaveAllAsync();
            if (!sucesso)
            {
                return Result<DisciplinaDTO>.Failure("Ocorreu um erro ao remover a matrícula.");
            }

            return Result<DisciplinaDTO>.Success(_mapper.Map<DisciplinaDTO>(matriculaParaRemover.IdDisciplinaNavigation));
        }
    }
}
