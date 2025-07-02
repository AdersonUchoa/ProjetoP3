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
    public class TipoDisciplinaService : ITipoDisciplinaService
    {
        private readonly ITipoDisciplinaRepository _repository;
        private readonly IMapper _mapper;

        public TipoDisciplinaService(ITipoDisciplinaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<TipoDisciplinaDTO>>> GetAllAsync()
        {
            var tiposDisciplinas = await _repository.GetAllAsync();
            var tipoDisciplinaDtos = _mapper.Map<List<TipoDisciplinaDTO>>(tiposDisciplinas);
            return Result<List<TipoDisciplinaDTO>>.Success(tipoDisciplinaDtos);
        }

        public async Task<Result<TipoDisciplinaDTO>> GetByIdAsync(ulong id)
        {
            var tipoDisciplina = await _repository.GetByIdAsync(id);
            if (tipoDisciplina == null)
            {
                return Result<TipoDisciplinaDTO>.Failure("Tipo de disciplina não encontrado com este ID.");
            }
            var tipoDisciplinaDto = _mapper.Map<TipoDisciplinaDTO>(tipoDisciplina);
            return Result<TipoDisciplinaDTO>.Success(tipoDisciplinaDto);
        }

        public async Task<Result<TipoDisciplinaDTO>> AddAsync(TipoDisciplinaCreateDTO tipoDisciplinaDto)
        {
            var tipoDisciplinaExiste = await _repository.ExistsAsync(tipoDisciplinaDto.IdTipoDisciplina);
            if (tipoDisciplinaExiste)
            {
                return Result<TipoDisciplinaDTO>.Failure("Tipo de disciplina já existente.");
            }

            var tipoDisciplina = _mapper.Map<Domain.Models.TipoDisciplina>(tipoDisciplinaDto);
            var addedTipoDisciplina = await _repository.AddAsync(tipoDisciplina);

            await _repository.SaveAllAsync();

            return Result<TipoDisciplinaDTO>.Success(_mapper.Map<TipoDisciplinaDTO>(addedTipoDisciplina));
        }

        public async Task<Result<TipoDisciplinaDTO>> UpdateAsync(TipoDisciplinaUpdateDTO tipoDisciplinaDto)
        {
            var tipoDisciplina = await _repository.GetByIdAsync(tipoDisciplinaDto.IdTipoDisciplina);

            if (tipoDisciplina == null)
            {
                return Result<TipoDisciplinaDTO>.Failure("Tipo de disciplina não encontrado para atualização.");
            }

            _mapper.Map(tipoDisciplinaDto, tipoDisciplina);

            var updatedTipoDisciplina = await _repository.UpdateAsync(tipoDisciplina);

            await _repository.SaveAllAsync();

            return Result<TipoDisciplinaDTO>.Success(_mapper.Map<TipoDisciplinaDTO>(updatedTipoDisciplina));
        }

        public async Task<Result<bool>> DeleteAsync(ulong id)
        {
            var tipoDisciplinaExiste = await _repository.ExistsAsync(id);
            if (!tipoDisciplinaExiste)
            {
                return Result<bool>.Failure("Tipo de disciplina não encontrado para exclusão.");
            }

            var deleted = await _repository.DeleteAsync(id);

            await _repository.SaveAllAsync();

            return Result<bool>.Success(deleted);
        }

        public async Task<Result<TipoDisciplinaDTO>> GetTipoDisciplinaByDescricaoAsync(string descricao)
        {
            var tipoDisciplina = await _repository.GetTipoDisciplinaByDescricaoAsync(descricao);
            if (tipoDisciplina == null)
            {
                return Result<TipoDisciplinaDTO>.Failure("Tipo de disciplina não encontrado com esta descrição.");
            }
            var tipoDisciplinaDto = _mapper.Map<TipoDisciplinaDTO>(tipoDisciplina);
            return Result<TipoDisciplinaDTO>.Success(tipoDisciplinaDto);
        }
    }
}
