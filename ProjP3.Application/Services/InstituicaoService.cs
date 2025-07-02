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
    public class InstituicaoService : IInstituicaoService
    {
        private readonly IInstituicaoRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICursoRepository _cursoRepository;

        public InstituicaoService(IInstituicaoRepository repository, IMapper mapper, ICursoRepository cursoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _cursoRepository = cursoRepository;
        }

        public async Task<Result<List<InstituicaoDTO>>> GetAllAsync()
        {
            var instituicoes = await _repository.GetAllAsync();
            var instituicoesDto = _mapper.Map<List<InstituicaoDTO>>(instituicoes);
            return Result<List<InstituicaoDTO>>.Success(instituicoesDto);
        }

        public async Task<Result<InstituicaoDTO>> GetByIdAsync(ulong id)
        {
            var instituicao = await _repository.GetByIdAsync(id);
            if (instituicao == null)
            {
                return Result<InstituicaoDTO>.Failure("Instituição não encontrada.");
            }
            var instituicaoDto = _mapper.Map<InstituicaoDTO>(instituicao);
            return Result<InstituicaoDTO>.Success(instituicaoDto);
        }

        public async Task<Result<InstituicaoDTO>> AddAsync(InstituicaoCreateDTO instituicaoDto)
        {
            var instituicaoExiste = await _repository.ExistsAsync(instituicaoDto.IdInstituicao);
            if (instituicaoExiste)
            {
                return Result<InstituicaoDTO>.Failure("Instituição já existe.");
            }
            var instituicao = _mapper.Map<Domain.Models.Instituicao>(instituicaoDto);
            var addedInstituicao = await _repository.AddAsync(instituicao);
            await _repository.SaveAllAsync();
            return Result<InstituicaoDTO>.Success(_mapper.Map<InstituicaoDTO>(addedInstituicao));
        }

        public async Task<Result<InstituicaoDTO>> UpdateAsync(InstituicaoUpdateDTO instituicaoDto)
        {
            var instituicaoOriginal = await _repository.GetByIdAsync(instituicaoDto.IdInstituicao);
            if (instituicaoOriginal == null)
            {
                return Result<InstituicaoDTO>.Failure("Instituição não encontrada com este ID.");
            }
            _mapper.Map(instituicaoDto, instituicaoOriginal);
            var updatedInstituicao = await _repository.UpdateAsync(instituicaoOriginal);
            await _repository.SaveAllAsync();
            return Result<InstituicaoDTO>.Success(_mapper.Map<InstituicaoDTO>(updatedInstituicao));
        }

        public async Task<Result<bool>> DeleteAsync(ulong id)
        {
            var instituicaoExiste = await _repository.ExistsAsync(id);
            if (!instituicaoExiste)
            {
                return Result<bool>.Failure("Instituição não encontrada.");
            }
            var deleted = await _repository.DeleteAsync(id);
            await _repository.SaveAllAsync();
            return Result<bool>.Success(deleted);
        }

        public async Task<Result<List<InstituicaoDTO>>> GetInstituicaoBySiglaAsync(string sigla)
        {
            var instituicoes = await _repository.GetInstituicaoBySiglaAsync(sigla);
            var instituicoesDto = _mapper.Map<List<InstituicaoDTO>>(instituicoes);
            return Result<List<InstituicaoDTO>>.Success(instituicoesDto);
        }

        public async Task<Result<List<InstituicaoDTO>>> GetInstituicaoByDescricaoAsync(string descricao)
        {
            var instituicoes = await _repository.GetInstituicaoByDescricaoAsync(descricao);
            var instituicoesDto = _mapper.Map<List<InstituicaoDTO>>(instituicoes);
            return Result<List<InstituicaoDTO>>.Success(instituicoesDto);
        }

        public async Task<Result<List<InstituicaoDTO>>> GetInstituicoesByCursoAsync(ulong idCurso)
        {
            var cursoExiste = await _cursoRepository.ExistsAsync(idCurso);
            if(!cursoExiste)
            {
                return Result<List<InstituicaoDTO>>.Failure("Curso não encontrado.");
            }
            var instituicoes = await _repository.GetInstituicoesByCursoAsync(idCurso);
            var instituicoesDto = _mapper.Map<List<InstituicaoDTO>>(instituicoes);
            return Result<List<InstituicaoDTO>>.Success(instituicoesDto);
        }

        //public async Task<Result<InstituicaoDTO>> AdicionarCursoAInstituicaoAsync(ulong idInstituicao, ulong idCurso)
        //{
        //    var instituicao = await _repository.GetByIdAsync(idInstituicao);
        //    if (instituicao == null)
        //    {
        //        return Result<InstituicaoDTO>.Failure("Instituição não encontrada.");
        //    }

        //    var curso = await _cursoRepository.GetByIdAsync(idCurso);
        //    if (curso == null)
        //    {
        //        return Result<InstituicaoDTO>.Failure("Curso não encontrado.");
        //    }

        //    var cursoJaAdicionado = await _repository.JaExisteCursoNaInstituicaoAsync(idInstituicao, idCurso);
        //    if (cursoJaAdicionado)
        //    {
        //        return Result<InstituicaoDTO>.Failure("Curso já está associado a esta instituição.");
        //    }
        //    instituicao.Cursos.Add(curso);
        //    await _repository.SaveAllAsync();
        //    var instituicaoDto = _mapper.Map<InstituicaoDTO>(instituicao);
        //    return Result<InstituicaoDTO>.Success(instituicaoDto);
        //}

        //public async Task<Result<InstituicaoDTO>> RemoverCursoDeInstituicaoAsync(ulong idInstituicao, ulong idCurso)
        //{
            
        //}
    }
}
