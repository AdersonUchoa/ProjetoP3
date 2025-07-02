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
    public class TituloService : ITituloService
    {
        private readonly ITituloRepository _repository;
        private readonly IMapper _mapper;

        public TituloService(ITituloRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<TituloDTO>>> GetAllAsync()
        {
            var titulos = await _repository.GetAllAsync();
            var tituloDtos = _mapper.Map<List<TituloDTO>>(titulos);
            return Result<List<TituloDTO>>.Success(tituloDtos);
        }

        public async Task<Result<TituloDTO>> GetByIdAsync(ulong id)
        {
            var titulo = await _repository.GetByIdAsync(id);
            if (titulo == null)
            {
                return Result<TituloDTO>.Failure("Titulo não encontrado com este ID.");
            }
            var tituloDto = _mapper.Map<TituloDTO>(titulo);
            return Result<TituloDTO>.Success(tituloDto);
        }

        public async Task<Result<TituloDTO>> AddAsync(TituloCreateDTO tituloDto)
        {
            var tituloExiste = await _repository.ExistsAsync(tituloDto.IdTitulo);
            if (tituloExiste)
            {
                return Result<TituloDTO>.Failure("Titulo já existe com este ID.");
            }

            var titulo = _mapper.Map<Domain.Models.Titulo>(tituloDto);
            var addedTitulo = await _repository.AddAsync(titulo);

            await _repository.SaveAllAsync();

            return Result<TituloDTO>.Success(_mapper.Map<TituloDTO>(addedTitulo));
        }

        public async Task<Result<TituloDTO>> UpdateAsync(TituloUpdateDTO tituloDto)
        {
            var tituloOriginal = await _repository.GetByIdAsync(tituloDto.IdTitulo);

            if (tituloOriginal == null)
            {
                return Result<TituloDTO>.Failure("Titulo não encontrado.");
            }

            _mapper.Map(tituloDto, tituloOriginal);

            var updatedTitulo = await _repository.UpdateAsync(tituloOriginal);

            await _repository.SaveAllAsync();

            return Result<TituloDTO>.Success(_mapper.Map<TituloDTO>(updatedTitulo));
        }

        public async Task<Result<bool>> DeleteAsync(ulong id)
        {
            var tituloExiste = await _repository.ExistsAsync(id);
            if (!tituloExiste)
            {
                return Result<bool>.Failure("Titulo não encontrado com este ID.");
            }

            var deleted = await _repository.DeleteAsync(id);

            await _repository.SaveAllAsync();

            return Result<bool>.Success(deleted);
        }

        public async Task<Result<List<TituloDTO>>> GetTituloByDescricaoAsync(string descricao)
        {
            var titulo = await _repository.GetTituloByDescricaoAsync(descricao);
            if (titulo == null)
            {
                return Result<List<TituloDTO>>.Failure("Nenhum titulo encontrado com esta descrição.");
            }
            var tituloDto = _mapper.Map<List<TituloDTO>>(titulo);
            return Result<List<TituloDTO>>.Success(tituloDto);
        }
    }
}
