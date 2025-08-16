using AutoMapper;
using ProjP3.Application.Common;
using ProjP3.Application.DTOs.Request;
using ProjP3.Application.DTOs.Response;
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
        private readonly ITipoDisciplinaRepository _tipoDisciplinaRepository;

        public DisciplinaService(IDisciplinaRepository repository, IMapper mapper, ICursoRepository cursoRepository, IAlunoRepository alunoRepository, IProfessorRepository professorRepository, ITipoDisciplinaRepository tipoDisciplinaRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _cursoRepository = cursoRepository;
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
            _tipoDisciplinaRepository = tipoDisciplinaRepository;
        }

        public async Task<List<DisciplinaDataDTO>> GetQuantidadeDisciplinasPorCursoAsync()
        {
            var rows = await _repository.GetQuantidadeDisciplinasPorCursoAsync();
            return _mapper.Map<List<DisciplinaDataDTO>>(rows);
        }

        public async Task<Result<List<DisciplinaDTO>>> GetAllAsync()
        {
            var disciplinas = await _repository.GetAllAsync();
            var disciplinaDtos = _mapper.Map<List<DisciplinaDTO>>(disciplinas);
            return Result<List<DisciplinaDTO>>.Success(disciplinaDtos);
        }

        public async Task<Result<DisciplinaDTO>> GetByIdAsync(int id)
        {
            var disciplina = await _repository.GetByIdAsync(id);
            if (disciplina == null)
            {
                return Result<DisciplinaDTO>.Failure("Disciplina não encontrada com este ID.");
            }
            var disciplinaDto = _mapper.Map<DisciplinaDTO>(disciplina);
            return Result<DisciplinaDTO>.Success(disciplinaDto);
        }

        public async Task<Result<DisciplinaDTO>> AddAsync(DisciplinaCreateDTO disciplinaDto)
        {
            var disciplinaExiste = await _repository.ExistsByDescricaoAsync(disciplinaDto.TxDescricao);
            if (disciplinaExiste)
            {
                return Result<DisciplinaDTO>.Failure("Disciplina já existe com esta descrição.");
            }
            var disciplina = _mapper.Map<Domain.Models.Disciplina>(disciplinaDto);
            var addedDisciplina = await _repository.AddAsync(disciplina);
            await _repository.SaveAllAsync();
            return Result<DisciplinaDTO>.Success(_mapper.Map<DisciplinaDTO>(addedDisciplina));
        }

        public async Task<Result<DisciplinaDTO>> UpdateAsync(DisciplinaUpdateDTO disciplinaDto)
        {
            var disciplinaOriginal = await _repository.ExistsByDescricaoAsync(disciplinaDto.TxDescricao);
            if (!disciplinaOriginal)
            {
                return Result<DisciplinaDTO>.Failure("Disciplina não encontrada com esta descrição.");
            }
            var disciplina = _mapper.Map<Domain.Models.Disciplina>(disciplinaDto);
            var updatedDisciplina = await _repository.UpdateAsync(disciplina);
            await _repository.SaveAllAsync();
            return Result<DisciplinaDTO>.Success(_mapper.Map<DisciplinaDTO>(updatedDisciplina));
        }

        public async Task<Result<bool>> DeleteAsync(int id)
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

        public async Task<Result<List<DisciplinaDTO>>> GetDisciplinasByAlunoAsync(int idAluno)
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

        public async Task<Result<List<DisciplinaDTO>>> GetDisciplinasByTipoAsync(int idTipoDisciplina)
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

        public async Task<Result<TipoDisciplinaDTO>> GetTipoByDisciplinaAsync(int idDisciplina)
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

        public async Task<Result<DisciplinaDTO>> AdicionarAlunoADisciplinaAsync(int idDisciplina, int idAluno, int periodo)
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

        public async Task<Result<DisciplinaDTO>> RemoverAlunoDaDisciplinaAsync(int idDisciplina, int idAluno, int periodo)
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

        public async Task<Result<DisciplinaDTO>> AdicionarProfessorADisciplinaAsync(int idDisciplina, int idProfessor, int periodo)
        {
            var disciplina = await _repository.GetByIdAsync(idDisciplina);
            if (disciplina == null)
            {
                return Result<DisciplinaDTO>.Failure("Disciplina não encontrada.");
            }
            var professorExiste = await _professorRepository.ExistsAsync(idProfessor);
            if (!professorExiste)
            {
                return Result<DisciplinaDTO>.Failure("Professor não encontrado com este ID.");
            }
            var jaLecionaNoPeriodo = await _repository.JaExisteLecionaAsync(idProfessor, idDisciplina, periodo);
            if (jaLecionaNoPeriodo)
            {
                return Result<DisciplinaDTO>.Failure($"O professor já leciona nesta disciplina no período {periodo}.");
            }
            var novaLeciona = new Leciona { IdProfessor = idProfessor, IdDisciplina = idDisciplina, InPeriodo = periodo };
            disciplina.Lecionas.Add(novaLeciona);
            await _repository.SaveAllAsync();
            var disciplinaDto = _mapper.Map<DisciplinaDTO>(disciplina);
            return Result<DisciplinaDTO>.Success(disciplinaDto);
        }

        public async Task<Result<DisciplinaDTO>> RemoverProfessorDaDisciplinaAsync(int idDisciplina, int idProfessor, int periodo)
        {
            var lecionaParaRemover = await _repository.GetLecionaAsync(idProfessor, idDisciplina, periodo);
            if (lecionaParaRemover == null)
            {
                return Result<DisciplinaDTO>.Failure($"Leciona para o professor na disciplina no período {periodo} não encontrada.");
            }
            _repository.RemoverLeciona(lecionaParaRemover);
            var sucesso = await _repository.SaveAllAsync();
            if (!sucesso)
            {
                return Result<DisciplinaDTO>.Failure("Ocorreu um erro ao remover a leciona.");
            }
            return Result<DisciplinaDTO>.Success(_mapper.Map<DisciplinaDTO>(lecionaParaRemover.IdDisciplinaNavigation));
        }

        public async Task<Result<List<DisciplinaDTO>>> GetDisciplinasByProfessorAsync(int idProfessor)
        {
            var professorExiste = await _professorRepository.ExistsAsync(idProfessor);
            if (!professorExiste)
            {
                return Result<List<DisciplinaDTO>>.Failure("Professor não encontrado com este ID.");
            }
            var disciplinas = await _repository.GetDisciplinasByProfessorAsync(idProfessor);
            var disciplinaDtos = _mapper.Map<List<DisciplinaDTO>>(disciplinas);
            return Result<List<DisciplinaDTO>>.Success(disciplinaDtos);
        }

        public async Task<Result<List<DisciplinaDTO>>> GetDisciplinasByCursoAsync(int idCurso)
        {
            var cursoExiste = await _cursoRepository.ExistsAsync(idCurso);
            if (!cursoExiste)
            {
                return Result<List<DisciplinaDTO>>.Failure("Curso não encontrado com este ID.");
            }
            var disciplinas = await _repository.GetDisciplinasByCursoAsync(idCurso);
            var disciplinaDtos = _mapper.Map<List<DisciplinaDTO>>(disciplinas);
            return Result<List<DisciplinaDTO>>.Success(disciplinaDtos);
        }
    }
}
