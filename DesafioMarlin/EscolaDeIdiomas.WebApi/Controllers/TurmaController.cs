using EscolaDeIdiomas.WebApi.Commands;
using EscolaDeIdiomas.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeIdiomas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : Controller
    {
        private ITurmaRepository _turmaRepository { get; set; } //Aplicando injeção de dependência

        public TurmaController(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }


        /// <summary>
        /// Lista todas as turmas
        /// </summary>
        /// <returns>Status Code Ok com lista de turmas</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_turmaRepository.ListarTodos());
        }

        /// <summary>
        /// Cadastra uma nova turma
        /// </summary>
        /// <param name="novaTurma">Objeto com as informações da turma (numero da sala, ano letivo e descrição da turma)</param>
        /// <returns>Status Code 201</returns>
        [HttpPost]
        public IActionResult Post(TurmaCommand novaTurma)
        {
            _turmaRepository.Cadastro(novaTurma);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza o cadastro de uma turma
        /// </summary>
        /// <param name="id">Id da turma que será atualizada</param>
        /// <param name="turmaAtualizada">Objeto com as novas informações da turma</param>
        /// <returns>Status Code 204</returns>
        [HttpPut("{id}")]
        public IActionResult Patch(Guid id, TurmaCommand turmaAtualizada)
        {
            _turmaRepository.Atualizar(id, turmaAtualizada);

            return StatusCode(204);
        }

        /// <summary>
        /// Exclui uma turma
        /// </summary>
        /// <param name="id">Id da turma que será excluida</param>
        /// <returns>Status Code 204</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _turmaRepository.Excluir(id);
            return StatusCode(204);
        }
    }
}
