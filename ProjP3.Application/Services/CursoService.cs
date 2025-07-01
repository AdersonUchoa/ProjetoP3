using AutoMapper;
using ProjP3.Application.Common;
using ProjP3.Application.DTOs;
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

        public CursoService(ICursoRepository repository, IMapper mapper, ITipoCursoRepository tipoCursoRepository, IInstituicaoRepository instituicaoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _tipoCursoRepository = tipoCursoRepository;
            _instituicaoRepository = instituicaoRepository;
        }

        public async Task<Result<List<CursoDTO>>> GetAllAsync()
        {
            var cursos = await _repository.GetAllAsync();
            var cursoDtos = _mapper.Map<List<CursoDTO>>(cursos);
            return Result<List<CursoDTO>>.Success(cursoDtos);
        }

        public async Task<Result<CursoDTO>> GetByIdAsync(ulong id)
        {
            var curso = await _repository.GetByIdAsync(id);
            if (curso == null)
            {
                return Result<CursoDTO>.Failure("Curso não encontrado com este ID.");
            }
            var cursoDto = _mapper.Map<CursoDTO>(curso);
            return Result<CursoDTO>.Success(cursoDto);
        }

        public async Task<Result<CursoDTO>> AddAsync(CursoDTO cursoDto)
        {
            var cursoExiste = await _repository.ExistsAsync(cursoDto.IdCurso);
            if (cursoExiste)
            {
                return Result<CursoDTO>.Failure("Curso já existe com este ID.");
            }
            var curso = _mapper.Map<Domain.Models.Curso>(cursoDto);
            var addedCurso = await _repository.AddAsync(curso);
            await _repository.SaveAllAsync();
            return Result<CursoDTO>.Success(_mapper.Map<CursoDTO>(addedCurso));
        }

        public async Task<Result<CursoDTO>> UpdateAsync(CursoDTO cursoDto)
        {
            var cursoOriginal = await _repository.GetByIdAsync(cursoDto.IdCurso);
            if (cursoOriginal == null)
            {
                return Result<CursoDTO>.Failure("Curso não encontrado com este ID.");
            }
            _mapper.Map(cursoDto, cursoOriginal);
            var updatedCurso = _repository.UpdateAsync(cursoOriginal);
            await _repository.SaveAllAsync();
            return Result<CursoDTO>.Success(_mapper.Map<CursoDTO>(updatedCurso));
        }

        public async Task<Result<bool>> DeleteAsync(ulong id)
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

        public async Task<Result<CursoDTO>> AdicionarDisciplinaAoCursoAsync(ulong idCurso, ulong idDisciplina)
        {
            var curso = await _repository.AdicionarDisciplinaAoCursoAsync(idCurso, idDisciplina);
            if (curso == null)
            {
                return Result<CursoDTO>.Failure("Erro ao adicionar disciplina ao curso.");
            }
            return Result<CursoDTO>.Success(_mapper.Map<CursoDTO>(curso));
        }

        public async Task<Result<CursoDTO>> RemoverDisciplinaDoCursoAsync(ulong idCurso, ulong idDisciplina)
        {
            var curso = await _repository.RemoverDisciplinaDoCursoAsync(idCurso, idDisciplina);
            if (curso == null)
            {
                return Result<CursoDTO>.Failure("Erro ao remover disciplina do curso.");
            }
            return Result<CursoDTO>.Success(_mapper.Map<CursoDTO>(curso));
        }

        public async Task<Result<List<CursoDTO>>> GetCursosByTipoAsync(ulong idTipoCurso)
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

        public async Task<Result<TipoCursoDTO>> GetTipoByCursoAsync(ulong idCurso)
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

        public async Task<Result<List<CursoDTO>>> GetCursosByInstituicaoAsync(ulong idInstituicao)
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
