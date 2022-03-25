using EscolaDeIdiomas.WebApi.Commands;
using EscolaDeIdiomas.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeIdiomas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : Controller
    {
        private readonly IMatriculaRepository _matriculaRepository; //Aplicando injeção de dependência
         
        public MatriculaController(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        /// <summary>
        /// Lista todas as matriculas
        /// </summary>
        /// <returns>Status Code Ok com lista de matriculas</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_matriculaRepository.ListarTodos());
        }

        /// <summary>
        /// Cadastra uma nova matricula
        /// </summary>
        /// <param name="novaMatricula">Objeto com as informações da matrícula (idAluno e idTurma)</param>
        /// <returns>Status Code 201</returns>
        [HttpPost]
        public IActionResult Post(MatriculaCommand novaMatricula)
        {
            _matriculaRepository.Cadastro(novaMatricula);

            return StatusCode(201);
        }

        /// <summary>
        /// Exclui uma matricula
        /// </summary>
        /// <param name="id">Id da Matricula que será excluída</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _matriculaRepository.Excluir(id);
            return StatusCode(204);
        }
    }
}
