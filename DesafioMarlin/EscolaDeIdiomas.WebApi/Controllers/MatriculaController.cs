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
        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaController(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_matriculaRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Post(MatriculaCommand novaMatricula)
        {
            _matriculaRepository.Cadastro(novaMatricula);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _matriculaRepository.Excluir(id);
            return StatusCode(204);
        }
    }
}
