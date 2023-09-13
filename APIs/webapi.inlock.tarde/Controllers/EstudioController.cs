using Microsoft.AspNetCore.Mvc;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;
using webapi.inlock.tarde.Repositories;

namespace webapi.inlock.tarde.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class EstudioController : ControllerBase
        {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
            {
            _estudioRepository = new EstudioRepository();
            }

        [HttpGet]
        public IActionResult GetAll()
            {
            try
                {
                return Ok(_estudioRepository.ListarTodos());
                }
            catch (Exception erro)
                {

                throw new Exception("Erro ao listar os estúdios" + erro.Message);
                }
            }

        [HttpGet("ListarComJogos")]
        public IActionResult GetWithGames()
            {
            try
                {
                return Ok(_estudioRepository.ListarComJogos());
                }
            catch (Exception erro)
                {

                throw new Exception("Erro ao listar os estúdios com os jogos" + erro.Message);
                }
            }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
            {
            try
                {
                if (_estudioRepository.BuscarPorId(id) == null) return NotFound("Estúdio não encontrado");
                return Ok(_estudioRepository.BuscarPorId(id));
                }
            catch (Exception erro)
                {

                throw new Exception("Erro ao buscar o estúdio" + erro.Message);
                }
            }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
            {
            try
                {
                if (_estudioRepository.BuscarPorId(id) == null) return NotFound("Estúdio não encontrado");
                _estudioRepository.Deletar(id);
                return Ok("Deletado com sucesso.");
                }
            catch (Exception erro)
                {

                throw new Exception("Erro ao deletar o estúdio" + erro.Message);
                }
            }

        [HttpPost]
        public IActionResult Post(Estudio novoEstudio)
            {
            try
                {
                _estudioRepository.Cadastrar(novoEstudio);
                return Created("Criado com sucesso!",novoEstudio);
                }
            catch (Exception erro)
                {

                throw new Exception("Erro ao cadastrar o estúdio" + erro.Message);
                }
            }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Estudio estudioAtualizado)
            {
            try
                {
                if (_estudioRepository.BuscarPorId(id) == null) return NotFound("Estúdio não encontrado"); 
                _estudioRepository.Atualizar(id, estudioAtualizado);
                return Ok("Atualizado com sucesso!");
                }
            catch (Exception erro)
                {

                throw new Exception(erro.Message);
                }
            }   
        }
    }

