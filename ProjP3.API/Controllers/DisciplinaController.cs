using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjP3.Application.DTOs.Request;
using ProjP3.Application.DTOs.Response;
using ProjP3.Application.InterfaceServices;
using System.Net;

namespace ProjP3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService _service;

        public DisciplinaController(IDisciplinaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Rota para buscar disciplinas e quantidade por curso.
        /// </summary>
        /// <remarks>Retorna todas as disciplinas e sua quantidade no curso</remarks>
        /// <returns>Lista de disciplinas</returns>
        [HttpGet("quantidades")]
        public async Task<ActionResult<IEnumerable<DisciplinaDataDTO>>> GetQuantidades()
        {
            var data = await _service.GetQuantidadeDisciplinasPorCursoAsync();
            return Ok(data);
        }

        /// <summary>
        /// Rota para buscar todas as disciplinas.
        /// </summary>
        /// <remarks>Retorna todas as disciplinas cadastradas no sistema</remarks>
        /// <returns>Lista de disciplinas</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            var response = new ApiResponse<List<DisciplinaDTO>>(true, HttpStatusCode.OK, result.Value!, "Disciplinas encontradas com sucesso.", "");
            return Ok(response);
        }

        /// <summary>
        /// Rota para buscar uma disciplina pelo ID.
        /// </summary>
        /// <remarks>Retorna uma disciplina específica com base no ID fornecido</remarks>
        /// <returns>Disciplina obtida por ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(ulong id)
        {
            var result = await _service.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<DisciplinaDTO>(true, HttpStatusCode.OK, result.Value!, "Disciplina encontrada com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para adicionar uma nova disciplina.
        /// </summary>
        /// <remarks>Adiciona uma nova disciplina ao sistema</remarks>
        /// <returns>Nova disciplina adicionada</returns>
        [HttpPost]
        public async Task<IActionResult> Add(DisciplinaCreateDTO disciplinaDto)
        {
            var result = await _service.AddAsync(disciplinaDto);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<DisciplinaDTO>(true, HttpStatusCode.Created, result.Value!, "Disciplina adicionada com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para atualizar uma disciplina existente.
        /// </summary>
        /// <remarks>Atualiza as informações de uma disciplina existente no sistema.</remarks>
        /// <returns>Disciplina atualizado</returns>
        [HttpPut]
        public async Task<IActionResult> Update(DisciplinaUpdateDTO disciplinaDto)
        {
            var result = await _service.UpdateAsync(disciplinaDto);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<DisciplinaDTO>(true, HttpStatusCode.OK, result.Value!, "Disciplina atualizada com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para excluir uma disciplina pelo ID.
        /// </summary>
        /// <remarks>Deleta os dados de uma disciplina</remarks>
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
        /// Rota para buscar todas as disciplinas de um aluno específico.
        /// </summary>
        /// <remarks>Retorna as disciplinas de um aluno</remarks>
        /// <returns>Lista de disciplinas de um aluno.</returns>
        [HttpGet("alunos/{idAluno}")]
        public async Task<IActionResult> GetDisciplinasByAluno(ulong idAluno)
        {
            var result = await _service.GetDisciplinasByAlunoAsync(idAluno);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<DisciplinaDTO>>(true, HttpStatusCode.OK, result.Value!, "Disciplinas encontradas com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para buscar disciplinas por tipo.
        /// </summary>
        /// <remarks>Retorna as disciplinas de um tipo específico</remarks>
        /// <returns>Lista de disciplinas filtradas por tipo.</returns>
        [HttpGet("tipos/{idTipoDisciplina}")]
        public async Task<IActionResult> GetDisciplinasByTipo(ulong idTipoDisciplina)
        {
            var result = await _service.GetDisciplinasByTipoAsync(idTipoDisciplina);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<DisciplinaDTO>>(true, HttpStatusCode.OK, result.Value!, "Disciplinas encontradas com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para buscar um tipo de disciplina.
        /// </summary>
        /// <remarks>Retorna o tipo de uma disciplina específico</remarks>
        /// <returns>Tipo de uma disciplina</returns>
        [HttpGet("{idDisciplina}/tipos")]
        public async Task<IActionResult> GetTipoByDisciplina(ulong idDisciplina)
        {
            var result = await _service.GetTipoByDisciplinaAsync(idDisciplina);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<TipoDisciplinaDTO>(true, HttpStatusCode.OK, result.Value!, "Tipo de disciplina encontrado com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para buscar disciplinas por período.
        /// </summary>
        /// <remarks>Retorna todas as disciplinas de um período específico.</remarks>
        /// <returns>Lista de disciplinas de um período.</returns>
        [HttpGet("periodos/{periodo}")]
        public async Task<IActionResult> GetDisciplinasByPeriodo(int periodo)
        {
            var result = await _service.GetDisciplinasByPeriodoAsync(periodo);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<DisciplinaDTO>>(true, HttpStatusCode.OK, result.Value!, "Disciplinas encontradas com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para buscar disciplinas por carga horária.
        /// </summary>
        /// <remarks>Retorna todas as disciplinas com uma carga horária específica.</remarks>
        /// <returns>Lista de disciplinas por carga horária.</returns>
        [HttpGet("cargas-horarias/{cargaHoraria}")]
        public async Task<IActionResult> GetDisciplinasByCargaHoraria(int cargaHoraria)
        {
            var result = await _service.GetDisciplinasByCargaHorariaAsync(cargaHoraria);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<DisciplinaDTO>>(true, HttpStatusCode.OK, result.Value!, "Disciplinas encontradas com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para buscar disciplinas por sigla.
        /// </summary>
        /// <remarks>Retorna todas as disciplinas com uma sígla específica.</remarks>
        /// <returns>Lista de disciplinas por sigla.</returns>
        [HttpGet("siglas/{sigla}")]
        public async Task<IActionResult> GetDisciplinasBySigla(string sigla)
        {
            var result = await _service.GetDisciplinasBySiglaAsync(sigla);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<DisciplinaDTO>>(true, HttpStatusCode.OK, result.Value!, "Disciplinas encontradas com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para buscar disciplinas por descrição.
        /// </summary>
        /// <remarks>Retorna todas as disciplinas com uma descrição específica.</remarks>
        /// <returns>Lista de disciplinas por descrição.</returns>
        [HttpGet("descricoes/{descricao}")]
        public async Task<IActionResult> GetDisciplinasByDescricao(string descricao)
        {
            var result = await _service.GetDisciplinasByDescricaoAsync(descricao);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<DisciplinaDTO>>(true, HttpStatusCode.OK, result.Value!, "Disciplinas encontradas com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para adicionar um aluno a uma disciplina.
        /// </summary>
        /// <remarks>Associa um aluno a uma disciplina.</remarks>
        /// <returns>Confirmação de associação.</returns>
        [HttpPost("alunos/{idDisciplina}/{idAluno}/{periodo}")]
        public async Task<IActionResult> AdicionarAlunoADisciplina(ulong idDisciplina, ulong idAluno, int periodo)
        {
            var result = await _service.AdicionarAlunoADisciplinaAsync(idDisciplina, idAluno, periodo);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<DisciplinaDTO>(true, HttpStatusCode.OK, result.Value!, "Aluno adicionado à disciplina com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para remover um aluno de uma disciplina.
        /// </summary>
        /// <remarks>Remove a associação de um aluno a uma disciplina.</remarks>
        /// <returns>Confirmação de remoção.</returns>
        [HttpDelete("alunos/{idDisciplina}/{idAluno}/{periodo}")]
        public async Task<IActionResult> RemoverAlunoDaDisciplina(ulong idDisciplina, ulong idAluno, int periodo)
        {
            var result = await _service.RemoverAlunoDaDisciplinaAsync(idDisciplina, idAluno, periodo);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            return NoContent();
        }

        /// <summary>
        /// Rota para adicionar um professor a uma disciplina.
        /// </summary>
        /// <remarks>Associa um professor a uma disciplina.</remarks>
        /// <returns>Confirmação de associação.</returns>
        [HttpPost("professores/{idDisciplina}/{idProfessor}/{periodo}")]
        public async Task<IActionResult> AdicionarProfessorADisciplina(ulong idDisciplina, ulong idProfessor, int periodo)
        {
            var result = await _service.AdicionarProfessorADisciplinaAsync(idDisciplina, idProfessor, periodo);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            var successResponse = new ApiResponse<DisciplinaDTO>(true, HttpStatusCode.OK, result.Value!, "Professor adicionado à disciplina com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para remover um professor de uma disciplina.
        /// </summary>
        /// <remarks>Remove a associação de um professor a uma disciplina.</remarks>
        /// <returns>Confirmação de remoção.</returns>
        [HttpDelete("professores/{idDisciplina}/{idProfessor}/{periodo}")]
        public async Task<IActionResult> RemoverProfessorDaDisciplina(ulong idDisciplina, ulong idProfessor, int periodo)
        {
            var result = await _service.RemoverProfessorDaDisciplinaAsync(idDisciplina, idProfessor, periodo);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.BadRequest, "", result.Error!, "");
                return BadRequest(response);
            }
            return NoContent();
        }

        /// <summary>
        /// Rota para buscar disciplinas de um professor específico.
        /// </summary>
        /// <remarks>Obtém as disciplinas que um professor leciona.</remarks>
        /// <returns>Lista de disciplinas por professor.</returns>
        [HttpGet("professores/{idProfessor}")]
        public async Task<IActionResult> GetDisciplinasByProfessor(ulong idProfessor)
        {
            var result = await _service.GetDisciplinasByProfessorAsync(idProfessor);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<DisciplinaDTO>>(true, HttpStatusCode.OK, result.Value!, "Disciplinas encontradas com sucesso.", "");
            return Ok(successResponse);
        }

        /// <summary>
        /// Rota para buscar disciplinas de um curso específico.
        /// </summary>
        /// <remarks>Obtém todas as disciplinas pertencentes a um curso.</remarks>
        /// <returns>Lista de disciplinas por curso.</returns>
        [HttpGet("cursos/{idCurso}")]
        public async Task<IActionResult> GetDisciplinasByCurso(ulong idCurso)
        {
            var result = await _service.GetDisciplinasByCursoAsync(idCurso);
            if (!result.IsSuccess)
            {
                var response = new ApiResponse<string>(false, HttpStatusCode.NotFound, "", result.Error!, "");
                return NotFound(response);
            }
            var successResponse = new ApiResponse<List<DisciplinaDTO>>(true, HttpStatusCode.OK, result.Value!, "Disciplinas encontradas com sucesso.", "");
            return Ok(successResponse);
        }
    }
}
