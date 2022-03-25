using EscolaDeIdiomas.WebApi.Commands;
using EscolaDeIdiomas.WebApi.Domains;
using EscolaDeIdiomas.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeIdiomas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        private IAlunoRepository _alunoRepository { get; set; }
        
        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_alunoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Post(NovoAlunoCommand novoAluno)
        {
            _alunoRepository.Cadastro(novoAluno);

            return StatusCode(201); 
        }

        [HttpPut("{id}")]
        public IActionResult Patch(Guid id, AlunoCommand alunoAtualizado)
        {
            _alunoRepository.Atualizar(id, alunoAtualizado);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _alunoRepository.Excluir(id);
            return StatusCode(204);
        }
    }
}
