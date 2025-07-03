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
    public class TipoCursoService : ITipoCursoService
    {
        private readonly ITipoCursoRepository _repository;
        private readonly IMapper _mapper;

        public TipoCursoService(ITipoCursoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<TipoCursoDTO>>> GetAllAsync()
        {
            var tiposCurso = await _repository.GetAllAsync();
            var tipoCursoDtos = _mapper.Map<List<TipoCursoDTO>>(tiposCurso);
            return Result<List<TipoCursoDTO>>.Success(tipoCursoDtos);
        }

        public async Task<Result<TipoCursoDTO>> GetByIdAsync(ulong id)
        {
            var tipoCurso = await _repository.GetByIdAsync(id);
            if (tipoCurso == null)
            {
                return Result<TipoCursoDTO>.Failure("Tipo de curso não encontrado com este ID.");
            }
            var tipoCursoDto = _mapper.Map<TipoCursoDTO>(tipoCurso);
            return Result<TipoCursoDTO>.Success(tipoCursoDto);
        }

        public async Task<Result<TipoCursoDTO>> AddAsync(TipoCursoCreateDTO tipoCursoDto)
        {
            var tipoCursoExiste = await _repository.ExistsByDescricaoAsync(tipoCursoDto.TxDescricao);
            if (tipoCursoExiste)
            {
                return Result<TipoCursoDTO>.Failure("Tipo de curso já existente com esta descrição.");
            }
            var tipoCurso = _mapper.Map<Domain.Models.TipoCurso>(tipoCursoDto);
            var addedTipoCurso = await _repository.AddAsync(tipoCurso);
            await _repository.SaveAllAsync();
            return Result<TipoCursoDTO>.Success(_mapper.Map<TipoCursoDTO>(addedTipoCurso));
        }

        public async Task<Result<TipoCursoDTO>> UpdateAsync(TipoCursoUpdateDTO tipoCursoDto)
        {
            var tipoCursoExiste = await _repository.ExistsByDescricaoAsync(tipoCursoDto.TxDescricao);
            if (!tipoCursoExiste)
            {
                return Result<TipoCursoDTO>.Failure("Tipo de curso não encontrado com esta descrição.");
            }

            var tipoCurso = _mapper.Map<Domain.Models.TipoCurso>(tipoCursoDto);

            var updatedTipoCurso = await _repository.UpdateAsync(tipoCurso);

            await _repository.SaveAllAsync();

            return Result<TipoCursoDTO>.Success(_mapper.Map<TipoCursoDTO>(updatedTipoCurso));
        }

        public async Task<Result<bool>> DeleteAsync(ulong id)
        {
            var tipoCursoExiste = await _repository.ExistsAsync(id);
            if (!tipoCursoExiste)
            {
                return Result<bool>.Failure("Tipo de curso não encontrado com este ID.");
            }
            var deleted = await _repository.DeleteAsync(id);
            await _repository.SaveAllAsync();
            return Result<bool>.Success(deleted);
        }

        public async Task<Result<List<TipoCursoDTO>>> GetTipoCursoByDescricaoAsync(string descricao)
        {
            var tipoCurso = await _repository.GetTipoCursoByDescricaoAsync(descricao);
            if (tipoCurso == null)
            {
                return Result<List<TipoCursoDTO>>.Failure("Nenhum tipo de curso encontrado com esta descrição.");
            }
            var tipoCursoDto = _mapper.Map<List<TipoCursoDTO>>(tipoCurso);
            return Result<List<TipoCursoDTO>>.Success(tipoCursoDto);
        }
    }
}
