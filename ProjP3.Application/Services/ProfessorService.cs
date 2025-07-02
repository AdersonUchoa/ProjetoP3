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
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITituloRepository _tituloRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;

        public ProfessorService(IProfessorRepository repository, IMapper mapper, ITituloRepository tituloRepository, IDisciplinaRepository disciplinaRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _tituloRepository = tituloRepository;
            _disciplinaRepository = disciplinaRepository;
        }

        public async Task<Result<List<ProfessorDTO>>> GetAllAsync()
        {
            var professores = await _repository.GetAllAsync();
            var professorDtos = _mapper.Map<List<ProfessorDTO>>(professores);
            return Result<List<ProfessorDTO>>.Success(professorDtos);
        }

        public async Task<Result<ProfessorDTO>> GetByIdAsync(ulong id)
        {
            var professor = await _repository.GetByIdAsync(id);
            if (professor == null)
            {
                return Result<ProfessorDTO>.Failure("Professor não encontrado com este ID.");
            }
            var professorDto = _mapper.Map<ProfessorDTO>(professor);
            return Result<ProfessorDTO>.Success(professorDto);
        }

        public async Task<Result<ProfessorDTO>> AddAsync(ProfessorCreateDTO professorDto)
        {
            var professorExiste = await _repository.ExistsAsync(professorDto.IdProfessor);
            if (professorExiste)
            {
                return Result<ProfessorDTO>.Failure("Professor já existe com este ID.");
            }
            var professor = _mapper.Map<Domain.Models.Professor>(professorDto);
            var addedProfessor = await _repository.AddAsync(professor);
            await _repository.SaveAllAsync();
            return Result<ProfessorDTO>.Success(_mapper.Map<ProfessorDTO>(addedProfessor));
        }

        public async Task<Result<ProfessorDTO>> UpdateAsync(ProfessorUpdateDTO professorDto)
        {
            var professorOriginal = await _repository.GetByIdAsync(professorDto.IdProfessor);
            if (professorOriginal == null)
            {
                return Result<ProfessorDTO>.Failure("Professor não encontrado com este ID.");
            }
            _mapper.Map(professorDto, professorOriginal);
            var updatedProfessor = await _repository.UpdateAsync(professorOriginal);
            await _repository.SaveAllAsync();
            return Result<ProfessorDTO>.Success(_mapper.Map<ProfessorDTO>(updatedProfessor));
        }

        public async Task<Result<bool>> DeleteAsync(ulong id)
        {
            var professorExiste = await _repository.ExistsAsync(id);
            if (!professorExiste)
            {
                return Result<bool>.Failure("Professor não encontrado com este ID.");
            }
            var deleted = await _repository.DeleteAsync(id);
            await _repository.SaveAllAsync();
            return Result<bool>.Success(deleted);
        }

        public async Task<Result<ProfessorDTO?>> GetProfessorByNomeAsync(string nome)
        {
            var professor = await _repository.GetProfessorByNomeAsync(nome);
            if (professor == null)
            {
                return Result<ProfessorDTO?>.Failure("Professor não encontrado com este nome.");
            }
            var professorDto = _mapper.Map<ProfessorDTO>(professor);
            return Result<ProfessorDTO?>.Success(professorDto);
        }

        public async Task<Result<List<ProfessorDTO>>> GetProfessoresByTitulo(ulong idTitulo)
        {
            var tituloExiste = await _tituloRepository.ExistsAsync(idTitulo);
            if (!tituloExiste)
            {
                return Result<List<ProfessorDTO>>.Failure("Título não encontrado com este ID.");
            }
            var professores = await _repository.GetProfessoresByTituloAsync(idTitulo);
            var professorDtos = _mapper.Map<List<ProfessorDTO>>(professores);
            return Result<List<ProfessorDTO>>.Success(professorDtos);
        }

        public async Task<Result<TituloDTO>> GetTituloByProfessorAsync(ulong idProfessor)
        {
            var professorExiste = await _repository.ExistsAsync(idProfessor);
            if (!professorExiste)
            {
                return Result<TituloDTO>.Failure("Professor não encontrado com este ID.");
            }
            var titulo = await _repository.GetTituloByProfessorAsync(idProfessor);
            if (titulo == null)
            {
                return Result<TituloDTO>.Failure("Título não encontrado para este professor.");
            }
            var tituloDto = _mapper.Map<TituloDTO>(titulo);
            return Result<TituloDTO>.Success(tituloDto);
        }

        public async Task<Result<List<ProfessorDTO>>> GetProfessoresByDisciplinaAsync(ulong idDisciplina)
        {
            var disciplinaExiste = await _disciplinaRepository.ExistsAsync(idDisciplina);
            if (!disciplinaExiste)
            {
                return Result<List<ProfessorDTO>>.Failure("Disciplina não encontrada com este ID.");
            }
            var professores = await _repository.GetProfessoresByDisciplinaAsync(idDisciplina);
            var professorDtos = _mapper.Map<List<ProfessorDTO>>(professores);
            return Result<List<ProfessorDTO>>.Success(professorDtos);
        }
    }
}
