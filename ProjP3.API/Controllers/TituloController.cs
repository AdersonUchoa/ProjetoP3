using Microsoft.AspNetCore.Mvc;
using ProjP3.Application.DTOs.Request;
using ProjP3.Application.DTOs.Response;
using ProjP3.Application.InterfaceServices;
using System.Net;

namespace ProjP3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TituloController : ControllerBase
    {
        private readonly ITituloService _tituloService;
        public TituloController(ITituloService tituloService)
        {
            _tituloService = tituloService;
        }

        /// <summary>
        /// Rota para buscar todos os títulos.
        /// </summary>
        /// <remarks>Obtém todos os títulos cadastrados no sistema</remarks>
        /// <returns>Lista de títulos</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _tituloService.GetAllAsync();
            var response = new ApiResponse<List<TituloDTO>>(true, HttpStatusCode.OK, result.Value!, "Titulos encontrados com sucesso.", "");
            return Ok(response);
        }

        /// <summary>
        /// Rota para buscar um título pelo ID.
        /// </summary>
        /// <remarks>Retorna um título específico com base no ID fornecido.</remarks>
        /// <returns>Título obtido por ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _tituloService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<TituloDTO>(true, HttpStatusCode.OK, result.Value!, "Titulo encontrado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para adicionar um novo título.
        /// </summary>
        /// <remarks>Adiciona um novo título ao sistema.</remarks>
        /// <returns>Novo título adicionado.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(TituloCreateDTO tituloDto)
        {
            var result = await _tituloService.AddAsync(tituloDto);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<TituloDTO>(true, HttpStatusCode.Created, result.Value!, "Titulo adicionado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para alterar um título específico pelo ID.
        /// </summary>
        /// <remarks>Altera os dados de um título existente.</remarks>
        /// <returns>Título atualizado.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(TituloUpdateDTO tituloDto)
        {
            var result = await _tituloService.UpdateAsync(tituloDto);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<TituloDTO>(true, HttpStatusCode.OK, result.Value!, "Titulo atualizado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para excluir um título pelo ID.
        /// </summary>
        /// <remarks>Deleta os dados de um título existente.</remarks>
        /// <returns>Confirmação de exclusão.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tituloService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            return NoContent();
        }

        /// <summary>
        /// Rota para buscar títulos por descrição.
        /// </summary>
        /// <remarks>Retorna um título que corresponde à descrição fornecida.</remarks>
        /// <returns>Título pela descrição.</returns>
        [HttpGet("descricoes/{descricao}")]
        public async Task<IActionResult> GetTituloByDescricaoAsync(string descricao)
        {
            var result = await _tituloService.GetTituloByDescricaoAsync(descricao);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<TituloDTO>>(true, HttpStatusCode.OK, result.Value!, "Titulos encontrados com sucesso.", "");
            return Ok(successResponse);
        }
    }
}
