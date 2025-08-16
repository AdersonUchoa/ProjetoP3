using AutoMapper;
using ProjP3.Application.Common;
using ProjP3.Application.DTOs.Request;
using ProjP3.Application.DTOs.Response;
using ProjP3.Application.InterfaceServices;
using ProjP3.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITipoCursoRepository _tipoCursoRepository;
        private readonly IInstituicaoRepository _instituicaoRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;

        public CursoService(ICursoRepository repository, IMapper mapper, ITipoCursoRepository tipoCursoRepository, IInstituicaoRepository instituicaoRepository, IDisciplinaRepository disciplinaRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _tipoCursoRepository = tipoCursoRepository;
            _instituicaoRepository = instituicaoRepository;
            _disciplinaRepository = disciplinaRepository;
        }

        public async Task<Result<List<CursoDTO>>> GetAllAsync()
        {
            var cursos = await _repository.GetAllAsync();
            var cursoDtos = _mapper.Map<List<CursoDTO>>(cursos);
            return Result<List<CursoDTO>>.Success(cursoDtos);
        }

        public async Task<Result<CursoDTO>> GetByIdAsync(int id)
        {
            var curso = await _repository.GetByIdAsync(id);
            if (curso == null)
            {
                return Result<CursoDTO>.Failure("Curso não encontrado com este ID.");
            }
            var cursoDto = _mapper.Map<CursoDTO>(curso);
            return Result<CursoDTO>.Success(cursoDto);
        }

        public async Task<Result<CursoDTO>> AddAsync(CursoCreateDTO cursoDto)
        {
            var cursoExiste = await _repository.ExistsByDescricaoAsync(cursoDto.TxDescricao);
            if (cursoExiste)
            {
                return Result<CursoDTO>.Failure("Curso já existe com esta descrição.");
            }
            var curso = _mapper.Map<Domain.Models.Curso>(cursoDto);
            var addedCurso = await _repository.AddAsync(curso);
            await _repository.SaveAllAsync();
            return Result<CursoDTO>.Success(_mapper.Map<CursoDTO>(addedCurso));
        }

        public async Task<Result<CursoDTO>> UpdateAsync(CursoUpdateDTO cursoDto)
        {
            var cursoOriginal = await _repository.ExistsByDescricaoAsync(cursoDto.TxDescricao);
            if (!cursoOriginal)
            {
                return Result<CursoDTO>.Failure("Curso não encontrado com esta descrição.");
            }
            var curso = _mapper.Map<Domain.Models.Curso>(cursoDto);
            var updatedCurso = _repository.UpdateAsync(curso);
            await _repository.SaveAllAsync();
            return Result<CursoDTO>.Success(_mapper.Map<CursoDTO>(updatedCurso));
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var cursoExiste = await _repository.ExistsAsync(id);
            if (!cursoExiste)
            {
                return Result<bool>.Failure("Curso não encontrado com este ID.");
            }
            var deleted = await _repository.DeleteAsync(id);
            await _repository.SaveAllAsync();
            return Result<bool>.Success(deleted);
        }

        public async Task<Result<CursoDTO>> AdicionarDisciplinaAoCursoAsync(int idCurso, int idDisciplina)
        {
            var curso = await _repository.GetByIdAsync(idCurso);
            if(curso == null)
            {
                return Result<CursoDTO>.Failure("Curso não encontrado com este ID.");
            }
            var disciplina = await _disciplinaRepository.GetByIdAsync(idDisciplina);
            if(disciplina == null)
            {
                return Result<CursoDTO>.Failure("Disciplina não encontrada com este ID.");
            }
            var jaExisteDisciplina = await _repository.JaExisteDisciplinaNoCurso(idDisciplina, idCurso);
            if(jaExisteDisciplina)
            {
                return Result<CursoDTO>.Failure("Disciplina já está associada a este curso.");
            }
            curso.Disciplinas.Add(disciplina);
            await _repository.SaveAllAsync();
            var cursoDto = _mapper.Map<CursoDTO>(curso);
            return Result<CursoDTO>.Success(cursoDto);
        }

        public async Task<Result<bool>> RemoverDisciplinaDoCursoAsync(int idCurso, int idDisciplina)
        {
            var disciplina = await _disciplinaRepository.GetByIdAsync(idDisciplina);
            if (disciplina == null)
            {
                return Result<bool>.Failure("Disciplina não encontrada.");
            }

            if (disciplina.IdCurso != idCurso)
            {
                return Result<bool>.Failure("Esta disciplina não pertence ao curso informado.");
            }

            disciplina.IdCurso = null;

            await _disciplinaRepository.UpdateAsync(disciplina);

            var sucesso = await _repository.SaveAllAsync();
            if (!sucesso)
            {
                return Result<bool>.Failure("Ocorreu um erro ao salvar a desassociação da disciplina.");
            }

            return Result<bool>.Success(true);
        }

        public async Task<Result<List<CursoDTO>>> GetCursosByTipoAsync(int idTipoCurso)
        {
            var tipoCursoExiste = await _tipoCursoRepository.ExistsAsync(idTipoCurso);
            if (!tipoCursoExiste)
            {
                return Result<List<CursoDTO>>.Failure("Tipo de curso não encontrado com este ID.");
            }
            var cursos = await _repository.GetCursosByTipoAsync(idTipoCurso);
            var cursoDtos = _mapper.Map<List<CursoDTO>>(cursos);
            return Result<List<CursoDTO>>.Success(cursoDtos);
        }

        public async Task<Result<TipoCursoDTO>> GetTipoByCursoAsync(int idCurso)
        {
            var tipoCurso = await _repository.GetTipoByCursoAsync(idCurso);
            if (tipoCurso == null)
            {
                return Result<TipoCursoDTO>.Failure("Tipo de curso não encontrado.");
            }
            var tipoCursoDto = _mapper.Map<TipoCursoDTO>(tipoCurso);
            return Result<TipoCursoDTO>.Success(tipoCursoDto);
        }

        public async Task<Result<CursoDTO?>> GetCursoByDescricaoAsync(string descricao)
        {
            var curso = await _repository.GetCursoByDescricaoAsync(descricao);
            if (curso == null)
            {
                return Result<CursoDTO?>.Failure("Curso não encontrado com esta descrição.");
            }
            return Result<CursoDTO?>.Success(_mapper.Map<CursoDTO>(curso));
        }

        public async Task<Result<List<CursoDTO>>> GetCursosByInstituicaoAsync(int idInstituicao)
        {
            var instituicaoExiste = await _instituicaoRepository.ExistsAsync(idInstituicao);
            if (!instituicaoExiste)
            {
                return Result<List<CursoDTO>>.Failure("Instituição não encontrada com este ID.");
            }
            var cursos = await _repository.GetCursosByInstituicaoAsync(idInstituicao);
            var cursoDtos = _mapper.Map<List<CursoDTO>>(cursos);
            return Result<List<CursoDTO>>.Success(cursoDtos);
        }
    }
}
