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
        private IAlunoRepository _alunoRepository { get; set; } // Aplicando injeção de dependência
        
        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        /// <summary>
        /// Lista todos os alunos cadastrados
        /// </summary>
        /// <returns>Status Code Ok com a lista de alunos</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_alunoRepository.ListarTodos());
        }

        /// <summary>
        /// Cadastra um novo aluno na plataforma
        /// </summary>
        /// <param name="novoAluno">Objeto com as informações do aluno e a turma que irá se matricular</param>
        /// <returns>Status Code 201</returns>
        [HttpPost]
        public IActionResult Post(NovoAlunoCommand novoAluno)
        {
            _alunoRepository.Cadastro(novoAluno);

            return StatusCode(201); 
        }

        /// <summary>
        /// Atualiza o cadastro de um aluno
        /// </summary>
        /// <param name="id">Id do aluno que será atualizado</param>
        /// <param name="alunoAtualizado">Objeto com as novas informações sobre o aluno</param>
        /// <returns>Status Code 204</returns>
        [HttpPut("{id}")]
        public IActionResult Patch(Guid id, AlunoCommand alunoAtualizado)
        {
            _alunoRepository.Atualizar(id, alunoAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Exclui um aluno
        /// </summary>
        /// <param name="id">Id do aluno que será excluido</param>
        /// <returns>Status Code 204</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _alunoRepository.Excluir(id);
            return StatusCode(204);
        }
    }
}
