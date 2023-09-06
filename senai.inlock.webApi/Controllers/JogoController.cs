using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : ControllerBase
        {

        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
            {
            _jogoRepository = new JogoRepository();
            }


        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                return Ok(_jogoRepository.ListarTodos());
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
            {
            try
                {
                JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

                return jogoBuscado == null ? NotFound("Jogo não encontrado!") : Ok(jogoBuscado);
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }

        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
            {
            try
                {
                _jogoRepository.Cadastrar(novoJogo);

                return StatusCode(201, "Jogo cadastrado com sucesso!");
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            {
            try
                {
                _jogoRepository.Deletar(id);

                return StatusCode(204, "Jogo deletado com sucesso.");
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }
        }
    }
