using Microsoft.AspNetCore.Mvc;
using ProjP3.Application.DTOs.Request;
using ProjP3.Application.DTOs.Response;
using ProjP3.Application.InterfaceServices;
using System.Net;

namespace ProjP3.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoCursoController : ControllerBase
    {
        private readonly ITipoCursoService _tipoCursoService;
        public TipoCursoController(ITipoCursoService tipoCursoService)
        {
            _tipoCursoService = tipoCursoService;
        }

        /// <summary>
        /// Rota para buscar todos os tipos de curso.
        /// </summary>
        /// <remarks>Obtém todos os tipos de curso cadastrados no sistema</remarks>
        /// <returns>Lista de tipos de curso</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _tipoCursoService.GetAllAsync();
            var response = new ApiResponse<List<TipoCursoDTO>>(true, HttpStatusCode.OK, result.Value!, "Tipos de curso encontrados com sucesso.", "");
            return Ok(response);
        }

        /// <summary>
        /// Rota para buscar um tipo de curso pelo ID.
        /// </summary>
        /// <remarks>Retorna um tipo de curso específico com base no ID fornecido.</remarks>
        /// <returns>Tipo de curso obtido por ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(ulong id)
        {
            var result = await _tipoCursoService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<TipoCursoDTO>(true, HttpStatusCode.OK, result.Value!, "Tipo de curso encontrado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para adicionar um novo tipo de curso.
        /// </summary>
        /// <remarks>Adiciona um novo tipo de curso ao sistema.</remarks>
        /// <returns>Novo tipo de curso adicionado.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(TipoCursoCreateDTO tipoCursoDto)
        {
            var result = await _tipoCursoService.AddAsync(tipoCursoDto);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<TipoCursoDTO>(true, HttpStatusCode.Created, result.Value!, "Tipo de curso adicionado com sucesso.", "");
            return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Value!.IdTipoCurso }, successResponse);
        }

        /// <summary>
        /// Rota para alterar um tipo de curso específico pelo ID.
        /// </summary>
        /// <remarks>Altera os dados de um tipo de curso existente.</remarks>
        /// <returns>Tipo de curso atualizado.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(TipoCursoUpdateDTO tipoCursoDto)
        {
            var result = await _tipoCursoService.UpdateAsync(tipoCursoDto);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<TipoCursoDTO>(true, HttpStatusCode.OK, result.Value!, "Tipo de curso atualizado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para excluir um tipo de curso pelo ID.
        /// </summary>
        /// <remarks>Deleta os dados de um tipo de curso existente.</remarks>
        /// <returns>Confirmação de exclusão.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ulong id)
        {
            var result = await _tipoCursoService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            return NoContent();
        }

        /// <summary>
        /// Rota para buscar tipos de curso por descrição.
        /// </summary>
        /// <remarks>Retorna um tipo de curso que corresponde à descrição fornecida.</remarks>
        /// <returns>Tipo de curso pela descrição</returns>
        [HttpGet("descricao/{descricao}")]
        public async Task<IActionResult> GetTipoCursoByDescricaoAsync(string descricao)
        {
            var result = await _tipoCursoService.GetTipoCursoByDescricaoAsync(descricao);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<TipoCursoDTO>>(true, HttpStatusCode.OK, result.Value!, "Tipos de curso encontrados com sucesso.", "");
            return Ok(successResponse);
        }
    }
}
