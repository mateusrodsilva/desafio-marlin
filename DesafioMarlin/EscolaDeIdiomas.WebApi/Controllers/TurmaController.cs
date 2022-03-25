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
        public TurmaController(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        private ITurmaRepository _turmaRepository { get; set; }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_turmaRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Post(TurmaCommand novaTurma)
        {
            _turmaRepository.Cadastro(novaTurma);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Patch(Guid id, TurmaCommand turmaAtualizada)
        {
            _turmaRepository.Atualizar(id, turmaAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _turmaRepository.Excluir(id);
            return StatusCode(204);
        }
    }
}
