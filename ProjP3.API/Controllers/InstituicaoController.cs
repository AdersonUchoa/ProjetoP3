using Microsoft.AspNetCore.Mvc;
using ProjP3.Application.DTOs.Request;
using ProjP3.Application.DTOs.Response;
using ProjP3.Application.InterfaceServices;
using System.Net;

namespace ProjP3.API.Controllers
{
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoService _service;

        public InstituicaoController(IInstituicaoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Rota para obter todas as instituições.
        /// </summary>
        /// <remarks>Obtém todas as instituições cadastradas no sistema.</remarks>
        /// <returns>Lista de instituições.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            var response = new ApiResponse<List<InstituicaoDTO>>(true, HttpStatusCode.OK, result.Value!, "Instituições encontradas com sucesso.", "");
            return Ok(response);
        }

        /// <summary>
        /// Rota para obter uma instituição por ID.
        /// </summary>
        /// <remarks>Obtém uma instituição específica pelo ID.</remarks>
        /// <returns>Instituição obtida por ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(ulong id)
        {
            var result = await _service.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<InstituicaoDTO>(true, HttpStatusCode.OK, result.Value!, "Instituição encontrada com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para adicionar uma nova instituição.
        /// </summary>
        /// <remarks>Adiciona uma nova instituição ao sistema.</remarks>
        /// <returns>Instituição criada com sucesso.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(InstituicaoCreateDTO instituicao)
        {
            var result = await _service.AddAsync(instituicao);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<InstituicaoDTO>(true, HttpStatusCode.Created, result.Value!, "Instituição criada com sucesso.", "");
            return CreatedAtAction(nameof(GetById), new { id = result.Value!.IdInstituicao }, successResponse);
        }

        /// <summary>
        /// Rota para atualizar uma instituição.
        /// </summary>
        /// <remarks>Atualiza uma instituição no sistema.</remarks>
        /// <returns>Instituição atualizada com sucesso.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(InstituicaoUpdateDTO instituicao)
        {
            var result = await _service.UpdateAsync(instituicao);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<InstituicaoDTO>(true, HttpStatusCode.OK, result.Value!, "Instituição atualizada com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para deletar uma instituição.
        /// </summary>
        /// <remarks>Remove uma instituição do sistema.</remarks>
        /// <returns>Confirmação de remoção.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ulong id)
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
        /// Rota para obter instituições por sigla.
        /// </summary>
        /// <remarks>Obtém a instituição que possui uma sigla específica.</remarks>
        /// <returns>Instituição encontrada pela sigla.</returns>
        [HttpGet("sigla/{sigla}")]
        public async Task<IActionResult> GetInstituicaoBySigla(string sigla)
        {
            var result = await _service.GetInstituicaoBySiglaAsync(sigla);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<InstituicaoDTO>>(true, HttpStatusCode.OK, result.Value!, "Instituições encontradas com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para obter instituições por descrição.
        /// </summary>
        /// <remarks>Obtém a instituição que possui uma sigla específica</remarks>
        /// <returns>Instituição encontrada pela descrição</returns>
        [HttpGet("descricao/{descricao}")]
        public async Task<IActionResult> GetInstituicaoByDescricao(string descricao)
        {
            var result = await _service.GetInstituicaoByDescricaoAsync(descricao);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<InstituicaoDTO>>(true, HttpStatusCode.OK, result.Value!, "Instituições encontradas com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para obter instituições por curso.
        /// </summary>
        /// <remarks>Obtém a instituição possuídora de um curso específico</remarks>
        /// <returns>Instituição obtida pelo curso</returns>
        [HttpGet("curso/{idCurso}")]
        public async Task<IActionResult> GetInstituicoesByCurso(ulong idCurso)
        {
            var result = await _service.GetInstituicoesByCursoAsync(idCurso);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<InstituicaoDTO>>(true, HttpStatusCode.OK, result.Value!, "Instituições encontradas com sucesso.", "");
            return Ok(successResponse);
        }
    }
}
