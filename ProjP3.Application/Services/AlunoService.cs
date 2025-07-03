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
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IDisciplinaRepository _disciplinaRepository;

        public AlunoService(IAlunoRepository repository, IMapper mapper, IDisciplinaRepository disciplinaRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _disciplinaRepository = disciplinaRepository;
        }

        public async Task<Result<List<AlunoDTO>>> GetAllAsync()
        {
            var alunos = await _repository.GetAllAsync();
            var alunoDtos = _mapper.Map<List<AlunoDTO>>(alunos);
            return Result<List<AlunoDTO>>.Success(alunoDtos);
        }

        public async Task<Result<AlunoDTO>> GetByIdAsync(ulong id)
        {
            var aluno = await _repository.GetByIdAsync(id);
            if (aluno == null)
            {
                return Result<AlunoDTO>.Failure("Aluno não encontrado com este ID.");
            }
            var alunoDto = _mapper.Map<AlunoDTO>(aluno);
            return Result<AlunoDTO>.Success(alunoDto);
        }

        public async Task<Result<AlunoDTO>> AddAsync(AlunoCreateDTO alunoDto)
        {
            var alunoExiste = await _repository.ExistsByNomeAsync(alunoDto.TxNome);
            if (alunoExiste)
            {
                return Result<AlunoDTO>.Failure("Aluno já existe com este exato nome.");
            }
            var aluno = _mapper.Map<Domain.Models.Aluno>(alunoDto);
            var addedAluno = await _repository.AddAsync(aluno);
            await _repository.SaveAllAsync();
            return Result<AlunoDTO>.Success(_mapper.Map<AlunoDTO>(addedAluno));
        }

        public async Task<Result<AlunoDTO>> UpdateAsync(AlunoUpdateDTO alunoDto)
        {
            var alunoOriginal = await _repository.ExistsByNomeAsync(alunoDto.TxNome);
            if (!alunoOriginal)
            {
                return Result<AlunoDTO>.Failure("Aluno não encontrado com este nome.");
            }
            var aluno = _mapper.Map<Domain.Models.Aluno>(alunoDto);
            var updatedAluno = await _repository.UpdateAsync(aluno);
            await _repository.SaveAllAsync();
            return Result<AlunoDTO>.Success(_mapper.Map<AlunoDTO>(updatedAluno));
        }

        public async Task<Result<bool>> DeleteAsync(ulong id)
        {
            var alunoExiste = await _repository.ExistsAsync(id);
            if (!alunoExiste)
            {
                return Result<bool>.Failure("Aluno não encontrado com este ID.");
            }
            var deleted = await _repository.DeleteAsync(id);
            await _repository.SaveAllAsync();
            return Result<bool>.Success(deleted);
        }

        public async Task<Result<AlunoDTO>> GetAlunoByNomeAsync(string nome)
        {
            var aluno = await _repository.GetAlunoByNomeAsync(nome);
            if (aluno == null)
            {
                return Result<AlunoDTO>.Failure("Aluno não encontrado com este nome.");
            }
            var alunoDto = _mapper.Map<AlunoDTO>(aluno);
            return Result<AlunoDTO>.Success(alunoDto);
        }

        public async Task<Result<List<AlunoDTO>>> GetAlunosByDisciplinaAsync(ulong idDisciplina)
        {
            var disciplinaExiste = await _disciplinaRepository.ExistsAsync(idDisciplina);
            if (!disciplinaExiste)
            {
                return Result<List<AlunoDTO>>.Failure("Disciplina não encontrada com este ID.");
            }
            var alunos = await _repository.GetAlunosByDisciplinaAsync(idDisciplina);
            var alunoDtos = _mapper.Map<List<AlunoDTO>>(alunos);
            return Result<List<AlunoDTO>>.Success(alunoDtos);
        }
    }
}
