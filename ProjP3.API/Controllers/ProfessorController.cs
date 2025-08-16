using Microsoft.AspNetCore.Mvc;
using ProjP3.Application.DTOs.Request;
using ProjP3.Application.DTOs.Response;
using ProjP3.Application.InterfaceServices;
using System.Net;

namespace ProjP3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        /// <summary>
        /// Rota para obter todos os professores cadastrados.
        /// </summary>
        /// <remarks>Obtém todos os professores cadastrados no sistema.</remarks>
        /// <returns>Lista de professores.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _professorService.GetAllAsync();
            var response = new ApiResponse<List<ProfessorDTO>>(true, HttpStatusCode.OK, result.Value!, "Professores encontrados com sucesso.", "");
            return Ok(response);
        }

        /// <summary>
        /// Rota para obter um professor pelo ID.
        /// </summary>
        /// <remarks>Obtém um professor específico pelo ID.</remarks>
        /// <returns>Professor obtido por ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(ulong id)
        {
            var result = await _professorService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<ProfessorDTO>(true, HttpStatusCode.OK, result.Value!, "Professor encontrado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para adicionar um novo professor.
        /// </summary>
        /// <remarks>Adiciona um novo professor ao sistema.</remarks>
        /// <returns>Professor adicionado com sucesso.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(ProfessorCreateDTO professor)
        {
            var result = await _professorService.AddAsync(professor);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<ProfessorDTO>(true, HttpStatusCode.Created, result.Value!, "Professor adicionado com sucesso.", "");
            return CreatedAtAction(nameof(GetById), new { id = result.Value!.IdProfessor }, successResponse);
        }

        /// <summary>
        /// Rota para alterar um professor.
        /// </summary>
        /// <remarks>Atualiza as informações de um professor cadastrado no sistema.</remarks>
        /// <returns>Professor atualizado.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(ProfessorUpdateDTO professor)
        {
            var result = await _professorService.UpdateAsync(professor);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<ProfessorDTO>(true, HttpStatusCode.OK, result.Value!, "Professor atualizado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para excluir um professor.
        /// </summary>
        /// <remarks>Exclui os dados de um professor do sistema.</remarks>
        /// <returns>Confirmação de exclusão.</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(ulong id)
        {
            var result = await _professorService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            return NoContent();
        }

        /// <summary>
        /// Rota para obter um professor pelo nome.
        /// </summary>
        /// <remarks>Obtém um professor específico pelo nome.</remarks>
        /// <returns>Professor obtido pelo nome.</returns>
        [HttpGet("nomes/{nome}")]
        public async Task<IActionResult> GetProfessoresByNome(string nome)
        {
            var result = await _professorService.GetProfessoresByNomeAsync(nome);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<ProfessorDTO>(true, HttpStatusCode.OK, result.Value!, "Professores encontrados com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para obter os professores possuídores de determinado título.
        /// </summary>
        /// <remarks>Obtém os professores que possuem um título específico.</remarks>
        /// <returns>Lista de professores pelo título.</returns>
        [HttpGet("titulos/{idTitulo}")]
        public async Task<IActionResult> GetProfessoresByTitulo(ulong idTitulo)
        {
            var result = await _professorService.GetProfessoresByTitulo(idTitulo);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<ProfessorDTO>>(true, HttpStatusCode.OK, result.Value!, "Professores encontrados com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para obter o título de um professor específico.
        /// </summary>
        /// <remarks>Obtém o título de um determinado professor.</remarks>
        /// <returns>Título obtido pelo professor.</returns>
        [HttpGet("{idProfessor}/titulos")]
        public async Task<IActionResult> GetTituloByProfessor(ulong idProfessor)
        {
            var result = await _professorService.GetTituloByProfessorAsync(idProfessor);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<TituloDTO>(true, HttpStatusCode.OK, result.Value!, "Título encontrado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para obter os professores que lecionam uma disciplina específica.
        /// </summary>
        /// <remarks>Obtém os professores associados a uma disciplina específica.</remarks>
        /// <returns>Lista de professores por disciplina.</returns>
        [HttpGet("disciplinas/{idDisciplina}")]
        public async Task<IActionResult> GetProfessoresByDisciplina(ulong idDisciplina)
        {
            var result = await _professorService.GetProfessoresByDisciplinaAsync(idDisciplina);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<ProfessorDTO>>(true, HttpStatusCode.OK, result.Value!, "Professores encontrados com sucesso.", "");
            return Ok(successResponse);
        }
    }
}
