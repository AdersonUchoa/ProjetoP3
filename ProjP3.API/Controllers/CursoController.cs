using Microsoft.AspNetCore.Mvc;
using ProjP3.Application.DTOs.Request;
using ProjP3.Application.DTOs.Response;
using ProjP3.Application.InterfaceServices;
using System.Net;

namespace ProjP3.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _service;
        public CursoController(ICursoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Rota para buscar todos os cursos.
        /// </summary>
        /// <remarks>Retorna todos os cursos cadastrados no sistema.</remarks>
        /// <returns>Lista de cursos</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            var response = new ApiResponse<List<CursoDTO>>(true, HttpStatusCode.OK, result.Value!, "Cursos encontrados com sucesso.", "");
            return Ok(response);
        }

        /// <summary>
        /// Rota para buscar um curso pelo ID.
        /// </summary>
        /// <remarks>Retorna um curso específico com base no ID fornecido.</remarks>
        /// <returns>Curso obtido por ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(ulong id)
        {
            var result = await _service.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<CursoDTO>(true, HttpStatusCode.OK, result.Value!, "Curso encontrado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para adicionar um novo curso.
        /// </summary>
        /// <remarks>Adiciona um novo curso ao sistema.</remarks>
        /// <returns>Novo curso adicionado.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CursoCreateDTO cursoDto)
        {
            var result = await _service.AddAsync(cursoDto);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<CursoDTO>(true, HttpStatusCode.Created, result.Value!, "Curso adicionado com sucesso.", "");
            return CreatedAtAction(nameof(GetById), new { id = result.Value!.IdCurso }, successResponse);
        }

        /// <summary>
        /// Rota para atualizar um curso existente.
        /// </summary>
        /// <remarks>Atualiza as informações de um curso existente no sistema.</remarks>
        /// <returns>Curso atualizado</returns>
        [HttpPut]
        public async Task<IActionResult> Update(CursoUpdateDTO cursoDto)
        {
            var result = await _service.UpdateAsync(cursoDto);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<CursoDTO>(true, HttpStatusCode.OK, result.Value!, "Curso atualizado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para excluir um curso pelo ID.
        /// </summary>
        /// <remarks>Deleta os dados de um curso</remarks>
        /// <returns>Confirmação de exclusão</returns>
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
        /// Rota para associar uma disciplina existente a um curso.
        /// </summary>
        /// <remarks>Associa uma disciplina a um curso</remarks>
        /// <returns>Confirmação de associação</returns>
        [HttpPost("{idCurso}/disciplinas")]
        public async Task<IActionResult> AdicionarDisciplinaAoCurso(ulong idCurso, ulong idDisciplina)
        {
            var result = await _service.AdicionarDisciplinaAoCursoAsync(idCurso, idDisciplina);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<CursoDTO>(true, HttpStatusCode.OK, result.Value!, "Disciplina adicionada ao curso com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para remover uma disciplina de um curso.
        /// </summary>
        /// <remarks>Desassocia uma disciplina de um curso</remarks>
        /// <returns>Confirmação de remoção</returns>
        [HttpDelete("{idCurso}/disciplinas/{idDisciplina}")]
        public async Task<IActionResult> RemoverDisciplinaDoCurso(ulong idCurso, ulong idDisciplina)
        {
            var result = await _service.RemoverDisciplinaDoCursoAsync(idCurso, idDisciplina);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            return NoContent();
        }

        /// <summary>
        /// Rota para buscar todos os cursos de um tipo específico.
        /// </summary>
        /// <remarks>Retorna todos os cursos de um tipo específico.</remarks>
        /// <returns>Lista de cursos de um tipo específico</returns>
        [HttpGet("tipo/{idTipoCurso}")]
        public async Task<IActionResult> GetCursosByTipo(ulong idTipoCurso)
        {
            var result = await _service.GetCursosByTipoAsync(idTipoCurso);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<CursoDTO>>(true, HttpStatusCode.OK, result.Value!, "Cursos encontrados com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para buscar o tipo de curso associado a um curso específico.
        /// </summary>
        /// <remarks>Retorna o tipo de curso de um curso específico</remarks>
        /// <returns>Tipo de curso associado</returns>
        [HttpGet("tipo/curso/{idCurso}")]
        public async Task<IActionResult> GetTipoByCurso(ulong idCurso)
        {
            var result = await _service.GetTipoByCursoAsync(idCurso);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<TipoCursoDTO>(true, HttpStatusCode.OK, result.Value!, "Tipo de curso encontrado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para buscar um curso pela descrição.
        /// </summary>
        /// <remarks>Retorna um curso específico com base na descrição fornecida.</remarks>
        /// <returns>Curso pela descrição</returns>
        [HttpGet("search")]
        public async Task<IActionResult> GetCursoByDescricao([FromQuery] string descricao)
        {
            var result = await _service.GetCursoByDescricaoAsync(descricao);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<CursoDTO?>(true, HttpStatusCode.OK, result.Value!, "Curso encontrado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para buscar todos os cursos de uma instituição específica.
        /// </summary>
        /// <remarks>Retorna os cursos de uma instituição</remarks>
        /// <returns>Cursos de uma instituição</returns>
        [HttpGet("instituicao/{idInstituicao}")]
        public async Task<IActionResult> GetCursosByInstituicao(ulong idInstituicao)
        {
            var result = await _service.GetCursosByInstituicaoAsync(idInstituicao);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<CursoDTO>>(true, HttpStatusCode.OK, result.Value!, "Cursos encontrados com sucesso.", "");
            return Ok(successResponse);
        }
    }
}
