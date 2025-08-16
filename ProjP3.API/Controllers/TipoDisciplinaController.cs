using Microsoft.AspNetCore.Mvc;
using ProjP3.Application.DTOs.Request;
using ProjP3.Application.DTOs.Response;
using ProjP3.Application.InterfaceServices;
using System.Net;

namespace ProjP3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoDisciplinaController : ControllerBase
    {
        private readonly ITipoDisciplinaService _tipoDisciplinaService;
        public TipoDisciplinaController(ITipoDisciplinaService tipoDisciplinaService)
        {
            _tipoDisciplinaService = tipoDisciplinaService;
        }

        /// <summary>
        /// Rota para buscar todos os tipos de disciplina.
        /// </summary>
        /// <remarks>Obtém todos os tipos de disciplina cadastrados no sistema</remarks>
        /// <returns>Lista de tipos de disciplina</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _tipoDisciplinaService.GetAllAsync();
            var response = new ApiResponse<List<TipoDisciplinaDTO>>(true, HttpStatusCode.OK, result.Value!, "Tipos de disciplina encontrados com sucesso.", "");
            return Ok(response);
        }

        /// <summary>
        /// Rota para buscar um tipo de disciplina pelo ID.
        /// </summary>
        /// <remarks>Retorna um tipo de disciplina específico com base no ID fornecido.</remarks>
        /// <returns>Tipo de disciplina obtido por ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _tipoDisciplinaService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<TipoDisciplinaDTO>(true, HttpStatusCode.OK, result.Value!, "Tipo de disciplina encontrado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para adicionar um novo tipo de disciplina.
        /// </summary>
        /// <remarks>Adiciona um novo tipo de disciplina ao sistema.</remarks>
        /// <returns>Novo tipo de disciplina adicionado.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(TipoDisciplinaCreateDTO tipoDisciplinaDto)
        {
            var result = await _tipoDisciplinaService.AddAsync(tipoDisciplinaDto);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<TipoDisciplinaDTO>(true, HttpStatusCode.Created, result.Value!, "Tipo de disciplina adicionado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para alterar um tipo de disciplina específico pelo ID.
        /// </summary>
        /// <remarks>Altera os dados de um tipo de disciplina existente.</remarks>
        /// <returns>Tipo de disciplina atualizado.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(TipoDisciplinaUpdateDTO tipoDisciplinaDto)
        {
            var result = await _tipoDisciplinaService.UpdateAsync(tipoDisciplinaDto);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<TipoDisciplinaDTO>(true, HttpStatusCode.OK, result.Value!, "Tipo de disciplina atualizado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para excluir um tipo de disciplina pelo ID.
        /// </summary>
        /// <remarks>Deleta os dados de um tipo de disciplina existente.</remarks>
        /// <returns>Confirmação de exclusão.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tipoDisciplinaService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            return NoContent();
        }

        /// <summary>
        /// Rota para buscar tipos de disciplina por descrição.
        /// </summary>
        /// <remarks>Retorna um tipo de disciplina que corresponde à descrição fornecida.</remarks>
        /// <returns>Tipo de disciplina pela descrição.</returns>
        [HttpGet("descricoes/{descricao}")]
        public async Task<IActionResult> GetTipoDisciplinaByDescricaoAsync(string descricao)
        {
            var result = await _tipoDisciplinaService.GetTipoDisciplinaByDescricaoAsync(descricao);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<TipoDisciplinaDTO>(true, HttpStatusCode.OK, result.Value!, "Tipo de disciplina encontrado com sucesso.", "");
            return Ok(successResponse);
        }
    }
}
