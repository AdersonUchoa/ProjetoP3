using Microsoft.AspNetCore.Mvc;
using ProjP3.Application.DTOs.Request;
using ProjP3.Application.DTOs.Response;
using ProjP3.Application.InterfaceServices;
using System.Net;

namespace ProjP3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;
        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Rota para buscar todos os alunos.
        /// </summary>
        /// <remarks>Retorna todos os alunos cadastrados no sistema.</remarks>
        /// <returns>Lista de alunos</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            var response = new ApiResponse<List<AlunoDTO>>(true, HttpStatusCode.OK, result.Value!, "Alunos encontrados com sucesso.", "");
            return Ok(response);
        }

        /// <summary>
        /// Rota para buscar um aluno pelo ID.
        /// </summary>
        /// <remarks>Retorna um aluno específico com base no ID fornecido.</remarks>
        /// <returns>Aluno obtido por ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<AlunoDTO>(true, HttpStatusCode.OK, result.Value!, "Aluno encontrado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para adicionar um novo aluno.
        /// </summary>
        /// <remarks>Adiciona um novo aluno ao sistema.</remarks>
        /// <returns>Novo aluno adicionado.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(AlunoCreateDTO alunoDto)
        {
            var result = await _service.AddAsync(alunoDto);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<AlunoDTO>(true, HttpStatusCode.Created, result.Value!, "Aluno adicionado com sucesso.", "");
            return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Value!.IdAluno }, successResponse);
        }

        /// <summary>
        /// Rota para alterar um aluno específico pelo ID.
        /// </summary>
        /// <remarks>Altera os dados de um aluno existente.</remarks>
        /// <returns>Aluno atualizado.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(AlunoUpdateDTO alunoDto)
        {
            var result = await _service.UpdateAsync(alunoDto);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<AlunoDTO>(true, HttpStatusCode.OK, result.Value!, "Aluno atualizado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para excluir um aluno pelo ID.
        /// </summary>
        /// <remarks>Deleta os dados de um aluno existente.</remarks>
        /// <returns>Confirmação de exclusão.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            return NoContent();
        }

        /// <summary>
        /// Rota para buscar um aluno pelo nome.
        /// </summary>
        /// <remarks>Retorna um aluno obtido pelo nome</remarks>
        /// <returns>Aluno obtido por nome</returns>
        [HttpGet("nomes/{nome}")]
        public async Task<IActionResult> GetAlunoByNome(string nome)
        {
            var result = await _service.GetAlunoByNomeAsync(nome);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<AlunoDTO>(true, HttpStatusCode.OK, result.Value!, "Aluno encontrado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para buscar alunos por disciplina.
        /// </summary>
        /// <remarks>Retorna uma lista de alunos que estão matriculados em uma disciplina específica.</remarks>
        /// <returns>Lista de alunos matriculados na disciplina</returns>
        [HttpGet("disciplinas/{idDisciplina}")]
        public async Task<IActionResult> GetAlunosByDisciplina(int idDisciplina)
        {
            var result = await _service.GetAlunosByDisciplinaAsync(idDisciplina);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<AlunoDTO>>(true, HttpStatusCode.OK, result.Value!, "Alunos encontrados com sucesso.", "");
            return Ok(successResponse);
        }
    }
}
